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
            // 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
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
            // 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
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
        public static BTBaseConditionNode CreateConditionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            var iscsnode = Application.isPlaying ? node.CheckIsCSNodeInRunTime() : node.CheckIsCSNodeInEditor();
            if(!iscsnode)
            {
                return new BTLuaConditionNode(node, btowner, parentnode, instanceid);
            }
            else
            {
                // 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
                if(node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[0]))
                {
                    return new BTCompareShareBool(node, btowner, parentnode, instanceid);
                }
                else if(node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[1]))
                {
                    return new BTCompareShareInt(node, btowner, parentnode, instanceid);
                }
                else if (node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[2]))
                {
                    return new BTCompareShareFloat(node, btowner, parentnode, instanceid);
                }
                else if (node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[3]))
                {
                    return new BTCompareShareString(node, btowner, parentnode, instanceid);
                }
                else
                {
                    Debug.LogError($"不支持创建的CS条件节点名:{node.NodeName},请检查代码!");
                    return null;
                }
            }
        }

        /// <summary>
        /// 创建动作节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BTBaseActionNode CreateActionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            var iscsnode = Application.isPlaying ? node.CheckIsCSNodeInRunTime() : node.CheckIsCSNodeInEditor();
            if (!iscsnode)
            {
                return new BTLuaActionNode(node, btowner, parentnode, instanceid);
            }
            else
            {
                // 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
                if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[0]))
                {
                    return new BTSetShareBool(node, btowner, parentnode, instanceid);
                }
                else if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[1]))
                {
                    return new BTSetShareInt(node, btowner, parentnode, instanceid);
                }
                else if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[2]))
                {
                    return new BTSetShareFloat(node, btowner, parentnode, instanceid);
                }
                else if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[3]))
                {
                    return new BTSetShareString(node, btowner, parentnode, instanceid);
                }
                else
                {
                    Debug.LogError($"不支持创建的CS行为节点名:{node.NodeName},请检查代码!");
                    return null;
                }
            }
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
        
        /// <summary>
        /// 指定节点名是否是否设置公共变量行为节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public static bool IsSetShareVariableAction(string nodename)
        {
            if (string.Equals(nodename, "SetShareBool") ||
                string.Equals(nodename, "SetShareInt") ||
                string.Equals(nodename, "SetShareFloat") ||
                string.Equals(nodename, "SetShareString"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 指定节点名是否是否比较公共变量条件节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public static bool IsCompareToShareVariableCondition(string nodename)
        {
            if (string.Equals(nodename, "CompareShareBool") ||
                string.Equals(nodename, "CompareShareInt") ||
                string.Equals(nodename, "CompareShareFloat") ||
                string.Equals(nodename, "CompareShareString"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取节点的变量类型
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public static EVariableType GetNodeVariableType(string nodename)
        {
            if (string.Equals(nodename, BTData.BTCSActionNodeNameArray[0]) || string.Equals(nodename, BTData.BTCSConditionNodeNameArray[0]))
            {
                return EVariableType.Bool;
            }
            else if (string.Equals(nodename, BTData.BTCSActionNodeNameArray[1]) || string.Equals(nodename, BTData.BTCSConditionNodeNameArray[1]))
            {
                return EVariableType.Int;
            }
            else if (string.Equals(nodename, BTData.BTCSActionNodeNameArray[2]) || string.Equals(nodename, BTData.BTCSConditionNodeNameArray[2]))
            {
                return EVariableType.Float;
            }
            else if (string.Equals(nodename, BTData.BTCSActionNodeNameArray[3]) || string.Equals(nodename, BTData.BTCSConditionNodeNameArray[3]))
            {
                return EVariableType.String;
            }
            else
            {
                return EVariableType.Invalide;
            }
        }

        /// <summary>
        /// 获取指定变量类型的节点变量默认值
        /// Note:
        /// 限非运行时用
        /// </summary>
        /// <param name="nodeuid"></param>
        /// <param name="variabletype"></param>
        /// <param name="variablename"></param>
        /// <returns></returns>
        public static CustomVariableNodeData GetVariableNodeDefaultValueInEditor(int nodeuid, string variablename, EVariableType variabletype)
        {
            if (variabletype == EVariableType.Bool)
            {
                return new CustomBoolVariableNodeData(nodeuid, variablename, variabletype, default(bool));
            }
            else if (variabletype == EVariableType.Int)
            {
                return new CustomIntVariableNodeData(nodeuid, variablename, variabletype, default(int));
            }
            else if (variabletype == EVariableType.String)
            {
                return new CustomStringVariableNodeData(nodeuid, variablename, variabletype, default(string));
            }
            else if (variabletype == EVariableType.Float)
            {
                return new CustomFloatVariableNodeData(nodeuid, variablename, variabletype, default(float));
            }
            else
            {
                Debug.LogError($"不支持的变量类型:{variabletype},获取节点变量默认值失败!");
                return null;
            }
        }
        #endregion
    }
}