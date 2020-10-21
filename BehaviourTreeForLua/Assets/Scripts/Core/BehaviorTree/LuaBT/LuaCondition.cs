/*
 * Description:             LuaCondition.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// LuaCondition.cs
    /// Lua条件节点
    /// </summary>
    public class LuaCondition : BaseCondition
    {
        public LuaCondition()
        {

        }

        public LuaCondition(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            BTUtilities.CreateLuaNode(this, instanceid);
        }

        public override void SetDatas(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            base.SetDatas(node, btowner, parentnode, instanceid);
            BTUtilities.CreateLuaNode(this, instanceid);
        }

        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            // 因为base.Dispose()为重置数据，导致UnbindLuaBTNodeCall无法正确解除回调绑定
            // 所以必须在父类Dispose()之前调用
            LuaDispose?.Invoke(InstanceID, UID);
            TBehaviourTreeManager.UnbindLuaBTNodeCall(InstanceID, UID);
            // Lua对象池(入池时机改到解绑Lua节点时了)
            //TBehaviourTreeManager.LuaReleaseLuaBTnode(InstanceID, UID);
            base.Dispose();
        }

        /// <summary>
        /// 响应暂停
        /// </summary>
        /// <param name="ispause"></param>
        public override void OnPause(bool ispause)
        {
            base.OnPause(ispause);
            LuaOnPause?.Invoke(InstanceID, UID, ispause);
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            LuaReset?.Invoke(InstanceID, UID);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            LuaOnEnter?.Invoke(InstanceID, UID);
        }

        protected override EBTNodeRunningState OnExecute()
        {
            return (EBTNodeRunningState)LuaOnExecute?.Invoke(InstanceID, UID);
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
            LuaOnExit?.Invoke(InstanceID, UID);
        }
    }
}