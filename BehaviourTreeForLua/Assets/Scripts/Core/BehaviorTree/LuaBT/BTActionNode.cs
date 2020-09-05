/*
 * Description:             BTActionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTActionNode.cs
    /// 行为节点
    /// </summary>
    public class BTActionNode : BTNode
    {
        #region 运行时部分
        /// <summary>
        /// Lua测对应的节点
        /// </summary>
        protected LuaBTNode mLuaBTNode;

        public BTActionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            mLuaBTNode = BTUtilities.CreateLuaNode(this, instanceid);
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
            // 仅当行为节点状态为运行时才需要重新判定已经判定过的条件节点
            if(NodeRunningState == EBTNodeRunningState.Running)
            {
                if(CheckReevaluatedConditionNodes())
                {
                    // TODO: 打断当前节点运行，重置整棵树

                }
            }
            return (EBTNodeRunningState)mLuaBTNode.OnExecute();
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
            mLuaBTNode.OnExit();
        }
        #endregion
    }
}