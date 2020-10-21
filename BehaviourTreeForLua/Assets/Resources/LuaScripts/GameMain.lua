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