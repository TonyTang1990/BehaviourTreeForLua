-------------------------------------------------------
-- File Name:       MoveToPostion.lua
-- Description:     移动到指定位置行为节点
-- Author:          TangHuan
-- Create Date:     2020/08/31
-------------------------------------------------------

print("MoveToPostion.lua")

---@class MoveToPostion : LuaBTActionNode @打印Log行为节点
---@field TargetPosition UnityEngine.Vector3 @目标位置
local MoveToPostion = _G.BaseClass("MoveToPostion", _G.LuaBTActionNode)
MoveToPostion.TargetPosition = nil

--- 解析参数
---@field nodeparams string @节点参数
function MoveToPostion:ParseParam(nodeparams)
    _G.LuaBTActionNode.ParseParam(self, nodeparams)
    local targetpositions = string.split(nodeparams, ",")
    self.TargetPosition = CS.UnityEngine.Vector3(tonumber(targetpositions[1]), tonumber(targetpositions[2]), tonumber(targetpositions[3]))
    --print(string.format("MoveToPostion:ParseParam() 节点UID:%s MoveToPostion参数:%s", self.CSBTNode.UID, self.TargetPosition:ToString()))
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function MoveToPostion:OnExecute()
    _G.LuaBTActionNode.OnExecute(self)
    --print(string.format("MoveToPostion:OnExecute() 节点UID:%s MoveToPostion参数:%s", self.CSBTNode.UID, self.TargetPosition:ToString()))
    local distance = CS.UnityEngine.Vector3.Distance(self.Go.transform.position, self.TargetPosition)
    --print(string.format("distance:%s", distance))
    if distance > 0.5 then
        local targetdir = (self.TargetPosition - self.Go.transform.position).normalized
        --print(string.format("targetdir:%s", targetdir:ToString()))
        self.Go.transform:Translate(targetdir * CS.UnityEngine.Time.deltaTime)
        return _G.EBTNodeRunningState.Running
    else
        return _G.EBTNodeRunningState.Success
    end
end

---行为树节点释放
function MoveToPostion:Dispose()
    _G.LuaBTActionNode.Dispose(self)
    --print(string.format("MoveToPostion:Dispose() 节点UID:%s MoveToPostion参数:%s", self.CSBTNode.UID, self.TargetPosition:ToString()))
    self.TargetPosition = nil
end

---@type MoveToPostion @打印Log行为节点
_G.MoveToPostion = MoveToPostion

---@return MoveToPostion @打印Log行为节点
return MoveToPostion