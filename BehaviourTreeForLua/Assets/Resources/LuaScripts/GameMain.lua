print("Lua GameMain()")

require "Init"

function Start()
    print("Lua Start()")
end

function Stop()
    print("Lua Stop()")  
    CS.LuaBehaviourTree.TBehaviourTreeManager.LuaCreateLuaBTnode = nil
    CS.LuaBehaviourTree.TBehaviourTreeManager.UnbindLuaBTNodeCall = nil
    CS.LuaBehaviourTree.BTNode.LuaOnPause = nil
    CS.LuaBehaviourTree.BTNode.LuaReset = nil
    CS.LuaBehaviourTree.BTNode.LuaOnEnter = nil
    CS.LuaBehaviourTree.BTNode.LuaOnExecute = nil
    CS.LuaBehaviourTree.BTNode.LuaOnExit = nil
    CS.LuaBehaviourTree.BTNode.LuaDispose = nil
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