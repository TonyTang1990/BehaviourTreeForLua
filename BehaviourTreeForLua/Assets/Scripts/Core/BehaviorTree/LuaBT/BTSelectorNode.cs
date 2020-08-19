﻿/*
 * Description:             BTSelectorNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTSelectorNode.cs
/// 选择节点
/// </summary>
public class BTSelectorNode : BTCompositionNode
{
    public BTSelectorNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner, aborttype)
    {

    }
}