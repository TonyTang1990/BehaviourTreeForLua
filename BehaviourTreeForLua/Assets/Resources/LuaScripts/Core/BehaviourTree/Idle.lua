-------------------------------------------------------
-- File Name:       idle.lua
-- Description:     空闲行为节点
-- Author:          TangHuan
-- Create Date:     2020/08/31
-------------------------------------------------------

print("idle.lua")

---@class idle : LuaBTActionNode @等待指定时长行为节点
local idle = _G.BaseClass("idle", _G.LuaBTActionNode)

---@param csbtnode LuaBehaviourTree.BTNode @CS测节点
function idle:__init(csbtnode)
    print("idle:__init()")
end

--- 解析参数
---@field nodeparams string @节点参数
function idle:ParseParam(nodeparams)
    _G.LuaBTActionNode.ParseParam(self, nodeparams)
    print(string.format("idle:ParseParam() 节点UID:%s", self.CSBTNode.UID))
end

function idle:OnEnter()
    _G.LuaBTActionNode.OnEnter(self)
    print(string.format("idle:OnEnter() 节点UID:%s", self.CSBTNode.UID))
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function idle:OnExecute()
    _G.LuaBTActionNode.OnExecute(self)
    print(string.format("idle:OnExecute() 节点UID:%s", self.CSBTNode.UID))
    return _G.EBTNodeRunningState.Running
end

function idle:OnExit()
    _G.LuaBTActionNode.OnExit(self)
    print(string.format("idle:OnExit() 节点UID:%s", self.CSBTNode.UID))
end

---行为树节点释放
function idle:Dispose()
    _G.LuaBTActionNode.Dispose(self)
    print(string.format("idle:Dispose() 节点UID:%s", self.CSBTNode.UID))
end

---@type idle @等待指定时长行为节点
_G.idle = idle

---@return idle @等待指定时长行为节点
return idle