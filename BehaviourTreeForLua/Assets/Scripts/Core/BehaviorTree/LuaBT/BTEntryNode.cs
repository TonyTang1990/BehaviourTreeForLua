/*
 * Description:             BTEntryNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/23
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTEntryNode.cs
    /// 入口节点
    /// </summary>
    public class BTEntryNode : BTNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public BTNode ChildNode;

        public BTEntryNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
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
        
        protected override EBTNodeRunningState OnExecute()
        {
            return ChildNode.OnUpdate();
        }
    }
}
