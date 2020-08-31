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

        public BTActionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode) : base(node, btowner, parentnode)
        {
            mLuaBTNode = BTUtilities.CreateLuaNode(this);
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
            return mLuaBTNode.OnExecute();
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            mLuaBTNode.OnExit();
        }
        #endregion
    }
}