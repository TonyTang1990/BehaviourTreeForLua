/*
 * Description:             ParalNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 并发节点(多个节点同时运行,支持多种判定策略，暂时默认是全部成功才算成功)
    /// </summary>
    public class ParalNode : CompositionNode
    {
        /// <summary>
        /// 并发策略
        /// </summary>
        public enum EParalPolicy
        {
            AllSuccess = 1,                 // 所有都成功就算成功
            OneSuccess,                     // 一个成功就算成功
        }

        /// <summary>
        /// 并发成功策略
        /// </summary>
        public EParalPolicy ParalPolicy;

        public ParalNode(string nodename, BehaviorTree btowner, ENodeAbortType aborttype = ENodeAbortType.AbortAll, EParalPolicy paralpolicy = EParalPolicy.AllSuccess) : base(nodename, btowner, aborttype)
        {
            ParalPolicy = paralpolicy;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (ShouldAbortRunning())
            {
                return ENodeRunningState.Failed;
            }

            var successcount = 0;
            var failedcount = 0;
            foreach(var childnode in ChildNodes)
            {
                ENodeRunningState childnodestate = childnode.NodeRunningState;
                if(childnode.CheckPrecondition())
                {
                    if (!childnode.IsTerminated)
                    {
                        childnodestate = childnode.Update();
                    }
                }
                else
                {
                    childnodestate = ENodeRunningState.Failed;
                }

                if (childnodestate == ENodeRunningState.Success)
                {
                    successcount++;
                    if (ParalPolicy == EParalPolicy.OneSuccess)
                    {
                        return ENodeRunningState.Success;
                    }
                }
                else if (childnodestate == ENodeRunningState.Failed)
                {
                    failedcount++;
                    if (ParalPolicy == EParalPolicy.AllSuccess)
                    {
                        return ENodeRunningState.Failed;
                    }
                }
            }

            if(ParalPolicy == EParalPolicy.AllSuccess)
            {
                if (successcount == ChildNodes.Count)
                {
                    return ENodeRunningState.Success;
                }
                else
                {
                    return ENodeRunningState.Running;
                }
            }
            else
            {
                return ENodeRunningState.Running;
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
                // 从左往右判定所有条件类型节点，是否还满足条件
                int conditionnodecout = 0;
                int flcount = 0;
                for (int i = 0, length = ChildNodes.Count; i < length; i++)
                {
                    // 条件节点或者修饰条件节点的修饰节点需要重新判定支持实时打断运行节点
                    if (ChildNodes[i] is ConditionNode || (ChildNodes[i] is DecorationNode && (ChildNodes[i] as DecorationNode).IsConditionDecoration()))
                    {
                        conditionnodecout++;
                        if (ChildNodes[i].Update() == ENodeRunningState.Failed)
                        {
                            flcount++;
                            // 并发策略是所有都成功，那么只要有一个条件节点失败就应该打断
                            if (ParalPolicy == EParalPolicy.AllSuccess)
                            {
                                Debug.Log(string.Format("并发节点:{0}的{1}条件节点不满足条件，打断当前所有并发子节点!", NodeName, ChildNodes[i].NodeName));
                                return true;
                            }
                        }
                    }
                }
                // 并发策略是一个成功，那么要所有条件节点都失败才允许打断
                if (ParalPolicy == EParalPolicy.OneSuccess)
                {
                    if (conditionnodecout == flcount)
                    {
                        Debug.Log(string.Format("并发节点:{0}所有条件节点都不满足，打断当前所有并发子节点!", NodeName));
                        return true;
                    }
                }
            }
            return false;
        }
    }
}