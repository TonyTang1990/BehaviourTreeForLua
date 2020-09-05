/*
 * Description:             BTConditionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTConditionNode.cs
    /// 条件节点
    /// </summary>
    public class BTConditionNode : BTNode
    {
        /// <summary>
        /// Lua对应的脚本对象
        /// </summary>
        protected LuaBTNode mLuaBTNode;

        public BTConditionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            mLuaBTNode = BTUtilities.CreateLuaNode(this, instanceid);
        }

        /// <summary>
        /// 更新已执行的条件节点结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool UpdateExecutedConditionNodeResult(EBTNodeRunningState result)
        {
            if (OwnerBT.BTRunningGraph != null)
            {
                return OwnerBT.BTRunningGraph.UpdateExecutedConditionNodeResult(this, result);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            mLuaBTNode.Dispose();
            mLuaBTNode = null;
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            mLuaBTNode.Reset();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mLuaBTNode.OnEnter();
        }

        protected override EBTNodeRunningState OnExecute()
        {
            var result = (EBTNodeRunningState)mLuaBTNode.OnExecute();
            if (result == EBTNodeRunningState.Success || result == EBTNodeRunningState.Failed)
            {
                UpdateExecutedConditionNodeResult(result);
                return result;
            }
            else
            {
                Debug.LogError($"条件节点执行不允许出现:{result}结果!");
                return EBTNodeRunningState.Invalide;
            }
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
            mLuaBTNode.OnExit();
        }
    }
}