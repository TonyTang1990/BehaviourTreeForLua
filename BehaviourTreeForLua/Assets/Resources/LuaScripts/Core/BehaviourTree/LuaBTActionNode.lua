-------------------------------------------------------
-- File Name:       LuaBTActionNode.lua
-- Description:     Lua行为树行为节点基类
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class LuaBTActionNode : LuaBTNode @Lua行为树行为节点基类
local LuaBTActionNode = _G.BaseClass("LuaBTActionNode", _G.LuaBTNode)

---@param csbtnode LuaBehaviourTree.BTNode @CS测节点
function LuaBTActionNode:__init(csbtnode)

end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function LuaBTActionNode:OnExecute()
    return _G.EBTNodeRunningState.Success
end

---行为树节点释放
function LuaBTActionNode:Dispose()

end

---@type LuaBTActionNode @Lua行为树行为节点基类
_G.LuaBTActionNode = LuaBTActionNode

---@return LuaBTActionNode @Lua行为树行为节点基类
return LuaBTActionNode