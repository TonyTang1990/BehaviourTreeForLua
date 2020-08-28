---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.Reflection.MemberInfo
---@field public MemberType System.Reflection.MemberTypes
---@field public Name string
---@field public DeclaringType System.Type
---@field public ReflectedType System.Type
---@field public CustomAttributes System.Collections.Generic.IEnumerable
---@field public MetadataToken int32
---@field public Module System.Reflection.Module
local MemberInfo = {}

---@param inherit System.Boolean
---@return System.Object[]
function MemberInfo:GetCustomAttributes(inherit) end

---@param attributeType System.Type
---@param inherit System.Boolean
---@return System.Object[]
function MemberInfo:GetCustomAttributes(attributeType,inherit) end

---@param attributeType System.Type
---@param inherit System.Boolean
---@return System.Boolean
function MemberInfo:IsDefined(attributeType,inherit) end

---@return System.Collections.Generic.IList
function MemberInfo:GetCustomAttributesData() end

---@param obj System.Object
---@return System.Boolean
function MemberInfo:Equals(obj) end

---@return int32
function MemberInfo:GetHashCode() end

return MemberInfo
