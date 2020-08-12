/*
 * Description:             SelectorNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 选择节点(多个节点里选择一个符合条件的执行)
    /// Note:
    /// 暂时只支持不带优先级的选择节点策略(默认从左往右优先级越来越低)
    /// TODO:
    /// 可以考虑支持带权值的选择节点
    /// </summary>
    public class SelectorNode : CompositionNode
    {
        /// <summary>
        /// 当前执行的节点索引
        /// </summary>
        protected int mCurrentNodeIndex;

        public SelectorNode(string nodename, BehaviorTree btowner, ENodeAbortType aborttype = ENodeAbortType.AbortAll) : base(nodename, btowner, aborttype)
        {
            
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mCurrentNodeIndex = 0;
        }

        protected override ENodeRunningState OnExecute()
        {
            while(true)
            {
                // 遍历执行子节点，找到第一个返回成功的节点
                if(ChildNodes.Count > mCurrentNodeIndex)
                {
                    if(ChildNodes[mCurrentNodeIndex].CheckPrecondition())
                    {
                        // 选择节点类型默认是选择第一个成功的，所以不会使用条件节点去判定
                        // 所以无需判定符合节点的终止类型去判定是否需要打断
                        var childstate = ChildNodes[mCurrentNodeIndex].Update();
                        if (childstate != ENodeRunningState.Failed)
                        {
                            return childstate;
                        }
                    }
                    mCurrentNodeIndex++;
                }
                else
                {
                    return ENodeRunningState.Failed;
                }
            }
        }
    }
}
