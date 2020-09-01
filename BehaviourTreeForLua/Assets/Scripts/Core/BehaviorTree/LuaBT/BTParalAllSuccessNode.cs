/*
 * Description:             BTParalAllSuccessNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/25
 */

using System;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTParalAllSuccessNode.cs
    /// 所有成功策略并发节点
    /// </summary>
    public class BTParalAllSuccessNode : BTBaseParalNode
    {
        public BTParalAllSuccessNode(BTNode node, TBehaviourTree btowner, BTNode parentnode) : base(node, btowner, parentnode)
        {
            ParalPolicy = EBTParalPolicy.AllSuccess;
        }
    }
}
