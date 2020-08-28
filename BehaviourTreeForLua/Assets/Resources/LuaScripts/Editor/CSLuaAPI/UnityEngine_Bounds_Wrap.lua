---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Bounds
---@field public center UnityEngine.Vector3
---@field public size UnityEngine.Vector3
---@field public extents UnityEngine.Vector3
---@field public min UnityEngine.Vector3
---@field public max UnityEngine.Vector3
local Bounds = {}

---@return int32
function Bounds:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Bounds:Equals(other) end

---@param other UnityEngine.Bounds
---@return System.Boolean
function Bounds:Equals(other) end

---@param min UnityEngine.Vector3
---@param max UnityEngine.Vector3
function Bounds:SetMinMax(min,max) end

---@param point UnityEngine.Vector3
function Bounds:Encapsulate(point) end

---@param bounds UnityEngine.Bounds
function Bounds:Encapsulate(bounds) end

---@param amount number
function Bounds:Expand(amount) end

---@param amount UnityEngine.Vector3
function Bounds:Expand(amount) end

---@param bounds UnityEngine.Bounds
---@return System.Boolean
function Bounds:Intersects(bounds) end

---@param ray UnityEngine.Ray
---@return System.Boolean
function Bounds:IntersectRay(ray) end

---@param ray UnityEngine.Ray
---@return System.Boolean
function Bounds:IntersectRay(ray) end

---@return string
function Bounds:ToString() end

---@param format string
---@return string
function Bounds:ToString(format) end

---@param point UnityEngine.Vector3
---@return System.Boolean
function Bounds:Contains(point) end

---@param point UnityEngine.Vector3
---@return number
function Bounds:SqrDistance(point) end

---@param point UnityEngine.Vector3
---@return UnityEngine.Vector3
function Bounds:ClosestPoint(point) end

return Bounds
