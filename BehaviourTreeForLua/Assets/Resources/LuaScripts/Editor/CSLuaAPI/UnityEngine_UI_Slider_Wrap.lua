---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.Slider : UnityEngine.UI.Selectable
---@field public fillRect UnityEngine.RectTransform
---@field public handleRect UnityEngine.RectTransform
---@field public direction UnityEngine.UI.Slider.Direction
---@field public minValue number
---@field public maxValue number
---@field public wholeNumbers System.Boolean
---@field public value number
---@field public normalizedValue number
---@field public onValueChanged UnityEngine.UI.Slider.SliderEvent
---@field public fillRect UnityEngine.RectTransform
---@field public handleRect UnityEngine.RectTransform
---@field public direction UnityEngine.UI.Slider.Direction
---@field public minValue number
---@field public maxValue number
---@field public wholeNumbers System.Boolean
---@field public value number
---@field public normalizedValue number
---@field public onValueChanged UnityEngine.UI.Slider.SliderEvent
local Slider = {}

---@param executing UnityEngine.UI.CanvasUpdate
function Slider:Rebuild(executing) end

function Slider:LayoutComplete() end

function Slider:GraphicUpdateComplete() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Slider:OnPointerDown(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Slider:OnDrag(eventData) end

---@param eventData UnityEngine.EventSystems.AxisEventData
function Slider:OnMove(eventData) end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnLeft() end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnRight() end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnUp() end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnDown() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Slider:OnInitializePotentialDrag(eventData) end

---@param direction UnityEngine.UI.Slider.Direction
---@param includeRectLayouts System.Boolean
function Slider:SetDirection(direction,includeRectLayouts) end

---@param executing UnityEngine.UI.CanvasUpdate
function Slider:Rebuild(executing) end

function Slider:LayoutComplete() end

function Slider:GraphicUpdateComplete() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Slider:OnPointerDown(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Slider:OnDrag(eventData) end

---@param eventData UnityEngine.EventSystems.AxisEventData
function Slider:OnMove(eventData) end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnLeft() end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnRight() end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnUp() end

---@return UnityEngine.UI.Selectable
function Slider:FindSelectableOnDown() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Slider:OnInitializePotentialDrag(eventData) end

---@param direction UnityEngine.UI.Slider.Direction
---@param includeRectLayouts System.Boolean
function Slider:SetDirection(direction,includeRectLayouts) end

return Slider
