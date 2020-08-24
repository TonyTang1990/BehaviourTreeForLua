﻿/*
 * Description:             BTSelectorNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTSelectorNode.cs
    /// 选择节点
    /// </summary>
    public class BTSelectorNode : BTCompositionNode
    {
        /// <summary>
        /// 当前执行的节点索引
        /// </summary>
        protected int mCurrentNodeIndex;

        public BTSelectorNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner, aborttype)
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
                // 遍历执行子节点，找到第一个返回成功的节点
                if (ChildNodes.Count > mCurrentNodeIndex)
                {
                    // 选择节点类型默认是选择第一个成功的，所以不会使用条件节点去判定
                    // 所以无需判定符合节点的终止类型去判定是否需要打断
                    var childstate = ChildNodes[mCurrentNodeIndex].Update();
                    if (childstate != EBTNodeRunningState.Failed)
                    {
                        return childstate;
                    }
                    mCurrentNodeIndex++;
                }
                else
                {
                    return EBTNodeRunningState.Failed;
                }
            }
        }
    }
}