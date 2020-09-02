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

        public BTBaseParalNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {

        }

        protected override EBTNodeRunningState OnExecute()
        {
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
                if(failedcount == ChildNodes.Count)
                {
                    return EBTNodeRunningState.Failed;
                }
                else
                {
                    return EBTNodeRunningState.Running;
                }
            }
        }
    }
}