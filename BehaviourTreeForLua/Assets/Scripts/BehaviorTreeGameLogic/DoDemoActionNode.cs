/*
 * Description:             DoDemoActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/11/04
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 写Demo动作节点
    /// </summary>
    public class DoDemoActionNode : ActionNode
    {
        /// <summary>
        /// 写Demo总时间
        /// </summary>
        private float mWriteDemoTimeCount;

        public DoDemoActionNode() : base()
        {

        }

        public DoDemoActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }
        protected override void OnEnter()
        {
            base.OnEnter();
            mWriteDemoTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (Vector3.Distance(GameLauncher.Singleton.Player.transform.position, GameLauncher.Singleton.Company.position) > 0.5f)
            {
                GameLauncher.Singleton.PlayerTxt.text = "去公司路上";
                GameLauncher.Singleton.Player.destination = GameLauncher.Singleton.Company.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mWriteDemoTimeCount += Time.deltaTime;
                if (mWriteDemoTimeCount > 5.0f)
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达公司,完成写Demo";
                    Debug.Log("抵达公司,完成写Demo");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达公司,写Demo中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}