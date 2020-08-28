---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Quaternion
---@field public Item number
---@field public eulerAngles UnityEngine.Vector3
---@field public normalized UnityEngine.Quaternion
---@field public x number
---@field public y number
---@field public z number
---@field public w number
---@field static identity UnityEngine.Quaternion
---@field static kEpsilon number
local Quaternion = {}

---@param newX number
---@param newY number
---@param newZ number
---@param newW number
function Quaternion:Set(newX,newY,newZ,newW) end

---@param view UnityEngine.Vector3
function Quaternion:SetLookRotation(view) end

---@param view UnityEngine.Vector3
---@param up UnityEngine.Vector3
function Quaternion:SetLookRotation(view,up) end

function Quaternion:ToAngleAxis() end

---@param fromDirection UnityEngine.Vector3
---@param toDirection UnityEngine.Vector3
function Quaternion:SetFromToRotation(fromDirection,toDirection) end

function Quaternion:Normalize() end

---@return int32
function Quaternion:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Quaternion:Equals(other) end

---@param other UnityEngine.Quaternion
---@return System.Boolean
function Quaternion:Equals(other) end

---@return string
function Quaternion:ToString() end

---@param format string
---@return string
function Quaternion:ToString(format) end

---@param fromDirection UnityEngine.Vector3
---@param toDirection UnityEngine.Vector3
---@return UnityEngine.Quaternion
function Quaternion.FromToRotation(fromDirection,toDirection) end

---@param rotation UnityEngine.Quaternion
---@return UnityEngine.Quaternion
function Quaternion.Inverse(rotation) end

---@param a UnityEngine.Quaternion
---@param b UnityEngine.Quaternion
---@param t number
---@return UnityEngine.Quaternion
function Quaternion.Slerp(a,b,t) end

---@param a UnityEngine.Quaternion
---@param b UnityEngine.Quaternion
---@param t number
---@return UnityEngine.Quaternion
function Quaternion.SlerpUnclamped(a,b,t) end

---@param a UnityEngine.Quaternion
---@param b UnityEngine.Quaternion
---@param t number
---@return UnityEngine.Quaternion
function Quaternion.Lerp(a,b,t) end

---@param a UnityEngine.Quaternion
---@param b UnityEngine.Quaternion
---@param t number
---@return UnityEngine.Quaternion
function Quaternion.LerpUnclamped(a,b,t) end

---@param angle number
---@param axis UnityEngine.Vector3
---@return UnityEngine.Quaternion
function Quaternion.AngleAxis(angle,axis) end

---@param forward UnityEngine.Vector3
---@param upwards UnityEngine.Vector3
---@return UnityEngine.Quaternion
function Quaternion.LookRotation(forward,upwards) end

---@param forward UnityEngine.Vector3
---@return UnityEngine.Quaternion
function Quaternion.LookRotation(forward) end

---@param a UnityEngine.Quaternion
---@param b UnityEngine.Quaternion
---@return number
function Quaternion.Dot(a,b) end

---@param a UnityEngine.Quaternion
---@param b UnityEngine.Quaternion
---@return number
function Quaternion.Angle(a,b) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Quaternion
function Quaternion.Euler(x,y,z) end

---@param euler UnityEngine.Vector3
---@return UnityEngine.Quaternion
function Quaternion.Euler(euler) end

---@param from UnityEngine.Quaternion
---@param to UnityEngine.Quaternion
---@param maxDegreesDelta number
---@return UnityEngine.Quaternion
function Quaternion.RotateTowards(from,to,maxDegreesDelta) end

---@param q UnityEngine.Quaternion
---@return UnityEngine.Quaternion
function Quaternion.Normalize(q) end

return Quaternion
