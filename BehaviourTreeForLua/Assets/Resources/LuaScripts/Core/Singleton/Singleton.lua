--[[
-- 单例类
--]]
---@class Singleton
---@field GetInstance fun():Singleton
local Singleton = _G.BaseClass("Singleton")

---@param SingCatchTab table 储存的所有单列的对象
local SingCatchTab = {}

---ALLDispose 释放所有的单列对象
function Singleton.ALLDispose()
    for k, _ in pairs(SingCatchTab) do
        if not _G.IsNil(SingCatchTab[k].Dispose) then
            -- LogError(k)
            SingCatchTab[k]:Dispose()
        end
        package.loaded[k] = nil
        SingCatchTab[k] = nil
        --Log(k,"<color=red>" .. "ALLDispose" .. "</color>")

    end
end

function Singleton:__init()
    assert(rawget(self._class_type, "Instance") == nil, self._class_type.__cname .. " to create singleton twice!")
    rawset(self._class_type, "Instance", self)
    SingCatchTab[self._class_type.__cname] = self
end

function Singleton:Dispose()
    rawset(self._class_type, "Instance", nil)
end

function Singleton:DontDestroy()
    SingCatchTab[self._class_type.__cname] = nil
end

-- 只是用于启动模块, 启动模块的需要从 SingCatchTab 移除
function Singleton:Startup()
end

function Singleton:Cleanup()
end

---GetInstance 取得一个单列对象，不要重写这个方法
---@return table 单列对象
function Singleton:GetInstance()
    if rawget(self, "Instance") == nil then
        rawset(self, "Instance", self.New())
    end
    assert(self.Instance ~= nil)
    return self.Instance
end

_G.Singleton = Singleton
return Singleton
