/*
 * Description:             BTGraph.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Lua行为树设计:
/// 组合节点和装饰节点在CS测
/// 行为节点和条件节点通过统一CS节点映射到Lua测实现自定义Lua条件和行为节点

namespace LuaBehaviourTree
{
    /// <summary>
    /// 变量类型枚举
    /// </summary>
    public enum EVariableType
    {
        Bool = 1,           // bool类型
        String,             // string类型
        Float,              // float类型
        Int,                // int类型
    }

    /// <summary>
    /// 自定义变量数据基类
    /// </summary>
    [Serializable]
    public class CustomVariableData
    {
        /// <summary>
        /// 变量名字
        /// </summary>
        public string VariableName;

        /// <summary>
        /// 变量类型
        /// </summary>
        public EVariableType VariableType;

        public CustomVariableData(string variablename, EVariableType variabletype)
        {
            VariableName = variablename;
            VariableType = variabletype;
        }
    }

    /// <summary>
    /// 自定义Bool变量数据
    /// </summary>
    [Serializable]
    public class CustomBoolVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public bool VariableValue;

        public CustomBoolVariableData(string variablename, EVariableType variabletype, bool variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }


    /// <summary>
    /// 自定义Int变量数据
    /// </summary>
    [Serializable]
    public class CustomIntVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public int VariableValue;

        public CustomIntVariableData(string variablename, EVariableType variabletype, int variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义float变量数据
    /// </summary>
    [Serializable]
    public class CustomFloatVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public float VariableValue;

        public CustomFloatVariableData(string variablename, EVariableType variabletype, float variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义string变量数据
    /// </summary>
    [Serializable]
    public class CustomStringVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public string VariableValue;

        public CustomStringVariableData(string variablename, EVariableType variabletype, string variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

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
            if(findboolvariabledata != null)
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
            return true;
        }

        /// <summary>
        /// 获取指定变量类型的默认值
        /// </summary>
        /// <param name="variabletype"></param>
        /// <returns></returns>
        public CustomVariableData GetVariableDefaultValue(string variablename, EVariableType variabletype)
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
        /// 添加自定义数据
        /// </summary>
        /// <param name="customvariabledata"></param>
        public void AddCustomVariableData(CustomVariableData customvariabledata)
        {
            if (customvariabledata.VariableType == EVariableType.Bool)
            {
                AllBoolVariableDataList.Add(customvariabledata as CustomBoolVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.Int)
            {
                AllIntVariableDataList.Add(customvariabledata as CustomIntVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.Float)
            {
                AllFloatVariableDataList.Add(customvariabledata as CustomFloatVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.String)
            {
                AllStringVariableDataList.Add(customvariabledata as CustomStringVariableData);
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
                return AllBoolVariableDataList.Remove(customvariabledata as CustomBoolVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.Int)
            {
                return AllIntVariableDataList.Remove(customvariabledata as CustomIntVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.Float)
            {
                return AllFloatVariableDataList.Remove(customvariabledata as CustomFloatVariableData);
            }
            else if (customvariabledata.VariableType == EVariableType.String)
            {
                return AllStringVariableDataList.Remove(customvariabledata as CustomStringVariableData);
            }
            else
            {
                Debug.LogError($"不支持添加的自定义变量类型:{customvariabledata.VariableType},移除失败!");
                return false;
            }
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
            Debug.Log("BTGraph()");
            AllNodesList = new List<BTNode>();
            AllBoolVariableDataList = new List<CustomBoolVariableData>();
            AllIntVariableDataList = new List<CustomIntVariableData>();
            AllFloatVariableDataList = new List<CustomFloatVariableData>();
            AllStringVariableDataList = new List<CustomStringVariableData>();
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
        }

        /// <summary>
        /// 设置行为树拥有者
        /// </summary>
        /// <param name="btowner"></param>
        public void SetBTOwner(TBehaviourTree btowner)
        {
            Dispose();
            // 通过编辑器构建的行为树图数据构建一颗运行时的行为树图数据
            BTFileName = btowner.BTOriginalGraph.BTFileName;
            AllNodesList = new List<BTNode>();
            AllBoolVariableDataList = btowner.BTOriginalGraph.AllBoolVariableDataList;
            AllIntVariableDataList = btowner.BTOriginalGraph.AllIntVariableDataList;
            AllFloatVariableDataList = btowner.BTOriginalGraph.AllFloatVariableDataList;
            AllStringVariableDataList = btowner.BTOriginalGraph.AllStringVariableDataList;
            OwnerBT = btowner;
            BTBlackBoard = new Blackboard();
            RootNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.RootNode, btowner, null, btowner.InstanceID);
            RootNodeUID = btowner.BTOriginalGraph.RootNodeUID;
            InitBlackBoard();
        }

        /// <summary>
        /// 初始化黑板数据
        /// </summary>
        private void InitBlackBoard()
        {
            foreach(var boolvariabledata in AllBoolVariableDataList)
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
        /// 释放
        /// </summary>
        public void Dispose()
        {
            //只有运行时构建的BTGraph需要节点入池以及清理运行时相关数据
            if (OwnerBT != null)
            {
                ClearRunningDatas();
                OwnerBT = null;
                for (int i = 0, length = AllNodesList != null ? AllNodesList.Count : 0; i < length; i++)
                {
                    AllNodesList[i].Dispose();
                    //ObjectPool.Singleton.PushAsObj(AllNodesList[i]);
                }
            }
            AllNodesList.Clear();
            RootNode = null;
            RootNodeUID = 0;
        }

        /// <summary>
        /// 添加执行节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool AddExecutingNode(BTNode node)
        {
            if(node != null)
            {
                if (!ExecutingNodesMap.ContainsKey(node.UID))
                {
                    Debug.Log($"添加UID:{node.UID}的执行节点!");
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
            if(ExecutingNodesMap.Count > 0)
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
                    Debug.Log($"添加UID:{node.UID}的已执行条件节点执行结果{result}!");
                    ExecutedReevaluatedNodesResultMap.Add(node, result);
                    return true;
                }
                else
                {
                    Debug.Log($"更新UID:{node.UID}的已执行条件节点执行结果:{result}!");
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
            if(ExecutedReevaluatedNodesResultMap.Count > 0)
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
                    if(!RootNode.IsRunning)
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
                if(executingnode.Value.IsRunning)
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

        #region 编辑器部分
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
        /// <param name="parentnodeuid"></param>
        /// <param name="childnodeuid"></param>
        /// <returns></returns>
        public bool MoveChildNodeForward(int parentnodeuid, int childnodeuid)
        {
            var parentnode = FindNodeByUID(parentnodeuid);
            var childnode = FindNodeByUID(childnodeuid);
            var childnodeindex = parentnode.ChildNodesUIDList.FindIndex((nodeuid) =>
            {
                return nodeuid == childnodeuid;
            });
            if (childnodeindex != -1)
            {
                if (childnodeindex > 0)
                {
                    var forwardchild = FindNodeByUID(parentnode.ChildNodesUIDList[childnodeindex - 1]);
                    parentnode.ChildNodesUIDList[childnodeindex - 1] = childnodeuid;
                    childnode.NodeIndex = childnodeindex - 1;
                    parentnode.ChildNodesUIDList[childnodeindex] = forwardchild.UID;
                    forwardchild.NodeIndex = childnodeindex;
                    var moveoffset = Vector2.zero;
                    moveoffset.x = forwardchild.NodeDisplayRect.x - childnode.NodeDisplayRect.x;
                    moveoffset.y = forwardchild.NodeDisplayRect.y - childnode.NodeDisplayRect.y;
                    // 移动当前两个节点及其所有子节点
                    childnode.Move(this, moveoffset, true);
                    forwardchild.Move(this, -moveoffset, true);
                    return true;
                }
                else
                {
                    Debug.LogWarning($"节点名:{parentnode.NodeName}的UID:{childnodeuid}子节点已经是第一个子节点,无法再向前移动!");
                    return false;
                }
            }
            else
            {
                Debug.LogError($"节点名:{parentnode.NodeName}找不到UID:{childnodeuid}的子节点,向前移动失败!");
                return false;
            }
        }

        /// <summary>
        /// 向后移动指定子节点
        /// </summary>
        /// <param name="parentnodeuid"></param>
        /// <param name="childnodeuid"></param>
        /// <returns></returns>
        public bool MoveChildNodeBackward(int parentnodeuid, int childnodeuid)
        {
            var parentnode = FindNodeByUID(parentnodeuid);
            var childnode = FindNodeByUID(childnodeuid);
            var childnodeindex = parentnode.ChildNodesUIDList.FindIndex((nodeuid) =>
            {
                return nodeuid == childnodeuid;
            });
            if (childnodeindex != -1)
            {
                if (childnodeindex < parentnode.ChildNodesUIDList.Count - 1)
                {
                    var backwardchild = FindNodeByUID(parentnode.ChildNodesUIDList[childnodeindex + 1]);
                    parentnode.ChildNodesUIDList[childnodeindex + 1] = childnodeuid;
                    childnode.NodeIndex = childnodeindex + 1;
                    parentnode.ChildNodesUIDList[childnodeindex] = backwardchild.UID;
                    backwardchild.NodeIndex = childnodeindex;
                    var moveoffset = Vector2.zero;
                    moveoffset.x = backwardchild.NodeDisplayRect.x - childnode.NodeDisplayRect.x;
                    moveoffset.y = backwardchild.NodeDisplayRect.y - childnode.NodeDisplayRect.y;
                    // 移动当前两个节点及其所有子节点
                    childnode.Move(this, moveoffset, true);
                    backwardchild.Move(this, -moveoffset, true);
                    return true;
                }
                else
                {
                    Debug.LogWarning($"节点名:{parentnode.NodeName}的UID:{childnodeuid}子节点已经是最后一个子节点,无法再向后移动!");
                    return false;
                }
            }
            else
            {
                Debug.LogError($"节点名:{parentnode.NodeName}找不到UID:{childnodeuid}的子节点,向前移动失败!");
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
        #endregion
    }
}