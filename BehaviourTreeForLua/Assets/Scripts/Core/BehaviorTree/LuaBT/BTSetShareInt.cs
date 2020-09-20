/*
 * Description:             BTSetShareInt.cs
 * Author:                  TONYTANG
 * Create Date:             2020/09/20
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTSetShareInt.cs
    /// 设置自定义变量Int行为节点
    /// </summary>
    public class BTSetShareInt : BTBaseActionNode
    {
        /// <summary>
        /// 需要改变的自定义变量名
        /// </summary>
        protected string mVariableName;

        /// <summary>
        /// 目标自定义变量数据
        /// </summary>
        protected int mTargetVariableValue;

        #region 运行时部分
        public BTSetShareInt(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            var variablenodedata = OwnerBTGraph.GetVariableNodeValueInRuntime<int>(this.UID) as CustomIntVariableNodeData;
            mVariableName = variablenodedata.VariableName;
            mTargetVariableValue = variablenodedata.VariableValue;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// 重置节点状态
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
            var result = OwnerBTGraph.UpdateData<int>(mVariableName, mTargetVariableValue);
            return result ? EBTNodeRunningState.Success : EBTNodeRunningState.Failed;
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
        }
        #endregion
    }
}