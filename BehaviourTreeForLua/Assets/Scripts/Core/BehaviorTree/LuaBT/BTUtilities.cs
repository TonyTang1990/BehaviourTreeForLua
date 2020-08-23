/*
 * Description:             BTUtilities.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/13
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTUtilities.cs
    /// 行为树静态工具类
    /// </summary>
    public static class BTUtilities
    {
        #region 静态方法
        /// <summary>
        /// 根据节点数据创建运行时节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <returns></returns>
        public static BTNode CreateRunningNodeByNode(BTNode node, TBehaviourTree btowner)
        {
            switch ((EBTNodeType)node.NodeType)
            {
                case EBTNodeType.ActionNodeType:
                    var actionnode = CreateActionNode(node, btowner);
                    if(btowner.BTRunningGraph.AddNode(actionnode))
                    {
                        return actionnode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.ConditionNodeType:
                    var conditionnode = CreateConditionNode(node, btowner);
                    if (btowner.BTRunningGraph.AddNode(conditionnode))
                    {
                        return conditionnode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.CompositeNodeType:
                    var compositenode = CreateCompositionNode(node, btowner);
                    if (btowner.BTRunningGraph.AddNode(compositenode))
                    {
                        return compositenode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.DecorationNodeType:
                    var decorationnode = CreateDecorationNode(node, btowner);
                    if (btowner.BTRunningGraph.AddNode(decorationnode))
                    {
                        return decorationnode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.EntryNodeType:
                    var entrynode = CreateEntryNode(node, btowner);
                    if (btowner.BTRunningGraph.AddNode(entrynode))
                    {
                        return entrynode;
                    }
                    else
                    {
                        return null;
                    }
                default:
                    Debug.LogError($"不支持的节点类型:{node.NodeType}");
                    return null;
            }
        }

        /// <summary>
        /// 创建选择节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="aborttype"></param>
        /// <returns></returns>
        public static BTSelectorNode CreateSelectorNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
        {
            return new BTSelectorNode(node, btowner, aborttype);
        }

        /// <summary>
        /// 创建顺序节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="aborttype"></param>
        /// <returns></returns>
        public static BTSequenceNode CreateSequenceNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
        {
            return new BTSequenceNode(node, btowner, aborttype);
        }

        /// <summary>
        /// 创建并发节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="aborttype"></param>
        /// <returns></returns>
        public static BTParalNode CreateParalNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
        {
            return new BTParalNode(node, btowner, aborttype);
        }

        /// <summary>
        /// 创建组合节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="aborttype"></param>
        /// <returns></returns>
        public static BTCompositionNode CreateCompositionNode(BTNode node, TBehaviourTree btowner, EBTNodeAbortType aborttype = EBTNodeAbortType.AbortAll)
        {
            if (node.NodeName == BTData.BTCompositeNodeNameArray[0])
            {
                return new BTSelectorNode(node, btowner, aborttype);
            }
            else if(node.NodeName == BTData.BTCompositeNodeNameArray[1])
            {
                return new BTSequenceNode(node, btowner, aborttype);
            }
            else if(node.NodeName == BTData.BTCompositeNodeNameArray[2])
            {
                return new BTParalNode(node, btowner, aborttype);
            }
            else
            {
                Debug.LogError($"不支持的组合节点名:{node.NodeName},创建组合节点失败!");
                return null;
            }
        }

        /// <summary>
        /// 创建修饰节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <returns></returns>
        public static BTDecorationNode CreateDecorationNode(BTNode node, TBehaviourTree btowner)
        {
            var decorationnode = new BTDecorationNode(node, btowner);
            return decorationnode;
        }

        /// <summary>
        /// 创建条件节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <returns></returns>
        public static BTConditionNode CreateConditionNode(BTNode node, TBehaviourTree btowner)
        {
            return new BTConditionNode(node, btowner);
        }

        /// <summary>
        /// 创建动作节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <returns></returns>
        public static BTActionNode CreateActionNode(BTNode node, TBehaviourTree btowner)
        {
            return new BTActionNode(node, btowner);
        }

        /// <summary>
        /// 创建入口节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <returns></returns>
        public static BTEntryNode CreateEntryNode(BTNode node, TBehaviourTree btowner)
        {
            return new BTEntryNode(node, btowner);
        }
        #endregion
    }
}