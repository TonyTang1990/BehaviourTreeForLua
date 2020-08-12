/*
 * Description:             DoWorkTaskActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 执行工作任务的动作节点
    /// </summary>
    public class DoWorkTaskActionNode : ActionNode
    {
        /// <summary>
        /// 工作总时间
        /// </summary>
        private float mWorkTimeCount;

        public DoWorkTaskActionNode():base()
        {

        }

        public DoWorkTaskActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mWorkTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (Vector3.Distance(GameLauncherCS.Singleton.Player.transform.position, GameLauncherCS.Singleton.Company.position) > 0.5f)
            {
                GameLauncherCS.Singleton.PlayerTxt.text = "去公司路上";
                GameLauncherCS.Singleton.Player.destination = GameLauncherCS.Singleton.Company.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mWorkTimeCount += Time.deltaTime;
                if (mWorkTimeCount > 3.0f)
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达公司,完成工作任务";
                    Debug.Log("抵达公司,完成工作任务");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达公司,完成工作任务中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}