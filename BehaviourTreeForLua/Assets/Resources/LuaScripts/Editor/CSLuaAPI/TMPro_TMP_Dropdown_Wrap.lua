---===================== Author Qcbf 这是自动生成的代码 =====================

---@class TMPro.TMP_Dropdown : UnityEngine.UI.Selectable
---@field public template UnityEngine.RectTransform
---@field public captionText TMPro.TMP_Text
---@field public captionImage UnityEngine.UI.Image
---@field public itemText TMPro.TMP_Text
---@field public itemImage UnityEngine.UI.Image
---@field public options System.Collections.Generic.List
---@field public onValueChanged TMPro.TMP_Dropdown.DropdownEvent
---@field public value int32
---@field public IsExpanded System.Boolean
local TMP_Dropdown = {}

---@param input int32
function TMP_Dropdown:SetValueWithoutNotify(input) end

function TMP_Dropdown:RefreshShownValue() end

---@param options System.Collections.Generic.List
function TMP_Dropdown:AddOptions(options) end

---@param options System.Collections.Generic.List
function TMP_Dropdown:AddOptions(options) end

---@param options System.Collections.Generic.List
function TMP_Dropdown:AddOptions(options) end

function TMP_Dropdown:ClearOptions() end

---@param eventData UnityEngine.EventSystems.PointerEventData
function TMP_Dropdown:OnPointerClick(eventData) end

---@param eventData UnityEngine.EventSystems.BaseEventData
function TMP_Dropdown:OnSubmit(eventData) end

---@param eventData UnityEngine.EventSystems.BaseEventData
function TMP_Dropdown:OnCancel(eventData) end

function TMP_Dropdown:Show() end

function TMP_Dropdown:Hide() end

return TMP_Dropdown
