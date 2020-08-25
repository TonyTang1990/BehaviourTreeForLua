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
        private string[] mToolBarStrings = { "总面板", "参数面板" };

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
        private const float ToolBarWidth = 300.0f;

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
        private const float InspectorWindowWidth = 300.0f;

        /// <summary>
        /// 操作选择面板高度
        /// </summary>
        private const float InspectorWindowHeight = 2000.0f;
        #endregion

        #region 节点操作区域
        /// <summary>
        /// 节点区域窗口宽度
        /// </summary>
        private const float NodeAreaWindowWidth = 2000.0f;

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
        #endregion

        #region 数据存储
        /// <summary>
        /// 当前选择的行为树图
        /// </summary>
        private BTGraph mCurrentSelectionBTGraph;
        #endregion

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
            var rootnode = new BTNode(GetNodeRect(new Vector2(ToolBarWidth, 50.0f)), 0, "Root", EBTNodeType.EntryNodeType);
            mCurrentSelectionBTGraph = new BTGraph(DefaultBTGrapshFileName, rootnode);
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
            EditorApplication.playModeStateChanged -= OnPlayModeStateChange;
            EditorApplication.playModeStateChanged += OnPlayModeStateChange;
            //XLuaManager.EditorHookCallBack = OnXLuaInit;
            //UpdateLuaEnv();
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
            InitMenu();
        }

        private void OnDestroy()
        {
            Debug.Log($"BTNodeEditor:OnDestroy()");
            //XLuaManager.EditorHookCallBack = null;
            EditorApplication.playModeStateChanged -= OnPlayModeStateChange;
        }

        /// <summary>
        /// 响应播放状态改变
        /// </summary>
        /// <param name="state"></param>
        private static void OnPlayModeStateChange(PlayModeStateChange state)
        {
            Debug.Log($"PlayModeStateChange:{state}");
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                //CurrentLuaEnvInstance = new LuaEnv();
                //UpdateLuaData();
            }
            else if (state == PlayModeStateChange.EnteredPlayMode)
            {
                //CurrentLuaEnvInstance = null;
                //XLuaManager.EditorHookCallBack = OnXLuaInit;
                //if(XLuaManager.getInstance() != null)
                //{
                //    Debug.Log($"CurrentLuaEnvInstance = XLuaManager.getInstance().GetLuaEnv();");
                //    CurrentLuaEnvInstance = XLuaManager.getInstance().GetLuaEnv();
                //    UpdateLuaData();
                //}
            }
        }

        /// <summary>
        /// 响应Xlua初始化
        /// </summary>
        /// <param name="luaenv"></param>
        //private static void OnXLuaInit(LuaEnv luaenv)
        //{
        //    Debug.Log($"OnXLuaInit()");
        //    CurrentLuaEnvInstance = luaenv;
        //    UpdateLuaData();
        //}

        ///// <summary>
        ///// 更新Lua相关数据
        ///// </summary>
        //private static void UpdateLuaData()
        //{
        //    Debug.Log($"UpdateLuaData()");
        //    //EBTCompositeNodeName = CurrentLuaEnvInstance.DoString("require \"Core/BehaviourTree/EBTCompositeNodeName\"")[0] as LuaTable;
        //    //EBTCompositeNodeName.ForEach<string, string>(PrintKeyValue);
        //    //EBTActionNodeName = CurrentLuaEnvInstance.DoString("require \"Core/BehaviourTree/EBTActionNodeName\"")[0] as LuaTable;
        //    //EBTActionNodeName.ForEach<string, string>(PrintKeyValue);
        //    //EBTConditionNodeName = CurrentLuaEnvInstance.DoString("require \"Core/BehaviourTree/EBTConditionNodeName\"")[0] as LuaTable;
        //    //EBTConditionNodeName.ForEach<string, string>(PrintKeyValue);
        //    //EBTDecorationNodeName = CurrentLuaEnvInstance.DoString("require \"Core/BehaviourTree/EBTDecorationNodeName\"")[0] as LuaTable;
        //    //EBTDecorationNodeName.ForEach<string, string>(PrintKeyValue);
        //}

        /// <summary>
        /// 打印Key和Value
        /// </summary>
        private static void PrintKeyValue(string key, string value)
        {
            Debug.Log($"Key:{key} Value:{value}");
        }

        /// <summary>
        /// 更新LuaEnv
        /// </summary>
        /// <param name="state"></param>
        //private void UpdateLuaEnv()
        //{
        //    if(Application.isPlaying)
        //    {
        //        if(CurrentLuaEnvInstance != XLuaManager.getInstance().GetLuaEnv())
        //        {
        //            CurrentLuaEnvInstance?.Dispose();
        //            CurrentLuaEnvInstance = XLuaManager.getInstance().GetLuaEnv();
        //            UpdateLuaData();
        //            Debug.Log($"当前Lua对象为:XLuaManager.getInstance().GetLuaEnv()");
        //        }
        //    }
        //    else
        //    {
        //        if(CurrentLuaEnvInstance == null)
        //        {
        //            CurrentLuaEnvInstance = new LuaEnv();
        //            UpdateLuaData();
        //            Debug.Log($"当前Lua对象为:new LuaEnv()");
        //        }
        //    }
        //}

        /// <summary>
        /// 选中Asset变化响应
        /// </summary>
        private void OnSelectionChange()
        {
            if (Selection.objects.Length > 0)
            {
                var selectionasset = Selection.objects[0] as TextAsset;
                if (selectionasset == null)
                {
                    Debug.Log($"选中的是非TextAsset，不处理!");
                    return;
                }
                else
                {
                    var assetpath = AssetDatabase.GetAssetPath(selectionasset);
                    if (assetpath.EndsWith(".json"))
                    {
                        var btgrapshdata = JsonUtility.FromJson<BTGraph>(selectionasset.text);
                        if (btgrapshdata == null)
                        {
                            Debug.Log($"选中的是非BTGraph的Json数据，不处理!");
                            return;
                        }
                        mCurrentSelectionBTGraph = btgrapshdata;
                        mCurrentSelectionBTGraphAsset = selectionasset;
                        var currentselectionbtnodeassetpath = AssetDatabase.GetAssetPath(selectionasset);
                        Debug.Log($"选中的Asset:{Selection.objects[0].name} AssetPath:{currentselectionbtnodeassetpath}!");
                    }
                    else
                    {
                        Debug.Log($"选中的是非Json数据，不处理!");
                    }
                }
            }
        }

        private void OnGUI()
        {
            mLableAlignMiddleStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
            mLableAlignLeftStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperLeft };
            //if (CurrentLuaEnvInstance == null)
            //{
            //    DrawWaitTips();
            //}
            //else
            //{
            if (mCurrentSelectionBTGraph != null)
            {
                HandleInteraction();
                DrawOperationPanel();
                DrawBTNode();
            }
            else
            {
                EditorGUILayout.LabelField("未选中有效行为树节点或文件!", mLableAlignMiddleStyle, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            }
            //}
        }

        /// <summary>
        /// 绘制等待提示
        /// </summary>
        private void DrawWaitTips()
        {
            EditorGUILayout.LabelField("请耐心等待!", mLableAlignMiddleStyle, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        }

        /// <summary>
        /// 处理交互
        /// </summary>
        private void HandleInteraction()
        {
            if (Application.isPlaying == false)
            {
                if (Event.current.type == EventType.ContextClick)
                {
                    var nodeareamouseposition = Event.current.mousePosition;
                    nodeareamouseposition.x = nodeareamouseposition.x - InspectorWindowWidth;
                    mCurrentClickNode = mCurrentSelectionBTGraph.FindNodeByMousePos(nodeareamouseposition + mWindowScrollPos);
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
                    Event.current.Use();
                }
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
            var halftoolbarwidth = ToolBarWidth / 2 - 10f;
            if (mToolBarSelectIndex == 0)
            {
                EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("行为树名:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                mCurrentSelectionBTGraph.BTFileName = EditorGUILayout.TextField(mCurrentSelectionBTGraph.BTFileName, GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                if (mCurrentSelectionBTGraphAsset != null)
                {
                    if (GUILayout.Button("保存", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f)))
                    {
                        var jsondata = JsonUtility.ToJson(mCurrentSelectionBTGraph, true);
                        var savefolderfullpath = $"{Application.dataPath}/Resources/{BTData.BTNodeSaveFolderRelativePath}";
                        var assetfullpath = $"{savefolderfullpath}{mCurrentSelectionBTGraph.BTFileName}.json";
                        File.WriteAllText(assetfullpath, jsondata, Encoding.UTF8);
                        Debug.Log($"assetfullpath:{assetfullpath}");
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                    }
                }
                else
                {
                    if (GUILayout.Button("导出", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f)))
                    {
                        if (string.IsNullOrEmpty(mCurrentSelectionBTGraph.BTFileName) == false)
                        {
                            var jsondata = JsonUtility.ToJson(mCurrentSelectionBTGraph, true);
                            var savefolderfullpath = $"{Application.dataPath}/Resources/{BTData.BTNodeSaveFolderRelativePath}";
                            Debug.Log($"savefolderfullpath:{savefolderfullpath}");
                            if (Directory.Exists(savefolderfullpath) == false)
                            {
                                Directory.CreateDirectory(savefolderfullpath);
                            }
                            var assetfullpath = $"{savefolderfullpath}{mCurrentSelectionBTGraph.BTFileName}.json";
                            File.WriteAllText(assetfullpath, jsondata, Encoding.UTF8);
                            Debug.Log($"assetfullpath:{assetfullpath}");
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }
                        else
                        {
                            Debug.LogError($"不允许导出行为树名为空的行为树数据!");
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
            else if (mToolBarSelectIndex == 1)
            {
                if (mCurrentClickNode != null)
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("节点名:", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                    GUILayout.Label(mCurrentClickNode != null ? mCurrentClickNode.NodeName : string.Empty, "textarea", GUILayout.Width(halftoolbarwidth), GUILayout.Height(20.0f));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.LabelField("节点参数:", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    mCurrentClickNode.NodeParams = GUILayout.TextField(mCurrentClickNode.NodeParams, GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    EditorGUILayout.LabelField("节点参数说明:", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    GUILayout.Label("待添加!", "textarea", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(40.0f));
                    EditorGUILayout.EndVertical();
                }
                else
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                    EditorGUILayout.LabelField("未选中有效节点!", GUILayout.Width(ToolBarWidth - 10), GUILayout.Height(20.0f));
                    EditorGUILayout.EndVertical();
                }
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
            for (int i = 0; i < node.ChildNodesUIDList.Count; i++)
            {
                var childnode = btgraph.FindNodeByUID(node.ChildNodesUIDList[i]);
                if (childnode != null)
                {
                    DrawCurve(node.NodeDisplayRect, childnode.NodeDisplayRect);
                    DrawNodeCurves(btgraph, childnode);
                }
            }
        }

        /// <summary>
        /// 绘制连线
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void DrawCurve(Rect start, Rect end)
        {
            Vector3 startpos = new Vector3(start.x + start.width / 2, start.y + start.height, 0);
            Vector3 endpos = new Vector3(end.x + end.width / 2, end.y, 0);
            Vector3 starttangent = startpos + Vector3.up * 40;
            Vector3 endtangent = endpos + Vector3.down * 40;
            Handles.DrawBezier(startpos, endpos, starttangent, endtangent, mNormalCurveColor, null, 2);
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
            var btnode = mCurrentSelectionBTGraph.FindNodeByUID(uid);
            if (btnode == null)
            {
                return;
            }
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField($"{btnode.NodeName}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField($"{GetNodeTypeName((EBTNodeType)btnode.NodeType)}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
            EditorGUILayout.EndVertical();
            //EditorGUILayout.BeginVertical("box");
            //EditorGUILayout.LabelField($"{btnode.UID}", mLableAlignMiddleStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
            //EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField($"节点参数:", mLableAlignLeftStyle, GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(20.0f));
            GUILayout.Label($"{btnode.NodeParams}", "textarea", GUILayout.Width(NodeWindowWidth - 20f), GUILayout.Height(40.0f));
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
            foreach (var actionnodename in BTNodeData.BTActionNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, actionnodename);
                menu.AddItem(new GUIContent($"添加子节点/行为节点/{actionnodename}"), false, OnCreateBTActionNode, nodeinfo);
            }
            foreach (var compositenodename in BTNodeData.BTCompositeNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, compositenodename);
                menu.AddItem(new GUIContent($"添加子节点/组合节点/{compositenodename}"), false, OnCreateBTCompositeNode, nodeinfo);
            }
            foreach (var conditionnodename in BTNodeData.BTConditionNodeNameArray)
            {
                var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, conditionnodename);
                menu.AddItem(new GUIContent($"添加子节点/条件节点/{conditionnodename}"), false, OnCreateBTConditionNode, nodeinfo);
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
            // 替换节点只允许替换同类型节点
            string validereplacetypename = "";
            string[] validereplacenodenamearray = null;
            if (operationnode.NodeType == (int)EBTNodeType.ActionNodeType)
            {
                validereplacetypename = "行为节点";
                validereplacenodenamearray = BTNodeData.BTActionNodeNameArray;
            }
            else if (operationnode.NodeType == (int)EBTNodeType.CompositeNodeType)
            {
                validereplacetypename = "组合节点";
                validereplacenodenamearray = BTNodeData.BTCompositeNodeNameArray;
            }
            else if (operationnode.NodeType == (int)EBTNodeType.ConditionNodeType)
            {
                validereplacetypename = "条件节点";
                validereplacenodenamearray = BTNodeData.BTConditionNodeNameArray;
            }
            else if (operationnode.NodeType == (int)EBTNodeType.DecorationNodeType)
            {
                validereplacetypename = "装饰节点";
                validereplacenodenamearray = BTNodeData.BTDecorationNodeNameArray;
            }
            if (string.IsNullOrEmpty(validereplacetypename) == false)
            {
                foreach (var nodename in validereplacenodenamearray)
                {
                    var nodeinfo = new CreateNodeInfo(mCurrentSelectionBTGraph, operationnode, nodename);
                    menu.AddItem(new GUIContent($"替换/{validereplacetypename}/{nodename}"), false, OnReplaceBTNode, nodeinfo);
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
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    var lastchildnode = nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]);
                    childnodeposx = lastchildnode.NodeDisplayRect.x + NodeWindowWidth;
                }
                var childnode = new BTNode(
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    nodeinfo.OperateNode.ChildNodesUIDList.Count,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.ActionNodeType,
                    nodeinfo.OperateNode);
                if (nodeinfo.OperateNode.AddChildNode(childnode.UID))
                {
                    mCurrentSelectionBTGraph.AddNode(childnode);
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
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    var lastchildnode = nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]);
                    childnodeposx = lastchildnode.NodeDisplayRect.x + NodeWindowWidth;
                }
                var childnode = new BTNode(
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    nodeinfo.OperateNode.ChildNodesUIDList.Count,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.CompositeNodeType,
                    nodeinfo.OperateNode);
                if (nodeinfo.OperateNode.AddChildNode(childnode.UID))
                {
                    mCurrentSelectionBTGraph.AddNode(childnode);
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
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    var lastchildnode = nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]);
                    childnodeposx = lastchildnode.NodeDisplayRect.x + NodeWindowWidth;
                }
                var childnode = new BTNode(
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    nodeinfo.OperateNode.ChildNodesUIDList.Count,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.ConditionNodeType,
                    nodeinfo.OperateNode);
                if (nodeinfo.OperateNode.AddChildNode(childnode.UID))
                {
                    mCurrentSelectionBTGraph.AddNode(childnode);
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
                if (nodeinfo.OperateNode.ChildNodesUIDList.Count > 0)
                {
                    var lastchildnode = nodeinfo.Graph.FindNodeByUID(nodeinfo.OperateNode.ChildNodesUIDList[nodeinfo.OperateNode.ChildNodesUIDList.Count - 1]);
                    childnodeposx = lastchildnode.NodeDisplayRect.x + NodeWindowWidth;
                }
                var childnode = new BTNode(
                    GetNodeRect(new Vector2(childnodeposx, nodeinfo.OperateNode.NodeDisplayRect.y + NodeWindowHeight)),
                    nodeinfo.OperateNode.ChildNodesUIDList.Count,
                    nodeinfo.CreateNodeName,
                    EBTNodeType.DecorationNodeType,
                    nodeinfo.OperateNode);
                if (nodeinfo.OperateNode.AddChildNode(childnode.UID))
                {
                    mCurrentSelectionBTGraph.AddNode(childnode);
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
            mCurrentSelectionBTGraph.DeleteNode(node);
            Debug.Log($"OnDeleteBTNode({node.NodeName})");
        }
        #endregion
    }
}