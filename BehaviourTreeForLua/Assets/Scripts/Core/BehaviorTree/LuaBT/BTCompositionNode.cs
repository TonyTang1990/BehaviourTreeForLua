/*
 * Description:             BTCompositionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTCompositionNode.cs
    /// 组合节点
    /// </summary>
    public class BTCompositionNode : BTNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public List<BTNode> ChildNodes;

        /// <summary>
        /// 节点打断类型
        /// </summary>
        public EBTNodeAbortType NodeAbortType;

        public BTCompositionNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll) : base(node, btowner)
        {
            ChildNodes = new List<BTNode>();
            NodeAbortType = aborttype;
            for (int i = 0, length = node.ChildNodesUIDList.Count; i < length; i++)
            {
                var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[i]);
                var runningchildnode  = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT);
                ChildNodes.Add(runningchildnode);
            }
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
            if (NodeRunningState != EBTNodeRunningState.Invalide)
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
            if (NodeAbortType == EBTNodeAbortType.AbortAll)
            {
                return true;
            }
            else if (NodeAbortType == EBTNodeAbortType.NoAbort)
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