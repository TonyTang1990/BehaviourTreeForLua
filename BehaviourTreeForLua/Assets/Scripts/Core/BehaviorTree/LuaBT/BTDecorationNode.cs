/*
 * Description:             BTDecorationNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTDecorationNode.cs
    /// 修饰节点
    /// </summary>
    public class BTDecorationNode : BTNode
    {
        /// <summary>
        /// 装饰的子节点
        /// </summary>
        public BTNode ChildNode;

        public BTDecorationNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]);
            var runningchildnode = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT, this, instanceid);
            ChildNode = runningchildnode;
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            // 避免重复reset
            if (NodeRunningState != EBTNodeRunningState.Invalide)
            {
                base.Reset();
                ChildNode.Reset();
            }
        }

        protected override EBTNodeRunningState OnExecute()
        {
            return ChildNode.OnUpdate();
        }

        protected override void OnExit()
        {
            base.OnExit();
            Reset();
        }
    }
}