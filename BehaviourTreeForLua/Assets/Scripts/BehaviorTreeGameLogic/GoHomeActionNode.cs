/*
 * Description:             GoHomeActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 回家动作节点
    /// </summary>
    public class GoHomeActionNode : ActionNode
    {
        /// <summary>
        /// 回家总时间
        /// </summary>
        private float mGoHomeTimeCount;

        public GoHomeActionNode():base()
        {
        }

        public GoHomeActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mGoHomeTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (Vector3.Distance(GameLauncher.Singleton.Player.transform.position, GameLauncher.Singleton.Home.position) > 0.5f)
            {
                GameLauncher.Singleton.PlayerTxt.text = "回家路上";
                GameLauncher.Singleton.Player.destination = GameLauncher.Singleton.Home.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mGoHomeTimeCount += Time.deltaTime;
                if (mGoHomeTimeCount > 3.0f)
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达家,完成回家";
                    Debug.Log("抵达家,完成回家");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达家,完成回家中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}