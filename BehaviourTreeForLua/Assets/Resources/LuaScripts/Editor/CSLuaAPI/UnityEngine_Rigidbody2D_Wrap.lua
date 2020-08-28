---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Rigidbody2D : UnityEngine.Component
---@field public position UnityEngine.Vector2
---@field public rotation number
---@field public velocity UnityEngine.Vector2
---@field public angularVelocity number
---@field public useAutoMass System.Boolean
---@field public mass number
---@field public sharedMaterial UnityEngine.PhysicsMaterial2D
---@field public centerOfMass UnityEngine.Vector2
---@field public worldCenterOfMass UnityEngine.Vector2
---@field public inertia number
---@field public drag number
---@field public angularDrag number
---@field public gravityScale number
---@field public bodyType UnityEngine.RigidbodyType2D
---@field public useFullKinematicContacts System.Boolean
---@field public isKinematic System.Boolean
---@field public freezeRotation System.Boolean
---@field public constraints UnityEngine.RigidbodyConstraints2D
---@field public simulated System.Boolean
---@field public interpolation UnityEngine.RigidbodyInterpolation2D
---@field public sleepMode UnityEngine.RigidbodySleepMode2D
---@field public collisionDetectionMode UnityEngine.CollisionDetectionMode2D
---@field public attachedColliderCount int32
local Rigidbody2D = {}

---@param position UnityEngine.Vector2
function Rigidbody2D:MovePosition(position) end

---@param angle number
function Rigidbody2D:MoveRotation(angle) end

---@return System.Boolean
function Rigidbody2D:IsSleeping() end

---@return System.Boolean
function Rigidbody2D:IsAwake() end

function Rigidbody2D:Sleep() end

function Rigidbody2D:WakeUp() end

---@param collider UnityEngine.Collider2D
---@return System.Boolean
function Rigidbody2D:IsTouching(collider) end

---@param collider UnityEngine.Collider2D
---@param contactFilter UnityEngine.ContactFilter2D
---@return System.Boolean
function Rigidbody2D:IsTouching(collider,contactFilter) end

---@param contactFilter UnityEngine.ContactFilter2D
---@return System.Boolean
function Rigidbody2D:IsTouching(contactFilter) end

---@return System.Boolean
function Rigidbody2D:IsTouchingLayers() end

---@param layerMask int32
---@return System.Boolean
function Rigidbody2D:IsTouchingLayers(layerMask) end

---@param point UnityEngine.Vector2
---@return System.Boolean
function Rigidbody2D:OverlapPoint(point) end

---@param collider UnityEngine.Collider2D
---@return UnityEngine.ColliderDistance2D
function Rigidbody2D:Distance(collider) end

---@param force UnityEngine.Vector2
function Rigidbody2D:AddForce(force) end

---@param force UnityEngine.Vector2
---@param mode UnityEngine.ForceMode2D
function Rigidbody2D:AddForce(force,mode) end

---@param relativeForce UnityEngine.Vector2
function Rigidbody2D:AddRelativeForce(relativeForce) end

---@param relativeForce UnityEngine.Vector2
---@param mode UnityEngine.ForceMode2D
function Rigidbody2D:AddRelativeForce(relativeForce,mode) end

---@param force UnityEngine.Vector2
---@param position UnityEngine.Vector2
function Rigidbody2D:AddForceAtPosition(force,position) end

---@param force UnityEngine.Vector2
---@param position UnityEngine.Vector2
---@param mode UnityEngine.ForceMode2D
function Rigidbody2D:AddForceAtPosition(force,position,mode) end

---@param torque number
function Rigidbody2D:AddTorque(torque) end

---@param torque number
---@param mode UnityEngine.ForceMode2D
function Rigidbody2D:AddTorque(torque,mode) end

---@param point UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rigidbody2D:GetPoint(point) end

---@param relativePoint UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rigidbody2D:GetRelativePoint(relativePoint) end

---@param vector UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rigidbody2D:GetVector(vector) end

---@param relativeVector UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rigidbody2D:GetRelativeVector(relativeVector) end

---@param point UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rigidbody2D:GetPointVelocity(point) end

---@param relativePoint UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rigidbody2D:GetRelativePointVelocity(relativePoint) end

---@param contactFilter UnityEngine.ContactFilter2D
---@return int32
function Rigidbody2D:OverlapCollider(contactFilter) end

---@param contacts UnityEngine.ContactPoint2D[]
---@return int32
function Rigidbody2D:GetContacts(contacts) end

---@param contactFilter UnityEngine.ContactFilter2D
---@param contacts UnityEngine.ContactPoint2D[]
---@return int32
function Rigidbody2D:GetContacts(contactFilter,contacts) end

---@param colliders UnityEngine.Collider2D[]
---@return int32
function Rigidbody2D:GetContacts(colliders) end

---@param contactFilter UnityEngine.ContactFilter2D
---@param colliders UnityEngine.Collider2D[]
---@return int32
function Rigidbody2D:GetContacts(contactFilter,colliders) end

---@return int32
function Rigidbody2D:GetAttachedColliders() end

---@param direction UnityEngine.Vector2
---@param results UnityEngine.RaycastHit2D[]
---@return int32
function Rigidbody2D:Cast(direction,results) end

---@param direction UnityEngine.Vector2
---@param results UnityEngine.RaycastHit2D[]
---@param distance number
---@return int32
function Rigidbody2D:Cast(direction,results,distance) end

---@param direction UnityEngine.Vector2
---@param contactFilter UnityEngine.ContactFilter2D
---@param results UnityEngine.RaycastHit2D[]
---@return int32
function Rigidbody2D:Cast(direction,contactFilter,results) end

---@param direction UnityEngine.Vector2
---@param contactFilter UnityEngine.ContactFilter2D
---@param results UnityEngine.RaycastHit2D[]
---@param distance number
---@return int32
function Rigidbody2D:Cast(direction,contactFilter,results,distance) end

return Rigidbody2D
