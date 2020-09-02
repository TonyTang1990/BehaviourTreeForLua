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
        }

        /// <summary>
        /// 节点更新
        /// </summary>
        /// <returns></returns>
        public override EBTNodeRunningState OnUpdate()
        {
            // 入口节点强制进入Enter，为了将根节点添加到执行节点里
            OnEnter();
            EBTNodeRunningState result = EBTNodeRunningState.Invalide;
            if (ChildNode != null)
            {
                result =  ChildNode.OnUpdate();
            }
            else
            {
                result = EBTNodeRunningState.Success;
            }
            NodeRunningState = result;
            return result;
        }


    }
}
