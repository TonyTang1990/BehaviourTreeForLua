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

        public BTEntryNode(BTNode node, TBehaviourTree btowner) : base(node, btowner)
        {
            if(node.ChildNodesUIDList.Count > 0)
            {
                ChildNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]), btowner);
            }
        }

        /// <summary>
        /// 节点更新
        /// </summary>
        /// <returns></returns>
        public override EBTNodeRunningState Update()
        {
            if(ChildNode != null)
            {
                return ChildNode.Update();
            }
            else
            {
                return EBTNodeRunningState.Success;
            }
        }
    }
}
