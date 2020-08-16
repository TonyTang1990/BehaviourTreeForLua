print("Lua GameMain()")

require "Init"

function Start()
    print("Lua Start()")
end

function Stop()
    print("Lua Stop()")
end

---@param deltatime number @间隔时间
---@param unscaleddeltatime number @间隔unscale时间
function Update(deltatime, unscaleddeltatime)
    ---print("Lua Update()")
end

function LateUpdate()
    ---print("Lua LateUpdate()")
end

function FixedUpdate()
    ---print("Lua FixedUpdate()")
end

--- 创建Lua测行为树
---@param csbehaviourtree CS.TBehaviourTree @CS测的行为树
---@return LuaBehaviourTree @Lua测行为树对象
function CreateLuaBehaviourTree(csbehaviourtree)
    print("CreateLuaBehaviourTree()")
    local luabehaviourtreeinstance = _G.LuaBehaviourTree.New(csbehaviourtree)
    luabehaviourtreeinstance:Init(csbehaviourtree)
    return luabehaviourtreeinstance
end