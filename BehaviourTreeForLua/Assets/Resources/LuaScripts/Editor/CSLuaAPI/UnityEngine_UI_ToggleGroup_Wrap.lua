---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.ToggleGroup : UnityEngine.EventSystems.UIBehaviour
---@field public allowSwitchOff System.Boolean
local ToggleGroup = {}

---@param toggle UnityEngine.UI.Toggle
function ToggleGroup:NotifyToggleOn(toggle) end

---@param toggle UnityEngine.UI.Toggle
function ToggleGroup:UnregisterToggle(toggle) end

---@param toggle UnityEngine.UI.Toggle
function ToggleGroup:RegisterToggle(toggle) end

---@return System.Boolean
function ToggleGroup:AnyTogglesOn() end

---@return System.Collections.Generic.IEnumerable
function ToggleGroup:ActiveToggles() end

function ToggleGroup:SetAllTogglesOff() end

return ToggleGroup
