/*
 * Description:             DoStudyActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 学习研究动作节点
    /// </summary>
    public class DoStudyActionNode : ActionNode
    {
        /// <summary>
        /// 学习总时间
        /// </summary>
        private float mStudyTimeCount;

        public DoStudyActionNode():base()
        {

        }

        public DoStudyActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }
        protected override void OnEnter()
        {
            base.OnEnter();
            mStudyTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if(Vector3.Distance(GameLauncherCS.Singleton.Player.transform.position, GameLauncherCS.Singleton.Company.position) > 0.5f)
            {
                GameLauncherCS.Singleton.PlayerTxt.text = "去公司路上";
                GameLauncherCS.Singleton.Player.destination = GameLauncherCS.Singleton.Company.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mStudyTimeCount += Time.deltaTime;
                if(mStudyTimeCount > 3.0f)
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达公司,完成学习";
                    Debug.Log("抵达公司,完成学习");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达公司,学习中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}