/*
 * Description:             BTParalAllSuccessNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/25
 */

using System;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTParalAllSuccessNode.cs
    /// 所有成功策略并发节点
    /// </summary>
    public class BTParalAllSuccessNode : BTBaseParalNode
    {
        public BTParalAllSuccessNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            ParalPolicy = EBTParalPolicy.AllSuccess;
        }
        protected override EBTNodeRunningState OnExecute()
        {
            var successcount = 0;
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
                }
                else if (childnodestate == EBTNodeRunningState.Failed)
                {
                    return EBTNodeRunningState.Failed;
                }
            }
            if (successcount == ChildNodes.Count)
            {
                return EBTNodeRunningState.Success;
            }
            else
            {
                return EBTNodeRunningState.Running;
            }
        }
    }
}
