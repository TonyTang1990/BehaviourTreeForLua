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
        
        /// <summary>
        /// 所有变量定义Map
        /// </summary>
        public Dictionary<string, EVariableType> AllVariableDefinitionMap;

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
        public BTGraph(string btfilename, BTNode rootnode)
        {
            BTFileName = btfilename;
            RootNodeUID = rootnode.UID;
            RootNode = rootnode;
            AllNodesList = new List<BTNode>();
            AllNodesList.Add(rootnode);
            ExecutingNodesMap = new Dictionary<int, BTNode>();
            ExecutedReevaluatedNodesResultMap = new Dictionary<BTNode, EBTNodeRunningState>();
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
            ExecutingNodesMap = new Dictionary<int, BTNode>();
            ExecutedReevaluatedNodesResultMap = new Dictionary<BTNode, EBTNodeRunningState>();
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
            OwnerBT = btowner;
            RootNode = BTUtilities.CreateRunningNodeByNode(btowner.BTOriginalGraph.RootNode, btowner, null, btowner.InstanceID);
            RootNodeUID = btowner.BTOriginalGraph.RootNodeUID;
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