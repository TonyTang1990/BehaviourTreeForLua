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
/// 行为树节点编辑器
/// </summary>
public class BTNodeEditor : EditorWindow
{
    /// <summary>
    /// 节点创建信息抽象
    /// </summary>
    public class CreateNodeInfo
    {
        /// <summary> 父节点 /// </summary>
        public BTNode ParentNode
        {
            get;
            set;
        }

        /// <summary> 创建的节点名 /// </summary>
        public string CreateNodeName
        {
            get;
            set;
        }

        /// <summary> 创建的节点类型 /// </summary>
        public EBTNodeType CreateNodeType
        {
            get;
            set;
        }

        /// <summary> 创建的节点所在子节点索引 /// </summary>
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
    /// 当前选择的行为树节点
    /// </summary>
    private BTNode mCurrentSelectionBTNode;

    /// <summary>
    /// 当前窗口滚动位置
    /// </summary>
    private Vector2 mWindowScrollPos;

    /// <summary>
    /// 行为树菜单枚举类型
    /// </summary>
    public enum EBTMenuType
    {
        EmptyAreaMenu = 1,             // 创建节点菜单(点击在空区域时的菜单)
        RootNodeAreaMenu,              // 根节点菜单(点击根节点时的菜单)
        ChildNodeAreaMenu,             // 子节点菜单(点击子节点时的菜单)
    }

    /// <summary>
    /// 节点菜单映射Map(Key为菜单类型，Value为对应菜单)
    /// </summary>
    private Dictionary<EBTMenuType, GenericMenu> mNodeMenuMap;

    /// <summary>
    /// 空白区域点击菜单
    /// </summary>
    private GenericMenu mEmptyAreaMenu;

    /// <summary>
    /// 根节点区域点击菜单
    /// </summary>
    private GenericMenu mRootNodeAreaMenu;

    /// <summary>
    /// 子节点区域点击菜单
    /// </summary>
    private GenericMenu mChildNodeAreaMenu;

    /// <summary>
    /// 当前点击的节点
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
        // 创建一个默认的空的BTNode
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
                Debug.Log($"选中的是非TextAsset，不处理!");
                return;
            }
            else
            {
                var btnodedata = JsonUtility.FromJson<BTNode>(selectionasset.text);
                if(btnodedata == null)
                {
                    Debug.Log($"选中的是非BTNode的Json数据，不处理!");
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
    /// 处理交互
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
    /// 获取点击选中的BTNode
    /// </summary>
    /// <param name="mouseposition"></param>
    private BTNode GetClickNode(Vector2 mouseposition)
    {
        return null;
    }

    /// <summary>
    /// 绘制行为树节点
    /// </summary>
    private void DrawBTNode()
    {

    }

    #region 菜单部分
    /// <summary>
    /// 初始化菜单
    /// </summary>
    private void InitMenu()
    {
        mNodeMenuMap = new Dictionary<EBTMenuType, GenericMenu>();

        mEmptyAreaMenu = new GenericMenu();
        mEmptyAreaMenu.AddItem(new GUIContent("创建根节点"), false, OnCreateBTRootNode, null);
        mRootNodeAreaMenu = new GenericMenu();
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/行为节点"), false, OnCreateBTActionNode, null);
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/组合节点"), false, OnCreateBTCompositeNode, null);
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/条件节点"), false, OnCreateBTConditionNode, null);
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/装饰节点"), false, OnCreateBTDecorationNode, null);
        mChildNodeAreaMenu = new GenericMenu();
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/行为节点"), false, OnCreateBTActionNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/组合节点"), false, OnCreateBTCompositeNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/条件节点"), false, OnCreateBTConditionNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/装饰节点"), false, OnCreateBTDecorationNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("向前移动节点"), false, OnMoveForwardBTNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("向后移动节点"), false, OnMoveBackwardBTNode, null);
        mChildNodeAreaMenu.AddItem(new GUIContent("删除节点"), false, OnDeleteBTNode, null);

        mNodeMenuMap.Add(EBTMenuType.EmptyAreaMenu, mEmptyAreaMenu);
        mNodeMenuMap.Add(EBTMenuType.RootNodeAreaMenu, mRootNodeAreaMenu);
        mNodeMenuMap.Add(EBTMenuType.ChildNodeAreaMenu, mChildNodeAreaMenu);
    }

    /// <summary>
    /// 响应创建行为树根节点
    /// </summary>
    /// <param name="nodeinfo">行为树节点</param>
    private void OnCreateBTRootNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTRootNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// 响应创建行为节点
    /// </summary>
    /// <param name="nodeinfo">创建节点信息</param>
    private void OnCreateBTActionNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTActionNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// 响应创建组合节点
    /// </summary>
    /// <param name="nodeinfo">创建节点信息</param>
    private void OnCreateBTCompositeNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTCompositeNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// 响应创建条件节点
    /// </summary>
    /// <param name="nodeinfo">创建节点信息</param>
    private void OnCreateBTConditionNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTConditionNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// 响应创建修饰节点
    /// </summary>
    /// <param name="nodeinfo">创建节点信息</param>
    private void OnCreateBTDecorationNode(object nodeinfo)
    {
        var createnodeinfo = nodeinfo as CreateNodeInfo;
        Debug.Log($"OnCreateBTDecorationNode({createnodeinfo.CreateNodeName})");
    }

    /// <summary>
    /// 向前移动节点顺序
    /// </summary>
    /// <param name="movebackwardnode">需要向前移动的节点</param>
    private void OnMoveForwardBTNode(object moveforwardnode)
    {
        var node = moveforwardnode as BTNode;
        Debug.Log($"OnMoveForwardBTNode({node.NodeName})");
    }

    /// <summary>
    /// 向后移动节点顺序
    /// </summary>
    /// <param name="movebackwardnode">需要向后移动的节点</param>
    private void OnMoveBackwardBTNode(object movebackwardnode)
    {
        var node = movebackwardnode as BTNode;
        Debug.Log($"OnMoveBackwardBTNode({node.NodeName})");
    }

    /// <summary>
    /// 响应删除行为树指定节点
    /// </summary>
    /// <param name="deletednode">需要删除的行为树节点</param>
    private void OnDeleteBTNode(object deletednode)
    {
        var node = deletednode as BTNode;
        Debug.Log($"OnDeleteBTNode({node.NodeName})");
    }
    #endregion
}