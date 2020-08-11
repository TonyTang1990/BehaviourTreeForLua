/*
 * Description:             PlayGameActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 玩游戏动作节点
    /// </summary>
    public class PlayGameActionNode : ActionNode
    {
        public PlayGameActionNode():base()
        {
        }

        public PlayGameActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        protected override ENodeRunningState OnExecute()
        {
            GameLauncher.Singleton.PlayerTxt.text = "完成打游戏";
            Debug.Log("完成打游戏");
            return ENodeRunningState.Success;
        }
    }
}