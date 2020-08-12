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
    NoneNodeType = 1,               // 无类型(根节点才为此类型)
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
    /// 节点类型
    /// </summary>
    public int NodeType;

    /// <summary>
    /// 父节点
    /// </summary>
    public BTNode ParentNode;

    /// <summary>
    /// 子节点列表
    /// </summary>
    public List<BTNode> ChildNodesList;

    private BTNode()
    {
    }

    public BTNode(Rect noderect, int nodeindex, string nodename, EBTNodeType nodetype, BTNode parentnode = null)
    {
        NodeDisplayRect = noderect;
        NodeIndex = nodeindex;
        NodeName = nodename;
        NodeType = (int)nodetype;
        ParentNode = parentnode;
        ChildNodesList = new List<BTNode>();
    }

    /// <summary>
    /// 添加子节点
    /// </summary>
    /// <param name="childnode"></param>
    /// <param name="insertindex">默认不传往尾部插入</param>
    public void AddChildNode(BTNode childnode, int? insertindex = null)
    {
        Debug.Assert(childnode == null, "不允许添加空的子节点!");
        if(insertindex == null)
        {
            ChildNodesList.Add(childnode);
        }
        else
        {
            var realyinsertindex = (int)insertindex;
            Debug.Assert(realyinsertindex < 0 || realyinsertindex > ChildNodesList.Count, $"子节点插入位置超出了有效范围:{0}-{ChildNodesList.Count}");
            ChildNodesList.Insert(realyinsertindex, childnode);
        }
    }
}