/*
 * Description:             NoTaskConditionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// û������������ڵ�
    /// </summary>
    public class NoTaskConditionNode : ConditionNode
    {
        public NoTaskConditionNode():base()
        {

        }

        public NoTaskConditionNode(string nodename, Func<Blackboard, bool> condition, BehaviorTree.BehaviorTree bt) : base(nodename, condition, bt)
        {

        }


        protected override ENodeRunningState OnExecute()
        {
            var hastask = BTOwner.BTBlackBoard.GetData<bool>(GameLauncher.TaskKey);
            if (!hastask)
            {
                Debug.Log("����û�й�������Ҫ��!");
                return ENodeRunningState.Success;
            }
            else
            {
                Debug.Log("������û�й�������Ҫ��!");
                return ENodeRunningState.Failed;
            }
        }
    }
}