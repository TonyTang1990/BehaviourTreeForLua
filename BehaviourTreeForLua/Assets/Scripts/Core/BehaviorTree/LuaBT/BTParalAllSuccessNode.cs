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
            for (int i = 0, length = ChildNodes.Count; i < length; i++)
            {
                // 已经执行完成的直接采用之前的结果
                if (mChildNodeExecuteStateList[i] == EBTNodeRunningState.Failed)
                {
                    return EBTNodeRunningState.Failed;
                }
                else if (mChildNodeExecuteStateList[i] == EBTNodeRunningState.Success)
                {
                    successcount++;
                }
                else
                {
                    EBTNodeRunningState childnodestate = ChildNodes[i].NodeRunningState;
                    if (!ChildNodes[i].IsTerminated)
                    {
                        childnodestate = ChildNodes[i].OnUpdate();
                    }
                    if (childnodestate == EBTNodeRunningState.Success)
                    {
                        successcount++;
                        mChildNodeExecuteStateList[i] = EBTNodeRunningState.Success;
                    }
                    else if (childnodestate == EBTNodeRunningState.Failed)
                    {
                        mChildNodeExecuteStateList[i] = EBTNodeRunningState.Failed;
                        return EBTNodeRunningState.Failed;
                    }
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
