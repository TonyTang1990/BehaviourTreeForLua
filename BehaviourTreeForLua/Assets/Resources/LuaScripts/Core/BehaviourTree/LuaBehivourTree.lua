print("LuaBehaviourTree")

---@class LuaBehaviourTree @Lua测行为树抽象
---@field CSBehaviourTree CS.TBehaviourTree @CS测行为树
local LuaBehaviourTree = BaseClass("LuaBehaviourTree")
LuaBehaviourTree.CSBehaviourTree = nil

function LuaBehaviourTree:__init()
    print("LuaBehaviourTree:__init()")
end

--- 行为树初始化
---@param csbehaviourtree CS.TBehaviourTree @CS测的行为树
function LuaBehaviourTree:Init(csbehaviourtree)
    print("LuaBehaviourTree:Init()")
    self.CSBehaviourTree = csbehaviourtree
end

--- 行为树更新
function LuaBehaviourTree:Update()

end

--- 行为树释放
function LuaBehaviourTree:Release()
    print("LuaBehaviourTree:Release()")
    self.CSBehaviourTree = nil
end

---@type LuaBehaviourTree @Lua测行为树抽象
_G.LuaBehaviourTree = LuaBehaviourTree

---@type LuaBehaviourTree
return _G.LuaBehaviourTree