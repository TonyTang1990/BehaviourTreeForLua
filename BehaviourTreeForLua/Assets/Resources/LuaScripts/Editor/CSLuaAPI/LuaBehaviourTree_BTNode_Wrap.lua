---===================== Author Qcbf 这是自动生成的代码 =====================

---@class LuaBehaviourTree.BTNode
---@field public OwnerBT LuaBehaviourTree.TBehaviourTree
---@field public NodeRunningState LuaBehaviourTree.EBTNodeRunningState
---@field public IsRunning System.Boolean
---@field public IsTerminated System.Boolean
---@field public UID int32
---@field public NodeDisplayRect UnityEngine.Rect
---@field public NodeIndex int32
---@field public NodeName string
---@field public NodeParams string
---@field public NodeType int32
---@field public ParentNodeUID int32
---@field public ChildNodesUIDList System.Collections.Generic.List
local BTNode = {}

---@return LuaBehaviourTree.EBTNodeRunningState
function BTNode:Update() end

function BTNode:Reset() end

---@param childnodeuid int32
---@param insertindex int32
---@return System.Boolean
function BTNode:AddChildNode(childnodeuid,insertindex) end

---@param childnodeuid int32
---@return System.Boolean
function BTNode:DeleteChildNode(childnodeuid) end

function BTNode:DeleteAllChildNodes() end

---@param graph LuaBehaviourTree.BTGraph
function BTNode:UpdateChildNodeIndex(graph) end

---@param pos UnityEngine.Vector2
---@return System.Boolean
function BTNode:UnderRectArea(pos) end

---@param graph LuaBehaviourTree.BTGraph
---@param offset UnityEngine.Vector2
---@param recursive System.Boolean
function BTNode:Move(graph,offset,recursive) end

---@return System.Boolean
function BTNode:IsRootNode() end

---@return System.Boolean
function BTNode:IsLeafNode() end

---@return System.Boolean
function BTNode:IsEntryNode() end

---@return System.Boolean
function BTNode:IsActionNode() end

---@return System.Boolean
function BTNode:IsConditionNode() end

---@return System.Boolean
function BTNode:IsCompositionNode() end

---@return System.Boolean
function BTNode:IsDecorationNode() end

return BTNode
