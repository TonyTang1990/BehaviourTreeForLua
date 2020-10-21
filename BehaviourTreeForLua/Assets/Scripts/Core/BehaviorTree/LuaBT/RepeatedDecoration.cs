/*
 * Description:             RepeatedDecoration.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/09/02
 */

using System;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// 重复执行装饰节点
    /// </summary>
    public class RepeatedDecoration : Decoration
    {
        /// <summary>
        /// 重复次数
        /// </summary>
        protected int RepeatedTimes;

        /// <summary>
        /// 已执行次数
        /// </summary>
        private int mExecutedTimes;

        public RepeatedDecoration()
        {

        }

        public RepeatedDecoration(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {

        }

        /// <summary>
        /// 设置数据(运行时用对象池后的调用初始化数据)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        public override void SetDatas(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            base.SetDatas(node, btowner, parentnode, instanceid);
            RepeatedTimes = int.Parse(this.NodeParams);
        }

        /// <summary>
        /// 进入节点
        /// </summary>
        protected override void OnEnter()
        {
            base.OnEnter();
            mExecutedTimes = 0;
        }

        /// <summary>
        /// 执行节点
        /// </summary>
        /// <returns></returns>
        protected override EBTNodeRunningState OnExecute()
        {
            while (mExecutedTimes < RepeatedTimes)
            {
                var childnodestate = ChildNode.OnUpdate();
                if (childnodestate != EBTNodeRunningState.Running)
                {
                    mExecutedTimes++;
                }
            }
            return EBTNodeRunningState.Success;
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
            mExecutedTimes = 0;
        }

        public override void Dispose()
        {
            base.Dispose();
            mExecutedTimes = 0;
        }
    }
}