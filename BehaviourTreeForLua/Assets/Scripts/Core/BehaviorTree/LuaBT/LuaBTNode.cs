/*
 * Description:             LuaBTNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/18
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// LuaBTNode.cs
    /// 抽象映射Lua测的节点类
    /// </summary>
    public interface LuaBTNode
    {
        /// <summary>
        /// 重置节点状态
        /// </summary>
        void Reset();

        /// <summary>
        /// 进入节点
        /// </summary>
        void OnEnter();

        /// <summary>
        /// 执行节点
        /// </summary>
        int OnExecute();

        /// <summary>
        /// 退出节点(节点判定完成(成功或失败)时做一些事情)
        /// </summary>
        void OnExit();

        /// <summary>
        /// 释放
        /// </summary>
        void Dispose();
    }
}