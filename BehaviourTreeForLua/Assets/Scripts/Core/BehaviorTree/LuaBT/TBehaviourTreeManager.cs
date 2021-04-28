/*
 * Description:             TBehaviourTreeManager.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/31
 */

using GeneralModule.Pool;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// 行为树管理单例类
    /// </summary>
    public class TBehaviourTreeManager : SingletonMonoBehaviourTemplate<TBehaviourTreeManager>
    {
        /// <summary>
        /// 所有有效的行为树列表
        /// </summary>
        public List<TBehaviourTree> AllBehaviourTreeList
        {
            get;
            set;
        }

        /// <summary>
        /// 是否暂停所有
        /// </summary>
        public bool IsPauseAll
        {
            get;
            set;
        }

        #region Lua相关
        /// <summary>
        /// Lua测CreateLuaLuaBTNode方法绑定
        /// </summary>
        public static Func<BTNode, int, int> LuaCreateLuaBTnode = null;

        /// <summary>
        /// Lua测LuaReleaseLuaBTnode方法绑定
        /// 释放改到Lua测了，避免Lua对象传到CS测
        /// </summary>
        ///public static Action<LuaBTNode> LuaReleaseLuaBTnode = null;

        /// <summary>
        /// Lua测BindLuaBTNodeCall方法绑定
        /// 绑定改到Lua测了，避免Lua对象传到CS测
        /// </summary>
        //public static Action<LuaBTNode> BindLuaBTNodeCall = null;

        /// <summary>
        /// Lua测UnbindLuaBTNodeCall方法绑定
        /// </summary>
        public static Action<int, int> UnbindLuaBTNodeCall = null;
        #endregion

        /// <summary>
        /// 行为树Json数据对象缓存Map(优化相同行为树Asset重复反序列化Json对象问题)
        /// Key为资源路径，Value为行为树BTGraph反序列化对象
        /// </summary>
        private Dictionary<string, BTGraph> mBTGraphCacheMap;

        public TBehaviourTreeManager()
        {
            AllBehaviourTreeList = new List<TBehaviourTree>();
            IsPauseAll = false;
            mBTGraphCacheMap = new Dictionary<string, BTGraph>();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            // 初始化AI节点对象池
            ObjectPool.Singleton.Initialize<Entry>(10);
            foreach (var type in GetType().Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Composition)) && type.IsClass && !type.IsAbstract))
            {
                //Debug.Log($"继承至Composition的子类名:{type.Name}");
                ObjectPool.Singleton.Initialize<Composition>(type, 10);
            }
            foreach (var type in GetType().Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Decoration)) && type.IsClass && !type.IsAbstract))
            {
                //Debug.Log($"继承至Decoration的子类名:{type.Name}");
                ObjectPool.Singleton.Initialize<Decoration>(type, 5);
            }
            var luaactiontype = typeof(LuaAction);
            var luaconditiontype = typeof(LuaCondition);
            foreach (var type in GetType().Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(BaseAction)) && type.IsClass && !type.IsAbstract && !type.Equals(luaactiontype)))
            {
                //Debug.Log($"继承至BaseAction的子类名:{type.Name}");
                ObjectPool.Singleton.Initialize<BaseAction>(type, 5);
            }
            foreach (var type in GetType().Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(BaseCondition)) && type.IsClass && !type.IsAbstract && !type.Equals(luaconditiontype)))
            {
                //Debug.Log($"继承至BaseCondition的子类名:{type.Name}");
                ObjectPool.Singleton.Initialize<BaseCondition>(type, 5);
            }
            ObjectPool.Singleton.Initialize<LuaCondition>(50);
            ObjectPool.Singleton.Initialize<LuaAction>(50);
        }

        private void OnDestroy()
        {
            Debug.Log($"TBehaviourTreeMaanger:OnDestroy()");
            AllBehaviourTreeList.Clear();
            ClearBTGraphCache();
            // 考虑到Lua静态委托释放时机和Lua虚拟机释放先后问题，
            // 这里将委托释放放到Lua测的GameMain.Stop里
            //LuaCreateLuaBTnode = null;
            //UnbindLuaBTNodeCall = null;
            //BTNode.LuaOnPause = null;
            //BTNode.LuaReset = null;
            //BTNode.LuaOnEnter = null;
            //BTNode.LuaOnExecute = null;
            //BTNode.LuaOnExit = null;
            //BTNode.LuaDispose = null;
        }

        private void Update()
        {
            if (!IsPauseAll)
            {
                for (int i = AllBehaviourTreeList.Count - 1; i >= 0; i--)
                {
                    AllBehaviourTreeList[i].OnUpdate();
                }
            }
        }

        /// <summary>
        /// 注册指定行为树对象
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public bool RegisterTBehaviourTree(TBehaviourTree bt)
        {
            if(AllBehaviourTreeList.Contains(bt) == false)
            {
                Debug.Log($"注册指定行为树，挂载对象名:{bt.name}");
                AllBehaviourTreeList.Add(bt);
                return true;
            }
            else
            {
                Debug.LogError($"重复注册指定行为树，挂载对象名:{bt.name}!");
                return false;
            }
        }

        /// <summary>
        /// 取消注册指定行为树对象
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public bool UnregisterTBhaviourTree(TBehaviourTree bt)
        {
#if UNITY_EDITOR
            Debug.Log($"取消注册指定行为树，挂载对象名:{bt.name}");
#endif
            return AllBehaviourTreeList.Remove(bt);
        }

        /// <summary>
        /// 暂停所有行为树
        /// </summary>
        public void PauseAll()
        {
            IsPauseAll = true;
            foreach(var bt in AllBehaviourTreeList)
            {
                bt.Pause();
            }
        }

        /// <summary>
        /// 继续所有行为树
        /// </summary>
        public void ResumeAll()
        {
            IsPauseAll = false;
            foreach (var bt in AllBehaviourTreeList)
            {
                bt.Resume();
            }
        }

        /// <summary>
        /// 打断所有行为树
        /// </summary>
        public void AbortAll()
        {
            foreach (var bt in AllBehaviourTreeList)
            {
                bt.Abort();
            }
        }

        #region 行为树BTGraph缓存部分
        /// <summary>
        /// 缓存指定行为树Asset的BTGraph对象
        /// </summary>
        /// <param name="assetpath"></param>
        /// <param name="btgraph"></param>
        /// <returns></returns>
        public bool CacheBTGraph(string assetpath, BTGraph btgraph)
        {
            if(!mBTGraphCacheMap.ContainsKey(assetpath))
            {
                mBTGraphCacheMap.Add(assetpath, btgraph);
                Debug.Log($"缓存行为树Asset:{assetpath}的BTGraph对象成功!");
                return true;
            }
            else
            {
                Debug.LogError($"重复缓存行为树Asset:{assetpath}的BTGraph对象,请检查代码!");
                return false;
            }
        }

        /// <summary>
        /// 返回指定行为树Asset的BTGraph对象
        /// </summary>
        /// <param name="assetpath"></param>
        /// <returns></returns>
        public BTGraph GetCacheBTGraph(string assetpath)
        {
            BTGraph btgraph = null;
            mBTGraphCacheMap.TryGetValue(assetpath, out btgraph);
            return btgraph;
        }

        /// <summary>
        /// 清理行为树反序列化对象缓存Cache(建议切换场景时调用，方便释放老的行为树反序列化对象)
        /// </summary>
        public void ClearBTGraphCache()
        {
            mBTGraphCacheMap.Clear();
        }
        #endregion
    }
}