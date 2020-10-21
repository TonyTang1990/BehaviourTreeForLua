/*
 * Description:             BTNodeEditor.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/12
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using XLua;

namespace LuaBehaviourTree
{
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
            /// <summary>
            /// 行为树图
            /// </summary>
            public BTGraph Graph
            {
                get;
                set;
            }

            /// <summary> 操作节点 /// </summary>
            public BTNode OperateNode
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

            private CreateNodeInfo()
            {

            }

            public CreateNodeInfo(BTGraph graph, BTNode operatenode, string nodename)
            {
                Graph = graph;
                OperateNode = operatenode;
                CreateNodeName = nodename;
            }
        }

        #region Lua部分
        /// <summary>
        /// 当前环境的LuaEnv
        /// </summary>
        //private static LuaEnv CurrentLuaEnvInstance;
        #endregion

        #region 左侧操作面板
        /// <summary>
        /// 操作面板
        /// </summary>
        private string[] mToolBarStrings = { "总面板", "参数面板", "动态变量" };

        /// <summary>
        /// 操作面板选择索引
        /// </summary>
        private int mToolBarSelectIndex;

        /// <summary>
        /// 操作选择面板区域
        /// </summary>
        private Rect mToolBarRect;

        /// <summary>
        /// 操作选择面板宽度
        /// </summary>
        private const float ToolBarWidth = 250.0f;

        /// <summary>
        /// 操作选择面板高度
        /// </summary>
        private const float ToolBarHeight = 20.0f;

        /// <summary>
        /// 操作选择详情面板区域
        /// </summary>
        private Rect mInspectorRect;

        /// <summary>
        /// 操作选择面板宽度
        /// </summary>
        private const float InspectorWindowWidth = ToolBarWidth;

        /// <summary>
        /// 操作选择面板高度
        /// </summary>
        private float InspectorWindowHeight = 2000.0f;
        #endregion

        #region 节点操作区域
        /// <summary>
        /// 节点区域窗口宽度
        /// </summary>
        private const float NodeAreaWindowWidth = 4000.0f;

        /// <summary>
        /// 节点区域窗口高度
        /// </summary>
        private const float NodeAreaWindowHeight = 2000.0f;

        /// <summary>
        /// 节点窗口可拖拽区域
        /// </summary>
        private Rect mNodeWindowDragableRect;

        /// <summary>
        /// 节点窗口宽度
        /// </summary>
        private const float NodeWindowWidth = 150.0f;

        /// <summary>
        /// 节点窗口高度
        /// </summary>
        private const float NodeWindowHeight = 150.0f;

        /// <summary>
        /// 默认行为树文件名
        /// </summary>
        private const string DefaultBTGrapshFileName = "DefaultBT";

        /// <summary>
        /// 当前选择的行为树图TextAsset
        /// </summary>
        private TextAsset mCurrentSelectionBTGraphAsset;

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
            ActionLeafNodeAreaMenu,        // 行为叶子节点菜单(点击子节点为行为节点时的菜单)
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
        /// 叶子节点区域点击菜单
        /// </summary>
        private GenericMenu mLeafNodeAreaMenu;

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
        /// Lable的居中对齐Style
        /// </summary>
        private GUIStyle mLableAlignMiddleStyle;

        /// <summary>
        /// Lable的居靠左对齐Style
        /// </summary>
        private GUIStyle mLableAlignLeftStyle;
        
        /// <summary>
        /// 是否是调试模式
        /// </summary>
        private bool IsDebugMode = false;

        /// <summary>
        /// 是否开启子节点一起移动
        /// </summary>
        private bool IsEnableMoveWithChildNodes = true;
        
        /// <summary>
        /// 节点创建插入策略
        /// </summary>
        public enum ECreateNodeStrategy
        {
            ToEnd = 1,                  // 插入到尾部
            ToStart,                    // 插入到头
        }

        /// <summary>
        /// 当前节点创建插入测流
        /// </summary>
        private ECreateNodeStrategy mCurrentCreateNodeStrategy = ECreateNodeStrategy.ToEnd;

        /// <summary>
        /// 当前设置的变量名
        /// </summary>
        private string mCurrentVariableName = string.Empty;

        /// <summary>
        /// 当前选中的变量类型
        /// </summary>
        private EVariableType mCurrentSelectedVariableType = EVariableType.Bool;
        #endregion

        #region 数据存储
        /// <summary>
        /// 当前选择的行为树图
        /// </summary>
        private BTGraph mCurrentSelectionBTGraph;

        /// <summary>
        /// 当前选择的行为树Asset原始名字
        /// </summary>
        private string mCurrentSelectionBTGraphAssetOriginalName;

        /// <summary>
        /// 当前选中的行为树Asset资源路径(新建的行为树对象此路径为空)
        /// </summary>
        private string mCurrentSelectionBTGraphAssetPath;

        /// <summary>
        /// 所有已经使用的节点UID映射Map(Key为已使用的UID，Value为已使用的UID)
        /// </summary>
        private Dictionary<int, int> AllUsedNodeUIDMap;

        /// <summary>
        /// 需要删除的UID列表
        /// </summary>
        private List<int> mNeedDeletedUIDList;
        #endregion

        [MenuItem("TonyTang/AI/行为树编辑器")]
        static void ShowEditor()
        {
            BTNodeEditor btnodeeditor = EditorWindow.GetWindow<BTNodeEditor>("行为树编辑器");
            btnodeeditor.Show();
            btnodeeditor.Init();
        }

        private void Init()
        {
            mCurrentSelectionBTGraph = new BTGraph(DefaultBTGrapshFileName);
            // 创建一个默认的空的BTNode
            var rootnode = new BTNode(mCurrentSelectionBTGraph, GetNodeRect(new Vector2(ToolBarWidth, 50.0f)), 0, "Root", EBTNodeType.EntryNodeType, null, AllUsedNodeUIDMap);
            mCurrentSelectionBTGraph.SetRootNode(rootnode);
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
            mNodeTypeColorMap = new Dictionary<EBTNodeType, Color>();
            mNodeTypeColorMap.Add(EBTNodeType.EntryNodeType, Color.white);
            mNodeTypeColorMap.Add(EBTNodeType.ActionNodeType, Color.red);
            mNodeTypeColorMap.Add(EBTNodeType.CompositeNodeType, Color.blue);
            mNodeTypeColorMap.Add(EBTNodeType.ConditionNodeType, Color.yellow);
            mNodeTypeColorMap.Add(EBTNodeType.DecorationNodeType, Color.cyan);
            mNodeTypeNameMap = new Dictionary<EBTNodeType, string>();
            mNodeTypeNameMap.Add(EBTNodeType.EntryNodeType, "根节点");
            mNodeTypeNameMap.Add(EBTNodeType.ActionNodeType, "行为节点");
            mNodeTypeNameMap.Add(EBTNodeType.CompositeNodeType, "组合节点");
            mNodeTypeNameMap.Add(EBTNodeType.ConditionNodeType, "条件节点");
            mNodeTypeNameMap.Add(EBTNodeType.DecorationNodeType, "装饰节点");
            mToolBarRect = new Rect(0, 0, ToolBarWidth, ToolBarHeight);
            mToolBarSelectIndex = 0;
            mInspectorRect = new Rect(0, ToolBarHeight, InspectorWindowWidth, InspectorWindowHeight);
            mNodeWindowDragableRect = new Rect(0, 0, NodeWindowWidth, 20f);
            mNormalCurveColor = Color.blue;
            mRunningCurveColor = Color.green;
            AllUsedNodeUIDMap = new Dictionary<int, int>();
            mNeedDeletedUIDList = new List<int>();
            // UID二次防御检测，以防万一
            ReadAllNodesUID();
            InitMenu();
        }

        /// <summary>
        /// 读取所有已经使用的UID
        /// </summary>
        private void ReadAllNodesUID()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            AllUsedNodeUIDMap.Clear();
            var btsavefolderfullpath = $"{BTData.BTNodeSaveFolderRelativePath}";
            Debug.Log($"btsavefolderfullpath:{btsavefolderfullpath}");
            var allbtfiles = Resources.LoadAll<TextAsset>(btsavefolderfullpath);
            foreach (var btfile in allbtfiles)
            {
                var btgraph = JsonUtility.FromJson<BTGraph>(btfile.text);
                foreach (var node in btgraph.AllNodesList)
                {
                    if (!AllUsedNodeUIDMap.ContainsKey(node.UID))
                    {
                        AllUsedNodeUIDMap.Add(node.UID, node.UID);
                    }
                    else
                    {
                        Debug.LogError($"严重错误，文件名:{btgraph.BTFileName}生成使用了重复的节点UID!");
                    }
                }
            }
            sw.Stop();
            Debug.Log($"读取的行为树文件数量:{allbtfiles.Length} 已使用UID数量:{AllUsedNodeUIDMap.Count}");
            Debug.Log($"读取所有已使用UID耗时:{sw.Elapsed.TotalSeconds}s");
        }

        private void OnDestroy()
        {
            Debug.Log($"BTNodeEditor:OnDestroy()");
        }
        
        /// <summary>
        /// 选中Asset变化响应
        /// </summary>
        private void OnSelectionChange()
        {
            if (Selection.objects.Length > 0)
            {
                var selectionasset = Selection.objects[0];
                if(selectionasset is TextAsset)
                {
                    var selectiontextasset = selectionasset as TextAsset;
                    LoadBTAsset(selectiontextasset);
                }
                else if(selectionasset is GameObject)
                {
                    var selectiongameobject = selectionasset as GameObject;
                    var tbt = selectiongameobject.GetComponent<TBehaviourTree>();
                    if (tbt != null && tbt.BTGraphAsset != null)
                    {
                        if (tbt.BTRunningGraph != null)
                        {
                            mCurrentSelectionBTGraph = tbt.BTRunningGraph;
                            mCurrentSelectionBTGraphAsset = tbt.BTGraphAsset;
                            mCurrentSelectionBTGraphAssetOriginalName = mCurrentSelectionBTGraphAsset.name;
                            mCurrentSelectionBTGraphAssetPath = AssetDatabase.GetAssetPath(mCurrentSelectionBTGraphAsset);
                            Debug.Log($"选中运行时有行为树数据对象:{selectiongameobject.name} 行为树AssetPath:{mCurrentSelectionBTGraphAssetPath}");
                        }
                        else
                        {
                            mCurrentSelectionBTGraph = tbt.BTOriginalGraph;
                            mCurrentSelectionBTGraphAsset = tbt.BTGraphAsset;
                            mCurrentSelectionBTGraphAssetOriginalName = mCurrentSelectionBTGraphAsset.name;
                            mCurrentSelectionBTGraphAssetPath = AssetDatabase.GetAssetPath(mCurrentSelectionBTGraphAsset);
                            Debug.Log($"非运行时选中的场景对象:{Selection.objects[0].name} AssetPath:{mCurrentSelectionBTGraphAssetPath}!");
                        }
                    }
                    else
                    {
                        Debug.Log($"未选中有效行为树对象!");
                    }
                }
                else
                {
                    Debug.Log($"选中的是非TextAsset也非有效TBehaviourTree，不处理!");
                    return;
                }
            }
        }

        /// <summary>
        /// 加载行为树Asset
        /// </summary>
        /// <param name="asset"></param>
        private void LoadBTAsset(TextAsset asset)
        {
            var assetpath = AssetDatabase.GetAssetPath(asset);
            if (assetpath.EndsWith(".json"))
            {
                var btgrapshdata = JsonUtility.FromJson<BTGraph>(asset.text);
                if (btgrapshdata == null)
                {
                    Debug.Log($"选中的是非BTGraph的Json数据，不处理!");
                    return;
                }
                ReadAllNodesUID();
                mCurrentSelectionBTGraph = btgrapshdata;
                mCurrentSelectionBTGraph.Init();
                mCurrentSelectionBTGraphAsset = asset;
                mCurrentSelectionBTGraphAssetOriginalName = mCurrentSelectionBTGraphAsset.name;
                mCurrentSelectionBTGraphAssetPath = assetpath;
                Debug.Log($"非运行时选中的Asset:{asset.name} AssetPath:{mCurrentSelectionBTGraphAssetPath}!");
            }
            else
            {
                Debug.Log($"选中的是非Json数据，不处理!");
            }
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        private void OnGUI()
        {
            InspectorWindowHeight = position.height;
            mInspectorRect.height = InspectorWindowHeight - mToolBarRect.height;
            mLableAlignMiddleStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
            mLableAlignLeftStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperLeft };
            // mCurrentSelectionBTGraph.RootNodeUID在运行时选中查看AI对象后关闭运行会导致为0
            if (mCurrentSelectionBTGraph != null && mCurrentSelectionBTGraph.RootNodeUID != 0)
            {
                HandleInteraction();
                DrawOperationPanel();
                DrawBTNode();
            }
            else
            {
                EditorGUILayout.LabelField("未选中有效行为树节点或文件!", mLableAlignMiddleStyle, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            }
        }

        /// <summary>
        /// 处理交互
        /// </summary>
        private void HandleInteraction()
        {
            if (Event.current.type == EventType.ContextClick)
            {
                var nodeareamouseposition = Event.current.mousePosition;
                nodeareamouseposition.x = nodeareamouseposition.x - InspectorWindowWidth;
                mCurrentClickNode = mCurrentSelectionBTGraph.FindNodeByMousePos(nodeareamouseposition + mWindowScrollPos);
                if (Application.isPlaying == false)
                {
                    if (mCurrentClickNode == null)
                    {
                        Debug.Log($"显示空白区域菜单!");
                        UpdateMenus();
                        var menu = GetNodeTypeMenu(EBTMenuType.EmptyAreaMenu);
                        menu.ShowAsContext();
                    }
                    else if (mCurrentClickNode != null && mCurrentClickNode.IsRootNode())
                    {
                        Debug.Log($"显示根节点区域菜单!");
                        UpdateMenus();
                        var menu = GetNodeTypeMenu(EBTMenuType.RootNodeAreaMenu);
                        menu.ShowAsContext();
                    }
                    else if (mCurrentClickNode != null && !mCurrentClickNode.IsRootNode() && (!mCurrentClickNode.IsActionNode() && !mCurrentClickNode.IsConditionNode()))
                    {
                        Debug.Log($"显示子节点区域菜单!");
                        UpdateMenus();
                        var menu = GetNodeTypeMenu(EBTMenuType.ChildNodeAreaMenu);
                        menu.ShowAsContext();
                    }
                    else if (mCurrentClickNode != null && !mCurrentClickNode.IsRootNode() && (mCurrentClickNode.IsActionNode() || mCurrentClickNode.IsConditionNode()))
                    {
                        Debug.Log($"显示行为叶节点区域菜单!");
                        UpdateMenus();
                        var menu = GetNodeTypeMenu(EBTMenuType.ActionLeafNodeAreaMenu);
                        menu.ShowAsContext();
                    }
                }
                Event.current.Use();
            }
        }

        /// <summary>
        /// 绘制操作面板
        /// </summary>
        private void DrawOperationPanel()
        {
            GUILayout.BeginArea(mToolBarRect, EditorStyles.toolbar);
            mToolBarSelectIndex = GUILayout.Toolbar(mToolBarSelectIndex, mToolBarStrings, EditorStyles.toolbarButton);
            GUILayout.EndArea();
            GUILayout.BeginArea(mInspectorRect);
            DrawSelectTollBarInspector();
            GUILayout.EndArea();
        }

        /// <summary>
        /// 绘制当前选择的操作选择详情面板
        /// </summary>
        private void DrawSelectTollBarInspector()
        {
            if (mToolBarSelectIndex == 0)
            {
                DrawUserOperationPanel();
            }
            else if (mToolBarSelectIndex == 1)
            {
                DrawParamsPanel();
            }
            else if(mToolBarSelectIndex == 2)
            {
                DrawVariablesPanel();
            }
        }

        /// <summary>
        /// 绘制用户操作面板
        /// </summary>
        private void DrawUserOperationPanel()
        {
            var halftoolbarwidth = ToolBarWidth / 2 - 10f;
            EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            EditorUtilities.DisplayDIYGUILable("操作面板", Color.yellow, 0, ToolBarWidth - 10, 20.0f);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("行为树名:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            mCurrentSelectionBTGraph.BTFileName = EditorGUILayout.TextField(mCurrentSelectionBTGraph.BTFileName, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginVertical();
            if (mCurrentSelectionBTGraphAsset != null)
            {
                if (Application.isPlaying == false)
                {
                    if (GUILayout.Button("保存", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f)))
                    {
                        TrySaveBTAsset();
                    }
                    if (GUILayout.Button("重新生成所有UID", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f)))
                    {
                        RecaculateAllNodesUID();
                    }
                }
            }
            else
            {
                if (Application.isPlaying == false)
                {
                    if (GUILayout.Button("导出", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f)))
                    {
                        if (string.IsNullOrEmpty(mCurrentSelectionBTGraph.BTFileName) == false)
                        {
                            TrySaveBTAsset();
                        }
                        else
                        {
                            Debug.LogError($"不允许导出行为树名为空的行为树数据!");
                        }
                    }
                }
            }
            EditorGUILayout.EndVertical();
            IsEnableMoveWithChildNodes = EditorGUILayout.Toggle("子节点一起移动开关:", IsEnableMoveWithChildNodes, GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
            mCurrentCreateNodeStrategy = (ECreateNodeStrategy)EditorGUILayout.EnumPopup("节点添加策略:", mCurrentCreateNodeStrategy, GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
            if (GUILayout.Button("新建", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f)))
            {
                if (EditorUtility.DisplayDialog("行为树保存", "是否保存之前的行为树!", "确认", "取消"))
                {
                    if (TrySaveBTAsset())
                    {
                        CreateNewBTAsset();
                    }
                    else
                    {
                        Debug.LogError($"保存失败!无法新建行为树,请先修复保存报错!");
                    }
                }
                else
                {
                    CreateNewBTAsset();
                }
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.Height(mInspectorRect.height / 2));
            EditorUtilities.DisplayDIYGUILable("调试面板", Color.yellow, 0, ToolBarWidth - 10, 20.0f);
            IsDebugMode = EditorGUILayout.Toggle("调试开关:", IsDebugMode, GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
            if (IsDebugMode && Application.isPlaying)
            {
                if (mCurrentSelectionBTGraph != null)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("运行节点数:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                    GUILayout.Label(mCurrentSelectionBTGraph.ExecutingNodesMap.Count.ToString(), "textarea", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("需要重新评估节点数:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                    GUILayout.Label(mCurrentSelectionBTGraph.ExecutedReevaluatedNodesResultMap.Count.ToString(), "textarea", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.LabelField("黑板数据:", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    var allblackboardkeyslist = mCurrentSelectionBTGraph.BTBlackBoard.GetAllBlackBoardKeysList();
                    var allblackboardvalueslist = mCurrentSelectionBTGraph.BTBlackBoard.GetAllBlackBoardValuesList();
                    if (allblackboardkeyslist.Count > 0)
                    {
                        for(int i = 0, length = allblackboardkeyslist.Count; i < length; i++)
                        {
                            DisplayOneBlackBoardKeyInfo(allblackboardkeyslist[i], allblackboardvalueslist[i]);
                        }
                    }
                    else
                    {
                        EditorGUILayout.LabelField("无", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    }
                }
            }
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// 显示一个黑板指定Key数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void DisplayOneBlackBoardKeyInfo(string key, IBlackboardData value)
        {
            EditorUtilities.DrawUILine();
            var halftoolbarwidth = ToolBarWidth / 2 - 10f;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("变量名:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            EditorGUILayout.LabelField(key, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("变量值:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            var blackboarddatatype = value.GetType();
            if (blackboarddatatype == typeof(BlackboardData<bool>))
            {
                var realblackboarddata = value as BlackboardData<bool>;
                EditorGUILayout.Toggle(realblackboarddata.Data, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            }
            else if (blackboarddatatype == typeof(BlackboardData<int>))
            {
                var realblackboarddata = value as BlackboardData<int>;
                EditorGUILayout.IntField(realblackboarddata.Data, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            }
            else if (blackboarddatatype == typeof(BlackboardData<float>))
            {
                var realblackboarddata = value as BlackboardData<float>;
                EditorGUILayout.FloatField(realblackboarddata.Data, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            }
            else if (blackboarddatatype == typeof(BlackboardData<string>))
            {
                var realblackboarddata = value as BlackboardData<string>;
                EditorGUILayout.LabelField(realblackboarddata.Data, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            }
            else
            {
                EditorGUILayout.LabelField($"不支持的黑板数据类型:{blackboarddatatype}!", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// 绘制参数面板
        /// </summary>
        private void DrawParamsPanel()
        {
            var halftoolbarwidth = ToolBarWidth / 2 - 10f;
            if (mCurrentClickNode != null)
            {
                EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("节点名:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
                GUILayout.Label(mCurrentClickNode != null ? mCurrentClickNode.NodeName : string.Empty, "textarea", GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                if (mCurrentClickNode.NodeType == (int)EBTNodeType.ConditionNodeType)
                {
                    EditorGUILayout.LabelField("打断类型:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
                    if (Application.isPlaying == false)
                    {
                        mCurrentClickNode.AbortType = (EAbortType)EditorGUILayout.EnumPopup("", mCurrentClickNode.AbortType, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                    }
                    else
                    {
                        EditorGUILayout.EnumPopup("", mCurrentClickNode.AbortType, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.LabelField("节点参数:", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                mCurrentClickNode.NodeParams = GUILayout.TextField(mCurrentClickNode.NodeParams, GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                EditorGUILayout.LabelField("节点参数说明:", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                var nodeparamintroduction = GetNodeParamsIntroduction(mCurrentClickNode);
                GUILayout.Label(nodeparamintroduction, "textarea", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(40.0f));
                EditorGUILayout.LabelField("节点介绍:", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                var nodeintroduction = GetNodeIntroduction(mCurrentClickNode);
                GUILayout.Label(nodeintroduction, "textarea", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(40.0f));
                DisplayNodeVariableInspector(mCurrentClickNode);
                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                EditorGUILayout.LabelField("未选中有效节点!", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                EditorGUILayout.EndVertical();
            }
        }

        /// <summary>
        /// 显示指定节点的自定义变量数据显示
        /// </summary>
        /// <param name="node"></param>
        private void DisplayNodeVariableInspector(BTNode node)
        {
            var halftoolbarwidth = ToolBarWidth / 2 - 10f;
            EditorGUILayout.BeginVertical();
            if (BTUtilities.IsSetShareVariableAction(mCurrentClickNode.NodeName))
            {
                var variablenodevalue = mCurrentClickNode.OwnerBTGraph.GetVariableNodeValueInEditor(mCurrentClickNode.UID);
                if(variablenodevalue != null)
                {
                    DrawOneVariableNodeName(mCurrentClickNode.OwnerBTGraph, variablenodevalue, halftoolbarwidth - 40.0f, halftoolbarwidth + 40.0f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("目标值:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
                    DrawOneVariableNodeValue(variablenodevalue, halftoolbarwidth + 40.0f);
                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                    EditorGUILayout.LabelField("未选中有效节点!", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    EditorGUILayout.EndVertical();
                }
            }
            else if (BTUtilities.IsCompareToShareVariableCondition(mCurrentClickNode.NodeName))
            {
                var variablenodevalue = mCurrentClickNode.OwnerBTGraph.GetVariableNodeValueInEditor(mCurrentClickNode.UID);
                if (variablenodevalue != null)
                {
                    DrawOneVariableNodeName(mCurrentClickNode.OwnerBTGraph, variablenodevalue, halftoolbarwidth - 40.0f, halftoolbarwidth + 40.0f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("比较值:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
                    DrawOneVariableNodeValue(variablenodevalue, halftoolbarwidth + 40.0f);
                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                    EditorGUILayout.LabelField("未选中有效节点!", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    EditorGUILayout.EndVertical();
                }
            }
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// 绘制一个节点自定义变量名字
        /// </summary>
        /// <param name="ownergraph"></param>
        /// <param name="variablenodevalue"></param>
        /// <param name="titlewidth"></param>
        /// <param name="contentwidth"></param>
        /// <param name="allowchangevalue"></param>
        private void DrawOneVariableNodeName(BTGraph ownergraph, CustomVariableNodeData variablenodevalue, float titlewidth, float contentwidth, bool allowchangevalue = true)
        {
            EditorGUILayout.BeginHorizontal();
            var allavaliblevariablenames = ownergraph.GetCustomVariableNames(variablenodevalue.VariableType);
            EditorGUILayout.LabelField("变量名:", GUILayout.Width(titlewidth), GUILayout.Height(20.0f));
            var variablenameindex = Array.FindIndex<string>(allavaliblevariablenames, (variablename) =>
            {
                return variablename == variablenodevalue.VariableName;
            });
            // 如果当前用到的自定义变量名被删除了默认置空
            if (variablenameindex == -1)
            {
                variablenameindex = 0;
            }
            if(allowchangevalue)
            {
                variablenameindex = EditorGUILayout.Popup(variablenameindex, allavaliblevariablenames, GUILayout.Width(contentwidth), GUILayout.Height(20.0f));
            }
            else
            {
                EditorGUILayout.Popup(variablenameindex, allavaliblevariablenames, GUILayout.Width(contentwidth), GUILayout.Height(20.0f));
            }
            // 实时更新变量名
            variablenodevalue.VariableName = allavaliblevariablenames[variablenameindex];
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// 绘制一个节点自定义变量值选项
        /// </summary>
        /// <param name="variablenodedata"></param>
        /// <param name="width"></param>
        /// <param name="allowchangevalue"></param>
        private void DrawOneVariableNodeValue(CustomVariableNodeData variablenodevalue, float width, bool allowchangevalue = true)
        {
            if (variablenodevalue.VariableType == EVariableType.Bool)
            {
                var customboolvariablenodedata = variablenodevalue as CustomBoolVariableNodeData;
                if (Application.isPlaying == false && allowchangevalue)
                {
                    customboolvariablenodedata.VariableValue = EditorGUILayout.Toggle(customboolvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.Toggle(customboolvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
            }
            else if (variablenodevalue.VariableType == EVariableType.Int)
            {
                var customintvariablenodedata = variablenodevalue as CustomIntVariableNodeData;
                if (Application.isPlaying == false && allowchangevalue)
                {
                    customintvariablenodedata.VariableValue = EditorGUILayout.IntField(customintvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.IntField(customintvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
            }
            else if (variablenodevalue.VariableType == EVariableType.String)
            {
                var customstringvariablenodedata = variablenodevalue as CustomStringVariableNodeData;
                if (Application.isPlaying == false && allowchangevalue)
                {
                    customstringvariablenodedata.VariableValue = EditorGUILayout.TextField(customstringvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.TextField(customstringvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
            }
            else if (variablenodevalue.VariableType == EVariableType.Float)
            {
                var customfloatvariablenodedata = variablenodevalue as CustomFloatVariableNodeData;
                if (Application.isPlaying == false && allowchangevalue)
                {
                    customfloatvariablenodedata.VariableValue = EditorGUILayout.FloatField(customfloatvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.FloatField(customfloatvariablenodedata.VariableValue, GUILayout.Width(width), GUILayout.Height(20.0f));
                }
            }
            else
            {
                EditorGUILayout.LabelField($"不支持的变量类型:{variablenodevalue.VariableType}", "textarea", GUILayout.Width(width), GUILayout.Height(20.0f));
            }
        }

        /// <summary>
        /// 绘制变量面板
        /// </summary>
        private void DrawVariablesPanel()
        {
            if (mCurrentSelectionBTGraphAsset != null)
            {
                var toolbarwidth = ToolBarWidth / mToolBarStrings.Length - 10;
                EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("变量名:", GUILayout.Width(toolbarwidth), GUILayout.Height(20.0f));
                mCurrentVariableName = GUILayout.TextField(mCurrentVariableName, GUILayout.Width(ToolBarWidth - toolbarwidth - 20), GUILayout.Height(20.0f));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("类型:", GUILayout.Width(toolbarwidth), GUILayout.Height(20.0f));
                mCurrentSelectedVariableType = (EVariableType)EditorGUILayout.EnumPopup("", mCurrentSelectedVariableType, GUILayout.Width(toolbarwidth), GUILayout.Height(20.0f));
                if (Application.isPlaying == false)
                {
                    if (GUILayout.Button("添加", GUILayout.Width(toolbarwidth), GUILayout.Height(20.0f)))
                    {
                        if (string.IsNullOrEmpty(mCurrentVariableName) == false)
                        {
                            if (mCurrentSelectionBTGraph.IsVariableNameAvalible(mCurrentVariableName))
                            {
                                var customvariabledata = mCurrentSelectionBTGraph.GetVariableDefaultValueInEditor(mCurrentVariableName, mCurrentSelectedVariableType);
                                mCurrentSelectionBTGraph.AddCustomVariableData(customvariabledata);
                            }
                            else
                            {
                                Debug.LogError($"变量名已存在不可重复定义!");
                            }
                        }
                        else
                        {
                            Debug.LogError($"不允许设置空的变量名!");
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
                for (int i = 0, length = mCurrentSelectionBTGraph.AllBoolVariableDataList.Count; i < length; i++)
                {
                    DrawOneCustomVariable(mCurrentSelectionBTGraph.AllBoolVariableDataList[i]);
                }
                for (int i = 0, length = mCurrentSelectionBTGraph.AllIntVariableDataList.Count; i < length; i++)
                {
                    DrawOneCustomVariable(mCurrentSelectionBTGraph.AllIntVariableDataList[i]);
                }
                for (int i = 0, length = mCurrentSelectionBTGraph.AllFloatVariableDataList.Count; i < length; i++)
                {
                    DrawOneCustomVariable(mCurrentSelectionBTGraph.AllFloatVariableDataList[i]);
                }
                for (int i = 0, length = mCurrentSelectionBTGraph.AllStringVariableDataList.Count; i < length; i++)
                {
                    DrawOneCustomVariable(mCurrentSelectionBTGraph.AllStringVariableDataList[i]);
                }
                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                EditorGUILayout.LabelField("未选中有效节点!", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                EditorGUILayout.EndVertical();
            }
        }

        /// <summary>
        /// 绘制一个自定义变量
        /// </summary>
        /// <param name="customvariabledata"></param>
        private void DrawOneCustomVariable(CustomVariableData customvariabledata)
        {
            EditorUtilities.DrawUILine();
            var halftoolbarwidth = ToolBarWidth / 2 - 10;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("变量名:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
            EditorGUILayout.LabelField(customvariabledata.VariableName, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            if (Application.isPlaying == false)
            {
                if (GUILayout.Button("×", GUILayout.Width(40f), GUILayout.Height(15.0f)))
                {
                    if (mCurrentSelectionBTGraph != null)
                    {
                        mCurrentSelectionBTGraph.RemoveCustomVariableData(customvariabledata);
                    }
                    else
                    {
                        Debug.LogError($"当前未选中有效行为树,移除自定义变量失败!");
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("类型:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
            GUILayout.Label(customvariabledata.VariableType.ToString(), "textarea", GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("变量值:", GUILayout.Width(halftoolbarwidth - 40f), GUILayout.Height(20.0f));
            if (customvariabledata.VariableType == EVariableType.Bool)
            {
                var customboolvariabledata = customvariabledata as CustomBoolVariableData;
                if (Application.isPlaying == false)
                {
                    customboolvariabledata.VariableValue = EditorGUILayout.Toggle(customboolvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.Toggle(customboolvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
            }
            else if (customvariabledata.VariableType == EVariableType.Int)
            {
                var customintvariabledata = customvariabledata as CustomIntVariableData;
                if (Application.isPlaying == false)
                {
                    customintvariabledata.VariableValue = EditorGUILayout.IntField(customintvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.IntField(customintvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
            }
            else if (customvariabledata.VariableType == EVariableType.String)
            {
                var customstringvariabledata = customvariabledata as CustomStringVariableData;
                if (Application.isPlaying == false)
                {
                    customstringvariabledata.VariableValue = EditorGUILayout.TextField(customstringvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.TextField(customstringvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
            }
            else if (customvariabledata.VariableType == EVariableType.Float)
            {
                var customfloatvariabledata = customvariabledata as CustomFloatVariableData;
                if (Application.isPlaying == false)
                {
                    customfloatvariabledata.VariableValue = EditorGUILayout.FloatField(customfloatvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
                else
                {
                    EditorGUILayout.FloatField(customfloatvariabledata.VariableValue, GUILayout.Width(halftoolbarwidth + 40f), GUILayout.Height(20.0f));
                }
            }
            else
            {
                EditorGUILayout.LabelField($"不支持的变量类型:{customvariabledata.VariableType}", "textarea", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// 保存行为树
        /// </summary>
        private bool TrySaveBTAsset()
        {
            if (Application.isPlaying == false)
            {
                if (string.IsNullOrEmpty(mCurrentSelectionBTGraph.BTFileName) == false)
                {
                    // 检查行为树的有效性
                    if (IsValideTree())
                    {
                        if (string.IsNullOrEmpty(mCurrentSelectionBTGraphAssetOriginalName) == false && !mCurrentSelectionBTGraph.BTFileName.Equals(mCurrentSelectionBTGraphAssetOriginalName) && !string.IsNullOrEmpty(mCurrentSelectionBTGraphAssetPath))
                        {
                            // 文件名有变化，自动删除老的文件
                            //var oldbtgraphassetpath = $"Assets/Resources/{BTData.BTNodeSaveFolderRelativePath}/{mCurrentSelectionBTGraphAssetOriginalName}.json";
                            var oldbtgraphassetpath = mCurrentSelectionBTGraphAssetPath;
                            Debug.Log($"文件名从:{mCurrentSelectionBTGraphAssetOriginalName}变到{mCurrentSelectionBTGraph.BTFileName},自动删除老文件:{mCurrentSelectionBTGraphAssetPath}!");
                            AssetDatabase.DeleteAsset(mCurrentSelectionBTGraphAssetPath);
                        }
                        // 矫正数据
                        CorrectBTData();
                        var asset = AssetDatabase.LoadAssetAtPath(mCurrentSelectionBTGraphAssetPath, typeof(TextAsset));
                        var isassetexist = asset != null;
                        var jsondata = JsonUtility.ToJson(mCurrentSelectionBTGraph, true);
                        var assetsavefullpath = string.Empty;
                        if (isassetexist)
                        {
                            //Asset存在
                            var assetpath = mCurrentSelectionBTGraphAssetPath;
                            assetsavefullpath = $"{Application.dataPath}{assetpath.Replace("Assets", string.Empty)}";
                            File.WriteAllText(assetsavefullpath, jsondata, Encoding.UTF8);
                            Debug.Log($"保存成功:{assetsavefullpath}");
                        }
                        else
                        {
                            //Asset不存在
                            var defaultsavefolderfullpath = $"{Application.dataPath}/Resources/{BTData.BTNodeSaveFolderRelativePath}";
                            var savefolderpath = EditorUtility.OpenFolderPanel("选择保存目录", defaultsavefolderfullpath, "");
                            if (!string.IsNullOrEmpty(savefolderpath))
                            {
                                assetsavefullpath = $"{savefolderpath}/{mCurrentSelectionBTGraph.BTFileName}.json";
                                File.WriteAllText(assetsavefullpath, jsondata, Encoding.UTF8);
                                Debug.Log($"保存成功:{assetsavefullpath}");
                            }
                            else
                            {
                                Debug.LogError("未选择有效存储目录,保存失败!");
                                return false;
                            }
                        }
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                        var newbtgraphassetpath = $"Assets{assetsavefullpath.Replace(Application.dataPath, string.Empty)}";
                        mCurrentSelectionBTGraphAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(newbtgraphassetpath);
                        LoadBTAsset(mCurrentSelectionBTGraphAsset);
                        return true;
                    }
                    else
                    {
                        Debug.LogError($"行为树有不符合条件的节点设定,保存失败!");
                        return false;
                    }
                }
                else
                {
                    Debug.LogError($"不允许导出行为树名为空的行为树数据!");
                    return false;
                }
            }
            else
            {
                Debug.LogError($"运行时不允许保存行为树文件!");
                return false;
            }
        }

        /// <summary>
        /// 矫正行为树数据
        /// Note:
        /// 未来加一些参数的时候可能以前的默认值反序列化后不对
        /// 所以在这里矫正相关数据
        /// </summary>
        private void CorrectBTData()
        {
            if (mCurrentSelectionBTGraph != null)
            {
                foreach (var node in mCurrentSelectionBTGraph.AllNodesList)
                {
                    if (node.AbortType == 0)
                    {
                        node.AbortType = node.GetNodeDefaultAbortType((EBTNodeType)node.NodeType);
                    }
                    var iscsnode = node.CheckIsCSNodeInEditor();
                    if(iscsnode != node.IsCSNode)
                    {
                        node.IsCSNode = iscsnode;
                        Debug.Log($"矫正节点UID:{node.UID}的IsCSNode:{node.IsCSNode}");
                    }
                }
            }
        }
        
        /// <summary>
        /// 所有节点重新计算生成新的UID
        /// </summary>
        private void RecaculateAllNodesUID()
        {
            if (Application.isPlaying == false)
            {
                if (mCurrentSelectionBTGraphAsset != null)
                {
                    // 新老UID映射Map，为了修改后矫正所有父节点子节点UID数据
                    // Key为老的UID，Value为新的UID
                    var oldrootuid = mCurrentSelectionBTGraph.RootNodeUID;
                    var uidmap = new Dictionary<int, int>();
                    foreach (var node in mCurrentSelectionBTGraph.AllNodesList)
                    {
                        var olduid = node.UID;
                        var uid = BTUtilities.GetNodeUID();
                        while (AllUsedNodeUIDMap.ContainsKey(uid))
                        {
                            uid = BTUtilities.GetNodeUID();
                        }
                        node.UID = uid;
                        AllUsedNodeUIDMap.Add(uid, uid);
                        //Debug.Log($"新增使用UID:{uid}");
                        AllUsedNodeUIDMap.Remove(olduid);
                        //Debug.Log($"移除使用UID:{olduid}");
                        uidmap.Add(olduid, uid);
                    }
                    // 矫正节点父节点子节点UID数据
                    foreach (var node in mCurrentSelectionBTGraph.AllNodesList)
                    {
                        if (node.IsRootNode() == false)
                        {
                            var newparentnodeuid = uidmap[node.ParentNodeUID];
                            node.ParentNodeUID = newparentnodeuid;
                        }
                        for (int i = 0, length = node.ChildNodesUIDList.Count; i < length; i++)
                        {
                            var newchildnodeuid = uidmap[node.ChildNodesUIDList[i]];
                            node.ChildNodesUIDList[i] = newchildnodeuid;
                        }
                    }
                    // 还原正确的Root节点数据
                    mCurrentSelectionBTGraph.RootNodeUID = uidmap[oldrootuid];
                    //矫正自定义变量UID数据
                    foreach (var variablenode in mCurrentSelectionBTGraph.AllBoolVariableNodeDataList)
                    {
                        var newnodeuid = uidmap[variablenode.NodeUID];
                        variablenode.NodeUID = newnodeuid;
                    }
                    foreach (var variablenode in mCurrentSelectionBTGraph.AllIntVariableNodeDataList)
                    {
                        var newnodeuid = uidmap[variablenode.NodeUID];
                        variablenode.NodeUID = newnodeuid;
                    }
                    foreach (var variablenode in mCurrentSelectionBTGraph.AllFloatVariableNodeDataList)
                    {
                        var newnodeuid = uidmap[variablenode.NodeUID];
                        variablenode.NodeUID = newnodeuid;
                    }
                    foreach (var variablenode in mCurrentSelectionBTGraph.AllStringVariableNodeDataList)
                    {
                        var newnodeuid = uidmap[variablenode.NodeUID];
                        variablenode.NodeUID = newnodeuid;
                    }
                    Debug.Log($"重新计算所有节点UID完成!");
                }
                else
                {
                    Debug.LogError($"未选中有效行为树文件,重新计算UID失败!");
                }
            }
            else
            {
                Debug.LogError($"运行时不允许重新计算生成UID!");
            }
        }

        /// <summary>
        /// 新建行为树Asset
        /// </summary>
        private void CreateNewBTAsset()
        {
            Debug.Log($"创建新的行为树!");
            mCurrentSelectionBTGraph = new BTGraph(DefaultBTGrapshFileName);
            // 创建一个默认的空的BTNode
            var rootnode = new BTNode(mCurrentSelectionBTGraph, GetNodeRect(new Vector2(ToolBarWidth, 50.0f)), 0, "Root", EBTNodeType.EntryNodeType, null, AllUsedNodeUIDMap);
            mCurrentSelectionBTGraph.SetRootNode(rootnode);
            mCurrentSelectionBTGraphAsset = null;
            mCurrentSelectionBTGraphAssetOriginalName = DefaultBTGrapshFileName;
        }

        /// <summary>
        /// 获取指定节点的参数介绍
        /// </summary>
        /// <param name="btnode"></param>
        /// <returns></returns>
        private string GetNodeParamsIntroduction(BTNode btnode)
        {
            if (btnode.NodeType == (int)EBTNodeType.ActionNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTLuaActionNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTLuaActionNodeParamsIntroArray.Length)
                    {
                        return BTNodeData.BTLuaActionNodeParamsIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTLuaActionNodeParamsIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    var index2 = Array.FindIndex<string>(BTNodeData.BTCSActionNodeNameArray, (name) =>
                    {
                        return name.Equals(btnode.NodeName);
                    });
                    if (index2 != -1)
                    {
                        if (index < BTNodeData.BTCSActionNodeParamsIntroArray.Length)
                        {
                            return BTNodeData.BTCSActionNodeParamsIntroArray[index2];
                        }
                        else
                        {
                            return "请在BTNodeData.cs BTCSActionNodeParamsIntroArray里添加对应介绍!";
                        }
                    }
                    else
                    {
                        return $"找不到节点名:{btnode.NodeName}定义";
                    }
                }
            }
            else if (btnode.NodeType == (int)EBTNodeType.ConditionNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTLuaConditionNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTLuaConditionNodeParamsIntroArray.Length)
                    {
                        return BTNodeData.BTLuaConditionNodeParamsIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTLuaConditionNodeParamsIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    var index2 = Array.FindIndex<string>(BTNodeData.BTCSConditionNodeNameArray, (name) =>
                    {
                        return name.Equals(btnode.NodeName);
                    });
                    if (index2 != -1)
                    {
                        if (index < BTNodeData.BTCSConditionNodeParamsIntroArray.Length)
                        {
                            return BTNodeData.BTCSConditionNodeParamsIntroArray[index2];
                        }
                        else
                        {
                            return "请在BTNodeData.cs BTCSConditionNodeParamsIntroArray里添加对应介绍!";
                        }
                    }
                    else
                    {
                        return $"找不到节点名:{btnode.NodeName}定义";
                    }
                }
            }
            else if (btnode.NodeType == (int)EBTNodeType.DecorationNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTDecorationNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTDecorationNodeParamsIntroArray.Length)
                    {
                        return BTNodeData.BTDecorationNodeParamsIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTDecorationNodeParamsIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    return $"找不到节点名:{btnode.NodeName}定义";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取指定节点介绍
        /// </summary>
        /// <param name="btnode"></param>
        /// <returns></returns>
        private string GetNodeIntroduction(BTNode btnode)
        {
            if (btnode.NodeType == (int)EBTNodeType.CompositeNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTCompositeNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTCompositeNodeIntroArray.Length)
                    {
                        return BTNodeData.BTCompositeNodeIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTCompositeNodeIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    return $"找不到节点名:{btnode.NodeName}定义";
                }
            }
            else if (btnode.NodeType == (int)EBTNodeType.ActionNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTLuaActionNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTLuaActionNodeIntroArray.Length)
                    {
                        return BTNodeData.BTLuaActionNodeIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTLuaActionNodeIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    var index2 = Array.FindIndex<string>(BTNodeData.BTCSActionNodeNameArray, (name) =>
                    {
                        return name.Equals(btnode.NodeName);
                    });
                    if(index2 != -1)
                    {
                        if (index2 < BTNodeData.BTCSActionNodeIntroArray.Length)
                        {
                            return BTNodeData.BTCSActionNodeIntroArray[index2];
                        }
                        else
                        {
                            return "请在BTNodeData.cs BTCSActionNodeIntroArray里添加对应介绍!";
                        }
                    }
                    else
                    {
                        return $"找不到节点名:{btnode.NodeName}定义";
                    }
                }
            }
            else if (btnode.NodeType == (int)EBTNodeType.ConditionNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTLuaConditionNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTLuaConditionNodeIntroArray.Length)
                    {
                        return BTNodeData.BTLuaConditionNodeIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTLuaConditionNodeIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    var index2 = Array.FindIndex<string>(BTNodeData.BTCSConditionNodeNameArray, (name) =>
                    {
                        return name.Equals(btnode.NodeName);
                    });
                    if (index2 != -1)
                    {
                        if (index2 < BTNodeData.BTCSConditionNodeIntroArray.Length)
                        {
                            return BTNodeData.BTCSConditionNodeIntroArray[index2];
                        }
                        else
                        {
                            return "请在BTNodeData.cs BTCSConditionNodeIntroArray里添加对应介绍!";
                        }
                    }
                    else
                    {
                        return $"找不到节点名:{btnode.NodeName}定义";
                    }
                }
            }
            else if (btnode.NodeType == (int)EBTNodeType.DecorationNodeType)
            {
                var index = Array.FindIndex<string>(BTNodeData.BTDecorationNodeNameArray, (name) =>
                {
                    return name.Equals(btnode.NodeName);
                });
                if (index != -1)
                {
                    if (index < BTNodeData.BTDecorationNodeIntroArray.Length)
                    {
                        return BTNodeData.BTDecorationNodeIntroArray[index];
                    }
                    else
                    {
                        return "请在BTNodeData.cs BTDecorationNodeIntroArray里添加对应介绍!";
                    }
                }
                else
                {
                    return $"找不到节点名:{btnode.NodeName}定义";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 检查是否是有效行为树
        /// </summary>
        /// <returns></returns>
        private bool IsValideTree()
        {
            if (mCurrentSelectionBTGraph != null && mCurrentSelectionBTGraph.IsValideGraph())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 绘制行为树节点
        /// </summary>
        private void DrawBTNode()
        {
            mWindowScrollPos = GUI.BeginScrollView(new Rect(InspectorWindowWidth, 0, position.width - InspectorWindowWidth, position.height), mWindowScrollPos, new Rect(0, 0, NodeAreaWindowWidth, NodeAreaWindowHeight));
            if (mCurrentSelectionBTGraph != null)
            {
                DrawNodeCurves(mCurrentSelectionBTGraph, mCurrentSelectionBTGraph.RootNode);
                BeginWindows();
                DrawNodes(mCurrentSelectionBTGraph, mCurrentSelectionBTGraph.RootNode);
                EndWindows();
            }
            GUI.EndScrollView();
        }

        /// <summary>
        /// 绘制节点所有相关连线
        /// </summary>
        /// <param name="btgraph"></param>
        /// <param name="node"></param>
        private void DrawNodeCurves(BTGraph btgraph, BTNode node)
        {
            if(node != null && node.ChildNodesUIDList != null)
            {
                for (int i = 0; i < node.ChildNodesUIDList.Count; i++)
                {
                    var childnode = btgraph.FindNodeByUID(node.ChildNodesUIDList[i]);
                    if (childnode != null)
                    {
                        var curvecolor = mNormalCurveColor;
                        if(btgraph.IsNodeRunning(node.UID) && btgraph.IsNodeRunning(childnode.UID))
                        {
                            curvecolor = mRunningCurveColor;
                        }
                        DrawCurve(node.NodeDisplayRect, childnode.NodeDisplayRect, curvecolor);
                        DrawNodeCurves(btgraph, childnode);
                    }
                }
            }
        }

        /// <summary>
        /// 绘制连线
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="curvecolor"></param>
        private void DrawCurve(Rect start, Rect end, Color curvecolor)
        {
            Vector3 startpos = new Vector3(start.x + start.width / 2, start.y + start.height, 0);
            Vector3 endpos = new Vector3(end.x + end.width / 2, end.y, 0);
            Vector3 starttangent = startpos + Vector3.up * 40;
            Vector3 endtangent = endpos + Vector3.down * 40;
            Handles.DrawBezier(startpos, endpos, starttangent, endtangent, curvecolor, null, 2);
        }

        /// <summary>
        /// 绘制节点
        /// </summary>
        /// <param name="btgraph"></param>
        /// <param name="node"></param>
        private void DrawNodes(BTGraph btgraph, BTNode node)
        {
            if (node != null)
            {
                var title = node.IsRootNode() ? "Root" : $"No.{node.NodeIndex}";
                GUI.color = GetNodeTypeColor((EBTNodeType)node.NodeType);
                var prenodedisplayrect = node.NodeDisplayRect;
                node.NodeDisplayRect = GUI.Window(node.UID, node.NodeDisplayRect, DrawNodeWindow, new GUIContent(title));
                if (node.NodeDisplayRect.Equals(prenodedisplayrect) == false)
                {
                    node.NodeDisplayRect.x = Mathf.Clamp(node.NodeDisplayRect.x, 0, NodeAreaWindowWidth - NodeWindowWidth);
                    node.NodeDisplayRect.y = Mathf.Clamp(node.NodeDisplayRect.y, 0, NodeAreaWindowHeight - NodeWindowHeight);
                    // 如果开启了子节点一起移动，控制子节点一起相对移动
                    if (IsEnableMoveWithChildNodes)
                    {
                        var moveoffset = Vector2.zero;
                        moveoffset.x = node.NodeDisplayRect.x - prenodedisplayrect.x;
                        moveoffset.y = node.NodeDisplayRect.y - prenodedisplayrect.y;
                        foreach (var childnodeuid in node.ChildNodesUIDList)
                        {
                            var childnode = btgraph.FindNodeByUID(childnodeuid);
                            childnode.Move(btgraph, moveoffset, true);
                        }
                    }
                }
                GUI.color = Color.white;
                for (int i = 0; i < node.ChildNodesUIDList.Count; ++i)
                {
                    var childnode = btgraph.FindNodeByUID(node.ChildNodesUIDList[i]);
                    if (childnode != null)
                    {
                        DrawNodes(btgraph, childnode);
                    }
                }
            }
        }

        /// <summary>
        /// 绘制节点窗口
        /// </summary>
        /// <param name="uid"></param>
        private void DrawNodeWindow(int uid)
        {
            var customvariablewidth = NodeWindowWidth / 2f;
            var btnode = mCurrentSelectionBTGraph.FindNodeByUID(uid);
            if (btnode == null)
            {
                return;
            }
            BTGraph btgraph = null;
            if(btnode != null && btnode.OwnerBT != null && btnode.OwnerBT.BTRunningGraph != null)
            {
                btgraph = btnode.OwnerBT.BTRunningGraph;
            }
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField($"{btnode.NodeName}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
            EditorGUILayout.EndVertical();
            if (IsDebugMode)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField($"{GetNodeTypeName((EBTNodeType)btnode.NodeType)}-状态:{btnode.LastNodeRunningState.ToString()}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField($"UID:{btnode.UID}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField($"{GetNodeTypeName((EBTNodeType)btnode.NodeType)}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.BeginVertical("box");
            if(BTUtilities.IsSetShareVariableAction(btnode.NodeName))
            {
                var variablenodevalue = btnode.OwnerBTGraph.GetVariableNodeValueInEditor(btnode.UID);
                DrawOneVariableNodeName(btnode.OwnerBTGraph, variablenodevalue, customvariablewidth - 30.0f, customvariablewidth + 10.0f, false);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("目标值:", GUILayout.Width(customvariablewidth - 30.0f), GUILayout.Height(20.0f));
                DrawOneVariableNodeValue(variablenodevalue, customvariablewidth + 10.0f, false);
                EditorGUILayout.EndHorizontal();
            }
            else if(BTUtilities.IsCompareToShareVariableCondition(btnode.NodeName))
            {
                var variablenodevalue = btnode.OwnerBTGraph.GetVariableNodeValueInEditor(btnode.UID);
                DrawOneVariableNodeName(btnode.OwnerBTGraph, variablenodevalue, customvariablewidth - 30.0f, customvariablewidth + 10.0f, false);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("比较值:", GUILayout.Width(customvariablewidth - 30.0f), GUILayout.Height(20.0f));
                DrawOneVariableNodeValue(variablenodevalue, customvariablewidth + 10.0f, false);
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.LabelField($"节点参数:", mLableAlignLeftStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
                GUILayout.Label($"{btnode.NodeParams}", "textarea", GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(40.0f));
            }
            EditorGUILayout.EndVertical();
            // 仅Editor非运行时允许拖拽
            if (Application.isPlaying == false)
            {
                GUI.DragWindow(mNodeWindowDragableRect);
            }
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
            if(mNodeTypeColorMap.ContainsKey(nodetype))
            {
                return mNodeTypeColorMap[nodetype];
            }
            else
            {
                // 意外情况处理
                return Color.white;
            }
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

        #region 菜单部分
        /// <summary>
        /// 初始化菜单
        /// </summary>
        private void InitMenu()
        {
            mNodeMenuMap = new Dictionary<EBTMenuType, GenericMenu>();
        }

        /// <summary>
        /// 更新操作菜单
        /// </summary>
        private void UpdateMenus()
        {
            mEmptyAreaMenu = new GenericMenu();
            mEmptyAreaMenu.AddItem(new GUIContent("待添加"), false, null, mCurrentSelectionBTGraph);
            mRootNodeAreaMenu = new GenericMenu();
            AddAllAvalibleAddBTNodeMenu(mRootNodeAreaMenu, mCurrentClickNode);

            mChildNodeAreaMenu = new GenericMenu();
            AddAllAvalibleAddBTNodeMenu(mChildNodeAreaMenu, mCurrentClickNode);
            AddAllAvalibleReplaceBTNodeMenu(mChildNodeAreaMenu, mCurrentClickNode);
            mChildNodeAreaMenu.AddItem(new GUIContent("向前移动节点"), false, OnMoveForwardBTNode, mCurrentClickNode);
            mChildNodeAreaMenu.AddItem(new GUIContent("向后移动节点"), false, OnMoveBackwardBTNode, mCurrentClickNode);
            mChildNodeAreaMenu.AddItem(new GUIContent("删除节点"), false, OnDeleteBTNode, mCurrentClickNode);

            mLeafNodeAreaMenu = new GenericMenu();
            AddAllAvalibleReplaceBTNodeMenu(mLeafNodeAreaMenu, mCurrentClickNode);
            mLeafNodeAreaMenu.AddItem(new GUIContent("向前移动节点"), false, OnMoveForwardBTNode, mCurrentClickNode);
            mLeafNodeAreaMenu.AddItem(new GUIContent("向后移动节点"), false, OnMoveBackwardBTNode, mCurrentClickNode);
            mLeafNodeAreaMenu.AddItem(new GUIContent("删除节点"), false, OnDeleteBTNode, mCurrentClickNode);

            mNodeMenuMap.Clear();
            mNodeMenuMap.Add(EBTMenuType.EmptyAreaMenu, mEmptyAreaMenu);
            mNodeMenuMap.Add(EBTMenuType.RootNodeAreaMenu, mRootNodeAreaMenu);
            mNodeMenuMap.Add(EBTMenuType.ChildNodeAreaMenu, mChildNodeAreaMenu);
            mNodeMenuMap.Add(EBTMenuType.ActionLeafNodeAreaMenu, mLeafNodeAreaMenu);
        }

        /// <summary>
        /// 添加所有可用的行为树节点菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="operationnode"></param>
        private void AddAllAvalibleAddBTNodeMenu(GenericMenu menu, BTNode operationnode)
        {
            foreach (var luaactionnodename in BTNodeData.BTLuaActionNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, luaactionnodename);
                menu.AddItem(new GUIContent($"添加子节点/行为节点/{luaactionnodename}"), false, OnCreateBTActionNode, nodeinfo);
            }
            foreach (var csactionnodename in BTNodeData.BTCSActionNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, csactionnodename);
                menu.AddItem(new GUIContent($"添加子节点/行为节点/{csactionnodename}"), false, OnCreateBTActionNode, nodeinfo);
            }
            foreach (var compositenodename in BTNodeData.BTCompositeNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, compositenodename);
                menu.AddItem(new GUIContent($"添加子节点/组合节点/{compositenodename}"), false, OnCreateBTCompositeNode, nodeinfo);
            }
            foreach (var luaconditionnodename in BTNodeData.BTLuaConditionNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, luaconditionnodename);
                menu.AddItem(new GUIContent($"添加子节点/条件节点/{luaconditionnodename}"), false, OnCreateBTConditionNode, nodeinfo);
            }
            foreach (var csconditionnodename in BTNodeData.BTCSConditionNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, csconditionnodename);
                menu.AddItem(new GUIContent($"添加子节点/条件节点/{csconditionnodename}"), false, OnCreateBTConditionNode, nodeinfo);
            }
            foreach (var decorationnodename in BTNodeData.BTDecorationNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, decorationnodename);
                menu.AddItem(new GUIContent($"添加子节点/装饰节点/{decorationnodename}"), false, OnCreateBTDecorationNode, nodeinfo);
            }
        }

        /// <summary>
        /// 添加所有可替换的行为树节点菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="operationnode"></param>
        private void AddAllAvalibleReplaceBTNodeMenu(GenericMenu menu, BTNode operationnode)
        {
            if (operationnode != null)
            {
                // 替换节点只允许替换同类型节点
                string validereplacetypename = "";
                List<string> validereplacenodenamelist = new List<string>();
                if (operationnode.NodeType == (int)EBTNodeType.ActionNodeType)
                {
                    validereplacetypename = "行为节点";
                    validereplacenodenamelist.AddRange(BTNodeData.BTLuaActionNodeNameArray);
                    validereplacenodenamelist.AddRange(BTNodeData.BTCSActionNodeNameArray);
                }
                else if (operationnode.NodeType == (int)EBTNodeType.CompositeNodeType)
                {
                    validereplacetypename = "组合节点";
                    validereplacenodenamelist.AddRange(BTNodeData.BTCompositeNodeNameArray);
                }
                else if (operationnode.NodeType == (int)EBTNodeType.ConditionNodeType)
                {
                    validereplacetypename = "条件节点";
                    validereplacenodenamelist.AddRange(BTNodeData.BTLuaConditionNodeNameArray);
                    validereplacenodenamelist.AddRange(BTNodeData.BTCSConditionNodeNameArray);
                }
                else if (operationnode.NodeType == (int)EBTNodeType.DecorationNodeType)
                {
                    validereplacetypename = "装饰节点";
                    validereplacenodenamelist.AddRange(BTNodeData.BTDecorationNodeNameArray);
                }
                if (string.IsNullOrEmpty(validereplacetypename) == false)
                {
                    foreach (var nodename in validereplacenodenamelist)
                    {
                        var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, nodename);
                        menu.AddItem(new GUIContent($"替换/{validereplacetypename}/{nodename}"), false, OnReplaceBTNode, nodeinfo);
                    }
                }
            }
        }

        /// <summary>
        /// 响应创建行为节点
        /// </summary>
        /// <param name="createnodeinfo">创建节点信息</param>
        private void OnCreateBTActionNode(object createnodeinfo)
        {
            var nodeinfo = createnodeinfo as CreateNodeInfo;
            if (nodeinfo.OperateNode.IsDecorationNode() && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"装饰节点只允许创建一个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"根节点不允许创建多个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == false || (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count == 0))
            {
                var childnodeposx = nodeinfo.OperateNode.NodeDisplayRect.x;
                var childindex = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.OperateNode.ChildNodesUIDList.Count : 0;
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    BTNode lastchildnode = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]) : nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[0]);
                    childnodeposx = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? lastchildnode.NodeDisplayRect.x + NodeWindowWidth : lastchildnode.NodeDisplayRect.x - NodeWindowWidth;
                }
                var childnode = new BTNode(
                    nodeinfo.Graph,
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    childindex,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.ActionNodeType,
                    nodeinfo.OperateNode,
                    AllUsedNodeUIDMap
                    );
                if (mCurrentSelectionBTGraph.AddNode(childnode))
                {
                    TryAddCustomVariableNodeData(childnode);
                    nodeinfo.OperateNode.AddChildNode(childnode.UID, nodeinfo.Graph, childnode.NodeIndex);
                }
                Debug.Log($"OnCreateBTActionNode()");
                Debug.Log($"ParentNodeName:{nodeinfo.OperateNode.NodeName} ChildNodeName:{nodeinfo.CreateNodeName}");
            }
            else
            {
                Debug.LogError($"未支持的创建情况!");
            }
        }

        /// <summary>
        /// 响应创建组合节点
        /// </summary>
        /// <param name="createnodeinfo">创建节点信息</param>
        private void OnCreateBTCompositeNode(object createnodeinfo)
        {
            var nodeinfo = createnodeinfo as CreateNodeInfo;
            if (nodeinfo.OperateNode.IsDecorationNode() && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"装饰节点只允许创建一个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"根节点不允许创建多个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == false || (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count == 0))
            {
                var childnodeposx = nodeinfo.OperateNode.NodeDisplayRect.x;
                var childindex = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.OperateNode.ChildNodesUIDList.Count : 0;
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    BTNode lastchildnode = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]) : nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[0]);
                    childnodeposx = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? lastchildnode.NodeDisplayRect.x + NodeWindowWidth : lastchildnode.NodeDisplayRect.x - NodeWindowWidth;
                }
                var childnode = new BTNode(
                    nodeinfo.Graph,
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    childindex,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.CompositeNodeType,
                    nodeinfo.OperateNode,
                    AllUsedNodeUIDMap
                    );
                if (mCurrentSelectionBTGraph.AddNode(childnode))
                {
                    nodeinfo.OperateNode.AddChildNode(childnode.UID, nodeinfo.Graph, childnode.NodeIndex);
                }
                Debug.Log($"OnCreateBTCompositeNode()");
                Debug.Log($"ParentNodeName:{nodeinfo.OperateNode.NodeName} ChildNodeName:{nodeinfo.CreateNodeName}");
            }
            else
            {
                Debug.LogError($"未支持的创建情况!");
            }
        }

        /// <summary>
        /// 响应创建条件节点
        /// </summary>
        /// <param name="createnodeinfo">创建节点信息</param>
        private void OnCreateBTConditionNode(object createnodeinfo)
        {
            var nodeinfo = createnodeinfo as CreateNodeInfo;
            if (nodeinfo.OperateNode.IsDecorationNode() && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"装饰节点只允许创建一个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"根节点不允许创建多个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == false || (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count == 0))
            {
                var childnodeposx = nodeinfo.OperateNode.NodeDisplayRect.x;
                var childindex = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.OperateNode.ChildNodesUIDList.Count : 0;
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    BTNode lastchildnode = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]) : nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[0]);
                    childnodeposx = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? lastchildnode.NodeDisplayRect.x + NodeWindowWidth : lastchildnode.NodeDisplayRect.x - NodeWindowWidth;
                }
                var childnode = new BTNode(
                    nodeinfo.Graph,
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    childindex,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.ConditionNodeType,
                    nodeinfo.OperateNode,
                    AllUsedNodeUIDMap
                    );
                if (mCurrentSelectionBTGraph.AddNode(childnode))
                {
                    TryAddCustomVariableNodeData(childnode);
                    nodeinfo.OperateNode.AddChildNode(childnode.UID, nodeinfo.Graph, childnode.NodeIndex);
                }
                Debug.Log($"OnCreateBTConditionNode()");
                Debug.Log($"ParentNodeName:{nodeinfo.OperateNode.NodeName} ChildNodeName:{nodeinfo.CreateNodeName}");
            }
            else
            {
                Debug.LogError($"未支持的创建情况!");
            }
        }

        /// <summary>
        /// 响应创建修饰节点
        /// </summary>
        /// <param name="createnodeinfo">创建节点信息</param>
        private void OnCreateBTDecorationNode(object createnodeinfo)
        {
            var nodeinfo = createnodeinfo as CreateNodeInfo;
            if (nodeinfo.OperateNode.IsDecorationNode() && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"装饰节点只允许创建一个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
            {
                Debug.LogError($"根节点不允许创建多个子节点!");
            }
            else if (nodeinfo.OperateNode.IsRootNode() == false || (nodeinfo.OperateNode.IsRootNode() == true && nodeinfo.OperateNode.ChildNodesUIDList.Count == 0))
            {
                var childnodeposx = nodeinfo.OperateNode.NodeDisplayRect.x;
                var childindex = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.OperateNode.ChildNodesUIDList.Count : 0;
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    BTNode lastchildnode = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]) : nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[0]);
                    childnodeposx = mCurrentCreateNodeStrategy == ECreateNodeStrategy.ToEnd ? lastchildnode.NodeDisplayRect.x + NodeWindowWidth : lastchildnode.NodeDisplayRect.x - NodeWindowWidth;
                }
                var childnode = new BTNode(
                    nodeinfo.Graph,
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    childindex,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.DecorationNodeType,
                    nodeinfo.OperateNode,
                    AllUsedNodeUIDMap
                    );
                if (mCurrentSelectionBTGraph.AddNode(childnode))
                {
                    nodeinfo.OperateNode.AddChildNode(childnode.UID, nodeinfo.Graph, childnode.NodeIndex);
                }
                Debug.Log($"OnCreateBTDecorationNode()");
                Debug.Log($"ParentNodeName:{nodeinfo.OperateNode.NodeName} ChildNodeName:{nodeinfo.CreateNodeName}");
            }
            else
            {
                Debug.LogError($"未支持的创建情况!");
            }
        }
        
        /// <summary>
        /// 尝试添加自定义变量节点数据
        /// </summary>
        /// <param name="node"></param>
        private void TryAddCustomVariableNodeData(BTNode node)
        {
            if (node.NodeType == (int)EBTNodeType.ConditionNodeType && BTUtilities.IsCompareToShareVariableCondition(node.NodeName))
            {
                var variabletype = BTUtilities.GetNodeVariableType(node.NodeName);
                var variablenodedata = BTUtilities.GetVariableNodeDefaultValueInEditor(node.UID, string.Empty, variabletype);
                node.OwnerBTGraph.AddCustomVariableNodeData(variablenodedata);
            }
            else if (node.NodeType == (int)EBTNodeType.ActionNodeType && BTUtilities.IsSetShareVariableAction(node.NodeName))
            {
                var variabletype = BTUtilities.GetNodeVariableType(node.NodeName);
                var variablenodedata = BTUtilities.GetVariableNodeDefaultValueInEditor(node.UID, string.Empty, variabletype);
                node.OwnerBTGraph.AddCustomVariableNodeData(variablenodedata);
            }
        }

        /// <summary>
        /// 响应替换节点
        /// </summary>
        /// <param name="createnodeinfo">替换节点信息</param>
        private void OnReplaceBTNode(object createnodeinfo)
        {
            var nodeinfo = createnodeinfo as CreateNodeInfo;
            Debug.Log($"节点名:{nodeinfo.OperateNode.NodeName}替换为:{nodeinfo.CreateNodeName}");
            nodeinfo.OperateNode.NodeName = nodeinfo.CreateNodeName;
        }

        /// <summary>
        /// 向前移动节点顺序
        /// </summary>
        /// <param name="movebackwardnode">需要向前移动的节点</param>
        private void OnMoveForwardBTNode(object moveforwardnode)
        {
            var node = moveforwardnode as BTNode;
            var parentnode = mCurrentSelectionBTGraph.FindNodeByUID(node.ParentNodeUID);
            mCurrentSelectionBTGraph.MoveChildNodeForward(node.ParentNodeUID, node.UID);
            Debug.Log($"OnMoveForwardBTNode({node.NodeName})");
        }

        /// <summary>
        /// 向后移动节点顺序
        /// </summary>
        /// <param name="movebackwardnode">需要向后移动的节点</param>
        private void OnMoveBackwardBTNode(object movebackwardnode)
        {
            var node = movebackwardnode as BTNode;
            var parentnode = mCurrentSelectionBTGraph.FindNodeByUID(node.ParentNodeUID);
            mCurrentSelectionBTGraph.MoveChildNodeBackward(node.ParentNodeUID, node.UID);
            Debug.Log($"OnMoveBackwardBTNode({node.NodeName})");
        }

        /// <summary>
        /// 响应删除行为树指定节点
        /// </summary>
        /// <param name="deletednode">需要删除的行为树节点</param>
        private void OnDeleteBTNode(object deletednode)
        {
            var node = deletednode as BTNode;
            mNeedDeletedUIDList.Clear();
            mNeedDeletedUIDList.Add(node.UID);
            mCurrentSelectionBTGraph.DeleteNode(node, mNeedDeletedUIDList);
            foreach (var deleteuid in mNeedDeletedUIDList)
            {
                AllUsedNodeUIDMap.Remove(deleteuid);
                //Debug.Log($"删除UID:{deleteuid}的使用!");
            }
            mNeedDeletedUIDList.Clear();
            Debug.Log($"OnDeleteBTNode({node.NodeName})");
}
        #endregion
    }
}