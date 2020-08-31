print("LuaBTNode.lua")

---@class LuaBTNode @Lua测行为树节点抽象基类
---@field CSBTNode LuaBehaviourTree.BTNode @CS测节点
---@field Go UnityEngine.GameObject @当前节点所绑定的GameObject对象
local LuaBTNode = BaseClass("LuaBTNode")
LuaBTNode.CSBTNode = nil
LuaBTNode.Go = nil

---@param csbtnode LuaBehaviourTree.BTNode @CS测节点
function LuaBTNode:__init(csbtnode)
    print("LuaBTNode:__init()")
    self.CSBTNode = csbtnode
    self.Go = self.CSBTNode.OwnerBT.gameObject
    self:ParseParam(self.CSBTNode.NodeParams)
end

--- 解析参数(子类重写实现自定义解析)
---@field nodeparams string @节点参数
function LuaBTNode:ParseParam(nodeparams)
    print("子类未实现参数解析!")
end

--- 重置节点状态
function LuaBTNode:Reset()

end

--- 进入节点
function LuaBTNode:OnEnter()

end

--- 执行节点
---@return EBTNodeRunningState @执行状态
function LuaBTNode:OnExecute()
    return _G.EBTNodeRunningState.Invalide
end

--- 退出节点
function LuaBTNode:OnExit()
    ---节点判定完成(成功或失败)时做一些事情
end

--- 行为树节点释放
function LuaBTNode:Dispose()
    print("LuaBTNode:Dispose()")
    self.CSBTNode = nil
    self.Go = nil
end

---@type LuaBTNode @Lua测行为树抽象
_G.LuaBTNode = LuaBTNode

---@type LuaBTNode
return _G.LuaBTNode