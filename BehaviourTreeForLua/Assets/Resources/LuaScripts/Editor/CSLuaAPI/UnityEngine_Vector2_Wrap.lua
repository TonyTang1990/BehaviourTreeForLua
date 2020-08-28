---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Vector2
---@field public Item number
---@field public normalized UnityEngine.Vector2
---@field public magnitude number
---@field public sqrMagnitude number
---@field public x number
---@field public y number
---@field static zero UnityEngine.Vector2
---@field static one UnityEngine.Vector2
---@field static up UnityEngine.Vector2
---@field static down UnityEngine.Vector2
---@field static left UnityEngine.Vector2
---@field static right UnityEngine.Vector2
---@field static positiveInfinity UnityEngine.Vector2
---@field static negativeInfinity UnityEngine.Vector2
---@field static kEpsilon number
---@field static kEpsilonNormalSqrt number
local Vector2 = {}

---@param newX number
---@param newY number
function Vector2:Set(newX,newY) end

---@param scale UnityEngine.Vector2
function Vector2:Scale(scale) end

function Vector2:Normalize() end

---@return string
function Vector2:ToString() end

---@param format string
---@return string
function Vector2:ToString(format) end

---@return int32
function Vector2:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Vector2:Equals(other) end

---@param other UnityEngine.Vector2
---@return System.Boolean
function Vector2:Equals(other) end

---@return number
function Vector2:SqrMagnitude() end

---@param a UnityEngine.Vector2
---@param b UnityEngine.Vector2
---@param t number
---@return UnityEngine.Vector2
function Vector2.Lerp(a,b,t) end

---@param a UnityEngine.Vector2
---@param b UnityEngine.Vector2
---@param t number
---@return UnityEngine.Vector2
function Vector2.LerpUnclamped(a,b,t) end

---@param current UnityEngine.Vector2
---@param target UnityEngine.Vector2
---@param maxDistanceDelta number
---@return UnityEngine.Vector2
function Vector2.MoveTowards(current,target,maxDistanceDelta) end

---@param a UnityEngine.Vector2
---@param b UnityEngine.Vector2
---@return UnityEngine.Vector2
function Vector2.Scale(a,b) end

---@param inDirection UnityEngine.Vector2
---@param inNormal UnityEngine.Vector2
---@return UnityEngine.Vector2
function Vector2.Reflect(inDirection,inNormal) end

---@param inDirection UnityEngine.Vector2
---@return UnityEngine.Vector2
function Vector2.Perpendicular(inDirection) end

---@param lhs UnityEngine.Vector2
---@param rhs UnityEngine.Vector2
---@return number
function Vector2.Dot(lhs,rhs) end

---@param from UnityEngine.Vector2
---@param to UnityEngine.Vector2
---@return number
function Vector2.Angle(from,to) end

---@param from UnityEngine.Vector2
---@param to UnityEngine.Vector2
---@return number
function Vector2.SignedAngle(from,to) end

---@param a UnityEngine.Vector2
---@param b UnityEngine.Vector2
---@return number
function Vector2.Distance(a,b) end

---@param vector UnityEngine.Vector2
---@param maxLength number
---@return UnityEngine.Vector2
function Vector2.ClampMagnitude(vector,maxLength) end

---@param a UnityEngine.Vector2
---@return number
function Vector2.SqrMagnitude(a) end

---@param lhs UnityEngine.Vector2
---@param rhs UnityEngine.Vector2
---@return UnityEngine.Vector2
function Vector2.Min(lhs,rhs) end

---@param lhs UnityEngine.Vector2
---@param rhs UnityEngine.Vector2
---@return UnityEngine.Vector2
function Vector2.Max(lhs,rhs) end

---@param current UnityEngine.Vector2
---@param target UnityEngine.Vector2
---@param smoothTime number
---@param maxSpeed number
---@return UnityEngine.Vector2
function Vector2.SmoothDamp(current,target,smoothTime,maxSpeed) end

---@param current UnityEngine.Vector2
---@param target UnityEngine.Vector2
---@param smoothTime number
---@return UnityEngine.Vector2
function Vector2.SmoothDamp(current,target,smoothTime) end

---@param current UnityEngine.Vector2
---@param target UnityEngine.Vector2
---@param smoothTime number
---@param maxSpeed number
---@param deltaTime number
---@return UnityEngine.Vector2
function Vector2.SmoothDamp(current,target,smoothTime,maxSpeed,deltaTime) end

return Vector2
