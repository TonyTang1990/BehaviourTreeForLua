/*
 * Description:             WriteBlogActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/11/04
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 写Blog动作节点
    /// </summary>
    public class WriteBlogActionNode : ActionNode
    {
        /// <summary>
        /// 写Blog总时间
        /// </summary>
        private float mWriteBlogTimeCount;

        public WriteBlogActionNode() : base()
        {

        }

        public WriteBlogActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }
        protected override void OnEnter()
        {
            base.OnEnter();
            mWriteBlogTimeCount = 0f;
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
                mWriteBlogTimeCount += Time.deltaTime;
                if (mWriteBlogTimeCount > 2.0f)
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达公司,完成写Blog";
                    Debug.Log("抵达公司,完成写Blog");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达公司,写Blog中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}