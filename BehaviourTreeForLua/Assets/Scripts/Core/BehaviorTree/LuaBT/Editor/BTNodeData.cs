/*
 * Description:             BTNodeData.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTNodeData.cs
/// 行为树常量数据
/// </summary>
public static class BTNodeData
{
    /// <summary>
    /// 组合节点名数据
    /// </summary>
    public static string[] BTCompositeNodeNameArray = { "SelectorNode", "SeqeunceNode", "ParalNode" };

    /// <summary>
    /// 行为节点名数据
    /// </summary>
    public static string[] BTActionNodeNameArray = { "LogAction" };

    /// <summary>
    /// 条件节点名数据
    /// </summary>
    public static string[] BTConditionNodeNameArray = { "ActiveSelfCondition" };

    /// <summary>
    /// 修饰节点名数据
    /// </summary>
    public static string[] BTDecorationNodeNameArray = { "InverseDecoration" };
}