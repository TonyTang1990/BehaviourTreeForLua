/*
 * Description:             BehaviorTreeBuilder.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/29
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树构建器
    /// </summary>
    public class BehaviorTreeBuilder
    {
        /// <summary>
        /// 构建一个行为树构建器
        /// </summary>
        /// <returns></returns>
        public static BehaviorTreeBuilder CreateBehaviorTreeBuilder()
        {
            return new BehaviorTreeBuilder();
        }

        /// <summary>
        /// 数据共享黑板
        /// </summary>
        public Blackboard BlackBoard
        {
            get;
            private set;
        }

        /// <summary>
        /// 行为树
        /// </summary>
        public BehaviorTree BT
        {
            get;
            private set;
        }

        private BehaviorTreeBuilder()
        {
            BlackBoard = new Blackboard();
            BT = new BehaviorTree(BlackBoard);
        }

        /// <summary>
        /// 设置根节点
        /// </summary>
        /// <param name="node"></param>
        public void SetRootNode(BaseNode node)
        {
            BT.RootNode = node;
        }

        /// <summary>
        /// 创建选择节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="aborttype"></param>
        /// <returns></returns>
        public SelectorNode CreateSelectorNode(string nodename, ENodeAbortType aborttype = ENodeAbortType.AbortAll)
        {
            return new SelectorNode(nodename, BT, aborttype);
        }

        /// <summary>
        /// 创建顺序节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public SequenceNode CreateSequenceNode(string nodename, ENodeAbortType aborttype = ENodeAbortType.AbortAll)
        {
            return new SequenceNode(nodename, BT, aborttype);
        }

        /// <summary>
        /// 创建并发节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public ParalNode CreateParalNode(string nodename, ENodeAbortType aborttype = ENodeAbortType.AbortAll)
        {
            return new ParalNode(nodename, BT, aborttype);
        }

        /// <summary>
        /// 泛型创建修饰节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="childnode"></param>
        /// <returns></returns>
        public T CreateDecorationNode<T>(string nodename, BaseNode childnode, ENodeAbortType aborttype = ENodeAbortType.AbortAll) where T : DecorationNode, new()
        {
            var decorationnode = new T();
            decorationnode.NodeName = nodename;
            decorationnode.BTOwner = BT;
            decorationnode.ChildNode = childnode;
            decorationnode.NodeAbortType = aborttype;
            return decorationnode;
        }

        /// <summary>
        /// 创建条件节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ConditionNode CreateConditionNode(string nodename, Func<Blackboard, bool> condition)
        {
            return new ConditionNode(nodename, condition, BT);
        }

        /// <summary>
        /// 泛型创建条件节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T CreateConditionNode<T>(string nodename, Func<Blackboard, bool> condition = null) where T : ConditionNode, new()
        {
            var conditionnode = new T();
            conditionnode.NodeName = nodename;
            conditionnode.BTOwner = BT;
            conditionnode.Condition = condition;
            return conditionnode;
        }

        /// <summary>
        /// 创建动作节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public ActionNode CreateActionNode(string nodename, Action<Blackboard> action)
        {
            return new ActionNode(nodename, action, BT);
        }

        /// <summary>
        /// 泛型创建动作节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public T CreateActionNode<T>(string nodename, Action<Blackboard> action = null) where T : ActionNode, new()
        {
            var actionnode = new T();
            actionnode.NodeName = nodename;
            actionnode.BTOwner = BT;
            actionnode.Action = action;
            return actionnode;
        }
    }
}
