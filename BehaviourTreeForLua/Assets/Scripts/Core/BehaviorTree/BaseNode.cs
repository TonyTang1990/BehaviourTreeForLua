/*
 * Description:             BaseNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/28
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树节点抽象
    /// </summary>
    public class BaseNode
    {
        /// <summary>
        /// 节点名字
        /// </summary>
        public string NodeName;

        /// <summary>
        /// 节点前置条件
        /// </summary>
        public NodePrecondition Precondition;

        /// <summary>
        /// 节点所属的行为树
        /// </summary>
        public BehaviorTree BTOwner;

        /// <summary>
        /// 是否处于运行中
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return NodeRunningState == ENodeRunningState.Running;
            }
        }

        /// <summary>
        /// 是否终止
        /// </summary>
        public bool IsTerminated
        {
            get
            {
                return NodeRunningState == ENodeRunningState.Success || NodeRunningState == ENodeRunningState.Failed;
            }
        }

        /// <summary>
        /// 节点运行状态
        /// </summary>
        public ENodeRunningState NodeRunningState
        {
            get;
            protected set;
        }

        public BaseNode()
        {
            NodeName = string.Empty;
            BTOwner = null;
            Precondition = null;
            NodeRunningState = ENodeRunningState.Invalide;
        }

        public BaseNode(string nodename, BehaviorTree btowner)
        {
            NodeName = nodename;
            BTOwner = btowner;
            Precondition = null;
            NodeRunningState = ENodeRunningState.Invalide;
        }

        /// <summary>
        /// 检查节点前置条件
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckPrecondition()
        {
            return Precondition == null ? true : Precondition.Evaluate(BTOwner.BTBlackBoard);
        }

        /// <summary>
        /// 节点更新
        /// </summary>
        /// <returns></returns>
        public ENodeRunningState Update()
        {
            if(NodeRunningState == ENodeRunningState.Invalide)
            {
                OnEnter();
            }
            NodeRunningState = OnExecute();
            var tempstate = NodeRunningState;
            if (IsTerminated)
            {
                OnExit();
            }
            return tempstate;
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public virtual void Reset()
        {
            Debug.Log(string.Format("重置节点:{0}", NodeName));
            NodeRunningState = ENodeRunningState.Invalide;
        }

        /// <summary>
        /// 进入节点
        /// </summary>
        protected virtual void OnEnter()
        {
            NodeRunningState = ENodeRunningState.Running;
        }

        /// <summary>
        /// 执行节点
        /// </summary>
        protected virtual ENodeRunningState OnExecute()
        {
            return ENodeRunningState.Success;
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected virtual void OnExit()
        {
            // 节点判定完成(成功或失败)时做一些事情
        }
    }
}
