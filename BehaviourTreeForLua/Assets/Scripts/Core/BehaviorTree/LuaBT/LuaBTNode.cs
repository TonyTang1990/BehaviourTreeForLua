/*
 * Description:             LuaBTNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/18
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LuaBTNode.cs
/// 抽象映射Lua测的节点类
/// </summary>
public class LuaBTNode
{
    /// <summary>
    /// 重置节点状态
    /// </summary>
    public void Reset()
    {

    }

    /// <summary>
    /// 进入节点
    /// </summary>
    public void OnEnter()
    {

    }

    /// <summary>
    /// 执行节点
    /// </summary>
    public EBTNodeRunningState OnExecute()
    {
        return EBTNodeRunningState.Invalide;
    }

    /// <summary>
    /// 退出节点
    /// </summary>
    public void OnExit()
    {
        // 节点判定完成(成功或失败)时做一些事情
    }
}