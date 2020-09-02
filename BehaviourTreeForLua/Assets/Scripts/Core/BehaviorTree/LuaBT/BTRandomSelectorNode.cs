/*
 * Description:             BTRandomSelectorNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/09/02
 */
 
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTRandomSelectorNode.cs
    /// 随机选择节点
    /// </summary>
    public class BTRandomSelectorNode : BTCompositionNode
    {
        /// <summary>
        /// 子节点索引列表
        /// </summary>
        protected List<int> mChildIndexList = new List<int>();

        /// <summary>
        /// 子节点执行顺序栈
        /// </summary>
        protected Stack<int> mChildrenExecutionOrder = new Stack<int>();

        public BTRandomSelectorNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            mChildIndexList.Clear();
            for (int i = 0; i < ChildNodesUIDList.Count; ++i)
            {
                mChildIndexList.Add(i);
            }
        }

        /// <summary>
        /// 进入节点
        /// </summary>
        protected override void OnEnter()
        {
            base.OnEnter();
            ShuffleChilden();
        }

        protected override EBTNodeRunningState OnExecute()
        {
            while (true)
            {
                // 遍历执行子节点，找到第一个返回成功的节点
                if (mChildrenExecutionOrder.Count > 0)
                {
                    // 选择节点类型默认是选择第一个成功的，所以不会使用条件节点去判定
                    // 所以无需判定符合节点的终止类型去判定是否需要打断
                    var childindex = mChildrenExecutionOrder.Peek();
                    var childstate = ChildNodes[childindex].OnUpdate();
                    if (childstate != EBTNodeRunningState.Failed)
                    {
                        return childstate;
                    }
                }
                else
                {
                    return EBTNodeRunningState.Failed;
                }
            }
        }

        /// <summary>
        /// 节点退出
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
            mChildrenExecutionOrder.Clear();
        }

        /// <summary>
        /// 随机洗牌
        /// </summary>
        private void ShuffleChilden()
        {
            for (int i = mChildIndexList.Count; i > 0; --i)
            {
                int j = Random.Range(0, i);
                int index = mChildIndexList[j];
                mChildrenExecutionOrder.Push(index);
                mChildIndexList[j] = mChildIndexList[i - 1];
                mChildIndexList[i - 1] = index;
            }
        }
    }
}