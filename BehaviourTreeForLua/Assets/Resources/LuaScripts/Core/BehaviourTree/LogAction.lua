print("LogAction.lua")

-------------------------------------------------------
-- File Name:       LogAction.lua
-- Description:     打印Log行为节点
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class LogAction : LuaBTActionNode @打印Log行为节点
---@field LogContent string @Log打印字符串
local LogAction = _G.BaseClass("LogAction", _G.LuaBTActionNode)
LogAction.LogContent = nil

--- 解析参数
---@field nodeparams string @节点参数
function LogAction:ParseParam(nodeparams)
    _G.LuaBTActionNode.ParseParam(self, nodeparams)
    self.LogContent = nodeparams
    print(string.format("LogAction:ParseParam() 节点UID:%s LogAction参数:%s", self.CSBTNode.UID, self.LogContent))
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function LogAction:OnExecute()
    _G.LuaBTActionNode.OnExecute(self)
    print(string.format("LogAction:OnExecute() 节点UID:%s LogAction参数:%s", self.CSBTNode.UID, self.LogContent))
    return _G.EBTNodeRunningState.Success
end

---行为树节点释放
function LogAction:Dispose()
    _G.LuaBTActionNode.Dispose(self)
    print(string.format("LogAction:Dispose() 节点UID:%s LogAction参数:%s", self.CSBTNode.UID, self.LogContent))
    self.LogContent = nil
end

---@type LogAction @打印Log行为节点
_G.LogAction = LogAction

---@return LogAction @打印Log行为节点
return LogAction