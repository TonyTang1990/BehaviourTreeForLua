/*
 * Description:             ENodeAbortType.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/11/01
 */

using System;


namespace BehaviorTree
{
    /// <summary>
    /// 节点打断类型
    /// </summary>
    public enum ENodeAbortType
    {
        AbortAll = 1,                   // 打断所有
        NoAbort,                        // 不能被打断
    }
}