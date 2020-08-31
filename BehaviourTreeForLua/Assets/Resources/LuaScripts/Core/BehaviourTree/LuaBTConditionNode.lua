print("LuaBTConditionNode.lua")

-------------------------------------------------------
-- File Name:       LuaBTConditionNode.lua
-- Description:     行为树条件节点基类
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class LuaBTConditionNode : LuaBTNode @行为树条件节点基类
local LuaBTConditionNode = _G.BaseClass("LuaBTConditionNode", _G.LuaBTNode)

---@param csbtnode LuaBehaviourTree.BTNode @CS测节点
function LuaBTConditionNode:__init(csbtnode)
    print("LuaBTConditionNode:__init()")
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function LuaBTConditionNode:OnExecute()
    return _G.EBTNodeRunningState.Success
end

---释放
function LuaBTConditionNode:Dispose()

end

---@type LuaBTConditionNode @行为树条件节点基类
_G.LuaBTConditionNode = LuaBTConditionNode

---@return LuaBTConditionNode @行为树条件节点基类
return LuaBTConditionNode