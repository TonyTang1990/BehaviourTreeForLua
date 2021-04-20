-------------------------------------------------------
-- File Name:       Idle.lua
-- Description:     空闲行为节点
-- Author:          TangHuan
-- Create Date:     2020/08/31
-------------------------------------------------------

print("Idle.lua")

---@class Idle : LuaBTActionNode @等待指定时长行为节点
local Idle = _G.BaseClass("Idle", _G.LuaBTActionNode)

--- 解析参数
---@field nodeparams string @节点参数
function Idle:ParseParam(nodeparams)
    _G.LuaBTActionNode.ParseParam(self, nodeparams)
    --print(string.format("Idle:ParseParam() 节点UID:%s", self.CSBTNode.UID))
end

function Idle:OnEnter()
    _G.LuaBTActionNode.OnEnter(self)
    --print(string.format("Idle:OnEnter() 节点UID:%s", self.CSBTNode.UID))
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function Idle:OnExecute()
    _G.LuaBTActionNode.OnExecute(self)
    --print(string.format("Idle:OnExecute() 节点UID:%s", self.CSBTNode.UID))
    return _G.EBTNodeRunningState.Running
end

function Idle:OnExit()
    _G.LuaBTActionNode.OnExit(self)
    --print(string.format("Idle:OnExit() 节点UID:%s", self.CSBTNode.UID))
end

---行为树节点释放
function Idle:Dispose()
    _G.LuaBTActionNode.Dispose(self)
    --print(string.format("Idle:Dispose() 节点UID:%s", self.CSBTNode.UID))
end

---@type Idle @等待指定时长行为节点
_G.Idle = Idle

---@return Idle @等待指定时长行为节点
return Idle