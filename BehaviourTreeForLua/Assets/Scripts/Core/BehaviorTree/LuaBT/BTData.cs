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
        public const string BTNodeSaveFolderRelativePath = "BehaviourTreeNodes/";

        /// <summary>
        /// 组合节点名数据
        /// </summary>
        public static string[] BTCompositeNodeNameArray = { "SelectorNode", "SeqeunceNode", "ParalAllSuccessNode", "ParalOneSuccessNode" };

        /// <summary>
        /// Lua脚本相对目录
        /// </summary>
        public const string BTLuaScriptFolderRelativePath = "LuaScripts/Core/BehaviourTree/";
    }
}