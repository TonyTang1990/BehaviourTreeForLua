/*
 * Description:             BTNodeData.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTNodeData.cs
    /// 行为树常量数据
    /// </summary>
    public static class BTNodeData
    {
        /// <summary>
        /// 组合节点名数据
        /// </summary>
        public static string[] BTCompositeNodeNameArray = BTData.BTCompositeNodeNameArray;

        /// <summary>
        /// 行为节点名数据
        /// </summary>
        public static string[] BTActionNodeNameArray = { "LogAction", "MoveToPostion" };

        /// <summary>
        /// 条件节点名数据
        /// </summary>
        public static string[] BTConditionNodeNameArray = { "ActiveSelfCondition" };

        /// <summary>
        /// 修饰节点名数据
        /// </summary>
        public static string[] BTDecorationNodeNameArray = { "InverterDecoration" };
    }
}