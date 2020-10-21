/*
 * Description:             Decoration.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// Decoration.cs
    /// 修饰节点
    /// </summary>
    public class Decoration : BTNode
    {
        /// <summary>
        /// 装饰的子节点
        /// </summary>
        public BTNode ChildNode;

        public Decoration()
        {

        }

        public Decoration(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]);
            var runningchildnode = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT, this, instanceid);
            ChildNode = runningchildnode;
        }

        /// <summary>
        /// 设置数据(运行时用对象池后的调用初始化数据)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        public override void SetDatas(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            base.SetDatas(node, btowner, parentnode, instanceid);
            var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[0]);
            var runningchildnode = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT, this, instanceid);
            ChildNode = runningchildnode;
        }

        /// <summary>
        /// 重置节点状态
        /// </summary>
        public override void Reset()
        {
            // 避免重复reset
            if (NodeRunningState != EBTNodeRunningState.Invalide)
            {
                base.Reset();
                // 不负责子节点的重置，避免子节点状态异常
                //ChildNode.Reset();
            }
        }

        protected override EBTNodeRunningState OnExecute()
        {
            return ChildNode.OnUpdate();
        }

        protected override void OnExit()
        {
            base.OnExit();
        }

        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            ChildNode = null;
        }
    }
}