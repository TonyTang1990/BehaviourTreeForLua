/*
 * Description:             TBehaviourTree.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// TBehaviourTree.cs
    /// Lua行为树挂载驱动组件
    /// </summary>
    [DisallowMultipleComponent]
    public class TBehaviourTree : MonoBehaviour
    {
        /// <summary>
        /// 行为树图数据
        /// </summary>
        public TextAsset BTGraphAsset;

        /// <summary>
        /// 当行为树完成时重新开始判定
        /// </summary>
        [Header("完成时重新开启判定(每帧判定)")]
        public bool RestartWhenComplete = false;

        /// <summary>
        /// 运行时的行为树图数据(根据反序列化数据构建而成)
        /// </summary>
        public BTGraph BTRunningGraph
        {
            get;
            private set;
        }

        /// <summary>
        /// 行为树是否开启
        /// </summary>
        public bool IsBTEnable
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否暂停
        /// </summary>
        public bool IsPaused
        {
            get;
            set;
        }

        /// <summary>
        /// 行为树图原始数据对象(反序列化)
        /// </summary>
        public BTGraph BTOriginalGraph
        {
            get;
            protected set;
        }

        private void Start()
        {
            IsPaused = false;
            TBehaviourTreeManager.getInstance().RegisterTBehaviourTree(this);
        }

        private void OnEnable()
        {
            IsBTEnable = true;
        }

        private void OnDisable()
        {
            IsBTEnable = false;
        }

        /// <summary>
        /// 触发行为树更新
        /// </summary>
        public void OnUpdate()
        {
            if(IsBTEnable && !IsPaused)
            {
                BTRunningGraph?.OnUpdate();
            }
        }

        private void OnDestroy()
        {
            TBehaviourTreeManager.getInstance().UnregisterTBhaviourTree(this);
            BTGraphAsset = null;
            BTOriginalGraph?.Dispose();
            BTOriginalGraph = null;
            BTRunningGraph?.Dispose();
            BTRunningGraph = null;
            IsBTEnable = false;
        }

        /// <summary>
        /// 加载行为树图数据
        /// </summary>
        /// <param name="assetname"></param>
        public void LoadBTGraphAsset(string assetname)
        {
            BTGraphAsset = Resources.Load<TextAsset>($"{BTData.BTNodeSaveFolderRelativePath}/{assetname}");
            BTOriginalGraph = JsonUtility.FromJson<BTGraph>(BTGraphAsset.text);
            // TODO: 根据原始数据构建运行时BTGraph数据
            BTRunningGraph = new BTGraph();
            BTRunningGraph.SetBTOwner(this);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            IsPaused = false;
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Resume()
        {
            IsPaused = true;
        }
    }
}