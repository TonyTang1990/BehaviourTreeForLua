---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Plane
---@field public normal UnityEngine.Vector3
---@field public distance number
---@field public flipped UnityEngine.Plane
local Plane = {}

---@param inNormal UnityEngine.Vector3
---@param inPoint UnityEngine.Vector3
function Plane:SetNormalAndPosition(inNormal,inPoint) end

---@param a UnityEngine.Vector3
---@param b UnityEngine.Vector3
---@param c UnityEngine.Vector3
function Plane:Set3Points(a,b,c) end

function Plane:Flip() end

---@param translation UnityEngine.Vector3
function Plane:Translate(translation) end

---@param point UnityEngine.Vector3
---@return UnityEngine.Vector3
function Plane:ClosestPointOnPlane(point) end

---@param point UnityEngine.Vector3
---@return number
function Plane:GetDistanceToPoint(point) end

---@param point UnityEngine.Vector3
---@return System.Boolean
function Plane:GetSide(point) end

---@param inPt0 UnityEngine.Vector3
---@param inPt1 UnityEngine.Vector3
---@return System.Boolean
function Plane:SameSide(inPt0,inPt1) end

---@param ray UnityEngine.Ray
---@return System.Boolean
function Plane:Raycast(ray) end

---@return string
function Plane:ToString() end

---@param format string
---@return string
function Plane:ToString(format) end

---@param plane UnityEngine.Plane
---@param translation UnityEngine.Vector3
---@return UnityEngine.Plane
function Plane.Translate(plane,translation) end

return Plane
