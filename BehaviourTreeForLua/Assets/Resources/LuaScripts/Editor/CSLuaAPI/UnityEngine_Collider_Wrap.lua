---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Collider : UnityEngine.Component
---@field public enabled System.Boolean
---@field public attachedRigidbody UnityEngine.Rigidbody
---@field public isTrigger System.Boolean
---@field public contactOffset number
---@field public bounds UnityEngine.Bounds
---@field public sharedMaterial UnityEngine.PhysicMaterial
---@field public material UnityEngine.PhysicMaterial
local Collider = {}

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Collider:ClosestPoint(position) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@return System.Boolean
function Collider:Raycast(ray,maxDistance) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Collider:ClosestPointOnBounds(position) end

return Collider
