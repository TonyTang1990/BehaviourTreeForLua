/*
 * Description:             BTParalNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTParalNode.cs
    /// 并发节点抽象基类
    /// </summary>
    public abstract class BTBaseParalNode : BTCompositionNode
    {
        /// <summary>
        /// 并发策略
        /// </summary>
        public enum EBTParalPolicy
        {
            AllSuccess = 1,                 // 所有都成功就算成功
            OneSuccess,                     // 一个成功就算成功
        }

        /// <summary>
        /// 并发成功策略
        /// </summary>
        public EBTParalPolicy ParalPolicy
        {
            get;
            protected set;
        }

        public BTBaseParalNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner, parentnode, aborttype)
        {

        }

        protected override EBTNodeRunningState OnExecute()
        {
            if (ShouldAbortRunning())
            {
                return EBTNodeRunningState.Failed;
            }

            var successcount = 0;
            var failedcount = 0;
            foreach (var childnode in ChildNodes)
            {
                EBTNodeRunningState childnodestate = childnode.NodeRunningState;
                if (!childnode.IsTerminated)
                {
                    childnodestate = childnode.OnUpdate();
                }
                if (childnodestate == EBTNodeRunningState.Success)
                {
                    successcount++;
                    if (ParalPolicy == EBTParalPolicy.OneSuccess)
                    {
                        return EBTNodeRunningState.Success;
                    }
                }
                else if (childnodestate == EBTNodeRunningState.Failed)
                {
                    failedcount++;
                    if (ParalPolicy == EBTParalPolicy.AllSuccess)
                    {
                        return EBTNodeRunningState.Failed;
                    }
                }
            }

            if (ParalPolicy == EBTParalPolicy.AllSuccess)
            {
                if (successcount == ChildNodes.Count)
                {
                    return EBTNodeRunningState.Success;
                }
                else
                {
                    return EBTNodeRunningState.Running;
                }
            }
            else
            {
                return EBTNodeRunningState.Running;
            }
        }

        /// <summary>
        /// 是否应该打断执行
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldAbortRunning()
        {
            //// 检查复合节点的终止类型，看是否需要支持打断
            //if (NodeAbortType == EBTNodeAbortType.AbortAll)
            //{
            //    // 支持打断的话需要每次都判定条件节点是否满足从而实现支持打断运行节点的效果
            //    // 从左往右判定所有条件类型节点，是否还满足条件
            //    int conditionnodecout = 0;
            //    int flcount = 0;
            //    for (int i = 0, length = ChildNodes.Count; i < length; i++)
            //    {
            //        // 条件节点或者修饰条件节点的修饰节点需要重新判定支持实时打断运行节点
            //        if (ChildNodes[i] is BTConditionNode || (ChildNodes[i] is BTDecorationNode && (ChildNodes[i] as BTDecorationNode).IsConditionDecoration()))
            //        {
            //            conditionnodecout++;
            //            if (ChildNodes[i].OnUpdate() == EBTNodeRunningState.Failed)
            //            {
            //                flcount++;
            //                // 并发策略是所有都成功，那么只要有一个条件节点失败就应该打断
            //                if (ParalPolicy == EBTParalPolicy.AllSuccess)
            //                {
            //                    Debug.Log(string.Format("并发节点:{0}的{1}条件节点不满足条件，打断当前所有并发子节点!", NodeName, ChildNodes[i].NodeName));
            //                    return true;
            //                }
            //            }
            //        }
            //    }
            //    // 并发策略是一个成功，那么要所有条件节点都失败才允许打断
            //    if (ParalPolicy == EBTParalPolicy.OneSuccess)
            //    {
            //        if (conditionnodecout == flcount)
            //        {
            //            Debug.Log(string.Format("并发节点:{0}所有条件节点都不满足，打断当前所有并发子节点!", NodeName));
            //            return true;
            //        }
            //    }
            //}
            return false;
        }
    }
}