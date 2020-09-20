/*
 * Description:             BTData.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTData.cs
    /// 行为树相关数据
    /// </summary>
    public static class BTData
    {
        /// <summary>
        /// 行为树节点存储目录相对路径
        /// </summary>
        public const string BTNodeSaveFolderRelativePath = "BehaviourTreeNodes";

        /// <summary>
        /// 组合节点名数据
        /// </summary>
        public static string[] BTCompositeNodeNameArray = { "Selector", "Seqeunce", "ParalAllSuccess", "ParalOneSuccess", "RandomSelector" };

        /// <summary>
        /// 修饰节点名数据
        /// </summary>
        public static string[] BTDecorationNodeNameArray = { "InverterDecoration", "RepeatedDecoration" };

        /// <summary>
        /// CS条件节点名数据(注意和BTNodeData.cs里保持一致)
        /// </summary>
        public static string[] BTCSConditionNodeNameArray = { "CompareShareBool", "CompareShareInt", "CompareShareFloat", "CompareShareString" };

        /// <summary>
        /// CS行为节点名数据(注意和BTNodeData.cs里保持一致)
        /// </summary>
        public static string[] BTCSActionNodeNameArray = { "SetShareBool", "SetShareInt", "SetShareFloat", "SetShareString" };

        /// <summary>
        /// Lua脚本相对目录
        /// </summary>
        public const string BTLuaScriptFolderRelativePath = "LuaScripts/Core/BehaviourTree/";
    }
}