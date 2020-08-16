/*
 * Description:             BTGraph.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BTGraph.cs
/// ��Ϊ��ͼ����
/// </summary>
[Serializable]
public class BTGraph
{
    /// <summary>
    /// ��Ϊ�������ļ���(ֻ�и��ڵ���)
    /// </summary>
    public string BTFileName;

    /// <summary>
    /// ��Ϊ�����ڵ�����
    /// </summary>
    public BTNode RootNode;

    /// <summary>
    /// ���еĽڵ�����
    /// </summary>
    public List<BTNode> AllNodesList;

    public BTGraph()
    {
        Debug.Log($"BTGraph()");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="btfilename">��Ϊ���ļ���</param>
    /// <param name="rootnode"></param>
    public BTGraph(string btfilename, BTNode rootnode)
    {
        BTFileName = btfilename;
        RootNode = rootnode;
        AllNodesList = new List<BTNode>();
        AllNodesList.Add(RootNode);
    }

    /// <summary>
    /// ��ӽڵ�
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
            Debug.Log($"��������ӿջ��ظ��ڵ�!");
            return false;
        }
    }

    /// <summary>
    /// ɾ���ڵ�
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public bool DeleteNode(BTNode node)
    {
        if(node.Equals(RootNode) == false)
        {
            if(AllNodesList.Remove(node))
            {
                if(node.ChildNodesUIDList.Count > 0)
                {
                    for(int i = 0, length = node.ChildNodesUIDList.Count; i < length; i++)
                    {
                        var childnode = FindNodeByUID(node.ChildNodesUIDList[i]);
                        DeleteNode(childnode);
                    }
                    node.DeleteAllChildNodes();
                }
                // �ýڵ�ĸ��ڵ�ɾ�����ӽڵ㲢�����Žڵ�˳��
                var parentnode = FindNodeByUID(node.ParentNodeUID);
                if(parentnode != null)
                {
                    parentnode.DeleteChildNode(node.UID);
                    parentnode.UpdateChildNodeIndex(this);
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
            Debug.Log($"������ɾ�����ڵ�!");
            return false;
        }
    }

    /// <summary>
    /// ����uid�ҵ���Ӧ����Ϊ���ڵ�
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
    /// �������λ�û�ȡ��Ӧ��������Ϊ�ڵ�
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
    /// ��ǰ�ƶ�ָ���ӽڵ�
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
                return true;
            }
            else
            {
                Debug.LogWarning($"�ڵ���:{parentnode.NodeName}��UID:{childnodeuid}�ӽڵ��Ѿ��ǵ�һ���ӽڵ�,�޷�����ǰ�ƶ�!");
                return false;
            }
        }
        else
        {
            Debug.LogError($"�ڵ���:{parentnode.NodeName}�Ҳ���UID:{childnodeuid}���ӽڵ�,��ǰ�ƶ�ʧ��!");
            return false;
        }
    }

    /// <summary>
    /// ����ƶ�ָ���ӽڵ�
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
                return true;
            }
            else
            {
                Debug.LogWarning($"�ڵ���:{parentnode.NodeName}��UID:{childnodeuid}�ӽڵ��Ѿ������һ���ӽڵ�,�޷�������ƶ�!");
                return false;
            }
        }
        else
        {
            Debug.LogError($"�ڵ���:{parentnode.NodeName}�Ҳ���UID:{childnodeuid}���ӽڵ�,��ǰ�ƶ�ʧ��!");
            return false;
        }
    }
}