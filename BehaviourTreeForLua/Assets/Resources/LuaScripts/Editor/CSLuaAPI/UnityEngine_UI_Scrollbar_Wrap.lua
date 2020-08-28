---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.Scrollbar : UnityEngine.UI.Selectable
---@field public handleRect UnityEngine.RectTransform
---@field public direction UnityEngine.UI.Scrollbar.Direction
---@field public value number
---@field public size number
---@field public numberOfSteps int32
---@field public onValueChanged UnityEngine.UI.Scrollbar.ScrollEvent
local Scrollbar = {}

---@param executing UnityEngine.UI.CanvasUpdate
function Scrollbar:Rebuild(executing) end

function Scrollbar:LayoutComplete() end

function Scrollbar:GraphicUpdateComplete() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Scrollbar:OnBeginDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Scrollbar:OnDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Scrollbar:OnPointerDown(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Scrollbar:OnPointerUp(eventData) end

---@param eventData UnityEngine.EventSystems.AxisEventData
function Scrollbar:OnMove(eventData) end

---@return UnityEngine.UI.Selectable
function Scrollbar:FindSelectableOnLeft() end

---@return UnityEngine.UI.Selectable
function Scrollbar:FindSelectableOnRight() end

---@return UnityEngine.UI.Selectable
function Scrollbar:FindSelectableOnUp() end

---@return UnityEngine.UI.Selectable
function Scrollbar:FindSelectableOnDown() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Scrollbar:OnInitializePotentialDrag(eventData) end

---@param direction UnityEngine.UI.Scrollbar.Direction
---@param includeRectLayouts System.Boolean
function Scrollbar:SetDirection(direction,includeRectLayouts) end

return Scrollbar
