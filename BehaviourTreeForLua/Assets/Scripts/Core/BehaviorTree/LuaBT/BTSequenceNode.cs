/*
 * Description:             BTSequenceNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTSequenceNode.cs
    /// 顺序节点
    /// </summary>
    public class BTSequenceNode : BTCompositionNode
    {
        /// <summary>
        /// 当前执行的节点索引
        /// </summary>
        protected int mCurrentNodeIndex;

        public BTSequenceNode(BTNode node, TBehaviourTree btowner, BTNode parentnode) : base(node, btowner, parentnode)
        {
            mCurrentNodeIndex = 0;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mCurrentNodeIndex = 0;
        }

        protected override EBTNodeRunningState OnExecute()
        {
            while (true)
            {
                // 遍历执行子节点，直到某个子节点返回失败
                if (ChildNodes.Count > mCurrentNodeIndex)
                {
                    var childstate = ChildNodes[mCurrentNodeIndex].OnUpdate();
                    if (childstate == EBTNodeRunningState.Failed)
                    {
                        return EBTNodeRunningState.Failed;
                    }
                    else if (childstate == EBTNodeRunningState.Success)
                    {
                        mCurrentNodeIndex++;
                    }
                    else
                    {
                        return EBTNodeRunningState.Running;
                    }
                }
                else
                {
                    return EBTNodeRunningState.Success;
                }
            }
        }
    }
}