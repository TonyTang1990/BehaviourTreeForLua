/*
 * Description:             BTSequenceNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTSequenceNode.cs
    /// 顺序节点
    /// </summary>
    public class BTSequenceNode : BTCompositionNode
    {
        /// <summary>
        /// 当前执行的节点索引
        /// </summary>
        protected int mCurrentNodeIndex;

        public BTSequenceNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner, parentnode, aborttype)
        {
            mCurrentNodeIndex = 0;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mCurrentNodeIndex = 0;
        }

        protected override EBTNodeRunningState OnExecute()
        {
            while (true)
            {
                // 遍历执行子节点，直到某个子节点返回失败
                if (ChildNodes.Count > mCurrentNodeIndex)
                {
                    if (ShouldAbortRunning())
                    {
                        return EBTNodeRunningState.Failed;
                    }

                    var childstate = ChildNodes[mCurrentNodeIndex].OnUpdate();
                    if (childstate == EBTNodeRunningState.Failed)
                    {
                        return EBTNodeRunningState.Failed;
                    }
                    else if (childstate == EBTNodeRunningState.Success)
                    {
                        mCurrentNodeIndex++;
                    }
                    else
                    {
                        return EBTNodeRunningState.Running;
                    }
                }
                else
                {
                    return EBTNodeRunningState.Success;
                }
            }
        }

        /// <summary>
        /// 是否应该打断执行
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldAbortRunning()
        {
            // 检查复合节点的终止类型，看是否需要支持打断
            //if (NodeAbortType == EBTNodeAbortType.AbortAll)
            //{
            //    // 支持打断的话需要每次都判定条件节点是否满足从而实现支持打断运行节点的效果
            //    // 从左往右判定当前运行节点前面的所有条件类型节点，是否还满足条件
            //    for (int i = 0; i < mCurrentNodeIndex; i++)
            //    {
            //        // 条件节点或者修饰条件节点的修饰节点需要重新判定支持实时打断运行节点
            //        if (ChildNodes[i] is BTConditionNode || (ChildNodes[i] is BTDecorationNode && (ChildNodes[i] as BTDecorationNode).IsConditionDecoration()))
            //        {
            //            if (ChildNodes[i].Update() == EBTNodeRunningState.Failed)
            //            {
            //                Debug.Log(string.Format("顺序节点:{0}的{1}条件节点不满足条件，打断正在运行的{2}节点!", NodeName, ChildNodes[i].NodeName, ChildNodes[mCurrentNodeIndex].NodeName));
            //                return true;
            //            }
            //        }
            //    }
            //}
            return false;
        }
    }
}