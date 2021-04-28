/*
 * Description:             BTGraph.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralModule.Pool;

/// Lua行为树设计:
/// 组合节点和装饰节点在CS测
/// 行为节点和条件节点通过统一CS节点映射到Lua测实现自定义Lua条件和行为节点

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTGraph.cs
    /// 行为树图抽象
    /// </summary>
    [Serializable]
    public class BTGraph
    {
        /// <summary>
        /// 行为树导出文件名
        /// </summary>
        public string BTFileName;

        /// <summary>
        /// 行为树根节点数据UID
        /// </summary>
        public int RootNodeUID;

        /// <summary>
        /// 所有的节点数据
        /// </summary>
        public List<BTNode> AllNodesList;

        /// Note:
        /// 因为Unity自带的JsonUtility不支持object和Dictionary所以才分别存储的各自类型的变量数据
        /// Newtonsoft测试支持object和Dictionary但序列化Unity自带的一些数据结构遇到一些问题未解决所以就还是沿用JsonUtility

        /// <summary>
        /// 所有Bool变量定义数据列表
        /// </summary>
        public List<CustomBoolVariableData> AllBoolVariableDataList;

        /// <summary>
        /// 所有Int变量定义数据列表
        /// </summary>
        public List<CustomIntVariableData> AllIntVariableDataList;

        /// <summary>
        /// 所有Float变量定义数据列表
        /// </summary>
        public List<CustomFloatVariableData> AllFloatVariableDataList;

        /// <summary>
        /// 所有String变量定义数据列表
        /// </summary>
        public List<CustomStringVariableData> AllStringVariableDataList;

        /// Note:
        /// 为了减少单个节点不必要的序列化数据，针对自定义变量的数据存储直接存储到BTGraph上
        /// 通过运行时加载后构建Dictionary<int, CustomVariableNodeData>来快速查询相关节点自定义变量数据
        /// 核心是因为JsonUtility不支持object和Dictionary序列化
        /// <summary>
        /// 所有Bool变量节点定义数据列表
        /// </summary>
        public List<CustomBoolVariableNodeData> AllBoolVariableNodeDataList;

        /// <summary>
        /// 所有Int变量节点定义数据列表
        /// </summary>
        public List<CustomIntVariableNodeData> AllIntVariableNodeDataList;

        /// <summary>
        /// 所有Float变量节点定义数据列表
        /// </summary>
        public List<CustomFloatVariableNodeData> AllFloatVariableNodeDataList;

        /// <summary>
        /// 所有String变量节点定义数据列表
        /// </summary>
        public List<CustomStringVariableNodeData> AllStringVariableNodeDataList;

        /// <summary>
        /// 所有自定义变量节点映射Map(运行时数据)
        /// Key为节点UID,Value为对应自定义变量节点数据
        /// </summary>
        public Dictionary<int, CustomVariableNodeData> AllVariableNodeDataMaps
        {
            get;
            protected set;
        }

        /// <summary>
        /// 根节点
        /// </summary>
        public BTNode RootNode
        {
            get;
            private set;
        }

        /// <summary>
        /// 执行中的节点Map(Key为节点UID，Value为节点Node对象)
        /// </summary>
        public Dictionary<int, BTNode> ExecutingNodesMap
        {
            get;
            private set;
        }

        /// <summary>
        /// 行为树已经执行过的需要重新评估的节点映射Map(Key为已经执行过的需要重新评估的节点,Value为该节点上一次的执行结果)
        /// </summary>
        public Dictionary<BTNode, EBTNodeRunningState> ExecutedReevaluatedNodesResultMap
        {
            get;
            private set;
        }
        #region 编辑器部分
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btfilename">行为树文件名</param>
        /// <param name="rootnode"></param>
        public BTGraph(string btfilename)
        {
            BTFileName = btfilename;
            AllNodesList = new List<BTNode>();
            AllBoolVariableDataList = new List<CustomBoolVariableData>();
            AllIntVariableDataList = new List<CustomIntVariableData>();
            AllFloatVariableDataList = new List<CustomFloatVariableData>();
            AllStringVariableDataList = new List<CustomStringVariableData>();
            AllBoolVariableNodeDataList = new List<CustomBoolVariableNodeData>();
            AllIntVariableNodeDataList = new List<CustomIntVariableNodeData>();
            AllFloatVariableNodeDataList = new List<CustomFloatVariableNodeData>();
            AllStringVariableNodeDataList = new List<CustomStringVariableNodeData>();
            AllVariableNodeDataMaps = new Dictionary<int, CustomVariableNodeData>();
            ExecutingNodesMap = new Dictionary<int, BTNode>();
            ExecutedReevaluatedNodesResultMap = new Dictionary<BTNode, EBTNodeRunningState>();
            BTBlackBoard = new Blackboard();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="btfilename">行为树文件名</param>
        ///// <param name="rootnode"></param>
        //public BTGraph(string btfilename, BTNode rootnode)
        //{
        //    BTFileName = btfilename;
        //    RootNodeUID = rootnode.UID;
        //    RootNode = rootnode;
        //    AllNodesList = new List<BTNode>();
        //    AllNodesList.Add(rootnode);
        //    AllBoolVariableDataList = new List<CustomBoolVariableData>();
        //    AllIntVariableDataList = new List<CustomIntVariableData>();
        //    AllFloatVariableDataList = new List<CustomFloatVariableData>();
        //    AllStringVariableDataList = new List<CustomStringVariableData>();
        //    ExecutingNodesMap = new Dictionary<int, BTNode>();
        //    ExecutedReevaluatedNodesResultMap = new Dictionary<BTNode, EBTNodeRunningState>();
        //    BTBlackBoard = new Blackboard();
        //}

        /// <summary>
        /// 设置根节点
        /// </summary>
        /// <param name="rootnode"></param>
        public void SetRootNode(BTNode rootnode)
        {
            RootNode = rootnode;
            RootNodeUID = rootnode.UID;
            AllNodesList.Add(rootnode);
        }

        #region 自定义变量部分
        /// <summary>
        /// 指定成员变量名是否可以
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsVariableNameAvalible(string name)
        {
            var findboolvariabledata = AllBoolVariableDataList.Find((variabledata) =>
            {
                return variabledata.VariableName == name;
            });
            if (findboolvariabledata != null)
            {
                return false;
            }
            var finintvariabledata = AllIntVariableDataList.Find((variabledata) =>
            {
                return variabledata.VariableName == name;
            });
            if (finintvariabledata != null)
            {
                return false;
            }
            var findfloatvariabledata = AllFloatVariableDataList.Find((variabledata) =>
            {
                return variabledata.VariableName == name;
            });
            if (findfloatvariabledata != null)
            {
                return false;
            }
            var findstringvariabledata = AllStringVariableDataList.Find((variabledata) =>
            {
                return variabledata.VariableName == name;
            });
            if (findstringvariabledata != null)
            {
                return false;
            }
            // Invalide作为默认无效参数名字特殊存在
            if (string.Equals(name, "Invalide"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取指定变量类型的默认值
        /// Note:
        /// 限非运行时用
        /// </summary>
        /// <param name="variabletype"></param>
        /// <returns></returns>
        public CustomVariableData GetVariableDefaultValueInEditor(string variablename, EVariableType variabletype)
        {
            if (variabletype == EVariableType.Bool)
            {
                return new CustomBoolVariableData(variablename, variabletype, default(bool));
            }
            else if (variabletype == EVariableType.Int)
            {
                return new CustomIntVariableData(variablename, variabletype, default(int));
            }
            else if (variabletype == EVariableType.String)
            {
                return new CustomStringVariableData(variablename, variabletype, default(string));
            }
            else if (variabletype == EVariableType.Float)
            {
                return new CustomFloatVariableData(variablename, variabletype, default(float));
            }
            else
            {
                Debug.LogError($"不支持的变量类型:{variabletype},获取默认值失败!");
                return null;
            }
        }

        /// <summary>
        /// 获取指定变量类型的自定义变量名可选列表
        /// </summary>
        /// <param name="variabletype"></param>
        /// <returns></returns>
        public string[] GetCustomVariableNames(EVariableType variabletype)
        {
            List<CustomVariableData> targetvariabledatalist = new List<CustomVariableData>();
            if (variabletype == EVariableType.Bool)
            {
                targetvariabledatalist.AddRange(AllBoolVariableDataList);
            }
            else if (variabletype == EVariableType.Int)
            {
                targetvariabledatalist.AddRange(AllIntVariableDataList);
            }
            else if (variabletype == EVariableType.Float)
            {
                targetvariabledatalist.AddRange(AllFloatVariableDataList);
            }
            else if (variabletype == EVariableType.String)
            {
                targetvariabledatalist.AddRange(AllStringVariableDataList);
            }
            else
            {
                Debug.LogError($"不支持添加的自定义变量类型:{variabletype},获取选项失败!");
                return null;
            }
            // 默认第一个是空选项
            var allavaliblenames = new string[targetvariabledatalist.Count + 1];
            allavaliblenames[0] = EVariableType.Invalide.ToString();
            for (int i = 0, length = targetvariabledatalist.Count; i < length; i++)
            {
                allavaliblenames[i + 1] = targetvariabledatalist[i].VariableName;
            }
            return allavaliblenames;
        }

        /// <summary>
        /// 获取指定UID节点的自定义变量数据
        /// </summary>
        /// <param name="variabletype"></param>
        /// <returns></returns>
        public CustomVariableNodeData GetSpecificUIDCustomVariableNodeData(int nodeuid)
        {
            CustomVariableNodeData variablenodedata = null;
            variablenodedata = AllBoolVariableNodeDataList.Find((vnode) =>
            {
                return vnode.NodeUID == nodeuid;
            });
            if (variablenodedata != null)
            {
                return variablenodedata;
            }
            variablenodedata = AllIntVariableNodeDataList.Find((vnode) =>
            {
                return vnode.NodeUID == nodeuid;
            });
            if (variablenodedata != null)
            {
                return variablenodedata;
            }
            variablenodedata = AllFloatVariableNodeDataList.Find((vnode) =>
            {
                return vnode.NodeUID == nodeuid;
            });
            if (variablenodedata != null)
            {
                return variablenodedata;
            }
            variablenodedata = AllStringVariableNodeDataList.Find((vnode) =>
            {
                return vnode.NodeUID == nodeuid;
            });
            if (variablenodedata != null)
            {
                return variablenodedata;
            }
            return null;
        }

        /// <summary>
        /// 添加自定义数据
        /// </summary>
        /// <param name="customvariabledata"></param>
        public void AddCustomVariableData(CustomVariableData customvariabledata)
        {
            if (customvariabledata.VariableType == EVariableType.Bool)
            {
                AllBoolVariableDataList.Add(customvariabledata as CustomBoolVariableData);
                Debug.Log($"添加变量名:{customvariabledata.VariableName}Bool类型自定义变量节点数据!");
            }
            else if (customvariabledata.VariableType == EVariableType.Int)
            {
                AllIntVariableDataList.Add(customvariabledata as CustomIntVariableData);
                Debug.Log($"添加变量名:{customvariabledata.VariableName}Int类型自定义变量节点数据!");
            }
            else if (customvariabledata.VariableType == EVariableType.Float)
            {
                AllFloatVariableDataList.Add(customvariabledata as CustomFloatVariableData);
                Debug.Log($"添加变量名:{customvariabledata.VariableName}Float类型自定义变量节点数据!");
            }
            else if (customvariabledata.VariableType == EVariableType.String)
            {
                AllStringVariableDataList.Add(customvariabledata as CustomStringVariableData);
                Debug.Log($"添加变量名:{customvariabledata.VariableName}String类型自定义变量节点数据!");
            }
            else
            {
                Debug.LogError($"不支持添加的自定义变量类型:{customvariabledata.VariableType},添加失败!");
            }
        }

        /// <summary>
        /// 移除指定自定义变量数据
        /// </summary>
        /// <param name="customvariabledata"></param>
        /// <returns></returns>
        public bool RemoveCustomVariableData(CustomVariableData customvariabledata)
        {
            if (customvariabledata.VariableType == EVariableType.Bool)
            {
                Debug.Log($"移除变量名:{customvariabledata.VariableName}Bool类型自定义变量节点数据!");
                return AllBoolVariableDataList.Remove(customvariabledata as CustomBoolVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.Int)
            {
                Debug.Log($"移除变量名:{customvariabledata.VariableName}Bool类型自定义变量节点数据!");
                return AllIntVariableDataList.Remove(customvariabledata as CustomIntVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.Float)
            {
                Debug.Log($"移除变量名:{customvariabledata.VariableName}Bool类型自定义变量节点数据!");
                return AllFloatVariableDataList.Remove(customvariabledata as CustomFloatVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.String)
            {
                Debug.Log($"移除变量名:{customvariabledata.VariableName}Bool类型自定义变量节点数据!");
                return AllStringVariableDataList.Remove(customvariabledata as CustomStringVariableData);
            }
            else
            {
                Debug.LogError($"不支持移除的自定义变量类型:{customvariabledata.VariableType},移除失败!");
                return false;
            }
        }

        /// <summary>
        /// 获取指定节点UID变量类型的节点数据
        /// Note:
        /// 编辑器模式下使用此接口，非运行时使用GetVariableNodeValueInRuntime
        /// </summary>
        /// <returns></returns>
        public CustomVariableNodeData GetVariableNodeValueInEditor(int uid)
        {
            var boolvariablenodedata = AllBoolVariableNodeDataList.Find((variablenodedata) =>
            {
                return variablenodedata.NodeUID == uid;
            });
            if (boolvariablenodedata != null)
            {
                return boolvariablenodedata;
            }
            var intvariablenodedata = AllIntVariableNodeDataList.Find((variablenodedata) =>
            {
                return variablenodedata.NodeUID == uid;
            });
            if (intvariablenodedata != null)
            {
                return intvariablenodedata;
            }
            var stringvariablenodedata = AllStringVariableNodeDataList.Find((variablenodedata) =>
            {
                return variablenodedata.NodeUID == uid;
            });
            if (stringvariablenodedata != null)
            {
                return stringvariablenodedata;
            }
            var floatvariablenodedata = AllFloatVariableNodeDataList.Find((variablenodedata) =>
            {
                return variablenodedata.NodeUID == uid;
            });
            if (floatvariablenodedata != null)
            {
                return floatvariablenodedata;
            }
            return null;
        }

        /// <summary>
        /// 添加自定义节点数据
        /// </summary>
        /// <param name="customvariablenodedata"></param>
        public void AddCustomVariableNodeData(CustomVariableNodeData customvariablenodedata)
        {
            if (customvariablenodedata.VariableType == EVariableType.Bool)
            {
                AllBoolVariableNodeDataList.Add(customvariablenodedata as CustomBoolVariableNodeData);
                Debug.Log($"添加节点UID:{customvariablenodedata.NodeUID} Bool类型自定义变量节点数据!");
            }
            else if (customvariablenodedata.VariableType == EVariableType.Int)
            {
                AllIntVariableNodeDataList.Add(customvariablenodedata as CustomIntVariableNodeData);
                Debug.Log($"添加节点UID:{customvariablenodedata.NodeUID} Int类型自定义变量节点数据!");
            }
            else if (customvariablenodedata.VariableType == EVariableType.Float)
            {
                AllFloatVariableNodeDataList.Add(customvariablenodedata as CustomFloatVariableNodeData);
                Debug.Log($"添加节点UID:{customvariablenodedata.NodeUID} Floatl类型自定义变量节点数据!");
            }
            else if (customvariablenodedata.VariableType == EVariableType.String)
            {
                AllStringVariableNodeDataList.Add(customvariablenodedata as CustomStringVariableNodeData);
                Debug.Log($"添加节点UID:{customvariablenodedata.NodeUID} String类型自定义变量节点数据!");
            }
            else
            {
                Debug.LogError($"不支持添加的自定义变量类型:{customvariablenodedata.VariableType}的节点数据,添加失败!");
            }
        }

        /// <summary>
        /// 移除指定自定义变量节点数据
        /// </summary>
        /// <param name="customvariablenodedata"></param>
        /// <returns></returns>
        public bool RemoveCustomVariableNodeData(CustomVariableNodeData customvariablenodedata)
        {
            if (customvariablenodedata.VariableType == EVariableType.Bool)
            {
                Debug.Log($"移除节点UID:{customvariablenodedata.NodeUID} Bool类型自定义变量节点数据!");
                return AllBoolVariableNodeDataList.Remove(customvariablenodedata as CustomBoolVariableNodeData);
            }
            else if (customvariablenodedata.VariableType == EVariableType.Int)
            {
                Debug.Log($"移除节点UID:{customvariablenodedata.NodeUID} Int类型自定义变量节点数据!");
                return AllIntVariableNodeDataList.Remove(customvariablenodedata as CustomIntVariableNodeData);
            }
            else if (customvariablenodedata.VariableType == EVariableType.Float)
            {
                Debug.Log($"移除节点UID:{customvariablenodedata.NodeUID} Float类型自定义变量节点数据!");
                return AllFloatVariableNodeDataList.Remove(customvariablenodedata as CustomFloatVariableNodeData);
            }
            else if (customvariablenodedata.VariableType == EVariableType.String)
            {
                Debug.Log($"移除节点UID:{customvariablenodedata.NodeUID} String类型自定义变量节点数据!");
                return AllStringVariableNodeDataList.Remove(customvariablenodedata as CustomStringVariableNodeData);
            }
            else
            {
                Debug.LogError($"不支持移除的自定义变量类型:{customvariablenodedata.VariableType}节点数据,移除失败!");
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="needdeleteduidlist">需要删除的UID列表</param>
        /// <returns></returns>
        public bool DeleteNode(BTNode node, List<int> needdeleteduidlist)
        {
            if (node.Equals(RootNode) == false)
            {
                if (AllNodesList.Remove(node))
                {
                    if (node.ChildNodesUIDList.Count > 0)
                    {
                        for (int i = 0, length = node.ChildNodesUIDList.Count; i < length; i++)
                        {
                            var childnode = FindNodeByUID(node.ChildNodesUIDList[i]);
                            needdeleteduidlist.Add(node.ChildNodesUIDList[i]);
                            DeleteNode(childnode, needdeleteduidlist);
                        }
                        node.DeleteAllChildNodes();
                    }
                    // 让节点的父节点删除该子节点并重新排节点顺序
                    var parentnode = FindNodeByUID(node.ParentNodeUID);
                    if (parentnode != null)
                    {
                        parentnode.DeleteChildNode(node.UID, this);
                    }
                    // 清除节点自定义变量相关数据
                    if (node.NodeType == (int)EBTNodeType.ConditionNodeType && BTUtilities.IsCompareToShareVariableCondition(node.NodeName))
                    {
                        var variablenodedata = GetVariableNodeValueInEditor(node.UID);
                        RemoveCustomVariableNodeData(variablenodedata);
                    }
                    else if (node.NodeType == (int)EBTNodeType.ActionNodeType && BTUtilities.IsSetShareVariableAction(node.NodeName))
                    {
                        var variablenodedata = GetVariableNodeValueInEditor(node.UID);
                        RemoveCustomVariableNodeData(variablenodedata);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Debug.Log($"不允许删除根节点!");
                return false;
            }
        }

        /// <summary>
        /// 根据鼠标位置获取对应操作的行为节点
        /// </summary>
        /// <param name="btgraph"></param>
        /// <param name="mpos"></param>
        /// <returns></returns>
        public BTNode FindNodeByMousePos(Vector3 mpos)
        {
            var findnode = AllNodesList.Find((btnode) =>
            {
                return btnode.NodeDisplayRect.Contains(mpos);
            });
            return findnode;
        }

        /// <summary>
        /// 向前移动指定子节点
        /// </summary>
        /// <param name="childnode"></param>
        /// <returns></returns>
        public bool MoveChildNodeForward(BTNode childnode)
        {
            var parentnode = childnode.GetParentNode();
            var childnodeindex = childnode.NodeIndex;
            if (childnodeindex > 0)
            {
                var forwardchild = FindNodeByUID(parentnode.ChildNodesUIDList[childnodeindex - 1]);
                var moveoffset = Vector2.zero;
                moveoffset.x = forwardchild.NodeDisplayRect.x - childnode.NodeDisplayRect.x;
                moveoffset.y = forwardchild.NodeDisplayRect.y - childnode.NodeDisplayRect.y;
                // 移动当前两个节点及其所有子节点
                childnode.Move(this, moveoffset, true);
                forwardchild.Move(this, -moveoffset, true);
                // 更新排序
                parentnode?.SortAndUpdateChildeNode();
                return true;
            }
            else
            {
                Debug.LogWarning($"节点名:{parentnode.NodeName}的UID:{childnode.UID}子节点已经是第一个子节点,无法再向前移动!");
                return false;
            }
        }

        /// <summary>
        /// 向后移动指定子节点
        /// </summary>
        /// <param name="childnode"></param>
        /// <returns></returns>
        public bool MoveChildNodeBackward(BTNode childnode)
        {
            var parentnode = childnode.GetParentNode();
            var childnodeindex = childnode.NodeIndex;
            if (childnodeindex < parentnode.ChildNodesUIDList.Count - 1)
            {
                var backwardchild = FindNodeByUID(parentnode.ChildNodesUIDList[childnodeindex + 1]);
                var moveoffset = Vector2.zero;
                moveoffset.x = backwardchild.NodeDisplayRect.x - childnode.NodeDisplayRect.x;
                moveoffset.y = backwardchild.NodeDisplayRect.y - childnode.NodeDisplayRect.y;
                // 移动当前两个节点及其所有子节点
                childnode.Move(this, moveoffset, true);
                backwardchild.Move(this, -moveoffset, true);
                // 更新排序
                parentnode?.SortAndUpdateChildeNode();
                return true;
            }
            else
            {
                Debug.LogWarning($"节点名:{parentnode.NodeName}的UID:{childnode}子节点已经是最后一个子节点,无法再向后移动!");
                return false;
            }
        }

        /// <summary>
        /// 节点是否在运行
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool IsNodeRunning(int uid)
        {
            return ExecutingNodesMap.ContainsKey(uid);
        }

        /// <summary>
        /// 是否是有效的行为树图
        /// </summary>
        /// <returns></returns>
        public bool IsValideGraph()
        {
            foreach (var btnode in AllNodesList)
            {
                if (btnode.IsValideNode() == false)
                {
                    return false;
                }
            }
            if (CheckVariableNodeDataValidation())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查自定义变量节点的有效性
        /// </summary>
        /// <returns></returns>
        private bool CheckVariableNodeDataValidation()
        {
            // 检查节点名有效性
            // 刚创建没进入参数面板，默认变量名为空
            var invalidestring = EVariableType.Invalide.ToString();
            CustomVariableNodeData variablenodedata = null;
            CustomVariableData variabledata = null;
            variablenodedata = AllBoolVariableNodeDataList.Find((vnodedata) =>
            {
                return vnodedata.VariableName.Equals(invalidestring) || vnodedata.VariableName.Equals(string.Empty);
            });
            if (variablenodedata != null)
            {
                Debug.LogError($"节点UID:{variablenodedata.NodeUID}自定义变量未设置有效变量名:{variablenodedata.VariableName}!");
                return false;
            }
            else
            {
                foreach (var boolvariablendoedata in AllBoolVariableNodeDataList)
                {
                    variabledata = AllBoolVariableDataList.Find((vnode) =>
                    {
                        return vnode.VariableName.Equals(boolvariablendoedata.VariableName);
                    });
                    if (variabledata == null)
                    {
                        Debug.LogError($"节点UID:{boolvariablendoedata.NodeUID}自定义变量:{boolvariablendoedata.VariableName}已经不存在了!");
                        return false;
                    }
                }
            }
            variablenodedata = AllIntVariableNodeDataList.Find((vnodedata) =>
            {
                return vnodedata.VariableName.Equals(invalidestring) || vnodedata.VariableName.Equals(string.Empty);
            });
            if (variablenodedata != null)
            {
                Debug.LogError($"节点UID:{variablenodedata.NodeUID}自定义变量未设置有效变量名:{variablenodedata.VariableName}!");
                return false;
            }
            else
            {
                foreach (var intvariablendoedata in AllIntVariableNodeDataList)
                {
                    variabledata = AllIntVariableDataList.Find((vnode) =>
                    {
                        return vnode.VariableName.Equals(intvariablendoedata.VariableName);
                    });
                    if (variabledata == null)
                    {
                        Debug.LogError($"节点UID:{intvariablendoedata.NodeUID}自定义变量:{intvariablendoedata.VariableName}已经不存在了!");
                        return false;
                    }
                }
            }
            variablenodedata = AllFloatVariableNodeDataList.Find((vnodedata) =>
            {
                return vnodedata.VariableName.Equals(invalidestring) || vnodedata.VariableName.Equals(string.Empty);
            });
            if (variablenodedata != null)
            {
                Debug.LogError($"节点UID:{variablenodedata.NodeUID}自定义变量未设置有效变量名:{variablenodedata.VariableName}!");
                return false;
            }
            else
            {
                foreach (var floatvariablendoedata in AllFloatVariableNodeDataList)
                {
                    variabledata = AllFloatVariableDataList.Find((vnode) =>
                    {
                        return vnode.VariableName.Equals(floatvariablendoedata.VariableName);
                    });
                    if (variabledata == null)
                    {
                        Debug.LogError($"节点UID:{floatvariablendoedata.NodeUID}自定义变量:{floatvariablendoedata.VariableName}已经不存在了!");
                        return false;
                    }
                }
            }
            variablenodedata = AllStringVariableNodeDataList.Find((vnodedata) =>
            {
                return vnodedata.VariableName.Equals(invalidestring) || vnodedata.VariableName.Equals(string.Empty);
            });
            if (variablenodedata != null)
            {
                Debug.LogError($"节点UID:{variablenodedata.NodeUID}自定义变量未设置有效变量名:{variablenodedata.VariableName}!");
                return false;
            }
            else
            {
                foreach (var stringvariablendoedata in AllStringVariableNodeDataList)
                {
                    variabledata = AllStringVariableDataList.Find((vnode) =>
                    {
                        return vnode.VariableName.Equals(stringvariablendoedata.VariableName);
                    });
                    if (variabledata == null)
                    {
                        Debug.LogError($"节点UID:{stringvariablendoedata.NodeUID}自定义变量:{stringvariablendoedata.VariableName}已经不存在了!");
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 运行时部分
        /// <summary>
        /// 行为树节点所属行为树
        /// </summary>
        public TBehaviourTree OwnerBT
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据共享黑板
        /// </summary>
        public Blackboard BTBlackBoard
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btgraph">行为树数据</param>
        /// <param name="btowner"></param>
        public BTGraph()
        {
            //Debug.Log("BTGraph()");
            AllNodesList = new List<BTNode>();
            AllBoolVariableDataList = new List<CustomBoolVariableData>();
            AllIntVariableDataList = new List<CustomIntVariableData>();
            AllFloatVariableDataList = new List<CustomFloatVariableData>();
            AllStringVariableDataList = new List<CustomStringVariableData>();
            AllBoolVariableNodeDataList = new List<CustomBoolVariableNodeData>();
            AllIntVariableNodeDataList = new List<CustomIntVariableNodeData>();
            AllFloatVariableNodeDataList = new List<CustomFloatVariableNodeData>();
            AllStringVariableNodeDataList = new List<CustomStringVariableNodeData>();
            AllVariableNodeDataMaps = new Dictionary<int, CustomVariableNodeData>();
            ExecutingNodesMap = new Dictionary<int, BTNode>();
            ExecutedReevaluatedNodesResultMap = new Dictionary<BTNode, EBTNodeRunningState>();
            BTBlackBoard = new Blackboard();
        }

        /// <summary>
        /// 初始化(反序列化构建后必须调用确保RootNode指向正确对象)
        /// </summary>
        public void Init()
        {
            RootNode = FindNodeByUID(RootNodeUID);
            // 确保反序列化后OwnerGraph指向正确对象
            foreach (var node in AllNodesList)
            {
                node.OwnerBTGraph = this;
            }
        }

        /// <summary>
        /// 设置行为树拥有者
        /// </summary>
        /// <param name="btowner"></param>
        public void SetBTOwner(TBehaviourTree btowner)
        {
            Debug.Assert(OwnerBT == null, "不允许重置所属行为树对象!");
            // 通过编辑器构建的行为树图数据构建一颗运行时的行为树图数据
            BTFileName = btowner.BTOriginalGraph.BTFileName;
            AllBoolVariableDataList = btowner.BTOriginalGraph.AllBoolVariableDataList;
            AllIntVariableDataList = btowner.BTOriginalGraph.AllIntVariableDataList;
            AllFloatVariableDataList = btowner.BTOriginalGraph.AllFloatVariableDataList;
            AllStringVariableDataList = btowner.BTOriginalGraph.AllStringVariableDataList;
            AllBoolVariableNodeDataList = btowner.BTOriginalGraph.AllBoolVariableNodeDataList;
            AllIntVariableNodeDataList = btowner.BTOriginalGraph.AllIntVariableNodeDataList;
            AllFloatVariableNodeDataList = btowner.BTOriginalGraph.AllFloatVariableNodeDataList;
            AllStringVariableNodeDataList = btowner.BTOriginalGraph.AllStringVariableNodeDataList;
            OwnerBT = btowner;
            InitBlackBoard();
            InitCustomVariableNodeData();
            RootNodeUID = btowner.BTOriginalGraph.RootNodeUID;
            RootNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.RootNode, btowner, null, btowner.InstanceID);
        }

        /// <summary>
        /// 初始化黑板数据
        /// </summary>
        private void InitBlackBoard()
        {
            foreach (var boolvariabledata in AllBoolVariableDataList)
            {
                BTBlackBoard.AddData(boolvariabledata.VariableName, new BlackboardData<bool>(boolvariabledata.VariableValue));
            }
            foreach (var intvariabledata in AllIntVariableDataList)
            {
                BTBlackBoard.AddData(intvariabledata.VariableName, new BlackboardData<int>(intvariabledata.VariableValue));
            }
            foreach (var floatvariabledata in AllFloatVariableDataList)
            {
                BTBlackBoard.AddData(floatvariabledata.VariableName, new BlackboardData<float>(floatvariabledata.VariableValue));
            }
            foreach (var stringvariabledata in AllStringVariableDataList)
            {
                BTBlackBoard.AddData(stringvariabledata.VariableName, new BlackboardData<string>(stringvariabledata.VariableValue));
            }
            BTBlackBoard.PrintAllBlackBoardDatas();
        }

        /// <summary>
        /// 初始化自定义变量节点数据Map
        /// </summary>
        private void InitCustomVariableNodeData()
        {
            foreach (var boolvariablenodedata in AllBoolVariableNodeDataList)
            {
                Debug.Log($"节点UID:{boolvariablenodedata.NodeUID}自定义变量值:{(boolvariablenodedata as CustomBoolVariableNodeData).VariableValue}");
                AllVariableNodeDataMaps.Add(boolvariablenodedata.NodeUID, boolvariablenodedata);
            }
            foreach (var intvariablenodedata in AllIntVariableNodeDataList)
            {
                Debug.Log($"节点UID:{intvariablenodedata.NodeUID}自定义变量值:{(intvariablenodedata as CustomIntVariableNodeData).VariableValue}");
                AllVariableNodeDataMaps.Add(intvariablenodedata.NodeUID, intvariablenodedata);
            }
            foreach (var floatvariablenodedata in AllFloatVariableNodeDataList)
            {
                Debug.Log($"节点UID:{floatvariablenodedata.NodeUID}自定义变量值:{(floatvariablenodedata as CustomFloatVariableNodeData).VariableValue}");
                AllVariableNodeDataMaps.Add(floatvariablenodedata.NodeUID, floatvariablenodedata);
            }
            foreach (var stringvariablenodedata in AllStringVariableNodeDataList)
            {
                Debug.Log($"节点UID:{stringvariablenodedata.NodeUID}自定义变量值:{(stringvariablenodedata as CustomStringVariableNodeData).VariableValue}");
                AllVariableNodeDataMaps.Add(stringvariablenodedata.NodeUID, stringvariablenodedata);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            //只有运行时构建的BTGraph需要节点入池以及清理运行时相关数据
            if (OwnerBT != null)
            {
                // 退出时强制终止运行，避免各种运行节点逻辑异常
                DoAbortBehaviourTree();
                OwnerBT = null;
                for (int i = 0, length = AllNodesList != null ? AllNodesList.Count : 0; i < length; i++)
                {
                    AllNodesList[i].Dispose();
                    ObjectPool.Singleton.PushAsObj(AllNodesList[i]);
                }
            }
            AllNodesList = null;
            RootNode = null;
            RootNodeUID = 0;
            AllBoolVariableDataList = null;
            AllIntVariableDataList = null;
            AllFloatVariableDataList = null;
            AllStringVariableDataList = null;
            AllBoolVariableNodeDataList = null;
            AllIntVariableNodeDataList = null;
            AllFloatVariableNodeDataList = null;
            AllStringVariableNodeDataList = null;
            AllVariableNodeDataMaps = null;
        }

        /// <summary>
        /// 添加执行节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool AddExecutingNode(BTNode node)
        {
            if (node != null)
            {
                if (!ExecutingNodesMap.ContainsKey(node.UID))
                {
                    //Debug.Log($"添加UID:{node.UID}的执行节点!");
                    ExecutingNodesMap.Add(node.UID, node);
                    return true;
                }
                else
                {
                    //Debug.LogError($"重复添加UID:{node.UID}的执行节点!");
                    return false;
                }
            }
            else
            {
                Debug.LogError("不允许添加空的执行节点!");
                return false;
            }
        }

        /// <summary>
        /// 清除所有执行节点
        /// </summary>
        /// <returns></returns>
        public void ClearAllExecutingNodes()
        {
            //Debug.Log("清除所有执行节点!");
            if (ExecutingNodesMap.Count > 0)
            {
                // 清理已执行节点前重置他们的状态，确保下一次运行状态回到初始状态
                foreach (var executingnode in ExecutingNodesMap)
                {
                    executingnode.Value.Reset();
                }
                ExecutingNodesMap.Clear();
            }
        }

        /// <summary>
        /// 更新已执行的条件节点执行
        /// </summary>
        /// <param name="node"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool UpdateExecutedConditionNodeResult(BTNode node, EBTNodeRunningState result)
        {
            if (node != null)
            {
                if (!ExecutedReevaluatedNodesResultMap.ContainsKey(node))
                {
                    //Debug.Log($"添加UID:{node.UID}的已执行条件节点执行结果{result}!");
                    ExecutedReevaluatedNodesResultMap.Add(node, result);
                    return true;
                }
                else
                {
                    //Debug.Log($"更新UID:{node.UID}的已执行条件节点执行结果:{result}!");
                    return true;
                }
            }
            else
            {
                Debug.LogError("不允许更新空的已执行条件节点结果!");
                return false;
            }
        }

        /// <summary>
        /// 清除所有需要重新评估的节点
        /// </summary>
        protected void ClearAllExectedReevaluatedNodes()
        {
            Debug.Log($"清除所有需要重新评估的节点!");
            if (ExecutedReevaluatedNodesResultMap.Count > 0)
            {
                ExecutedReevaluatedNodesResultMap.Clear();
            }
        }

        /// <summary>
        /// 检查需要评估的节点状态变化
        /// </summary>
        /// <returns>评估的条件节点是否有变化</returns>
        protected bool ReevaluatedExecutedNodes()
        {
            if (ExecutedReevaluatedNodesResultMap.Count > 0)
            {
                var allkeys = ExecutedReevaluatedNodesResultMap.Keys;
                foreach (var conditionnode in allkeys)
                {
                    var newresult = conditionnode.OnUpdate();
                    if (newresult != ExecutedReevaluatedNodesResultMap[conditionnode])
                    {
                        Debug.Log($"节点UID:{conditionnode.UID}的条件节点状态由:{ExecutedReevaluatedNodesResultMap[conditionnode]}变到{newresult},需要打断行为树重置整棵树运行!");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void OnUpdate()
        {
            if (RootNode != null)
            {
                if (!RootNode.IsTerminated)
                {
                    if (!RootNode.IsRunning)
                    {
                        ClearRunningDatas();
                    }
                    if (ReevaluatedExecutedNodes())
                    {
                        // 重新判定节点运行结果有变化需要重置运行节点重新判定
                        DoAbortBehaviourTree();
                    }
                    RootNode.OnUpdate();
                }
                else
                {
                    ClearRunningDatas();
                    if (ReevaluatedExecutedNodes())
                    {
                        // 重新判定节点运行结果有变化需要重置运行节点重新判定
                        DoAbortBehaviourTree();
                    }
                    if (OwnerBT.RestartWhenComplete)
                    {
                        RootNode.OnUpdate();
                    }
                }
            }
        }

        /// <summary>
        /// 响应暂停
        /// </summary>
        /// <param name="ispause"></param>
        public void OnPause(bool ispause)
        {
            foreach (var btnode in ExecutingNodesMap)
            {
                btnode.Value.OnPause(ispause);
            }
        }

        /// <summary>
        /// 执行终止行为树
        /// </summary>
        public void DoAbortBehaviourTree()
        {
            Debug.Log("DoAbortBehaviourTree()");
            foreach (var executingnode in ExecutingNodesMap)
            {
                // 只有执行中的节点需要打断(避免执行完成的节点二次打断)
                if (executingnode.Value.IsRunning)
                {
                    executingnode.Value.OnConditionalAbort();
                }
            }
            ClearRunningDatas();
        }

        /// <summary>
        /// 清理运行数据
        /// </summary>
        protected void ClearRunningDatas()
        {
            ClearAllExecutingNodes();
            ClearAllExectedReevaluatedNodes();
        }

        /// <summary>
        /// 获取指定自定义变量值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variablename"></param>
        /// <returns></returns>
        public T GetData<T>(string variablename)
        {
            return BTBlackBoard.GetData<T>(variablename);
        }

        /// <summary>
        /// 更新指定自定义变量值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variablename"></param>
        /// <param name="newvalue"></param>
        /// <returns></returns>
        public bool UpdateData<T>(string variablename, T newvalue)
        {
            return BTBlackBoard.UpdateData<T>(variablename, newvalue);
        }

        /// <summary>
        /// 获取指定节点UID变量类型的数据
        /// Note:
        /// 运行时模式下使用此接口，非运行时使用GetVariableNodeValueInEditor
        /// </summary>
        /// <returns></returns>
        public CustomVariableNodeData GetVariableNodeValueInRuntime(int uid)
        {
            if (AllVariableNodeDataMaps.ContainsKey(uid))
            {
                return AllVariableNodeDataMaps[uid];
            }
            else
            {
                Debug.LogError($"找不到的UID:{uid}自定义变量节点数据,获取节点数据失败!");
                return null;
            }
        }
        #endregion

        #region 通用部分
        /// <summary>
        /// 根据uid找到对应的行为树节点
        /// </summary>
        /// <param name="btgraph"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public BTNode FindNodeByUID(int uid)
        {
            var findnode = AllNodesList.Find((btnode) =>
            {
                return btnode.UID == uid;
            });
            return findnode;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool AddNode(BTNode node)
        {
            if (node != null && AllNodesList.Contains(node) == false)
            {
                AllNodesList.Add(node);
                return true;
            }
            else
            {
                Debug.Log($"不允许添加空或UID:{node.UID}的重复节点!");
                return false;
            }
        }
        #endregion
    }
}