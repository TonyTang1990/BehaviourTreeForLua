---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Vector3
---@field public Item number
---@field public normalized UnityEngine.Vector3
---@field public magnitude number
---@field public sqrMagnitude number
---@field public x number
---@field public y number
---@field public z number
---@field static zero UnityEngine.Vector3
---@field static one UnityEngine.Vector3
---@field static forward UnityEngine.Vector3
---@field static back UnityEngine.Vector3
---@field static up UnityEngine.Vector3
---@field static down UnityEngine.Vector3
---@field static left UnityEngine.Vector3
---@field static right UnityEngine.Vector3
---@field static positiveInfinity UnityEngine.Vector3
---@field static negativeInfinity UnityEngine.Vector3
---@field static kEpsilon number
---@field static kEpsilonNormalSqrt number
local Vector3 = {}

---@param newX number
---@param newY number
---@param newZ number
function Vector3:Set(newX,newY,newZ) end

---@param scale UnityEngine.Vector3
function Vector3:Scale(scale) end

---@return int32
function Vector3:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Vector3:Equals(other) end

---@param other UnityEngine.Vector3
---@return System.Boolean
function Vector3:Equals(other) end

function Vector3:Normalize() end

---@return string
function Vector3:ToString() end

---@param format string
---@return string
function Vector3:ToString(format) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@param t number
---@return UnityEngine.Vector3
function Vector3.Slerp(a,b,t) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@param t number
---@return UnityEngine.Vector3
function Vector3.SlerpUnclamped(a,b,t) end

function Vector3.OrthoNormalize() end

function Vector3.OrthoNormalize() end

---@param current UnityEngine.Vector3
---@param target UnityEngine.Vector3
---@param maxRadiansDelta number
---@param maxMagnitudeDelta number
---@return UnityEngine.Vector3
function Vector3.RotateTowards(current,target,maxRadiansDelta,maxMagnitudeDelta) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@param t number
---@return UnityEngine.Vector3
function Vector3.Lerp(a,b,t) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@param t number
---@return UnityEngine.Vector3
function Vector3.LerpUnclamped(a,b,t) end

---@param current UnityEngine.Vector3
---@param target UnityEngine.Vector3
---@param maxDistanceDelta number
---@return UnityEngine.Vector3
function Vector3.MoveTowards(current,target,maxDistanceDelta) end

---@param current UnityEngine.Vector3
---@param target UnityEngine.Vector3
---@param smoothTime number
---@param maxSpeed number
---@return UnityEngine.Vector3
function Vector3.SmoothDamp(current,target,smoothTime,maxSpeed) end

---@param current UnityEngine.Vector3
---@param target UnityEngine.Vector3
---@param smoothTime number
---@return UnityEngine.Vector3
function Vector3.SmoothDamp(current,target,smoothTime) end

---@param current UnityEngine.Vector3
---@param target UnityEngine.Vector3
---@param smoothTime number
---@param maxSpeed number
---@param deltaTime number
---@return UnityEngine.Vector3
function Vector3.SmoothDamp(current,target,smoothTime,maxSpeed,deltaTime) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Scale(a,b) end

---@param lhs UnityEngine.Vector3
---@param rhs UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Cross(lhs,rhs) end

---@param inDirection UnityEngine.Vector3
---@param inNormal UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Reflect(inDirection,inNormal) end

---@param value UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Normalize(value) end

---@param lhs UnityEngine.Vector3
---@param rhs UnityEngine.Vector3
---@return number
function Vector3.Dot(lhs,rhs) end

---@param vector UnityEngine.Vector3
---@param onNormal UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Project(vector,onNormal) end

---@param vector UnityEngine.Vector3
---@param planeNormal UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.ProjectOnPlane(vector,planeNormal) end

---@param from UnityEngine.Vector3
---@param to UnityEngine.Vector3
---@return number
function Vector3.Angle(from,to) end

---@param from UnityEngine.Vector3
---@param to UnityEngine.Vector3
---@param axis UnityEngine.Vector3
---@return number
function Vector3.SignedAngle(from,to,axis) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@return number
function Vector3.Distance(a,b) end

---@param vector UnityEngine.Vector3
---@param maxLength number
---@return UnityEngine.Vector3
function Vector3.ClampMagnitude(vector,maxLength) end

---@param vector UnityEngine.Vector3
---@return number
function Vector3.Magnitude(vector) end

---@param vector UnityEngine.Vector3
---@return number
function Vector3.SqrMagnitude(vector) end

---@param lhs UnityEngine.Vector3
---@param rhs UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Min(lhs,rhs) end

---@param lhs UnityEngine.Vector3
---@param rhs UnityEngine.Vector3
---@return UnityEngine.Vector3
function Vector3.Max(lhs,rhs) end

return Vector3
