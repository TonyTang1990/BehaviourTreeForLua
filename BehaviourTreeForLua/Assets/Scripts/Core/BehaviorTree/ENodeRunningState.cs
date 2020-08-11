/*
 * Description:             ENodeRunningState.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 节点运行状态
    /// </summary>
    public enum ENodeRunningState
    {
        Invalide = 1,           // 无效状态
        Running,                // 运行中
        Success,                // 成功
        Failed,                 // 失败
    }
}