print("ActiveSelfCondition.lua")

-------------------------------------------------------
-- File Name:       ActiveSelfCondition.lua
-- Description:     自身显示条件节点
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class ActiveSelfCondition : LuaBTConditionNode @自身显示条件节点
---@field TargetUID number @目标对象UID
local ActiveSelfCondition = _G.BaseClass("ActiveSelfCondition", _G.LuaBTConditionNode)
ActiveSelfCondition.TargetUID = nil

--- 解析参数
---@field nodeparams string @节点参数
function ActiveSelfCondition:ParseParam(nodeparams)
    _G.LuaBTConditionNode.ParseParam(self, nodeparams)
    self.TargetUID = nodeparams
    --print(string.format("ActiveSelfCondition:ParseParam() 节点UID:%s ActiveSelfCondition参数:%s", self.CSBTNode.UID, self.TargetUID))
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function ActiveSelfCondition:OnExecute()
    _G.LuaBTConditionNode.OnExecute(self)
    if self.Go.activeInHierarchy then
        --print(string.format("Success ActiveSelfCondition:OnExecute() 节点UID:%s ActiveSelfCondition参数:%s", self.CSBTNode.UID, self.TargetUID))
        return _G.EBTNodeRunningState.Success
    else
        --print(string.format("Failed ActiveSelfCondition:OnExecute() 节点UID:%s ActiveSelfCondition参数:%s", self.CSBTNode.UID, self.TargetUID))
        return _G.EBTNodeRunningState.Failed
    end
end

---行为树节点释放
function ActiveSelfCondition:Dispose()
    _G.LuaBTConditionNode.Dispose(self)
    --print(string.format("ActiveSelfCondition:Dispose() 节点UID:%s ActiveSelfCondition参数:%s", self.CSBTNode.UID, self.TargetUID))
    self.TargetUID = nil
end

---@type ActiveSelfCondition @自身显示条件节点
_G.ActiveSelfCondition = ActiveSelfCondition

---@return ActiveSelfCondition @自身显示条件节点
return ActiveSelfCondition