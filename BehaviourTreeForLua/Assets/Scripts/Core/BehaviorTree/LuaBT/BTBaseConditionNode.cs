/*
 * Description:             BTBaseConditionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/09/20
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTBaseConditionNode.cs
    /// 条件节点基类
    /// </summary>
    public abstract class BTBaseConditionNode : BTNode
    {
        public BTBaseConditionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {

        }

        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        protected override EBTNodeRunningState OnExecute()
        {
            return base.OnExecute();
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
        }

        /// <summary>
        /// 是否可被重新评估
        /// </summary>
        /// <returns></returns>
        protected override bool CanReevaluate()
        {
            return AbortType == EAbortType.Self;
        }
    }
}