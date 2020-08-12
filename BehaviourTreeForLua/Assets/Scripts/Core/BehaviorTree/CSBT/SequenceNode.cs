/*
 * Description:             SequenceNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 序列节点(多个节点按顺序执行直到遇到返回失败的节点)
    /// </summary>
    public class SequenceNode : CompositionNode
    {
        /// <summary>
        /// 当前执行的节点索引
        /// </summary>
        protected int mCurrentNodeIndex;

        public SequenceNode(string nodename, BehaviorTree btowner, ENodeAbortType aborttype = ENodeAbortType.AbortAll) : base(nodename, btowner, aborttype)
        {
            mCurrentNodeIndex = 0;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mCurrentNodeIndex = 0;
        }

        protected override ENodeRunningState OnExecute()
        {
            while (true)
            {
                // 遍历执行子节点，直到某个子节点返回失败
                if (ChildNodes.Count > mCurrentNodeIndex)
                {
                    if (ChildNodes[mCurrentNodeIndex].CheckPrecondition())
                    {
                        if(ShouldAbortRunning())
                        {
                            return ENodeRunningState.Failed;
                        }

                        var childstate = ChildNodes[mCurrentNodeIndex].Update();
                        if (childstate == ENodeRunningState.Failed)
                        {
                            return ENodeRunningState.Failed;
                        }
                        else if(childstate == ENodeRunningState.Success)
                        {
                            mCurrentNodeIndex++;
                        }
                        else
                        {
                            return ENodeRunningState.Running;
                        }
                    }
                    else
                    {
                        return ENodeRunningState.Failed;
                    }
                }
                else
                {
                    return ENodeRunningState.Success;
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
            if (NodeAbortType == ENodeAbortType.AbortAll)
            {
                // 支持打断的话需要每次都判定条件节点是否满足从而实现支持打断运行节点的效果
                // 从左往右判定当前运行节点前面的所有条件类型节点，是否还满足条件
                for (int i = 0; i < mCurrentNodeIndex; i++)
                {
                    // 条件节点或者修饰条件节点的修饰节点需要重新判定支持实时打断运行节点
                    if (ChildNodes[i] is ConditionNode || (ChildNodes[i] is DecorationNode && (ChildNodes[i] as DecorationNode).IsConditionDecoration()))
                    {
                        if (ChildNodes[i].Update() == ENodeRunningState.Failed)
                        {
                            Debug.Log(string.Format("顺序节点:{0}的{1}条件节点不满足条件，打断正在运行的{2}节点!", NodeName, ChildNodes[i].NodeName, ChildNodes[mCurrentNodeIndex].NodeName));
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
