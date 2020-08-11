/*
 * Description:             ActionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/29
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 动作节点基类
    /// </summary>
    public class ActionNode : BaseNode
    {
        /// <summary>
        /// 具体的动作回调
        /// </summary>
        public Action<Blackboard> Action;

        public ActionNode():base()
        {

        }

        public ActionNode(string nodename, Action<Blackboard> action, BehaviorTree bt) : base(nodename, bt)
        {
            Action = action;
        }

        protected override ENodeRunningState OnExecute()
        {
            Action?.Invoke(BTOwner.BTBlackBoard);
            return ENodeRunningState.Success;
        }
    }
}
