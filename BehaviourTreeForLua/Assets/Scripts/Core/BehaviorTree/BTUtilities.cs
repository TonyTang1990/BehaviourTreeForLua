/*
 * Description:             BTUtilities.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/13
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTUtilities.cs
/// 行为树静态工具类
/// </summary>
public static class BTUtilities
{
    #region 静态方法
    /// <summary>
    /// 根据uid找到对应的行为树节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public static BTNode FindByUID(BTNode node,int uid)
    {
        List<BTNode> allnodes = new List<BTNode>();
        GetAllNodes(node, allnodes);
        var findnode = allnodes.Find((btnode) =>
        {
            return btnode.UID == uid;
        });
        return findnode;
    }

    /// <summary>
    /// 根据鼠标位置获取对应操作的行为节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="mpos"></param>
    /// <returns></returns>
    public static BTNode FindNodeByMousePos(BTNode node, Vector3 mpos)
    {
        List<BTNode> allnodes = new List<BTNode>();
        GetAllNodes(node, allnodes);
        var findnode = allnodes.Find((btnode) =>
        {
            return btnode.NodeDisplayRect.Contains(mpos);
        });
        return findnode;
    }

    /// <summary>
    /// 获取所有节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="allnodes"></param>
    /// <returns></returns>
    private static void GetAllNodes(BTNode node, List<BTNode> allnodes)
    {
        allnodes.Add(node);
        foreach(var childnode in node.ChildNodesList)
        {
            GetAllNodes(childnode, allnodes);
        }
    }
    #endregion
}