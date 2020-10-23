/*
 * Description:             BTUtilities.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/13
 */

using GeneralModule.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTUtilities.cs
    /// 行为树静态工具类
    /// </summary>
    public static class BTUtilities
    {
        #region 静态成员
        /// <summary>
        /// 行为树节点名类型信息缓存映射Map(优化行为树节点反射创建)
        /// Key为节点类名，Value为对应类型信息
        /// </summary>
        public static Dictionary<string, Type> BTNodeTypeCacheMap = new Dictionary<string, Type>();

        /// <summary>
        /// 当前类所在Assembly
        /// </summary>
        public static Assembly CurrentLocatedAssembly = typeof(BTUtilities).Assembly;

        /// <summary>
        /// BTNode类型
        /// </summary>
        public static Type BTNodeType = typeof(BTNode);

        /// <summary>
        /// CompareShareBool类型名
        /// </summary>
        public static string CompareShareBoolTypeName = typeof(CompareShareBool).Name;

        /// <summary>
        /// CompareShareInt类型名
        /// </summary>
        public static string CompareShareIntTypeName = typeof(CompareShareInt).Name;

        /// <summary>
        /// CompareShareFloat类型名
        /// </summary>
        public static string CompareShareFloatTypeName = typeof(CompareShareFloat).Name;

        /// <summary>
        /// CompareShareString类型名
        /// </summary>
        public static string CompareShareStringTypeName = typeof(CompareShareString).Name;

        /// <summary>
        /// SetShareBool类型名
        /// </summary>
        public static string SetShareBoolTypeName = typeof(SetShareBool).Name;

        /// <summary>
        /// SetShareInt类型名
        /// </summary>
        public static string SetShareIntTypeName = typeof(SetShareInt).Name;

        /// <summary>
        /// SetShareFloat类型名
        /// </summary>
        public static string SetShareFloatTypeName = typeof(SetShareFloat).Name;

        /// <summary>
        /// SetShareString类型名
        /// </summary>
        public static string SetShareStringTypeName = typeof(SetShareString).Name;
        #endregion

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
        public static Composition CreateCompositionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            // 考虑到扩展性，最终还是选择采用反射的形式创建CS节点类
            var compositenode = TryGetBTNodeTypeInstance<Composition>(node.NodeName);
            compositenode?.SetDatas(node, btowner, parentnode, instanceid);
            return compositenode;

            //// 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
            //if (node.NodeName == BTData.BTCompositeNodeNameArray[0])
            //{
            //    return new BTSelectorNode(node, btowner, parentnode, instanceid);
            //}
            //else if(node.NodeName == BTData.BTCompositeNodeNameArray[1])
            //{
            //    return new BTSequenceNode(node, btowner, parentnode, instanceid);
            //}
            //else if(node.NodeName == BTData.BTCompositeNodeNameArray[2])
            //{
            //    return new BTParalAllSuccessNode(node, btowner, parentnode, instanceid);
            //}
            //else if (node.NodeName == BTData.BTCompositeNodeNameArray[3])
            //{
            //    return new BTParalOneSuccessNode(node, btowner, parentnode, instanceid);
            //}
            //else if (node.NodeName == BTData.BTCompositeNodeNameArray[4])
            //{
            //    return new BTRandomSelectorNode(node, btowner, parentnode, instanceid);
            //}
            //else
            //{
            //    Debug.LogError($"不支持的组合节点名:{node.NodeName},创建组合节点失败!");
            //    return null;
            //}
        }

        /// <summary>
        /// 创建修饰节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static Decoration CreateDecorationNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            // 考虑到扩展性，最终还是选择采用反射的形式创建CS节点类
            var decorationnode = TryGetBTNodeTypeInstance<Decoration>(node.NodeName);
            decorationnode?.SetDatas(node, btowner, parentnode, instanceid);
            return decorationnode;

            //// 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
            //if (node.NodeName == BTData.BTDecorationNodeNameArray[0])
            //{
            //    return new BTInverterDecorationNode(node, btowner, parentnode, instanceid);
            //}
            //else if (node.NodeName == BTData.BTDecorationNodeNameArray[1])
            //{
            //    return new BTRepeatedDecorationNode(node, btowner, parentnode, instanceid);
            //}
            //else
            //{
            //    Debug.LogError($"不支持的修饰节点名:{node.NodeName},创建修饰节点失败!");
            //    return null;
            //}
        }

        /// <summary>
        /// 创建条件节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="btowner"></param>
        /// <param name="parentnode"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static BaseCondition CreateConditionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            var iscsnode = Application.isPlaying ? node.CheckIsCSNodeInRunTime() : node.CheckIsCSNodeInEditor();
            if(!iscsnode)
            {
                LuaCondition luaconditionnode = ObjectPool.Singleton.Pop<LuaCondition>();
                luaconditionnode.SetDatas(node, btowner, parentnode, instanceid);
                return luaconditionnode;
                //return new BTLuaConditionNode(node, btowner, parentnode, instanceid);
            }
            else
            {
                // 考虑到扩展性，最终还是选择采用反射的形式创建CS节点类
                var conditionnode = TryGetBTNodeTypeInstance<BaseCondition>(node.NodeName);
                conditionnode?.SetDatas(node, btowner, parentnode, instanceid);
                return conditionnode;

                //// 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
                //if (node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[0]))
                //{
                //    return new BTCompareShareBool(node, btowner, parentnode, instanceid);
                //}
                //else if(node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[1]))
                //{
                //    return new BTCompareShareInt(node, btowner, parentnode, instanceid);
                //}
                //else if (node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[2]))
                //{
                //    return new BTCompareShareFloat(node, btowner, parentnode, instanceid);
                //}
                //else if (node.NodeName.Equals(BTData.BTCSConditionNodeNameArray[3]))
                //{
                //    return new BTCompareShareString(node, btowner, parentnode, instanceid);
                //}
                //else
                //{
                //    Debug.LogError($"不支持创建的CS条件节点名:{node.NodeName},请检查代码!");
                //    return null;
                //}
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
        public static BaseAction CreateActionNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            var iscsnode = Application.isPlaying ? node.CheckIsCSNodeInRunTime() : node.CheckIsCSNodeInEditor();
            if (!iscsnode)
            {
                LuaAction luaactionnode = ObjectPool.Singleton.Pop<LuaAction>();
                luaactionnode.SetDatas(node, btowner, parentnode, instanceid);
                return luaactionnode;
                //return new BTLuaActionNode(node, btowner, parentnode, instanceid);
            }
            else
            {
                // 考虑到扩展性，最终还是选择采用反射的形式创建CS节点类
                var actionnode = TryGetBTNodeTypeInstance<BaseAction>(node.NodeName);
                actionnode?.SetDatas(node, btowner, parentnode, instanceid);
                return actionnode;

                //// 为了避免反射带来的性能开销，这里采用穷举法判定创建具体CS节点类
                //if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[0]))
                //{
                //    return new BTSetShareBool(node, btowner, parentnode, instanceid);
                //}
                //else if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[1]))
                //{
                //    return new BTSetShareInt(node, btowner, parentnode, instanceid);
                //}
                //else if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[2]))
                //{
                //    return new BTSetShareFloat(node, btowner, parentnode, instanceid);
                //}
                //else if (node.NodeName.Equals(BTData.BTCSActionNodeNameArray[3]))
                //{
                //    return new BTSetShareString(node, btowner, parentnode, instanceid);
                //}
                //else
                //{
                //    Debug.LogError($"不支持创建的CS行为节点名:{node.NodeName},请检查代码!");
                //    return null;
                //}
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
        public static Entry CreateEntryNode(BTNode node, TBehaviourTree btowner, BTNode parentnode, int instanceid)
        {
            Entry entrynode = ObjectPool.Singleton.Pop<Entry>();
            entrynode.SetDatas(node, btowner, parentnode, instanceid);
            return entrynode;
            //return new BTEntryNode(node, btowner, parentnode, instanceid);
        }

        /// <summary>
        /// 创建绑定指定BTNode的Lua脚本对象
        /// </summary>
        /// <param name="node"></param>
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public static int CreateLuaNode(BTNode node, int instanceid)
        {
            if (TBehaviourTreeManager.LuaCreateLuaBTnode != null)
            {
                var uid = TBehaviourTreeManager.LuaCreateLuaBTnode(node, instanceid);
                return uid;
            }
            else
            {
                Debug.LogError("未绑定创建Lua节点创建委托，创建Lua行为节点失败!");
                return 0;
            }
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
            if (string.Equals(nodename, SetShareBoolTypeName) ||
                string.Equals(nodename, SetShareIntTypeName) ||
                string.Equals(nodename, SetShareFloatTypeName) ||
                string.Equals(nodename, SetShareStringTypeName))
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
            if (string.Equals(nodename, CompareShareBoolTypeName) ||
                string.Equals(nodename, CompareShareIntTypeName) ||
                string.Equals(nodename, CompareShareFloatTypeName) ||
                string.Equals(nodename, CompareShareStringTypeName))
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
            if (string.Equals(nodename, SetShareBoolTypeName) || string.Equals(nodename, CompareShareBoolTypeName))
            {
                return EVariableType.Bool;
            }
            else if (string.Equals(nodename, SetShareIntTypeName) || string.Equals(nodename, CompareShareIntTypeName))
            {
                return EVariableType.Int;
            }
            else if (string.Equals(nodename, SetShareFloatTypeName) || string.Equals(nodename, CompareShareFloatTypeName))
            {
                return EVariableType.Float;
            }
            else if (string.Equals(nodename, SetShareStringTypeName) || string.Equals(nodename, CompareShareStringTypeName))
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

        /// <summary>
        /// 尝试获取指定节点类型实例对象
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        private static T TryGetBTNodeTypeInstance<T>(string nodename) where T : BTNode
        {
            // 考虑到扩展性，最终还是选择采用反射的形式创建CS节点类
            Type nodetype;
            if (!BTNodeTypeCacheMap.TryGetValue(nodename, out nodetype))
            {
                var nodefullname = $"LuaBehaviourTree.{nodename}";
                nodetype = CurrentLocatedAssembly.GetType(nodefullname);
                if (BTNodeType.IsAssignableFrom(nodetype))
                {
                    BTNodeTypeCacheMap.Add(nodename, nodetype);
                    //Debug.Log($"添加行为树节点类型:{nodename}缓存!");
                }
                else
                {
                    nodetype = null;
                }
            }
            if (nodetype != null)
            {
                // Note:
                // 带参的反射构建比不带参的默认构造函数反射构建耗时更多
                var btnode = ObjectPool.Singleton.PopWithType(nodetype);
                return (T)btnode;
            }
            else
            {
                Debug.LogError($"节点名:{nodename}未继承至:BTNode类型，请检查代码!");
                return null;
            }
        }
        #endregion
    }
}