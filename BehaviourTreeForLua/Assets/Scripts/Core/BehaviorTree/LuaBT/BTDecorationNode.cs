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

        public BTDecorationNode(BTNode node, TBehaviourTree btowner) : base(node, btowner)
        {
            var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]);
            var runningchildnode = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT);
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

        /// <summary>
        /// 是否是修饰条件节点的修饰节点(暂时用于判定修饰节点是否需要参与终止判定)
        /// </summary>
        /// <returns></returns>
        public bool IsConditionDecoration()
        {
            return ChildNode is BTConditionNode;
        }

        protected override EBTNodeRunningState OnExecute()
        {
            if (ShouldAbortRunning())
            {
                return EBTNodeRunningState.Failed;
            }

            return ChildNode.Update();
        }

        protected override void OnExit()
        {
            base.OnExit();
            Reset();
        }

        /// <summary>
        /// 是否应该打断执行
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldAbortRunning()
        {
            // 装饰节点一般除了修饰Conditon也可以是修饰Action
            // 如果是修饰条件判定是否满足打断条件
            if (ChildNode is BTConditionNode)
            {
                if (ChildNode.Update() == EBTNodeRunningState.Failed)
                {
                    Debug.Log(string.Format("修饰节点:{0}的{1}条件节点不满足条件，打断当前装饰节点!", NodeName, ChildNode.NodeName));
                    return true;
                }
            }
            return false;
        }
    }
}