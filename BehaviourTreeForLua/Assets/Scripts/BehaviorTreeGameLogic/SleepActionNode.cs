/*
 * Description:             SleepActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 睡觉动作节点
    /// </summary>
    public class SleepActionNode : ActionNode
    {
        /// <summary>
        /// 睡觉总时间
        /// </summary>
        private float mSleepTimeCount;

        public SleepActionNode():base()
        {
        }

        public SleepActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mSleepTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (Vector3.Distance(GameLauncherCS.Singleton.Player.transform.position, GameLauncherCS.Singleton.Home.position) > 0.5f)
            {
                GameLauncherCS.Singleton.PlayerTxt.text = "回家路上";
                GameLauncherCS.Singleton.Player.destination = GameLauncherCS.Singleton.Home.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mSleepTimeCount += Time.deltaTime;
                if (mSleepTimeCount > 3.0f)
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达家,完成睡觉";
                    Debug.Log("抵达家,完成睡觉");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达家,完成睡觉中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}