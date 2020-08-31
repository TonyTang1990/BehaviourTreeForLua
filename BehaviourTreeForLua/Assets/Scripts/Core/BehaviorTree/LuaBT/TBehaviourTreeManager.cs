/*
 * Description:             TBehaviourTreeManager.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/31
 */

using System;
using System.Collections.Generic;
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

        public TBehaviourTreeManager()
        {
            AllBehaviourTreeList = new List<TBehaviourTree>();
            IsPauseAll = false;
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
    }
}