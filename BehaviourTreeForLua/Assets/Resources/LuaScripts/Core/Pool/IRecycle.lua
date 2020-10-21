-- 包路径:        Framework.Pool.IRecycle
-- File Name:    IRecycle.lua
-- Description:  对象池对象接口抽象
-- Author:       TangHuan
-- Create Date:  2020/01/15
local ObjectPool = require("Core.Pool.ObjectPool")
---Note:
---所有进ObjectPool的对象都必须继承实现此类 ,入池直接调用ToPool()

---@class IRecycle @对象池对象接口抽象
---@field IsInPool boolean 是否已经入池(外部禁止访问）
local IRecycle = _G.BaseClass("IRecycle")

function IRecycle:__init(...)
    self.IsInPool = false
    self:OnInit(...)
end

---IRecycle出池构造函数
function IRecycle:OnInit(...)

end

---IRecycle进池析构函数
function IRecycle:OnDispose()

end

---入池   成员函数 出池调用 ObjectPool:GetInstance():Pop(),注意 入池为：出池为.
function IRecycle:ToPool()
    ObjectPool:GetInstance():Push(self)
end

--- 出池  静态函数
function IRecycle.GetFromPool(clasType, ...)
    return ObjectPool:GetInstance():Pop(clasType, ...)
end

---@type IRecycle @对象池对象接口抽象
_G.IRecycle = IRecycle

---@return IRecycle @对象池对象接口抽象
return IRecycle
