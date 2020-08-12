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
/// ��Ϊ����̬������
/// </summary>
public static class BTUtilities
{
    #region ��̬����
    /// <summary>
    /// ����uid�ҵ���Ӧ����Ϊ���ڵ�
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
    /// �������λ�û�ȡ��Ӧ��������Ϊ�ڵ�
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
    /// ��ȡ���нڵ�
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