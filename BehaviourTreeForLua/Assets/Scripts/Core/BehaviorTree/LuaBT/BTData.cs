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
        /// CS组合节点名数据
        /// </summary>
        public static string[] BTCompositeNodeNameArray = { typeof(Selector).Name, typeof(Sequence).Name, typeof(ParalAllSuccess).Name, typeof(ParalOneSuccess).Name, typeof(RandomSelector).Name };

        /// <summary>
        /// CS修饰节点名数据
        /// </summary>
        public static string[] BTDecorationNodeNameArray = { typeof(InverterDecoration).Name, typeof(RepeatedDecoration).Name };

        /// <summary>
        /// CS条件节点名数据(注意和BTNodeData.cs里保持一致)
        /// </summary>
        public static string[] BTConditionNodeNameArray = { typeof(CompareShareBool).Name, typeof(CompareShareInt).Name, typeof(CompareShareFloat).Name, typeof(CompareShareString).Name };

        /// <summary>
        /// CS行为节点名数据(注意和BTNodeData.cs里保持一致)
        /// </summary>
        public static string[] BTActionNodeNameArray = { typeof(SetShareBool).Name, typeof(SetShareInt).Name, typeof(SetShareFloat).Name, typeof(SetShareString).Name };

        /// <summary>
        /// Lua脚本相对目录
        /// </summary>
        public const string BTLuaScriptFolderRelativePath = "LuaScripts/Core/BehaviourTree/";
    }
}