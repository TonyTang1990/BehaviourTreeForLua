/*
 * Description:             BTUtilities.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/13
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTUtilities.cs
/// 行为树静态工具类
/// </summary>
public static class BTUtilities
{
    #region 静态方法

    /// <summary>
    /// 创建选择节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <param name="aborttype"></param>
    /// <returns></returns>
    public static BTSelectorNode CreateSelectorNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
    {
        return new BTSelectorNode(node, btowner, aborttype);
    }

    /// <summary>
    /// 创建顺序节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <param name="aborttype"></param>
    /// <returns></returns>
    public static BTSequenceNode CreateSequenceNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
    {
        return new BTSequenceNode(node, btowner, aborttype);
    }

    /// <summary>
    /// 创建并发节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <param name="aborttype"></param>
    /// <returns></returns>
    public static BTParalNode CreateParalNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
    {
        return new BTParalNode(node, btowner, aborttype);
    }

    /// <summary>
    /// 泛型创建修饰节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <returns></returns>
    public static T CreateDecorationNode<T>(BTNode node, TBehaviourTree btowner) where T : BTDecorationNode, new()
    {
        var decorationnode = new T(node, btowner);
        return decorationnode;
    }

    /// <summary>
    /// 创建条件节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <returns></returns>
    public static BTConditionNode CreateConditionNode(BTNode node, TBehaviourTree btowner)
    {
        return new BTConditionNode(node, btowner);
    }

    /// <summary>
    /// 泛型创建条件节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <returns></returns>
    public static T CreateConditionNode<T>(BTNode node, TBehaviourTree btowner) where T : BTConditionNode, new()
    {
        var conditionnode = new T(node, btowner);
        return conditionnode;
    }

    /// <summary>
    /// 创建动作节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <returns></returns>
    public static BTActionNode CreateActionNode(BTNode node, TBehaviourTree btowner)
    {
        return new BTActionNode(node, btowner);
    }

    /// <summary>
    /// 泛型创建动作节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="btowner"></param>
    /// <returns></returns>
    public static T CreateActionNode<T>(BTNode node, TBehaviourTree btowner) where T : BTActionNode, new()
    {
        var actionnode = new T(node, btowner);
        return actionnode;
    }
    #endregion
}