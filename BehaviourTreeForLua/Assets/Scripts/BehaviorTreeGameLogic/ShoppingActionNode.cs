/*
 * Description:             ShoppingActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 逛街动作节点
    /// </summary>
    public class ShoppingActionNode : ActionNode
    {
        /// <summary>
        /// 逛街总时间
        /// </summary>
        private float mShoppingTimeCount;

        public ShoppingActionNode():base()
        {

        }

        public ShoppingActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mShoppingTimeCount = 0f;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (Vector3.Distance(GameLauncher.Singleton.Player.transform.position, GameLauncher.Singleton.ShoppingMall.position) > 0.5f)
            {
                GameLauncher.Singleton.PlayerTxt.text = "去商场路上";
                GameLauncher.Singleton.Player.destination = GameLauncher.Singleton.ShoppingMall.position;
                return ENodeRunningState.Running;
            }
            else
            {
                mShoppingTimeCount += Time.deltaTime;
                if (mShoppingTimeCount > 3.0f)
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达商场,完成逛街";
                    Debug.Log("抵达商场,完成逛街");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达商场,完成逛街中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}