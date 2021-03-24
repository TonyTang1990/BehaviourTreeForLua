-- 包名:         Framework.Pool.ObjectPool
-- File Name:    ObjectPool.lua
-- Description:    Lua层类对象池
-- Author:       TangHuan
-- Create Date:    2019/12/11
--- 使用对象必须继承IRecycle，new的对象走__init,非new对象，管理器自动调用OnInit，__init和Oninit接口必须统一
print("ObjectPool.lua")

--- Note:
--- 实现对象池的类请实现IRecycle接口里的OnInit()和OnDispose()方法确保数据正确性,前者模拟构造函数，后者模拟析构
--- 底层没有自动递归调用OnInit()和OnDispose(),是否递归由继承类自行决定

---@class ObjectPool :Singleton @对象池(仅限BaseClass实例对象)
---@field GetInstance fun():ObjectPool
---@field private ObjectPoolTable table @对象池表
local ObjectPool = _G.BaseClass("ObjectPool", _G.Singleton)
ObjectPool.ObjectPoolTable = nil

---ObjectPool构造函数
function ObjectPool:__init( ... )
    print("ObjectPool:__init()")
    self.ObjectPoolTable = {}
end

---对象入池(public)
---@param obj IRecycle BaseClass @实例对象
---@return boolean @进池是否成功
function ObjectPool:Push(obj)
    if obj.IsInPool then
        print("对象池重复入池，请检查代码逻辑!")
        return
    end
    print("ObjectPool:Push()")
    assert(obj ~= nil and _G.IsClassInstance(obj), "进池对象不能为空且只允许类实例对象进池!")
    assert(_G.IsClass(obj, _G.IRecycle), "进池对象必须继承至IRecycle")
    --local loopItem;
    if not self.ObjectPoolTable[obj.__cname] then
        self.ObjectPoolTable[obj.__cname] = {}
    end
    --if not self:IsAlreadyInPool(obj, loopItem) then
    if not obj.IsInPool then
        print("对象不在池里，可以进池!")
        obj:OnDispose()
        obj.IsInPool = true
        table.insert(self.ObjectPoolTable[obj.__cname], obj)
        print(string.format("类:%s对象进池，对象池可用数量:%s", obj.__cname, #self.ObjectPoolTable[obj.__cname]))
        return true
    else
        _G.printError("对象已经在池里，无法再次进池!")
        return false
    end
end

---指定对象弹出(public)
---@param cls IRecycle BaseClass @类定义table
---@param ... any @对象参数
---@return IRecycle BaseClass @实例对象
function ObjectPool:Pop(cls, ...)
    print("ObjectPool:Pop()")
    assert(cls ~= nil and _G.IsClassDefinition(cls), string.format("弹出对象:%s参数不能为空且只允许传类定义table!", cls.__cname))
    assert(_G.IsClass(cls, _G.IRecycle), string.format("出池对象:%s必须继承至IRecycle", cls.__cname))
    if not self.ObjectPoolTable[cls.__cname] then
        self.ObjectPoolTable[cls.__cname] = {}
    end
    local avaliblenumber = #self.ObjectPoolTable[cls.__cname]
    if avaliblenumber > 0 then
        print("对象池有可用对象，弹出对象!")
        local instance = table.remove(self.ObjectPoolTable[cls.__cname], avaliblenumber)
        instance.IsInPool = false
        instance:OnInit(...)
        print(string.format("类:%s弹出，对象池可用数量:%s", cls.__cname, #self.ObjectPoolTable[cls.__cname]))
        return instance
    else
        print(string.format("类:%s对象池无可用对象，实例化一个!", cls.__cname))
        local instance = _G.New(cls, ...)
        instance:OnInit(...)
        return instance;
    end
end

---获取某个对象池
---@param clasName string 类名
function ObjectPool:InitOnePool(clasName)
    if not self.ObjectPoolTable[clasName] then
        self.ObjectPoolTable[clasName] = {}
        return self.ObjectPoolTable[clasName]
    end
    return self.ObjectPoolTable[clasName]
end

---清除空指定对象类型的对象池(public)
---@param cls IRecycle BaseClass @类定义table
function ObjectPool:ClearObj(cls)
    print("ObjectPool:Clear(cls)")
    assert(cls ~= nil and _G.IsClassDefinition(cls), "清空指定类型对象池的参数不能为空且只允许传类定义table!")
    if self.ObjectPoolTable[cls.__cname] then
        print(string.format("清除类型:%s的对象池缓存!", cls.__cname))
        self.ObjectPoolTable[cls.__cname] = nil
    end
end

---清除空对象池(public)
function ObjectPool:Clear()
    print("ObjectPool:Clear()")
    print("清除所有类型的对象池缓存!")
    self.ObjectPoolTable = {}
end

---打印所有对象池里的对象数量信息(public)
function ObjectPool:PrintAllObjNumber()
    print("ObjectPool:PrintAllObjNumber()")
    for k, v in pairs(self.ObjectPoolTable) do
        print(string.format("%s对象池数量: %s", k, #v))
    end
end

---检查指定对象是否已经在池里(private)
---@param obj IRecycle BaseClass @实例对象
---@return boolean @是否已经在池里
function ObjectPool:IsAlreadyInPool(obj, loopItem)
    print("ObjectPool:IsAlreadyInPool()")
    --assert(obj ~= nil and IsClass(obj, BaseClass), "进池对象不能为空且只允许类对象进池!")
    for k, v in pairs(self.ObjectPoolTable[obj.__cname]) do
        if v == obj then
            return true
        end
    end
    return false
end

function ObjectPool:Dispose()
    self.ObjectPoolTable = nil
end

---@type ObjectPool
_G.ObjectPool = ObjectPool

---@type ObjectPool
return ObjectPool