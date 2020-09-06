/*
 * Description:             InverterDecorationNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/11/01
 */

using System;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 取反装饰节点
    /// </summary>
    public class InverterDecorationNode : DecorationNode
    {
        public InverterDecorationNode():base()
        {

        }

        public InverterDecorationNode(string nodename, BaseNode dtnode, BehaviorTree bt) : base(nodename, dtnode, bt)
        {

        }

        protected override ENodeRunningState OnExecute()
        {
            var childnodestate = ChildNode.Update();
            switch (childnodestate)
            {
                case ENodeRunningState.Running:
                    return ENodeRunningState.Running;
                case ENodeRunningState.Success:
                    return ENodeRunningState.Failed;
                case ENodeRunningState.Failed:
                    return ENodeRunningState.Success;
                default:
                    Debug.LogError(string.Format("无效的子节点:{0}状态!", NodeName));
                    return ENodeRunningState.Invalide;
            }
        }
    }
}