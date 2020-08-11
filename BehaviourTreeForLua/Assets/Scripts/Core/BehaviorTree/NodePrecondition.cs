/*
 * Description:             NodePrecondition.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树节点前置条件接口抽象
    /// </summary>
    public abstract class NodePrecondition
    {
        /// <summary>
        /// 检查节点前置条件
        /// </summary>
        /// <returns></returns>
        public virtual bool Evaluate(Blackboard bb)
        {
            return true;
        }
    }
}
