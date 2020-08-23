/*
 * Description:             BTParalNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTParalNode.cs
    /// 并发节点
    /// </summary>
    public class BTParalNode : BTCompositionNode
    {
        public BTParalNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner, aborttype)
        {

        }
    }
}