﻿/*
 * Description:             BTParalOneSuccessNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/25
 */

using System;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTParalOneSuccessNode.cs
    /// 一个成功算成功策略并发节点
    /// </summary>
    public class BTParalOneSuccessNode : BTBaseParalNode
    {
        public BTParalOneSuccessNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            ParalPolicy = EBTParalPolicy.OneSuccess;
        }
    }
}
