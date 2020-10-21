print("LuaBTNode.lua")

local IRecycle = require("Core.Pool.IRecycle")

---@class LuaBTNode : IRecycle @Lua测行为树节点抽象基类
---@field CSBTNode LuaBehaviourTree.BTNode @CS测节点
---@field InstanceID number @实例对象ID
---@field Go UnityEngine.GameObject @当前节点所绑定的GameObject对象
local LuaBTNode = BaseClass("LuaBTNode", IRecycle)
LuaBTNode.CSBTNode = nil
LuaBTNode.Go = nil

---@param csbtnode LuaBehaviourTree.BTNode @CS测节点
---@param instanceid number @实例对象ID
function LuaBTNode:__init(csbtnode, instanceid)
    print("LuaBTNode:__init()")
    self:OnInit(csbtnode, instanceid)
end

---LuaBTNode出池构造函数
---@param csbtnode LuaBehaviourTree.BTNode @CS测节点
---@param instanceid number @实体对象ID
function LuaBTNode:OnInit(csbtnode, instanceid)
    self.CSBTNode = csbtnode
    self.UID = self.CSBTNode.UID
    self.InstanceID = instanceid
    self.Go = self.CSBTNode.OwnerBT.gameObject
    self:ParseParam(self.CSBTNode.NodeParams)
end

--- 解析参数(子类重写实现自定义解析)
---@field nodeparams string @节点参数
function LuaBTNode:ParseParam(nodeparams)
    print(string.format("子类未实现参数解析:%s!", nodeparams))
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
    --- UID和InstanceID不置空是为了后续能正确解除绑定
    ---self.UID = nil
    ---self.InstanceID = nil
    self.Go = nil
end

---LuaBTNode进池析构函数
function LuaBTNode:OnDispose()
    self.CSBTNode = nil
    self.UID = nil
    self.InstanceID = nil
    self.Go = nil
    self.WorldItemUID = nil
end

---@type LuaBTNode @Lua测行为树抽象
_G.LuaBTNode = LuaBTNode

---@type LuaBTNode
return _G.LuaBTNode