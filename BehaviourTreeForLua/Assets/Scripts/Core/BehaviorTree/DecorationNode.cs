/*
 * Description:             DecorationNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/29
 */

using System;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 装饰节点类型基类
    /// </summary>
    public class DecorationNode : BaseNode
    {
        /// <summary>
        /// 装饰的子节点
        /// </summary>
        public BaseNode ChildNode;

        /// <summary>
        /// 节点打断类型
        /// </summary>
        public ENodeAbortType NodeAbortType;

        public DecorationNode() : base()
        {

        }

        public DecorationNode(string nodename, BaseNode childnode, BehaviorTree bt, ENodeAbortType aborttype = ENodeAbortType.AbortAll) : base(nodename, bt)
        {
            ChildNode = childnode;
            NodeAbortType = aborttype;
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            // 避免重复reset
            if (NodeRunningState != ENodeRunningState.Invalide)
            {
                base.Reset();
                ChildNode.Reset();
            }
        }

        /// <summary>
        /// 是否是修饰条件节点的修饰节点(暂时用于判定修饰节点是否需要参与终止判定)
        /// </summary>
        /// <returns></returns>
        public bool IsConditionDecoration()
        {
            return ChildNode is ConditionNode;
        }

        protected override ENodeRunningState OnExecute()
        {
            if(ShouldAbortRunning())
            {
                return ENodeRunningState.Failed;
            }

            return ChildNode.Update();
        }

        protected override void OnExit()
        {
            base.OnExit();
            Reset();
        }

        /// <summary>
        /// 是否应该打断执行
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldAbortRunning()
        {
            // 检查装饰节点的终止类型，看是否需要支持打断
            if (NodeAbortType == ENodeAbortType.AbortAll)
            {
                // 装饰节点一般除了修饰Conditon也可以是修饰Action
                // 如果是修饰条件判定是否满足打断条件
                if (ChildNode is ConditionNode)
                {
                    if (ChildNode.Update() == ENodeRunningState.Failed)
                    {
                        Debug.Log(string.Format("修饰节点:{0}的{1}条件节点不满足条件，打断当前装饰节点!", NodeName, ChildNode.NodeName));
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
