---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.RectTransform : UnityEngine.Transform
---@field public rect UnityEngine.Rect
---@field public anchorMin UnityEngine.Vector2
---@field public anchorMax UnityEngine.Vector2
---@field public anchoredPosition UnityEngine.Vector2
---@field public sizeDelta UnityEngine.Vector2
---@field public pivot UnityEngine.Vector2
---@field public anchoredPosition3D UnityEngine.Vector3
---@field public offsetMin UnityEngine.Vector2
---@field public offsetMax UnityEngine.Vector2
local RectTransform = {}

function RectTransform:ForceUpdateRectTransforms() end

---@param fourCornersArray UnityEngine.Vector3[]
function RectTransform:GetLocalCorners(fourCornersArray) end

---@param fourCornersArray UnityEngine.Vector3[]
function RectTransform:GetWorldCorners(fourCornersArray) end

---@param edge UnityEngine.RectTransform.Edge
---@param inset number
---@param size number
function RectTransform:SetInsetAndSizeFromParentEdge(edge,inset,size) end

---@param axis UnityEngine.RectTransform.Axis
---@param size number
function RectTransform:SetSizeWithCurrentAnchors(axis,size) end

return RectTransform
