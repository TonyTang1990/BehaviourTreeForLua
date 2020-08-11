/*
 * Description:             ConditionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/29
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 条件节点基类
    /// Note:
    /// 条件节点不允许返回Running状态，只允许Success或者Failed
    /// </summary>
    public class ConditionNode : BaseNode
    {
        /// <summary>
        /// 条件回调
        /// </summary>
        public Func<Blackboard, bool> Condition;

        public ConditionNode():base()
        {

        }

        public ConditionNode(string nodename, Func<Blackboard, bool> condition, BehaviorTree bt) : base(nodename, bt)
        {
            Condition = condition;
        }

        protected override ENodeRunningState OnExecute()
        {
            if(Condition(BTOwner.BTBlackBoard))
            {
                return ENodeRunningState.Success;
            }
            else
            {
                return ENodeRunningState.Failed;
            }
        }
    }
}
