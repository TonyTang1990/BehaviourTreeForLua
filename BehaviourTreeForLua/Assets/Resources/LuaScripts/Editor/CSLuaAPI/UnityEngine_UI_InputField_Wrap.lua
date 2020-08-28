---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.InputField : UnityEngine.UI.Selectable
---@field public shouldHideMobileInput System.Boolean
---@field public text string
---@field public isFocused System.Boolean
---@field public caretBlinkRate number
---@field public caretWidth int32
---@field public textComponent UnityEngine.UI.Text
---@field public placeholder UnityEngine.UI.Graphic
---@field public caretColor UnityEngine.Color
---@field public customCaretColor System.Boolean
---@field public selectionColor UnityEngine.Color
---@field public onEndEdit UnityEngine.UI.InputField.SubmitEvent
---@field public onValueChanged UnityEngine.UI.InputField.OnChangeEvent
---@field public onValidateInput UnityEngine.UI.InputField.OnValidateInput
---@field public characterLimit int32
---@field public contentType UnityEngine.UI.InputField.ContentType
---@field public lineType UnityEngine.UI.InputField.LineType
---@field public inputType UnityEngine.UI.InputField.InputType
---@field public touchScreenKeyboard UnityEngine.TouchScreenKeyboard
---@field public keyboardType UnityEngine.TouchScreenKeyboardType
---@field public characterValidation UnityEngine.UI.InputField.CharacterValidation
---@field public readOnly System.Boolean
---@field public multiLine System.Boolean
---@field public asteriskChar System.Char
---@field public wasCanceled System.Boolean
---@field public caretPosition int32
---@field public selectionAnchorPosition int32
---@field public selectionFocusPosition int32
---@field public minWidth number
---@field public preferredWidth number
---@field public flexibleWidth number
---@field public minHeight number
---@field public preferredHeight number
---@field public flexibleHeight number
---@field public layoutPriority int32
local InputField = {}

---@param shift System.Boolean
function InputField:MoveTextEnd(shift) end

---@param shift System.Boolean
function InputField:MoveTextStart(shift) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function InputField:OnBeginDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function InputField:OnDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function InputField:OnEndDrag(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function InputField:OnPointerDown(eventData) end

---@param e UnityEngine.Event
function InputField:ProcessEvent(e) end

---@param eventData UnityEngine.EventSystems.BaseEventData
function InputField:OnUpdateSelected(eventData) end

function InputField:ForceLabelUpdate() end

---@param update UnityEngine.UI.CanvasUpdate
function InputField:Rebuild(update) end

function InputField:LayoutComplete() end

function InputField:GraphicUpdateComplete() end

function InputField:ActivateInputField() end

---@param eventData UnityEngine.EventSystems.BaseEventData
function InputField:OnSelect(eventData) end

---@param eventData UnityEngine.EventSystems.PointerEventData
function InputField:OnPointerClick(eventData) end

function InputField:DeactivateInputField() end

---@param eventData UnityEngine.EventSystems.BaseEventData
function InputField:OnDeselect(eventData) end

---@param eventData UnityEngine.EventSystems.BaseEventData
function InputField:OnSubmit(eventData) end

function InputField:CalculateLayoutInputHorizontal() end

function InputField:CalculateLayoutInputVertical() end

return InputField
