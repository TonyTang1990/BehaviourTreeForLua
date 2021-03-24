-------------------------------------------------------
-- File Name:       WaitForSeconds.lua
-- Description:     等待指定时长行为节点
-- Author:          TangHuan
-- Create Date:     2020/08/31
-------------------------------------------------------

print("WaitForSeconds.lua")

---@class WaitForSeconds : LuaBTActionNode @等待指定时长行为节点
---@field WaitTime number @等待时长(s)
---@field TimePassed number @经历的时间
local WaitForSeconds = _G.BaseClass("WaitForSeconds", _G.LuaBTActionNode)
WaitForSeconds.TargetPosition = nil
WaitForSeconds.TimePassed = nil

--- 解析参数
---@field nodeparams string @节点参数
function WaitForSeconds:ParseParam(nodeparams)
    _G.LuaBTActionNode.ParseParam(self, nodeparams)
    self.WaitTime = tonumber(nodeparams)
    print(string.format("WaitForSeconds:ParseParam() 节点UID:%s WaitForSeconds参数:%s", self.CSBTNode.UID, self.WaitTime))
end

function WaitForSeconds:OnEnter()
    _G.LuaBTActionNode.OnEnter(self)
    print(string.format("WaitForSeconds:OnEnter() 节点UID:%s WaitForSeconds参数:%s", self.CSBTNode.UID, self.WaitTime))
    self.TimePassed = 0
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function WaitForSeconds:OnExecute()
    _G.LuaBTActionNode.OnExecute(self)
    print(string.format("WaitForSeconds:OnExecute() 节点UID:%s WaitForSeconds参数:%s TimePassed:%s", self.CSBTNode.UID, self.WaitTime, self.TimePassed))
    if self.TimePassed < self.WaitTime then
        self.TimePassed = self.TimePassed + CS.UnityEngine.Time.deltaTime
        return _G.EBTNodeRunningState.Running
    else
        return _G.EBTNodeRunningState.Success
    end
end

function WaitForSeconds:OnExit()
    _G.LuaBTActionNode.OnExit(self)
    print(string.format("WaitForSeconds:OnExit() 节点UID:%s WaitForSeconds参数:%s", self.CSBTNode.UID, self.WaitTime))
    self.TimePassed = 0
end

---行为树节点释放
function WaitForSeconds:Dispose()
    _G.LuaBTActionNode.Dispose(self)
    print(string.format("WaitForSeconds:Dispose() 节点UID:%s WaitForSeconds参数:%s", self.CSBTNode.UID, self.WaitTime))
    self.WaitTime = nil
    self.TimePassed = nil
end

---@type WaitForSeconds @等待指定时长行为节点
_G.WaitForSeconds = WaitForSeconds

---@return WaitForSeconds @等待指定时长行为节点
return WaitForSeconds