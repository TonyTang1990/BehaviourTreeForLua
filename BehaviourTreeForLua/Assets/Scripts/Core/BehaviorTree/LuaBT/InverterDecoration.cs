/*
 * Description:             InverterDecoration.cs
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
    public class InverterDecoration : Decoration
    {
        public InverterDecoration()
        {

        }

        public InverterDecoration(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {

        }

        protected override EBTNodeRunningState OnExecute()
        {
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
    }
}