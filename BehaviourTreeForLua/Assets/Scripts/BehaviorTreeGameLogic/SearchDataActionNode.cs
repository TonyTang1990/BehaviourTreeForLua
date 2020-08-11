/*
 * Description:             SearchDataActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/11/04
 */

using BehaviorTree;
using System;
using UnityEngine;

namespace Game.BT
{
    /// <summary>
    /// 查资料动作节点
    /// </summary>
    public class SearchDataActionNode : ActionNode
    {
        /// <summary>
        /// 搜索资料总时间
        /// </summary>
        private float mSearchDataTimeCount;

        public SearchDataActionNode() : base()
        {

        }

        public SearchDataActionNode(string nodename, Action<Blackboard> action, BehaviorTree.BehaviorTree bt) : base(nodename, action, bt)
        {

        }
        protected override void OnEnter()
        {
            base.OnEnter();
            mSearchDataTimeCount = 0f;
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
                mSearchDataTimeCount += Time.deltaTime;
                if (mSearchDataTimeCount > 4.0f)
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达公司,完成查资料";
                    Debug.Log("抵达公司,完成查资料");
                    return ENodeRunningState.Success;
                }
                else
                {
                    GameLauncher.Singleton.PlayerTxt.text = "抵达公司,查资料中";
                    return ENodeRunningState.Running;
                }
            }
        }
    }
}