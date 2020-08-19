/*
 * Description:             BTSequenceNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTSequenceNode.cs
/// 顺序节点
/// </summary>
public class BTSequenceNode : BTCompositionNode
{
    public BTSequenceNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner, aborttype)
    {

    }
}