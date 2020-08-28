---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Vector4
---@field public Item number
---@field public normalized UnityEngine.Vector4
---@field public magnitude number
---@field public sqrMagnitude number
---@field public x number
---@field public y number
---@field public z number
---@field public w number
---@field static zero UnityEngine.Vector4
---@field static one UnityEngine.Vector4
---@field static positiveInfinity UnityEngine.Vector4
---@field static negativeInfinity UnityEngine.Vector4
---@field static kEpsilon number
local Vector4 = {}

---@param newX number
---@param newY number
---@param newZ number
---@param newW number
function Vector4:Set(newX,newY,newZ,newW) end

---@param scale UnityEngine.Vector4
function Vector4:Scale(scale) end

---@return int32
function Vector4:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Vector4:Equals(other) end

---@param other UnityEngine.Vector4
---@return System.Boolean
function Vector4:Equals(other) end

function Vector4:Normalize() end

---@return string
function Vector4:ToString() end

---@param format string
---@return string
function Vector4:ToString(format) end

---@return number
function Vector4:SqrMagnitude() end

---@param a UnityEngine.Vector4
---@param b UnityEngine.Vector4
---@param t number
---@return UnityEngine.Vector4
function Vector4.Lerp(a,b,t) end

---@param a UnityEngine.Vector4
---@param b UnityEngine.Vector4
---@param t number
---@return UnityEngine.Vector4
function Vector4.LerpUnclamped(a,b,t) end

---@param current UnityEngine.Vector4
---@param target UnityEngine.Vector4
---@param maxDistanceDelta number
---@return UnityEngine.Vector4
function Vector4.MoveTowards(current,target,maxDistanceDelta) end

---@param a UnityEngine.Vector4
---@param b UnityEngine.Vector4
---@return UnityEngine.Vector4
function Vector4.Scale(a,b) end

---@param a UnityEngine.Vector4
---@return UnityEngine.Vector4
function Vector4.Normalize(a) end

---@param a UnityEngine.Vector4
---@param b UnityEngine.Vector4
---@return number
function Vector4.Dot(a,b) end

---@param a UnityEngine.Vector4
---@param b UnityEngine.Vector4
---@return UnityEngine.Vector4
function Vector4.Project(a,b) end

---@param a UnityEngine.Vector4
---@param b UnityEngine.Vector4
---@return number
function Vector4.Distance(a,b) end

---@param a UnityEngine.Vector4
---@return number
function Vector4.Magnitude(a) end

---@param lhs UnityEngine.Vector4
---@param rhs UnityEngine.Vector4
---@return UnityEngine.Vector4
function Vector4.Min(lhs,rhs) end

---@param lhs UnityEngine.Vector4
---@param rhs UnityEngine.Vector4
---@return UnityEngine.Vector4
function Vector4.Max(lhs,rhs) end

---@param a UnityEngine.Vector4
---@return number
function Vector4.SqrMagnitude(a) end

return Vector4
