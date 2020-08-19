print("LuaBTNode")

---@class LuaBTNode @Lua测行为树节点抽象
---@field CSBehaviourTree CS.TBehaviourTree @CS测行为树
local LuaBTNode = BaseClass("LuaBTNode")
LuaBTNode.CSBehaviourTree = nil

function LuaBTNode:__init()
    print("LuaBTNode:__init()")
end

--- 行为树初始化
---@param csbehaviourtree CS.TBehaviourTree @CS测的行为树
function LuaBTNode:Init(csbehaviourtree)
    print("LuaBTNode:Init()")
    self.CSBehaviourTree = csbehaviourtree
end

--- 行为树更新
function LuaBTNode:Update()

end

--- 行为树释放
function LuaBTNode:Release()
    print("LuaBTNode:Release()")
    self.CSBehaviourTree = nil
end

---@type LuaBTNode @Lua测行为树抽象
_G.LuaBTNode = LuaBTNode

---@type LuaBTNode
return _G.LuaBTNode