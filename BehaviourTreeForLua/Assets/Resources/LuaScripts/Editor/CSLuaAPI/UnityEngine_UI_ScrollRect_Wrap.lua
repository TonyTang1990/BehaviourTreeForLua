---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.ScrollRect : UnityEngine.EventSystems.UIBehaviour
---@field public content UnityEngine.RectTransform
---@field public horizontal System.Boolean
---@field public vertical System.Boolean
---@field public movementType UnityEngine.UI.ScrollRect.MovementType
---@field public elasticity number
---@field public inertia System.Boolean
---@field public decelerationRate number
---@field public scrollSensitivity number
---@field public viewport UnityEngine.RectTransform
---@field public horizontalScrollbar UnityEngine.UI.Scrollbar
---@field public verticalScrollbar UnityEngine.UI.Scrollbar
---@field public horizontalScrollbarVisibility UnityEngine.UI.ScrollRect.ScrollbarVisibility
---@field public verticalScrollbarVisibility UnityEngine.UI.ScrollRect.ScrollbarVisibility
---@field public horizontalScrollbarSpacing number
---@field public verticalScrollbarSpacing number
---@field public onValueChanged UnityEngine.UI.ScrollRect.ScrollRectEvent
---@field public velocity UnityEngine.Vector2
---@field public normalizedPosition UnityEngine.Vector2
---@field public horizontalNormalizedPosition number
---@field public verticalNormalizedPosition number
---@field public minWidth number
---@field public preferredWidth number
---@field public flexibleWidth number
---@field public minHeight number
---@field public preferredHeight number
---@field public flexibleHeight number
---@field public layoutPriority int32
local ScrollRect = {}

---@param executing UnityEngine.UI.CanvasUpdate
function ScrollRect:Rebuild(executing) end

function ScrollRect:LayoutComplete() end

function ScrollRect:GraphicUpdateComplete() end

---@return System.Boolean
function ScrollRect:IsActive() end

function ScrollRect:StopMovement() end

---@param data UnityEngine.EventSystems.PointerEventData
function ScrollRect:OnScroll(data) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function ScrollRect:OnInitializePotentialDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function ScrollRect:OnBeginDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function ScrollRect:OnEndDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function ScrollRect:OnDrag(eventData) end

function ScrollRect:CalculateLayoutInputHorizontal() end

function ScrollRect:CalculateLayoutInputVertical() end

function ScrollRect:SetLayoutHorizontal() end

function ScrollRect:SetLayoutVertical() end

return ScrollRect
