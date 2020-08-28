---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.Delegate
---@field public Method System.Reflection.MethodInfo
---@field public Target System.Object
local Delegate = {}

---@param args System.Object[]
---@return System.Object
function Delegate:DynamicInvoke(args) end

---@return System.Object
function Delegate:Clone() end

---@param obj System.Object
---@return System.Boolean
function Delegate:Equals(obj) end

---@return int32
function Delegate:GetHashCode() end

---@param info System.Runtime.Serialization.SerializationInfo
---@param context System.Runtime.Serialization.StreamingContext
function Delegate:GetObjectData(info,context) end

---@return System.Delegate[]
function Delegate:GetInvocationList() end

---@param type System.Type
---@param firstArgument System.Object
---@param method System.Reflection.MethodInfo
---@param throwOnBindFailure System.Boolean
---@return System.Delegate
function Delegate.CreateDelegate(type,firstArgument,method,throwOnBindFailure) end

---@param type System.Type
---@param firstArgument System.Object
---@param method System.Reflection.MethodInfo
---@return System.Delegate
function Delegate.CreateDelegate(type,firstArgument,method) end

---@param type System.Type
---@param method System.Reflection.MethodInfo
---@param throwOnBindFailure System.Boolean
---@return System.Delegate
function Delegate.CreateDelegate(type,method,throwOnBindFailure) end

---@param type System.Type
---@param method System.Reflection.MethodInfo
---@return System.Delegate
function Delegate.CreateDelegate(type,method) end

---@param type System.Type
---@param target System.Object
---@param method string
---@return System.Delegate
function Delegate.CreateDelegate(type,target,method) end

---@param type System.Type
---@param target System.Type
---@param method string
---@param ignoreCase System.Boolean
---@param throwOnBindFailure System.Boolean
---@return System.Delegate
function Delegate.CreateDelegate(type,target,method,ignoreCase,throwOnBindFailure) end

---@param type System.Type
---@param target System.Type
---@param method string
---@return System.Delegate
function Delegate.CreateDelegate(type,target,method) end

---@param type System.Type
---@param target System.Type
---@param method string
---@param ignoreCase System.Boolean
---@return System.Delegate
function Delegate.CreateDelegate(type,target,method,ignoreCase) end

---@param type System.Type
---@param target System.Object
---@param method string
---@param ignoreCase System.Boolean
---@param throwOnBindFailure System.Boolean
---@return System.Delegate
function Delegate.CreateDelegate(type,target,method,ignoreCase,throwOnBindFailure) end

---@param type System.Type
---@param target System.Object
---@param method string
---@param ignoreCase System.Boolean
---@return System.Delegate
function Delegate.CreateDelegate(type,target,method,ignoreCase) end

---@param a System.Delegate
---@param b System.Delegate
---@return System.Delegate
function Delegate.Combine(a,b) end

---@param delegates System.Delegate[]
---@return System.Delegate
function Delegate.Combine(delegates) end

---@param source System.Delegate
---@param value System.Delegate
---@return System.Delegate
function Delegate.Remove(source,value) end

---@param source System.Delegate
---@param value System.Delegate
---@return System.Delegate
function Delegate.RemoveAll(source,value) end

return Delegate
