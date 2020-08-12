/*
 * Description:             WatchMovieActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/31
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 看电影动作节点
    /// </summary>
    public class WatchMovieActionNode : ActionNode
    {
        /// <summary>
        /// 看电影总时间
        /// </summary>
        private float mWatchMoviewTimeCount;

        public WatchMovieActionNode():base()
        {
        }

        public WatchMovieActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mWatchMoviewTimeCount = 0f;
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
                mWatchMoviewTimeCount += Time.deltaTime;
                if (mWatchMoviewTimeCount > 3.0f)
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达商场,完成看电影";
                    Debug.Log("抵达商场,完成看电影");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncherCS.Singleton.PlayerTxt.text = "抵达商场,完成看电影中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}