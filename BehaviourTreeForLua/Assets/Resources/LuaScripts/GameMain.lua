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

--- 创建Lua测行为树节点
---@param btnode LuaBehaviourTree.BTNode @CS测的行为树对应的节点
---@return LuaBTNode @Lua测行为树节点对象
function CreateLuaBTnode(btnode)
    print("创建Lua节点!")
    local luabtnodescriptname = btnode.NodeName
    local luabtnodescriptfullpath = string.format("%s.%s", _G.BTData.BTLuaScriptRelativePath, luabtnodescriptname)
    print("luabtnodescriptname = " .. luabtnodescriptname)
    print("luabtnodescriptfullpath = " .. luabtnodescriptfullpath)
    local luabtnodeinstance = require(luabtnodescriptfullpath).New(btnode)
    return luabtnodeinstance
end