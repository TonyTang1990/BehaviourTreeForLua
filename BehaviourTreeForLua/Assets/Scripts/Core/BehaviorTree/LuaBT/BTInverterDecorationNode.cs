/*
 * Description:             BTInverterDecorationNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/31
 */

using System;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// 取反装饰节点
    /// </summary>
    public class BTInverterDecorationNode : BTDecorationNode
    {
        public BTInverterDecorationNode(BTNode node, TBehaviourTree btowner, BTNode parentnode) : base(node, btowner, parentnode)
        {

        }

        protected override EBTNodeRunningState OnExecute()
        {
            // 终止逻辑不允许被翻转结果
            if (ShouldAbortRunning())
            {
                return EBTNodeRunningState.Failed;
            }

            var childnodestate = ChildNode.OnUpdate();
            switch (childnodestate)
            {
                case EBTNodeRunningState.Running:
                    return EBTNodeRunningState.Running;
                case EBTNodeRunningState.Success:
                    return EBTNodeRunningState.Failed;
                case EBTNodeRunningState.Failed:
                    return EBTNodeRunningState.Success;
                default:
                    Debug.LogError(string.Format("无效的子节点:{0}状态!", NodeName));
                    return EBTNodeRunningState.Invalide;
            }
        }

        /// <summary>
        /// 是否应该打断执行
        /// Note:
        /// 取反装饰节点的打断判定要反过来，需要重写
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldAbortRunning()
        {
            //// 检查装饰节点的终止类型，看是否需要支持打断
            //if (NodeAbortType == EBTNodeAbortType.AbortAll)
            //{
            //    // 装饰节点一般除了修饰Conditon也可以是修饰Action
            //    // 如果是修饰条件判定是否满足打断条件
            //    if (ChildNode is BTConditionNode)
            //    {
            //        if (ChildNode.Update() == EBTNodeRunningState.Success)
            //        {
            //            Debug.Log(string.Format("取反修饰节点:{0}的{1}条件节点满足条件，打断当前取反装饰节点!", NodeName, ChildNode.NodeName));
            //            return true;
            //        }
            //    }
            //}
            return false;
        }
    }
}