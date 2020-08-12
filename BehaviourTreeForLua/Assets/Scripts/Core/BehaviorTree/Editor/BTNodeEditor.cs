/*
 * Description:             BTNodeEditor.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/12
 */

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// ��Ϊ���ڵ�༭��
/// </summary>
public class BTNodeEditor : EditorWindow
{
    /// <summary>
    /// �ڵ㴴����Ϣ����
    /// </summary>
    public class CreateNodeInfo
    {
        /// <summary> ���ڵ� /// </summary>
        public BTNode ParentNode
        {
            get;
            set;
        }

        /// <summary> �����Ľڵ��� /// </summary>
        public string CreateNodeName
        {
            get;
            set;
        }

        /// <summary> �����Ľڵ����� /// </summary>
        public EBTNodeType CreateNodeType
        {
            get;
            set;
        }

        /// <summary> �����Ľڵ������ӽڵ����� /// </summary>
        public int CreateNodeChildIndex
        {
            get;
            set;
        }

        private CreateNodeInfo()
        {

        }

        public CreateNodeInfo(BTNode parentnode, string nodename, EBTNodeType nodetype, int nodechildindex)
        {
            ParentNode = parentnode;
            CreateNodeName = nodename;
            CreateNodeType = nodetype;
            CreateNodeChildIndex = nodechildindex;
        }
    }

    /// <summary>
    /// ��ǰѡ�����Ϊ���ڵ�
    /// </summary>
    private BTNode mCurrentSelectionBTNode;

    /// <summary>
    /// ��ǰ���ڹ���λ��
    /// </summary>
    private Vector2 mWindowScrollPos;

    /// <summary>
    /// ��Ϊ���˵�ö������
    /// </summary>
    public enum EBTMenuType
    {
        EmptyAreaMenu = 1,             // �����ڵ�˵�(����ڿ�����ʱ�Ĳ˵�)
        RootNodeAreaMenu,              // ���ڵ�˵�(������ڵ�ʱ�Ĳ˵�)
        ChildNodeAreaMenu,             // �ӽڵ�˵�(����ӽڵ�ʱ�Ĳ˵�)
    }

    /// <summary>
    /// �ڵ�˵�ӳ��Map(KeyΪ�˵����ͣ�ValueΪ��Ӧ�˵�)
    /// </summary>
    private Dictionary<EBTMenuType, GenericMenu> mNodeMenuMap;

    /// <summary>
    /// �հ��������˵�
    /// </summary>
    private GenericMenu mEmptyAreaMenu;

    /// <summary>
    /// ���ڵ��������˵�
    /// </summary>
    private GenericMenu mRootNodeAreaMenu;

    /// <summary>
    /// �ӽڵ��������˵�
    /// </summary>
    private GenericMenu mChildNodeAreaMenu;

    /// <summary>
    /// ��ǰ����Ľڵ�
    /// </summary>
    private BTNode mCurrentClickNode;

    [MenuItem("TonyTang/AI/BTNodeEditor")]
    static void ShowEditor()
    {
        BTNodeEditor btnodeeditor = EditorWindow.GetWindow<BTNodeEditor>();
        btnodeeditor.Show();
        btnodeeditor.Init();
    }

    private void Init()
    {
        // ����һ��Ĭ�ϵĿյ�BTNode
        //mCurrentSelectionBTNode = new BTNode();
    }

    private void OnEnable()
    {
        InitMenu();
    }

    private void OnSelectionChange()
    {
        if(Selection.objects.Length > 0)
        {
            var selectionasset = Selection.objects[0] as TextAsset;
            if(selectionasset == null)
            {
                Debug.Log($"ѡ�е��Ƿ�TextAsset��������!");
                return;
            }
            else
            {
                var btnodedata = JsonUtility.FromJson<BTNode>(selectionasset.text);
                if(btnodedata == null)
                {
                    Debug.Log($"ѡ�е��Ƿ�BTNode��Json���ݣ�������!");
                    return;
                }
                mCurrentSelectionBTNode = btnodedata;
            }
        }
    }

    private void OnGUI()
    {
        HandleInteraction();
        DrawBTNode();
    }

    /// <summary>
    /// ������
    /// </summary>
    private void HandleInteraction()
    {
        if(Application.isPlaying == false)
        {
            if (Event.current.type == EventType.ContextClick)
            {
                mCurrentClickNode = GetClickNode(Event.current.mousePosition + mWindowScrollPos);
                if(mCurrentClickNode == null && mCurrentSelectionBTNode != null)
                {

                }
                Event.current.Use();
            }
        }
    }

    /// <summary>
    /// ��ȡ���ѡ�е�BTNode
    /// </summary>
    /// <param name="mouseposition"></param>
    private BTNode GetClickNode(Vector2 mouseposition)
    {
        return null;
    }

    /// <summary>
    /// ������Ϊ���ڵ�
    /// </summary>
    private void DrawBTNode()
    {

    }

    #region �˵�����
    /// <summary>
    /// ��ʼ���˵�
    /// </summary>
    private void InitMenu()
    {
        mNodeMenuMap = new Dictionary<EBTMenuType, GenericMenu>();

        mEmptyAreaMenu = new GenericMenu();
        mEmptyAreaMenu.AddItem(new GUIContent("�������ڵ�"), false, OnCreateBTRootNode, null);
        mRootNodeAreaMenu = new GenericMenu();
        mRootNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/��Ϊ�ڵ�"), false, OnCreateBTActionNode, null);
        mRootNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/��Ͻڵ�"), false, OnCreateBTCompositeNode, null);
        mRootNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/�����ڵ�"), false, OnCreateBTConditionNode, null);
        mRootNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/װ�νڵ�"), false, OnCreateBTDecorationNode, null);
        mChildNodeAreaMenu = new GenericMenu();
        mChildNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/��Ϊ�ڵ�"), false, OnCreateBTActionNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/��Ͻڵ�"), false, OnCreateBTCompositeNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/�����ڵ�"), false, OnCreateBTConditionNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("����ӽڵ�/װ�νڵ�"), false, OnCreateBTDecorationNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("��ǰ�ƶ��ڵ�"), false, OnMoveForwardBTNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("����ƶ��ڵ�"), false, OnMoveBackwardBTNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("ɾ���ڵ�"), false, OnDeleteBTNode, null);

        mNodeMenuMap.Add(EBTMenuType.EmptyAreaMenu, mEmptyAreaMenu);
        mNodeMenuMap.Add(EBTMenuType.RootNodeAreaMenu, mRootNodeAreaMenu);
        mNodeMenuMap.Add(EBTMenuType.ChildNodeAreaMenu, mChildNodeAreaMenu);
    }

    /// <summary>
    /// ��Ӧ������Ϊ�����ڵ�
    /// </summary>
    /// <param name="nodeinfo">��Ϊ���ڵ�</param>
    private void OnCreateBTRootNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTRootNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// ��Ӧ������Ϊ�ڵ�
    /// </summary>
    /// <param name="nodeinfo">�����ڵ���Ϣ</param>
    private void OnCreateBTActionNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTActionNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// ��Ӧ������Ͻڵ�
    /// </summary>
    /// <param name="nodeinfo">�����ڵ���Ϣ</param>
    private void OnCreateBTCompositeNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTCompositeNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// ��Ӧ���������ڵ�
    /// </summary>
    /// <param name="nodeinfo">�����ڵ���Ϣ</param>
    private void OnCreateBTConditionNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTConditionNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// ��Ӧ�������νڵ�
    /// </summary>
    /// <param name="nodeinfo">�����ڵ���Ϣ</param>
    private void OnCreateBTDecorationNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTDecorationNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// ��ǰ�ƶ��ڵ�˳��
    /// </summary>
    /// <param name="movebackwardnode">��Ҫ��ǰ�ƶ��Ľڵ�</param>
    private void OnMoveForwardBTNode(object moveforwardnode)
    {
        var node = moveforwardnode as BTNode;
        Debug.Log($"OnMoveForwardBTNode({node.NodeName})");
    }

    /// <summary>
    /// ����ƶ��ڵ�˳��
    /// </summary>
    /// <param name="movebackwardnode">��Ҫ����ƶ��Ľڵ�</param>
    private void OnMoveBackwardBTNode(object movebackwardnode)
    {
        var node = movebackwardnode as BTNode;
        Debug.Log($"OnMoveBackwardBTNode({node.NodeName})");
    }

    /// <summary>
    /// ��Ӧɾ����Ϊ��ָ���ڵ�
    /// </summary>
    /// <param name="deletednode">��Ҫɾ������Ϊ���ڵ�</param>
    private void OnDeleteBTNode(object deletednode)
    {
        var node = deletednode as BTNode;
        Debug.Log($"OnDeleteBTNode({node.NodeName})");
    }
    #endregion
}