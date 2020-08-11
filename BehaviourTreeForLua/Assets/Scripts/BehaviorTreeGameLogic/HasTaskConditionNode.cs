/*
 * Description:             HasTaskConditionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 拥有工作任务的条件节点
    /// </summary>
    public class HasTaskConditionNode : ConditionNode
    {
        public HasTaskConditionNode():base()
        {

        }

        public HasTaskConditionNode(string nodename, Func<Blackboard, bool> condition, BehaviorTree.BehaviorTree bt) : base(nodename, condition, bt)
        {

        }


        protected override ENodeRunningState OnExecute()
        {
            var hastask = BTOwner.BTBlackBoard.GetData<bool>(GameLauncher.TaskKey);
            if(hastask)
            {
                //Debug.Log("满足有工作任务要求!");
                return ENodeRunningState.Success;
            }
            else
            {
                //Debug.Log("不满足有工作任务要求!");
                return ENodeRunningState.Failed;
            }
        }
    }
}