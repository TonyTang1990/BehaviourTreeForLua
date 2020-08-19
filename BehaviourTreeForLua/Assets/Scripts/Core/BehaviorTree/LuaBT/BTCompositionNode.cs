/*
 * Description:             BTCompositionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTCompositionNode.cs
/// 组合节点
/// </summary>
public class BTCompositionNode : BTNode
{
    /// <summary>
    /// 节点打断类型
    /// </summary>
    public EBTNodeAbortType NodeAbortType;

    public BTCompositionNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner)
    {
        NodeAbortType = aborttype;
    }
}