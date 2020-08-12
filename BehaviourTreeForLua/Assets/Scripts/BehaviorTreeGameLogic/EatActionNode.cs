/*
 * Description:             EatActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 吃饭动作节点
    /// </summary>
    public class EatActionNode : ActionNode
    {
        /// <summary>
        /// 吃饭总时间
        /// </summary>
        private float mEatTimeCount;

        public EatActionNode():base()
        {
        }

        public EatActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mEatTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (Vector3.Distance(GameLauncherCS.Singleton.Player.transform.position, GameLauncherCS.Singleton.ShoppingMall.position) > 0.5f)
            {
                GameLauncherCS.Singleton.PlayerTxt.text = "去商场路上";
                GameLauncherCS.Singleton.Player.destination = GameLauncherCS.Singleton.ShoppingMall.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mEatTimeCount += Time.deltaTime;
                if (mEatTimeCount > 3.0f)
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达商场,完成吃饭";
                    Debug.Log("抵达商场,完成吃饭");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达商场,完成吃饭中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}