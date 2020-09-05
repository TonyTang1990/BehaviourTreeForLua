/*
 * Description:             BTParalOneSuccessNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/25
 */

using System;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTParalOneSuccessNode.cs
    /// 一个成功算成功策略并发节点
    /// </summary>
    public class BTParalOneSuccessNode : BTBaseParalNode
    {
        public BTParalOneSuccessNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            ParalPolicy = EBTParalPolicy.OneSuccess;
        }

        protected override EBTNodeRunningState OnExecute()
        {
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
                    return EBTNodeRunningState.Success;
                }
                else if (childnodestate == EBTNodeRunningState.Failed)
                {
                    failedcount++;
                }
            }
            if (failedcount == ChildNodes.Count)
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
