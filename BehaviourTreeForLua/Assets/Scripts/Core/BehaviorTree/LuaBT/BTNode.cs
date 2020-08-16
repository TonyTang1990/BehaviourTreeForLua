/*
 * Description:             BTNode.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/12
 */

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 行为树节点类型
/// </summary>
public enum EBTNodeType
{
    EntryNodeType = 1,              // 入口节点类型(根节点才为此类型)
    ActionNodeType,                 // 行为节点类型
    CompositeNodeType,              // 组合节点类型
    ConditionNodeType,              // 条件节点类型
    DecorationNodeType,             // 装饰节点类型
}

/// <summary>
/// 行为树节点抽象
/// </summary>
[Serializable]
public class BTNode
{
    /// <summary>
    /// 节点UID
    /// </summary>
    public int UID;

    /// <summary>
    /// 节点显示框数据
    /// </summary>
    public Rect NodeDisplayRect;

    /// <summary>
    /// 节点索引
    /// </summary>
    public int NodeIndex;

    /// <summary>
    /// 节点名字
    /// </summary>
    public string NodeName;

    /// <summary>
    /// 节点参数(设计成编辑器只负责序列化参数数据，解析由运行时Lua对象节点自行解析)
    /// </summary>
    public string NodeParams;

    /// <summary>
    /// 节点类型
    /// </summary>
    public int NodeType;

    /// <summary>
    /// 父节点UID
    /// </summary>
    public int ParentNodeUID;

    /// <summary>
    /// 子节点UID列表
    /// </summary>
    public List<int> ChildNodesUIDList;

    private BTNode()
    {
    }

    public BTNode(Rect noderect, int nodeindex, string nodename, EBTNodeType nodetype, BTNode parentnode = null)
    {
        UID = GetHashCode();
        NodeDisplayRect = noderect;
        NodeIndex = nodeindex;
        NodeName = nodename;
        NodeType = (int)nodetype;
        ParentNodeUID = parentnode != null ? parentnode.UID : 0;
        ChildNodesUIDList = new List<int>();
    }

    /// <summary>
    /// 添加子节点
    /// </summary>
    /// <param name="childnodeuid"></param>
    /// <param name="insertindex">默认不传往尾部插入</param>
    public bool AddChildNode(int childnodeuid, int? insertindex = null)
    {
        if(insertindex == null)
        {
            insertindex = ChildNodesUIDList.Count;
        }
        if (ChildNodesUIDList.Contains(childnodeuid) == false)
        {
            ChildNodesUIDList.Insert((int)insertindex, childnodeuid);
            return true;
        }
        else
        {
            Debug.LogError($"节点名:{NodeName}不允许添加重复UID:{childnodeuid}!");
            return false;
        }
    }

    /// <summary>
    /// 删除子节点
    /// </summary>
    /// <param name="childnodeuid"></param>
    /// <param name="insertindex">默认不传往尾部插入</param>
    public bool DeleteChildNode(int childnodeuid)
    {
        return ChildNodesUIDList.Remove(childnodeuid);
    }

    /// <summary>
    /// 删除所有子节点
    /// </summary>
    public void DeleteAllChildNodes()
    {
        ChildNodesUIDList.Clear();
    }

    /// <summary>
    /// 是否是根节点
    /// </summary>
    /// <returns></returns>
    public bool IsRootNode()
    {
        return ParentNodeUID == 0;
    }

    /// <summary>
    /// 是否是叶子节点
    /// </summary>
    /// <returns></returns>
    public bool IsLeafNode()
    {
        return ChildNodesUIDList.Count == 0;
    }

    /// <summary>
    /// 是否是行为节点
    /// </summary>
    /// <returns></returns>
    public bool IsActionNode()
    {
        return NodeType == (int)EBTNodeType.ActionNodeType;
    }

    /// <summary>
    /// 是否是条件节点
    /// </summary>
    /// <returns></returns>
    public bool IsConditionNode()
    {
        return NodeType == (int)EBTNodeType.ConditionNodeType;
    }

    /// <summary>
    /// 更新子节点顺序
    /// </summary>
    /// <param name="graph"></param>
    public void UpdateChildNodeIndex(BTGraph graph)
    {
        for(int i = 0, length = ChildNodesUIDList.Count; i < length; i++)
        {
            var node = graph.FindNodeByUID(ChildNodesUIDList[i]);
            node.NodeIndex = i;
        }
    }

    /// <summary>
    /// 判定位置是否在指定节点区域内
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public bool UnderRectArea(Vector2 pos)
    {
        return NodeDisplayRect.Contains(pos);
    }
}