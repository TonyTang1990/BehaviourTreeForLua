---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.Toggle : UnityEngine.UI.Selectable
---@field public group UnityEngine.UI.ToggleGroup
---@field public isOn System.Boolean
---@field public toggleTransition UnityEngine.UI.Toggle.ToggleTransition
---@field public graphic UnityEngine.UI.Graphic
---@field public onValueChanged UnityEngine.UI.Toggle.ToggleEvent
local Toggle = {}

---@param executing UnityEngine.UI.CanvasUpdate
function Toggle:Rebuild(executing) end

function Toggle:LayoutComplete() end

function Toggle:GraphicUpdateComplete() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function Toggle:OnPointerClick(eventData) end

---@param eventData UnityEngine.EventSystems.BaseEventData
function Toggle:OnSubmit(eventData) end

return Toggle
