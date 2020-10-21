/*
 * Description:             Entry.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// Entry.cs
    /// 入口节点
    /// </summary>
    public class Entry : BTNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public BTNode ChildNode;

        public Entry()
        {

        }

        public Entry(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            if(node.ChildNodesUIDList.Count > 0)
            {
                ChildNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]), btowner, this, instanceid);
            }
            else
            {
                Debug.LogError($"根节点至少且必须要有一个子节点!");
            }
        }

        /// <summary>
        /// 设置数据(运行时用对象池后的调用初始化数据)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        public override void SetDatas(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            base.SetDatas(node, btowner, parentnode, instanceid);
            if (node.ChildNodesUIDList.Count > 0)
            {
                ChildNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]), btowner, this, instanceid);
            }
        }
        protected override EBTNodeRunningState OnExecute()
        {
            return ChildNode.OnUpdate();
        }
    }
}
