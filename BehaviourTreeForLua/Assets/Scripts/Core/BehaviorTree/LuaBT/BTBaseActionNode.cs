/*
 * Description:             BTBaseActionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/09/20
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTActionNode.cs
    /// ��Ϊ�ڵ����
    /// </summary>
    public abstract class BTBaseActionNode : BTNode
    {
        #region ����ʱ����
        public BTBaseActionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
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
        #endregion
    }
}