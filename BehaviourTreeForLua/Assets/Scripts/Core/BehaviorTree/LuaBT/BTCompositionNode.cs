/*
 * Description:             BTCompositionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTCompositionNode.cs
    /// 组合节点
    /// </summary>
    public class BTCompositionNode : BTNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public List<BTNode> ChildNodes;

        /// <summary>
        /// 节点打断类型
        /// </summary>
        public EBTNodeAbortType NodeAbortType;

        public BTCompositionNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner)
        {
            ChildNodes = new List<BTNode>();
            NodeAbortType = aborttype;
        }
    }
}