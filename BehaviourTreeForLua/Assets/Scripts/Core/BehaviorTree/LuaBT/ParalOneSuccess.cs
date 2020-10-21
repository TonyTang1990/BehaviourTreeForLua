/*
 * Description:             ParalOneSuccess.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/25
 */

using System;

namespace LuaBehaviourTree
{
    /// <summary>
    /// ParalOneSuccess.cs
    /// 一个成功算成功策略并发节点
    /// </summary>
    public class ParalOneSuccess : BaseParal
    {
        public ParalOneSuccess()
        {

        }

        public ParalOneSuccess(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            OnCreate();
        }

        public override void OnCreate()
        {
            base.OnCreate();
            ParalPolicy = EBTParalPolicy.OneSuccess;
        }

        protected override EBTNodeRunningState OnExecute()
        {
            var failedcount = 0;
            for (int i = 0, length = ChildNodes.Count; i < length; i++)
            {
                // 已经执行完成的直接采用之前的结果
                if (mChildNodeExecuteStateList[i] == EBTNodeRunningState.Success)
                {
                    return EBTNodeRunningState.Success;
                }
                else if (mChildNodeExecuteStateList[i] == EBTNodeRunningState.Failed)
                {
                    failedcount++;
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
                        mChildNodeExecuteStateList[i] = EBTNodeRunningState.Success;
                        return EBTNodeRunningState.Success;
                    }
                    else if (childnodestate == EBTNodeRunningState.Failed)
                    {
                        mChildNodeExecuteStateList[i] = EBTNodeRunningState.Failed;
                        failedcount++;
                    }
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
