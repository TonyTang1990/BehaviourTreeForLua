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
        /// 行为树图原始数据对象(反序列化)
        /// </summary>
        public BTGraph BTOriginalGraph
        {
            get;
            protected set;
        }

        private void Start()
        {

        }

        private void OnEnable()
        {
            IsBTEnable = true;
        }

        private void OnDisable()
        {
            IsBTEnable = false;
        }

        private void Update()
        {

        }

        private void OnDestroy()
        {
            IsBTEnable = false;
        }

        /// <summary>
        /// 加载行为树图数据
        /// </summary>
        /// <param name="assetname"></param>
        public void LoadBTGraphAsset(string assetname)
        {
            BTGraphAsset = Resources.Load<TextAsset>($"{BTData.BTNodeSaveFolderRelativePath}/{assetname}.json");
            BTOriginalGraph = JsonUtility.FromJson<BTGraph>(BTGraphAsset.text);
            // TODO: 根据原始数据构建运行时BTGraph数据
            BTRunningGraph = new BTGraph(BTOriginalGraph, this);
        }
    }
}