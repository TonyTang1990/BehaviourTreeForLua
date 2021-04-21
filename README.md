# BehaviourTreeForLua
支持Lua的行为树简易实现。

详细介绍请参考后面的博客连接，这里只简单介绍一下用法和实现。

## 理论介绍

行为树更新方案选择：

- **每次从上次未运行完的节点运行(打断时回到根节点开始执行)**

行为树打断机制支持(设计在了条件节点上不想BehaviourDesigner实现在组合节点上--同时只实现了简单的两种情况):

- None(运行时条件变化不立刻打断)
- Self(相当于BehaviourDesigner的Both,条件变化立刻打断)

Note:

1. **条件变化打断的前提是运行过这个条件**

行为树动态变量实现：

- 黑板模式实现(行为树内的动态变量)

序列化方式选择:

- Unity自带Json库(没有实现自定义Public面变显示所以不需要过于强大的序列化方案)

编辑器实现方案:

- Unity原生自带GUI(主要使用GUI.Window,Handles.DrawBezier,GenericMenu以及EditorGUILayout相关API)

编辑器操作支持：

- 只支持对指定节点通过菜单选择的方式添加子节点和刪除节点(没有支持自定义连线)
- 支持自动拖拽节点位置并排序
- 支持子节点从头添加还是从尾添加子节点添加策略设置
- 支持子节点是否一起移动开关设置
- 支持调试模式开关勾选(方便查看运行时的一些数据情况)
- 支持自定义路径的Json序列化路径保存
- 支持同类型节点快速替换操作
- ......

Lua行为树节点支持实现方案:

- 通过序列化节点名+节点参数的形式做到运行时构建对应Lua节点脚本以及初始化节点自定义数据，从而实现自定义Lua节点扩展。

## 实战效果

上面说了这么多，直接来看下实际的成果吧：

**黑板模式这里用于实现自定义变量并支持修改和读取判定，用于实现自定义变量控制AI逻辑。**
黑板模式实现效果如下:
![自定义变量节点](/img/AI/BehaviourTree/CustomVariableNodes.png)
![自定义变量参数面板](/img/AI/BehaviourTree/CustomVariableInspector.png)
![所有自定义变量展示面板](/img/AI/BehaviourTree/AllCustomVariableInspector.png)

节点编辑器

关于节点编辑器，核心要了解Unity以下几个API:
1. Event -- UnityGUI事件响应编写接口类
    ![节点编辑器操作响应](/img/AI/BehaviourTree/GenericMenu.png)
2. GUILayout.BeginArea() GUILayout.Toolbar() GUILayout.EndArea() EditorGUILayout.*** -- GUI自定义面板UI显示接口
    ![节点编辑器操作面板](/img/AI/BehaviourTree/BTOperationPanel.png)
3. GenericMenu -- Unity编写自定义菜单的类
    ![行为树编辑器菜单](/img/AI/BehaviourTree/GenericMenu.png)
4. BeginWindows() GUI.Window() EndWindows() GUI.DragWindow() -- Unity编写节点窗口的类(支持拖拽的节点)
    ![行为树节点窗口](/img/AI/BehaviourTree/BTEditorNode.png)
5. Handles.DrawBezier() -- 绘制节点曲线(Bezier曲线)连接线的接口
    ![行为树节点连线](/img/AI/BehaviourTree/BTNodeConnectLine.png)
6. JsonUtility.ToJson() JsonUtility.FromJson<T>() -- Unity Json数据序列化反序列化存储
    ![行为树序列化反序列化存储](/img/AI/BehaviourTree/BTJsonData.png)

结合上面几个核心类，最终实现行为树节点编辑器效果图如下:
![行为树节点编辑器效果展示](/img/AI/BehaviourTree/BTNodeEditor.png)

## 行为树框架类图设计

通过给出行为树的UML类图设计，大家可以参考思路自行实现(因为UML比较大所以分了两张图):
![行为树UML类图1](/img/AI/BehaviourTree/BehaviourTreeUML1.png)
![行为树UML类图2](/img/AI/BehaviourTree/BehaviourTreeUML2.png)

项目没有继续做了，本项目开源了。

## 已知还未修复Bug

1. ~~非动态变量条件节点和非动态变量行为节点在替换为动态变量节点时报错(**2021/4/21修复**)~~
2. ~~动态变量条件节点和动态变量行为节点在替换为非动态变量节点时潜在相关数据未删除(**2021/4/21修复**)~~

# 个人博客

详细的博客记录学习:

[行为树-Unity](http://tonytang1990.github.io/2020/09/12/行为树-Unity/)