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
        #region CS节点部分
        /// <summary>
        /// 组合节点名数据
        /// </summary>
        public static string[] BTCompositeNodeNameArray = BTData.BTCompositeNodeNameArray;

        /// <summary>
        /// 组合节点描述数据(和BTCompositeNodeNameArray一一对应)
        /// </summary>
        public static string[] BTCompositeNodeIntroArray =
        {
            "顺序执行，第一个成功的节点就算成功，后面不再执行",     // 顺序选择
            "顺序执行，有一个失败就算失败，后面不再执行",           // 顺序执行
            "并发，所有节点全部成功才算成功，任何一个失败都算失败", // 并发节点(所有成功算成功)
            "并发，任何一个成功就算成功，其它行为同时停止",         // 并发节点(一个成功算成功)
            "随机选择一个子节点来执行",                             // 随机节点
        };


        /// <summary>
        /// 修饰节点名数据
        /// </summary>
        public static string[] BTDecorationNodeNameArray = BTData.BTDecorationNodeNameArray;
        
        /// <summary>
        /// 修饰节点描述数据(和BTDecorationNodeNameArray一一对应)
        /// </summary>
        public static string[] BTDecorationNodeParamsIntroArray =
        {
            "无",                                                // 翻转修饰节点
            "重复次数",                                          // 重复次数
        };

        /// <summary>
        /// 修饰节点描述数据(和BTDecorationNodeNameArray一一对应)
        /// </summary>
        public static string[] BTDecorationNodeIntroArray =
        {
            "翻转结果修饰节点",                                  // 翻转结果修饰节点
            "重复执行修饰节点",                                  // 重复执行修饰节点
        };

        /// <summary>
        /// CS行为节点名数据
        /// </summary>
        public static string[] BTCSActionNodeNameArray = {
            "SetShareBool",                                     // 设置自定义Bool变量值
            "SetShareInt",                                      // 设置自定义Int变量值
            "SetShareFloat",                                    // 设置自定义Float变量值
            "SetShareString",                                   // 设置自定义String变量值
        };

        /// <summary>
        /// CS行为节点描述数据(和BTCSActionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTCSActionNodeIntroArray =
        {
            "设置自定义Bool变量值",                             // 设置自定义Bool变量值节点描述数据
            "设置自定义Int变量值",                              // 设置自定义Int变量值节点描述数据
            "设置自定义Float变量值",                            // 设置自定义Float变量值节点描述数据
            "设置自定义String变量值",                           // 设置自定义String变量值节点描述数据
        };

        /// <summary>
        /// CS行为节点参数介绍(和BTCSActionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTCSActionNodeParamsIntroArray =
        {
            "无",                                                // 设置自定义Bool变量值节点参数介绍
            "无",                                                // 设置自定义Int变量值节点参数介绍
            "无",                                                // 设置自定义Float变量值节参数点介绍
            "无",                                                // 设置自定义String变量值节点参数介绍
        };

        /// <summary>
        /// CS条件节点名数据
        /// </summary>
        public static string[] BTCSConditionNodeNameArray = {
            "CompareShareBool",                                   // 比较自定义Bool变量值
            "CompareShareInt",                                    // 比较自定义Int变量值
            "CompareShareFloat",                                  // 比较自定义Float变量值
            "CompareShareString",                                 // 比较自定义String变量值
        };

        /// <summary>
        /// CS条件节点描述数据(和BTConditionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTCSConditionNodeIntroArray =
        {
            "比较自定义Bool变量值",                                 // 比较自定义Bool变量值
            "比较自定义Int变量值",                                  // 比较自定义Int变量值
            "比较自定义Float变量值",                                // 比较自定义Float变量值
            "比较自定义String变量值",                               // 比较自定义String变量值
        };

        /// <summary>
        /// CS条件节点参数介绍(和BTCSConditionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTCSConditionNodeParamsIntroArray =
        {
            "无",                                                    // 比较自定义Bool变量值参数点介绍
            "无",                                                    // 比较自定义Int变量值参数点介绍
            "无",                                                    // 比较自定义Float变量值参数点介绍
            "无",                                                    // 比较自定义String变量值参数点介绍
        };
        #endregion

        #region Lua节点部分
        /// <summary>
        /// Lua行为节点名数据
        /// </summary>
        public static string[] BTLuaActionNodeNameArray = {
            "LogAction",
            "MoveToPostion",
            "WaitForSeconds",
        };

        /// <summary>
        /// Lua行为节点描述数据(和BTLuaActionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTLuaActionNodeIntroArray =
        {
            "打印log",                                              // 打印log
            "移动到指定位置",                                       // 移动到指定位置
            "等待执行一段时间",                                     // 等待执行一段时间
        };

        /// <summary>
        /// Lua行为节点参数介绍(和BTLuaActionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTLuaActionNodeParamsIntroArray =
        {
            "Log内容",
            "坐标X,坐标Y,坐标Z",
            "等待指定时长(s)",
            "无需参数(保持空闲，直到条件有变化时)",
        };

        /// <summary>
        /// Lua条件节点名数据
        /// </summary>
        public static string[] BTLuaConditionNodeNameArray = {
            "ActiveSelfCondition",                                  // 自身是否激活
            "HasTaskCondition"                                      // 是否拥有任务
        };

        /// <summary>
        /// Lua条件节点描述数据(和BTLuaConditionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTLuaConditionNodeIntroArray =
        {
            "自身显示出来",                                      // 自身显示出来
            "正在执行指定任务",                                  // 正在执行指定任务
        };

        /// <summary>
        /// Lua条件节点参数介绍(和BTLuaConditionNodeNameArray一一对应)
        /// </summary>
        public static string[] BTLuaConditionNodeParamsIntroArray =
        {
            "目标对象UID(0表示玩家)",
            "是否拥有任务",
        };
        #endregion
    }
}