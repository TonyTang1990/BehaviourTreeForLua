/*
 * Description:             MoneyRequirementConditionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 固定钱要求的条件节点
    /// </summary>
    public class MoneyRequirementConditionNode : ConditionNode
    {
        public MoneyRequirementConditionNode():base()
        {

        }

        public MoneyRequirementConditionNode(string nodename, Func<Blackboard, bool> condition, BehaviorTree.BehaviorTree bt) : base(nodename, condition, bt)
        {

        }

        protected override ENodeRunningState OnExecute()
        {
            var money = BTOwner.BTBlackBoard.GetData<int>(GameLauncher.MoneyKey);
            if (money > 0)
            {
                GameLauncher.Singleton.PlayerTxt.text = "";
                //Debug.Log("满足钱 > 0要求!");
                return ENodeRunningState.Success;
            }
            else
            {
                //Debug.Log("不满足钱 > 0要求!");
                return ENodeRunningState.Failed;
            }
        }
    }
}