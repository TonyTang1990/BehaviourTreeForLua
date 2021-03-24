print("HasTaskCondition.lua")

-------------------------------------------------------
-- File Name:       HasTaskCondition.lua
-- Description:     是否有任务条件节点
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class HasTaskCondition : LuaBTConditionNode @是否有任务条件节点
local HasTaskCondition = _G.BaseClass("HasTaskCondition", _G.LuaBTConditionNode)

--- 解析参数
---@field nodeparams string @节点参数
function HasTaskCondition:ParseParam(nodeparams)
    _G.LuaBTConditionNode.ParseParam(self, nodeparams)
    print(string.format("HasTaskCondition:ParseParam() 节点UID:%s", self.CSBTNode.UID))
end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function HasTaskCondition:OnExecute()
    _G.LuaBTConditionNode.OnExecute(self)
    if CS.GameLauncherLua.Singleton.TgHasTask.isOn then
        print(string.format("Success HasTaskCondition:OnExecute() 节点UID:%s", self.CSBTNode.UID))
        return _G.EBTNodeRunningState.Success
    else
        print(string.format("Failed HasTaskCondition:OnExecute() 节点UID:%s", self.CSBTNode.UID))
        return _G.EBTNodeRunningState.Failed
    end
end

---行为树节点释放
function HasTaskCondition:Dispose()
    _G.LuaBTConditionNode.Dispose(self)
    print(string.format("HasTaskCondition:Dispose() 节点UID:%s", self.CSBTNode.UID))
end

---@type HasTaskCondition @是否有任务条件节点
_G.HasTaskCondition = HasTaskCondition

---@return HasTaskCondition @是否有任务条件节点
return HasTaskCondition