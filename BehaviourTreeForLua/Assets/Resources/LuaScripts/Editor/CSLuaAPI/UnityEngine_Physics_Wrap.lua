---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Physics
---@field static gravity UnityEngine.Vector3
---@field static defaultContactOffset number
---@field static sleepThreshold number
---@field static queriesHitTriggers System.Boolean
---@field static queriesHitBackfaces System.Boolean
---@field static bounceThreshold number
---@field static defaultSolverIterations int32
---@field static defaultSolverVelocityIterations int32
---@field static defaultPhysicsScene UnityEngine.PhysicsScene
---@field static autoSimulation System.Boolean
---@field static autoSyncTransforms System.Boolean
---@field static reuseCollisionCallbacks System.Boolean
---@field static interCollisionDistance number
---@field static interCollisionStiffness number
---@field static interCollisionSettingsToggle System.Boolean
---@field static IgnoreRaycastLayer int32
---@field static DefaultRaycastLayers int32
---@field static AllLayers int32
local Physics = {}

---@param collider1 UnityEngine.Collider
---@param collider2 UnityEngine.Collider
---@param ignore System.Boolean
function Physics.IgnoreCollision(collider1,collider2,ignore) end

---@param collider1 UnityEngine.Collider
---@param collider2 UnityEngine.Collider
function Physics.IgnoreCollision(collider1,collider2) end

---@param layer1 int32
---@param layer2 int32
---@param ignore System.Boolean
function Physics.IgnoreLayerCollision(layer1,layer2,ignore) end

---@param layer1 int32
---@param layer2 int32
function Physics.IgnoreLayerCollision(layer1,layer2) end

---@param layer1 int32
---@param layer2 int32
---@return System.Boolean
function Physics.GetIgnoreLayerCollision(layer1,layer2) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.Raycast(origin,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.Raycast(origin,direction,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return System.Boolean
function Physics.Raycast(origin,direction,maxDistance) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.Raycast(origin,direction) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.Raycast(origin,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.Raycast(origin,direction,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return System.Boolean
function Physics.Raycast(origin,direction,maxDistance) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.Raycast(origin,direction) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.Raycast(ray,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.Raycast(ray,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@return System.Boolean
function Physics.Raycast(ray,maxDistance) end

---@param ray UnityEngine.Ray
---@return System.Boolean
function Physics.Raycast(ray) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.Raycast(ray,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.Raycast(ray,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@return System.Boolean
function Physics.Raycast(ray,maxDistance) end

---@param ray UnityEngine.Ray
---@return System.Boolean
function Physics.Raycast(ray) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.Linecast(start,end_,layerMask,queryTriggerInteraction) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param layerMask int32
---@return System.Boolean
function Physics.Linecast(start,end_,layerMask) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@return System.Boolean
function Physics.Linecast(start,end_) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.Linecast(start,end_,layerMask,queryTriggerInteraction) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param layerMask int32
---@return System.Boolean
function Physics.Linecast(start,end_,layerMask) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@return System.Boolean
function Physics.Linecast(start,end_) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction,maxDistance,layerMask) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction,maxDistance) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction,maxDistance,layerMask) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction,maxDistance) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.CapsuleCast(point1,point2,radius,direction) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.SphereCast(origin,radius,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.SphereCast(origin,radius,direction,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return System.Boolean
function Physics.SphereCast(origin,radius,direction,maxDistance) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.SphereCast(origin,radius,direction) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.SphereCast(ray,radius,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.SphereCast(ray,radius,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@return System.Boolean
function Physics.SphereCast(ray,radius,maxDistance) end

---@param ray UnityEngine.Ray
---@param radius number
---@return System.Boolean
function Physics.SphereCast(ray,radius) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.SphereCast(ray,radius,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.SphereCast(ray,radius,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@return System.Boolean
function Physics.SphereCast(ray,radius,maxDistance) end

---@param ray UnityEngine.Ray
---@param radius number
---@return System.Boolean
function Physics.SphereCast(ray,radius) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation,maxDistance,layerMask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation,maxDistance,layerMask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation,maxDistance) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation,maxDistance,layerMask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation,maxDistance,layerMask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation,maxDistance) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@return System.Boolean
function Physics.BoxCast(center,halfExtents,direction) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(origin,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(origin,direction,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(origin,direction,maxDistance) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(origin,direction) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(ray,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@param layerMask int32
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(ray,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param maxDistance number
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(ray,maxDistance) end

---@param ray UnityEngine.Ray
---@return UnityEngine.RaycastHit[]
function Physics.RaycastAll(ray) end

---@param ray UnityEngine.Ray
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.RaycastNonAlloc(ray,results,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@return int32
function Physics.RaycastNonAlloc(ray,results,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@return int32
function Physics.RaycastNonAlloc(ray,results,maxDistance) end

---@param ray UnityEngine.Ray
---@param results UnityEngine.RaycastHit[]
---@return int32
function Physics.RaycastNonAlloc(ray,results) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.RaycastNonAlloc(origin,direction,results,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@return int32
function Physics.RaycastNonAlloc(origin,direction,results,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@return int32
function Physics.RaycastNonAlloc(origin,direction,results,maxDistance) end

---@param origin UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@return int32
function Physics.RaycastNonAlloc(origin,direction,results) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.RaycastHit[]
function Physics.CapsuleCastAll(point1,point2,radius,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return UnityEngine.RaycastHit[]
function Physics.CapsuleCastAll(point1,point2,radius,direction,maxDistance,layerMask) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return UnityEngine.RaycastHit[]
function Physics.CapsuleCastAll(point1,point2,radius,direction,maxDistance) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@return UnityEngine.RaycastHit[]
function Physics.CapsuleCastAll(point1,point2,radius,direction) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(origin,radius,direction,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@param layerMask int32
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(origin,radius,direction,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param maxDistance number
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(origin,radius,direction,maxDistance) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(origin,radius,direction) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(ray,radius,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@param layerMask int32
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(ray,radius,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param radius number
---@param maxDistance number
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(ray,radius,maxDistance) end

---@param ray UnityEngine.Ray
---@param radius number
---@return UnityEngine.RaycastHit[]
function Physics.SphereCastAll(ray,radius) end

---@param point0 UnityEngine.Vector3
---@param point1 UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.Collider[]
function Physics.OverlapCapsule(point0,point1,radius,layerMask,queryTriggerInteraction) end

---@param point0 UnityEngine.Vector3
---@param point1 UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@return UnityEngine.Collider[]
function Physics.OverlapCapsule(point0,point1,radius,layerMask) end

---@param point0 UnityEngine.Vector3
---@param point1 UnityEngine.Vector3
---@param radius number
---@return UnityEngine.Collider[]
function Physics.OverlapCapsule(point0,point1,radius) end

---@param position UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.Collider[]
function Physics.OverlapSphere(position,radius,layerMask,queryTriggerInteraction) end

---@param position UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@return UnityEngine.Collider[]
function Physics.OverlapSphere(position,radius,layerMask) end

---@param position UnityEngine.Vector3
---@param radius number
---@return UnityEngine.Collider[]
function Physics.OverlapSphere(position,radius) end

---@param step number
function Physics.Simulate(step) end

function Physics.SyncTransforms() end

---@param colliderA UnityEngine.Collider
---@param positionA UnityEngine.Vector3
---@param rotationA UnityEngine.Quaternion
---@param colliderB UnityEngine.Collider
---@param positionB UnityEngine.Vector3
---@param rotationB UnityEngine.Quaternion
---@return System.Boolean
function Physics.ComputePenetration(colliderA,positionA,rotationA,colliderB,positionB,rotationB) end

---@param point UnityEngine.Vector3
---@param collider UnityEngine.Collider
---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
---@return UnityEngine.Vector3
function Physics.ClosestPoint(point,collider,position,rotation) end

---@param position UnityEngine.Vector3
---@param radius number
---@param results UnityEngine.Collider[]
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.OverlapSphereNonAlloc(position,radius,results,layerMask,queryTriggerInteraction) end

---@param position UnityEngine.Vector3
---@param radius number
---@param results UnityEngine.Collider[]
---@param layerMask int32
---@return int32
function Physics.OverlapSphereNonAlloc(position,radius,results,layerMask) end

---@param position UnityEngine.Vector3
---@param radius number
---@param results UnityEngine.Collider[]
---@return int32
function Physics.OverlapSphereNonAlloc(position,radius,results) end

---@param position UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.CheckSphere(position,radius,layerMask,queryTriggerInteraction) end

---@param position UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@return System.Boolean
function Physics.CheckSphere(position,radius,layerMask) end

---@param position UnityEngine.Vector3
---@param radius number
---@return System.Boolean
function Physics.CheckSphere(position,radius) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.CapsuleCastNonAlloc(point1,point2,radius,direction,results,maxDistance,layerMask,queryTriggerInteraction) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@return int32
function Physics.CapsuleCastNonAlloc(point1,point2,radius,direction,results,maxDistance,layerMask) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@return int32
function Physics.CapsuleCastNonAlloc(point1,point2,radius,direction,results,maxDistance) end

---@param point1 UnityEngine.Vector3
---@param point2 UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@return int32
function Physics.CapsuleCastNonAlloc(point1,point2,radius,direction,results) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.SphereCastNonAlloc(origin,radius,direction,results,maxDistance,layerMask,queryTriggerInteraction) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@return int32
function Physics.SphereCastNonAlloc(origin,radius,direction,results,maxDistance,layerMask) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@return int32
function Physics.SphereCastNonAlloc(origin,radius,direction,results,maxDistance) end

---@param origin UnityEngine.Vector3
---@param radius number
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@return int32
function Physics.SphereCastNonAlloc(origin,radius,direction,results) end

---@param ray UnityEngine.Ray
---@param radius number
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.SphereCastNonAlloc(ray,radius,results,maxDistance,layerMask,queryTriggerInteraction) end

---@param ray UnityEngine.Ray
---@param radius number
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@param layerMask int32
---@return int32
function Physics.SphereCastNonAlloc(ray,radius,results,maxDistance,layerMask) end

---@param ray UnityEngine.Ray
---@param radius number
---@param results UnityEngine.RaycastHit[]
---@param maxDistance number
---@return int32
function Physics.SphereCastNonAlloc(ray,radius,results,maxDistance) end

---@param ray UnityEngine.Ray
---@param radius number
---@param results UnityEngine.RaycastHit[]
---@return int32
function Physics.SphereCastNonAlloc(ray,radius,results) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.CheckCapsule(start,end_,radius,layerMask,queryTriggerInteraction) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param radius number
---@param layerMask int32
---@return System.Boolean
function Physics.CheckCapsule(start,end_,radius,layerMask) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param radius number
---@return System.Boolean
function Physics.CheckCapsule(start,end_,radius) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param layermask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return System.Boolean
function Physics.CheckBox(center,halfExtents,orientation,layermask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param layerMask int32
---@return System.Boolean
function Physics.CheckBox(center,halfExtents,orientation,layerMask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@return System.Boolean
function Physics.CheckBox(center,halfExtents,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@return System.Boolean
function Physics.CheckBox(center,halfExtents) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.Collider[]
function Physics.OverlapBox(center,halfExtents,orientation,layerMask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param layerMask int32
---@return UnityEngine.Collider[]
function Physics.OverlapBox(center,halfExtents,orientation,layerMask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@return UnityEngine.Collider[]
function Physics.OverlapBox(center,halfExtents,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@return UnityEngine.Collider[]
function Physics.OverlapBox(center,halfExtents) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param results UnityEngine.Collider[]
---@param orientation UnityEngine.Quaternion
---@param mask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.OverlapBoxNonAlloc(center,halfExtents,results,orientation,mask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param results UnityEngine.Collider[]
---@param orientation UnityEngine.Quaternion
---@param mask int32
---@return int32
function Physics.OverlapBoxNonAlloc(center,halfExtents,results,orientation,mask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param results UnityEngine.Collider[]
---@param orientation UnityEngine.Quaternion
---@return int32
function Physics.OverlapBoxNonAlloc(center,halfExtents,results,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param results UnityEngine.Collider[]
---@return int32
function Physics.OverlapBoxNonAlloc(center,halfExtents,results) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.BoxCastNonAlloc(center,halfExtents,direction,results,orientation,maxDistance,layerMask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param orientation UnityEngine.Quaternion
---@return int32
function Physics.BoxCastNonAlloc(center,halfExtents,direction,results,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@return int32
function Physics.BoxCastNonAlloc(center,halfExtents,direction,results,orientation,maxDistance) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@return int32
function Physics.BoxCastNonAlloc(center,halfExtents,direction,results,orientation,maxDistance,layerMask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param results UnityEngine.RaycastHit[]
---@return int32
function Physics.BoxCastNonAlloc(center,halfExtents,direction,results) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return UnityEngine.RaycastHit[]
function Physics.BoxCastAll(center,halfExtents,direction,orientation,maxDistance,layerMask,queryTriggerInteraction) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@param layerMask int32
---@return UnityEngine.RaycastHit[]
function Physics.BoxCastAll(center,halfExtents,direction,orientation,maxDistance,layerMask) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@param maxDistance number
---@return UnityEngine.RaycastHit[]
function Physics.BoxCastAll(center,halfExtents,direction,orientation,maxDistance) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@param orientation UnityEngine.Quaternion
---@return UnityEngine.RaycastHit[]
function Physics.BoxCastAll(center,halfExtents,direction,orientation) end

---@param center UnityEngine.Vector3
---@param halfExtents UnityEngine.Vector3
---@param direction UnityEngine.Vector3
---@return UnityEngine.RaycastHit[]
function Physics.BoxCastAll(center,halfExtents,direction) end

---@param point0 UnityEngine.Vector3
---@param point1 UnityEngine.Vector3
---@param radius number
---@param results UnityEngine.Collider[]
---@param layerMask int32
---@param queryTriggerInteraction UnityEngine.QueryTriggerInteraction
---@return int32
function Physics.OverlapCapsuleNonAlloc(point0,point1,radius,results,layerMask,queryTriggerInteraction) end

---@param point0 UnityEngine.Vector3
---@param point1 UnityEngine.Vector3
---@param radius number
---@param results UnityEngine.Collider[]
---@param layerMask int32
---@return int32
function Physics.OverlapCapsuleNonAlloc(point0,point1,radius,results,layerMask) end

---@param point0 UnityEngine.Vector3
---@param point1 UnityEngine.Vector3
---@param radius number
---@param results UnityEngine.Collider[]
---@return int32
function Physics.OverlapCapsuleNonAlloc(point0,point1,radius,results) end

---@param worldBounds UnityEngine.Bounds
---@param subdivisions int32
function Physics.RebuildBroadphaseRegions(worldBounds,subdivisions) end

return Physics
