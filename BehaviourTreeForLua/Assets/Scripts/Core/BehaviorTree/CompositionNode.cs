/*
 * Description:             CompositionNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;
using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// 组合节点基类(比如 选择节点，顺序节点，并发节点等)
    /// </summary>
    public class CompositionNode : BaseNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public List<BaseNode> ChildNodes;

        /// <summary>
        /// 节点打断类型
        /// </summary>
        public ENodeAbortType NodeAbortType;

        public CompositionNode(string nodename, BehaviorTree btowner, ENodeAbortType aborttype = ENodeAbortType.AbortAll) : base(nodename, btowner)
        {
            ChildNodes = new List<BaseNode>();
            NodeAbortType = aborttype;
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="node"></param>
        public void AddChild(BaseNode node)
        {
            ChildNodes.Add(node);
        }

        /// <summary>
        /// 移除子节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool RemoveChild(BaseNode node)
        {
            return ChildNodes.Remove(node);
        }

        /// <summary>
        /// 清除所有子节点
        /// </summary>
        public void ClearAllChild()
        {
            ChildNodes.Clear();
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
            // 节点判定完成(成功或失败)时做一些事情
            Reset();
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            // 避免重复reset
            if(NodeRunningState != ENodeRunningState.Invalide)
            {
                base.Reset();
                // 符合节点完成后需要重置之前运行的所有节点状态，确保下一次再次进入正常运行
                foreach (var childnode in ChildNodes)
                {
                    childnode.Reset();
                }
            }
        }

        /// <summary>
        /// 是否应该打断执行
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldAbortRunning()
        {
            if (NodeAbortType == ENodeAbortType.AbortAll)
            {
                return true;
            }
            else if (NodeAbortType == ENodeAbortType.NoAbort)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
