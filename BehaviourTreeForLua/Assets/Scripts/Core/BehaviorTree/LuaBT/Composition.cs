/*
 * Description:             Composition.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// Composition.cs
    /// 组合节点
    /// </summary>
    public class Composition : BTNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public List<BTNode> ChildNodes;

        public Composition()
        {

        }

        public Composition(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid) : base(node, btowner, parentnode, instanceid)
        {
            ChildNodes = new List<BTNode>();
            for (int i = 0, length = node.ChildNodesUIDList.Count; i < length; i++)
            {
                var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[i]);
                var runningchildnode  = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT, this, instanceid);
                ChildNodes.Add(runningchildnode);
            }
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
            ChildNodes = new List<BTNode>();
            for (int i = 0, length = node.ChildNodesUIDList.Count; i < length; i++)
            {
                var originalchildnode = OwnerBT.BTOriginalGraph.FindNodeByUID(node.ChildNodesUIDList[i]);
                var runningchildnode = BTUtilities.CreateRunningNodeByNode(originalchildnode, OwnerBT, this, instanceid);
                ChildNodes.Add(runningchildnode);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            ChildNodes = null;
        }

        /// <summary>
        /// 退出节点
        /// </summary>
        protected override void OnExit()
        {
            base.OnExit();
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
                //组合节点重置不负责子节点的重置，避免子节点状态异常
                //// 符合节点完成后需要重置之前运行的所有节点状态，确保下一次再次进入正常运行
                //foreach (var childnode in ChildNodes)
                //{
                //    childnode.Reset();
                //}
            }
        }
    }
}