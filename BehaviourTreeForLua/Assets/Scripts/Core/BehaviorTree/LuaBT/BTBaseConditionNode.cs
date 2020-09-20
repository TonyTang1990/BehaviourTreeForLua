/*
 * Description:             BTBaseConditionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/09/20
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTBaseConditionNode.cs
    /// �����ڵ����
    /// </summary>
    public abstract class BTBaseConditionNode : BTNode
    {
        public BTBaseConditionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {

        }

        /// <summary>
        /// �ͷ�
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// ���ýڵ�״̬
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        protected override EBTNodeRunningState OnExecute()
        {
            return base.OnExecute();
        }

        /// <summary>
        /// �˳��ڵ�
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
        }

        /// <summary>
        /// �Ƿ�ɱ���������
        /// </summary>
        /// <returns></returns>
        protected override bool CanReevaluate()
        {
            return AbortType == EAbortType.Self;
        }
    }
}