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
        /// 行为树根节点数据
        /// </summary>
        public BTNode RootNode;

        /// <summary>
        /// 所有的节点数据
        /// </summary>
        public List<BTNode> AllNodesList;

        /// <summary>
        /// 执行中的节点Map(Key为节点UID，Value为节点Node对象)
        /// </summary>
        public Dictionary<int, BTNode> ExecutingNodesMap
        {
            get;
            protected set;
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
            RootNode = rootnode;
            AllNodesList = new List<BTNode>();
            AllNodesList.Add(RootNode);
            ExecutingNodesMap = new Dictionary<int, BTNode>();
        }
        #endregion

        #region 运行时部分
        /// <summary>
        /// 行为树节点所属行为树
        /// </summary>
        public TBehaviourTree OwnerBT
        {
            get;
            protected set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btgraph">行为树数据</param>
        /// <param name="btowner"></param>
        public BTGraph()
        {
            Debug.Log("BTGraph()");
            ExecutingNodesMap = new Dictionary<int, BTNode>();
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
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            OwnerBT = null;
            for(int i = 0, length = AllNodesList != null ? AllNodesList.Count : 0; i < length; i++)
            {
                AllNodesList[i].Dispose();
            }
            AllNodesList = null;
            RootNode = null;
#if UNITY_EDITOR
            ClearAllExecutingNodes();
#endif
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
            ExecutingNodesMap.Clear();
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
#if UNITY_EDITOR
                    if(!RootNode.IsRunning)
                    {
                        ClearAllExecutingNodes();
                    }
#endif
                    RootNode.OnUpdate();
                }
                else
                {
#if UNITY_EDITOR
                    ClearAllExecutingNodes();
#endif
                    if (OwnerBT.RestartWhenComplete)
                    {
                        RootNode.OnUpdate();
                    }
                }
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

        #region 编辑器部分
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool DeleteNode(BTNode node)
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
                            DeleteNode(childnode);
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