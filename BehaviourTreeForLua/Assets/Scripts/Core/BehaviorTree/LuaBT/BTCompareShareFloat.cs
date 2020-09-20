/*
 * Description:             BTCompareShareFloat.cs
 * Author:                  TONYTANG
 * Create Date:             2020/09/20
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LuaBehaviourTree
{
    /// <summary>
    /// BTCompareShareFloat.cs
    /// 比较自定义Float变量行为节点
    /// </summary>
    public class BTCompareShareFloat : BTBaseConditionNode
    {
        /// <summary>
        /// 需要改变的自定义变量名
        /// </summary>
        protected string mVariableName;

        /// <summary>
        /// 目标自定义变量数据
        /// </summary>
        protected float mTargetVariableValue;

        #region 运行时部分
        public BTCompareShareFloat(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            var variablenodedata = OwnerBTGraph.GetVariableNodeValueInRuntime<float>(this.UID) as CustomFloatVariableNodeData;
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
            var currentvariablevalue = OwnerBTGraph.GetData<float>(mVariableName);
            var result = currentvariablevalue == mTargetVariableValue;
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