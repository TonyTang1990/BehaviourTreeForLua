---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.RectTransformUtility
local RectTransformUtility = {}

---@param rect UnityEngine.RectTransform
---@param screenPoint UnityEngine.Vector2
---@return System.Boolean
function RectTransformUtility.RectangleContainsScreenPoint(rect,screenPoint) end

---@param rect UnityEngine.RectTransform
---@param screenPoint UnityEngine.Vector2
---@param cam UnityEngine.Camera
---@return System.Boolean
function RectTransformUtility.RectangleContainsScreenPoint(rect,screenPoint,cam) end

---@param rect UnityEngine.RectTransform
---@param screenPoint UnityEngine.Vector2
---@param cam UnityEngine.Camera
---@return System.Boolean
function RectTransformUtility.ScreenPointToWorldPointInRectangle(rect,screenPoint,cam) end

---@param rect UnityEngine.RectTransform
---@param screenPoint UnityEngine.Vector2
---@param cam UnityEngine.Camera
---@return System.Boolean
function RectTransformUtility.ScreenPointToLocalPointInRectangle(rect,screenPoint,cam) end

---@param cam UnityEngine.Camera
---@param screenPos UnityEngine.Vector2
---@return UnityEngine.Ray
function RectTransformUtility.ScreenPointToRay(cam,screenPos) end

---@param cam UnityEngine.Camera
---@param worldPoint UnityEngine.Vector3
---@return UnityEngine.Vector2
function RectTransformUtility.WorldToScreenPoint(cam,worldPoint) end

---@param root UnityEngine.Transform
---@param child UnityEngine.Transform
---@return UnityEngine.Bounds
function RectTransformUtility.CalculateRelativeRectTransformBounds(root,child) end

---@param trans UnityEngine.Transform
---@return UnityEngine.Bounds
function RectTransformUtility.CalculateRelativeRectTransformBounds(trans) end

---@param rect UnityEngine.RectTransform
---@param axis int32
---@param keepPositioning System.Boolean
---@param recursive System.Boolean
function RectTransformUtility.FlipLayoutOnAxis(rect,axis,keepPositioning,recursive) end

---@param rect UnityEngine.RectTransform
---@param keepPositioning System.Boolean
---@param recursive System.Boolean
function RectTransformUtility.FlipLayoutAxes(rect,keepPositioning,recursive) end

---@param point UnityEngine.Vector2
---@param elementTransform UnityEngine.Transform
---@param canvas UnityEngine.Canvas
---@return UnityEngine.Vector2
function RectTransformUtility.PixelAdjustPoint(point,elementTransform,canvas) end

---@param rectTransform UnityEngine.RectTransform
---@param canvas UnityEngine.Canvas
---@return UnityEngine.Rect
function RectTransformUtility.PixelAdjustRect(rectTransform,canvas) end

return RectTransformUtility
