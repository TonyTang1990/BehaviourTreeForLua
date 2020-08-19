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
---@param btnode CS.BTNode @CS测的行为树对应的节点
---@return LuaBTNode @Lua测行为树节点对象
function CreateLuaBTnode(btnode)
    print("CreateLuaBTnode()")
    local luabtnodeinstance = _G.LuaBTNode.New(btnode)
    luabtnodeinstance:Init(btnode)
    return luabtnodeinstance
end