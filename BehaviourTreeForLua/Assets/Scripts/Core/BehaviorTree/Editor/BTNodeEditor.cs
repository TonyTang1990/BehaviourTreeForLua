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
        EmptyAreaMenu = 1,             // 主菜单(点击在空区域时的菜单)
        RootNodeAreaMenu,              // 根节点菜单(点击根节点时的菜单)
        ChildNodeAreaMenu,             // 子节点菜单(点击子节点时的菜单)
    }

    /// <summary>
    /// 节点菜单映射Map(Key为菜单类型，Value为对应菜单)
    /// </summary>
    private Dictionary<EBTMenuType, GenericMenu> mNodeMenuMap;

    /// <summary>
    /// 节点类型对应颜色Map，Key为节点类型，Value为节点颜色
    /// </summary>
    private Dictionary<EBTNodeType, Color> mNodeTypeColorMap;

    /// <summary>
    /// 节点类型对应名字Map，Key为节点类型，Value为节点名字
    /// </summary>
    private Dictionary<EBTNodeType, string> mNodeTypeNameMap;

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

    /// <summary>
    /// 普通曲线颜色
    /// </summary>
    private Color mNormalCurveColor;

    /// <summary>
    /// 运行曲线颜色
    /// </summary>
    private Color mRunningCurveColor;

    /// <summary>
    /// Lable的Style
    /// </summary>
    private GUIStyle mLableStyle;

    /// <summary>
    /// 节点窗口可拖拽区域
    /// </summary>
    private Rect NodeWindowDragableRect;

    /// <summary>
    /// 节点窗口宽度
    /// </summary>
    private const float NodeWindowWidth = 150.0f;

    /// <summary>
    /// 节点窗口高度
    /// </summary>
    private const float NodeWindowHeight = 150.0f;

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
        mCurrentSelectionBTNode = new BTNode(GetNodeRect(new Vector2(100f,100f)), 0, "Root", EBTNodeType.NoneNodeType);
    }

    /// <summary>
    /// 根据位置获取节点Rect
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private Rect GetNodeRect(Vector2 pos)
    {
        var rect = new Rect();
        rect.x = pos.x;
        rect.y = pos.y;
        rect.width = NodeWindowWidth;
        rect.height = NodeWindowHeight;
        return rect;
    }

    private void OnEnable()
    {
        Debug.Log($"BTNodeEditor:OnEnable()");
        InitMenu();
        mNodeTypeColorMap = new Dictionary<EBTNodeType, Color>();
        mNodeTypeColorMap.Add(EBTNodeType.NoneNodeType, Color.white);
        mNodeTypeColorMap.Add(EBTNodeType.ActionNodeType, Color.red);
        mNodeTypeColorMap.Add(EBTNodeType.CompositeNodeType, Color.blue);
        mNodeTypeColorMap.Add(EBTNodeType.ConditionNodeType, Color.yellow);
        mNodeTypeColorMap.Add(EBTNodeType.DecorationNodeType, Color.cyan);
        mNodeTypeNameMap = new Dictionary<EBTNodeType, string>();
        mNodeTypeNameMap.Add(EBTNodeType.NoneNodeType, "根节点");
        mNodeTypeNameMap.Add(EBTNodeType.ActionNodeType, "行为节点");
        mNodeTypeNameMap.Add(EBTNodeType.CompositeNodeType, "组合节点");
        mNodeTypeNameMap.Add(EBTNodeType.ConditionNodeType, "条件点");
        mNodeTypeNameMap.Add(EBTNodeType.DecorationNodeType, "装饰节点");
        NodeWindowDragableRect = new Rect(0, 0, NodeWindowWidth, NodeWindowHeight);
        mNormalCurveColor = Color.blue;
        mRunningCurveColor = Color.green;
    }

    /// <summary>
    /// 选中Asset变化响应
    /// </summary>
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
                Debug.Log($"选中的Asset:{Selection.objects[0].name}!");
                mCurrentSelectionBTNode = btnodedata;
            }
        }
    }

    private void OnGUI()
    {
        mLableStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
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
                if(mCurrentClickNode == null)
                {
                    Debug.Log($"显示空白区域菜单!");
                    var menu = GetNodeTypeMenu(EBTMenuType.EmptyAreaMenu);
                    menu.ShowAsContext();
                }
                else if(mCurrentClickNode != null && mCurrentClickNode.IsRootNode())
                {
                    Debug.Log($"显示根节点区域菜单!");
                    var menu = GetNodeTypeMenu(EBTMenuType.RootNodeAreaMenu);
                    menu.ShowAsContext();
                }
                else
                {
                    Debug.Log($"显示子节点区域菜单!");
                    var menu = GetNodeTypeMenu(EBTMenuType.ChildNodeAreaMenu);
                    menu.ShowAsContext();
                }
                Event.current.Use();
            }
        }
    }

    /// <summary>
    /// 绘制行为树节点
    /// </summary>
    private void DrawBTNode()
    {
        mWindowScrollPos = GUI.BeginScrollView(new Rect(0, 0, position.width, position.height), mWindowScrollPos, new Rect(0, 0, 2000, 2000));
        if(mCurrentSelectionBTNode != null)
        {
            DrawNodeCurves(mCurrentSelectionBTNode);
            BeginWindows();
            DrawNodes(mCurrentSelectionBTNode);
            EndWindows();
        }
        GUI.EndScrollView();
    }

    /// <summary>
    /// 绘制节点所有相关连线
    /// </summary>
    /// <param name="node"></param>
    private void DrawNodeCurves(BTNode node)
    {
        for(int i = 0; i < node.ChildNodesList.Count; i++)
        {
            DrawCurve(node.NodeDisplayRect, node.ChildNodesList[i].NodeDisplayRect);
            DrawNodeCurves(node.ChildNodesList[i]);
        }
    }

    /// <summary>
    /// 绘制连线
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    private void DrawCurve(Rect start, Rect end)
    {
        Vector3 startpos = new Vector3(start.x + start.width / 2, start.y, 0);
        Vector3 endpos = new Vector3(end.x + end.width / 2, end.y + end.height, 0);
        Vector3 starttangent = startpos + Vector3.left;
        Vector3 endtangent = endpos + Vector3.right;
        Handles.DrawBezier(startpos, endpos, starttangent, endtangent, mNormalCurveColor, null, 2);
    }

    /// <summary>
    /// 绘制节点
    /// </summary>
    /// <param name="node"></param>
    private void DrawNodes(BTNode node)
    {
        var title = node.IsRootNode() ? "Root" : $"No.{node.NodeIndex}";
        GUI.color = GetNodeTypeColor((EBTNodeType)node.NodeType);
        node.NodeDisplayRect = GUI.Window(node.UID, node.NodeDisplayRect, DrawNodeWindow, new GUIContent(title));
        GUI.color = Color.white;
        for (int i = 0; i < node.ChildNodesList.Count; ++i)
        {
            DrawNodes(node.ChildNodesList[i]);
        }
    }

    /// <summary>
    /// 绘制节点窗口
    /// </summary>
    /// <param name="uid"></param>
    private void DrawNodeWindow(int uid)
    {
        var btnode = BTUtilities.FindByUID(mCurrentSelectionBTNode, uid);
        if(btnode == null)
        {
            return;
        }
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField($"{btnode.NodeName}", mLableStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField($"{GetNodeTypeName((EBTNodeType)btnode.NodeType)}", mLableStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
        EditorGUILayout.EndVertical();
        GUI.DragWindow(NodeWindowDragableRect);
    }

    /// <summary>
    /// 获取指定节点菜单类型的菜单
    /// </summary>
    /// <param name="menutype"></param>
    /// <returns></returns>
    private GenericMenu GetNodeTypeMenu(EBTMenuType menutype)
    {
        return mNodeMenuMap[menutype];
    }

    /// <summary>
    /// 获取指定节点类型的颜色
    /// </summary>
    /// <param name="nodetype"></param>
    /// <returns></returns>
    private Color GetNodeTypeColor(EBTNodeType nodetype)
    {
        return mNodeTypeColorMap[nodetype];
    }

    /// <summary>
    /// 获取指定节点类型的名字
    /// </summary>
    /// <param name="nodetype"></param>
    /// <returns></returns>
    private string GetNodeTypeName(EBTNodeType nodetype)
    {
        return mNodeTypeNameMap[nodetype];
    }

    /// <summary>
    /// 获取点击选中的BTNode
    /// </summary>
    /// <param name="mouseposition"></param>
    private BTNode GetClickNode(Vector2 mouseposition)
    {
        return BTUtilities.FindNodeByMousePos(mCurrentSelectionBTNode, mouseposition);
    }

    #region 菜单部分
    /// <summary>
    /// 初始化菜单
    /// </summary>
    private void InitMenu()
    {
        mNodeMenuMap = new Dictionary<EBTMenuType, GenericMenu>();

        mEmptyAreaMenu = new GenericMenu();
        mEmptyAreaMenu.AddItem(new GUIContent("导出AI配置"), false, OnExportBTNode, null);
        mRootNodeAreaMenu = new GenericMenu();
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/行为节点"), false, OnCreateBTActionNode, mCurrentClickNode);
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/组合节点"), false, OnCreateBTCompositeNode, mCurrentClickNode);
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/条件节点"), false, OnCreateBTConditionNode, mCurrentClickNode);
        mRootNodeAreaMenu.AddItem(new GUIContent("添加子节点/装饰节点"), false, OnCreateBTDecorationNode, mCurrentClickNode);
        mChildNodeAreaMenu = new GenericMenu();
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/行为节点"), false, OnCreateBTActionNode, mCurrentClickNode);
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/组合节点"), false, OnCreateBTCompositeNode, mCurrentClickNode);
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/条件节点"), false, OnCreateBTConditionNode, mCurrentClickNode);
        mChildNodeAreaMenu.AddItem(new GUIContent("添加子节点/装饰节点"), false, OnCreateBTDecorationNode, mCurrentClickNode);
        mChildNodeAreaMenu.AddItem(new GUIContent("向前移动节点"), false, OnMoveForwardBTNode, mCurrentClickNode);
        mChildNodeAreaMenu.AddItem(new GUIContent("向后移动节点"), false, OnMoveBackwardBTNode, mCurrentClickNode);
        mChildNodeAreaMenu.AddItem(new GUIContent("删除节点"), false, OnDeleteBTNode, mCurrentClickNode);

        mNodeMenuMap.Add(EBTMenuType.EmptyAreaMenu, mEmptyAreaMenu);
        mNodeMenuMap.Add(EBTMenuType.RootNodeAreaMenu, mRootNodeAreaMenu);
        mNodeMenuMap.Add(EBTMenuType.ChildNodeAreaMenu, mChildNodeAreaMenu);
    }

    /// <summary>
    /// 响应导出AI配置
    /// </summary>
    /// <param name="rootnode">行为树跟节点</param>
    private void OnExportBTNode(object rootnode)
    {
        var rtnode = rootnode as BTNode;
        Debug.Log($"OnExportBTNode({rtnode.NodeName})");
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