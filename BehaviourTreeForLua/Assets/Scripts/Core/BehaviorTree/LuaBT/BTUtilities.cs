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
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BTNode CreateRunningNodeByNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            switch ((EBTNodeType)node.NodeType)
            {
                case EBTNodeType.ActionNodeType:
                    var actionnode = CreateActionNode(node, btowner, parentnode, instanceid);
                    if(btowner.BTRunningGraph.AddNode(actionnode))
                    {
                        return actionnode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.ConditionNodeType:
                    var conditionnode = CreateConditionNode(node, btowner, parentnode, instanceid);
                    if (btowner.BTRunningGraph.AddNode(conditionnode))
                    {
                        return conditionnode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.CompositeNodeType:
                    var compositenode = CreateCompositionNode(node, btowner, parentnode, instanceid);
                    if (btowner.BTRunningGraph.AddNode(compositenode))
                    {
                        return compositenode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.DecorationNodeType:
                    var decorationnode = CreateDecorationNode(node, btowner, parentnode, instanceid);
                    if (btowner.BTRunningGraph.AddNode(decorationnode))
                    {
                        return decorationnode;
                    }
                    else
                    {
                        return null;
                    }
                case EBTNodeType.EntryNodeType:
                    var entrynode = CreateEntryNode(node, btowner, parentnode, instanceid);
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
        /// 创建组合节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BTCompositionNode CreateCompositionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            if (node.NodeName == BTData.BTCompositeNodeNameArray[0])
            {
                return new BTSelectorNode(node, btowner, parentnode, instanceid);
            }
            else if(node.NodeName == BTData.BTCompositeNodeNameArray[1])
            {
                return new BTSequenceNode(node, btowner, parentnode, instanceid);
            }
            else if(node.NodeName == BTData.BTCompositeNodeNameArray[2])
            {
                return new BTParalAllSuccessNode(node, btowner, parentnode, instanceid);
            }
            else if (node.NodeName == BTData.BTCompositeNodeNameArray[3])
            {
                return new BTParalOneSuccessNode(node, btowner, parentnode, instanceid);
            }
            else if (node.NodeName == BTData.BTCompositeNodeNameArray[4])
            {
                return new BTRandomSelectorNode(node, btowner, parentnode, instanceid);
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
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BTDecorationNode CreateDecorationNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            if (node.NodeName == BTData.BTDecorationNodeNameArray[0])
            {
                return new BTInverterDecorationNode(node, btowner, parentnode, instanceid);
            }
            else if (node.NodeName == BTData.BTDecorationNodeNameArray[1])
            {
                return new BTRepeatedDecorationNode(node, btowner, parentnode, instanceid);
            }
            else
            {
                Debug.LogError($"不支持的修饰节点名:{node.NodeName},创建修饰节点失败!");
                return null;
            }
        }

        /// <summary>
        /// 创建条件节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BTConditionNode CreateConditionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            return new BTConditionNode(node, btowner, parentnode, instanceid);
        }

        /// <summary>
        /// 创建动作节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BTActionNode CreateActionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            return new BTActionNode(node, btowner, parentnode, instanceid);
        }

        /// <summary>
        /// 创建入口节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <<param name="instanceid"></param>
        /// <returns></returns>
        public static BTEntryNode CreateEntryNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            return new BTEntryNode(node, btowner, parentnode, instanceid);
        }

        /// <summary>
        /// 创建绑定指定BTNode的Lua脚本对象
        /// </summary>
        /// <param name="node"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static LuaBTNode CreateLuaNode(BTNode node, int instanceid)
        {
            return XLuaManager.getInstance().LuaCreateLuaBTnode(node, instanceid);
        }

        /// <summary>
        /// 获取一个唯一个UID
        /// </summary>
        /// <returns></returns>
        public static int GetNodeUID()
        {
            // 经测试，1000000次大概有100次重复的几率
            // 后续会结合本地是否使用过此UID来做二次验证确保唯一性
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int uid = BitConverter.ToInt32(buffer, 0);
            return uid;
        }
        #endregion
    }
}