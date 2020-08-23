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
    /// ��ڽڵ�
    /// </summary>
    public class BTEntryNode : BTNode
    {
        /// <summary>
        /// �ӽڵ�
        /// </summary>
        public BTNode ChildNode;

        public BTEntryNode(BTNode node, TBehaviourTree btowner) : base(node, btowner)
        {
            if(node.ChildNodesUIDList.Count > 0)
            {
                ChildNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]), btowner);
            }
        }
    }
}
