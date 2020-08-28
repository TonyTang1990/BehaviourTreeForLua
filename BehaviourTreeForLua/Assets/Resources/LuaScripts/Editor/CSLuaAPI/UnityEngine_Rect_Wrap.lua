---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Rect
---@field public x number
---@field public y number
---@field public position UnityEngine.Vector2
---@field public center UnityEngine.Vector2
---@field public min UnityEngine.Vector2
---@field public max UnityEngine.Vector2
---@field public width number
---@field public height number
---@field public size UnityEngine.Vector2
---@field public xMin number
---@field public yMin number
---@field public xMax number
---@field public yMax number
---@field static zero UnityEngine.Rect
local Rect = {}

---@param x number
---@param y number
---@param width number
---@param height number
function Rect:Set(x,y,width,height) end

---@param point UnityEngine.Vector2
---@return System.Boolean
function Rect:Contains(point) end

---@param point UnityEngine.Vector3
---@return System.Boolean
function Rect:Contains(point) end

---@param point UnityEngine.Vector3
---@param allowInverse System.Boolean
---@return System.Boolean
function Rect:Contains(point,allowInverse) end

---@param other UnityEngine.Rect
---@return System.Boolean
function Rect:Overlaps(other) end

---@param other UnityEngine.Rect
---@param allowInverse System.Boolean
---@return System.Boolean
function Rect:Overlaps(other,allowInverse) end

---@return int32
function Rect:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Rect:Equals(other) end

---@param other UnityEngine.Rect
---@return System.Boolean
function Rect:Equals(other) end

---@return string
function Rect:ToString() end

---@param format string
---@return string
function Rect:ToString(format) end

---@param xmin number
---@param ymin number
---@param xmax number
---@param ymax number
---@return UnityEngine.Rect
function Rect.MinMaxRect(xmin,ymin,xmax,ymax) end

---@param rectangle UnityEngine.Rect
---@param normalizedRectCoordinates UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rect.NormalizedToPoint(rectangle,normalizedRectCoordinates) end

---@param rectangle UnityEngine.Rect
---@param point UnityEngine.Vector2
---@return UnityEngine.Vector2
function Rect.PointToNormalized(rectangle,point) end

return Rect
