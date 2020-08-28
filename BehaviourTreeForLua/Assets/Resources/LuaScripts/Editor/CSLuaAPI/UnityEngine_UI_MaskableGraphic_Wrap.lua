---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.MaskableGraphic : UnityEngine.UI.Graphic
---@field public onCullStateChanged UnityEngine.UI.MaskableGraphic.CullStateChangedEvent
---@field public maskable System.Boolean
local MaskableGraphic = {}

---@param baseMaterial UnityEngine.Material
---@return UnityEngine.Material
function MaskableGraphic:GetModifiedMaterial(baseMaterial) end

---@param clipRect UnityEngine.Rect
---@param validRect System.Boolean
function MaskableGraphic:Cull(clipRect,validRect) end

---@param clipRect UnityEngine.Rect
---@param validRect System.Boolean
function MaskableGraphic:SetClipRect(clipRect,validRect) end

function MaskableGraphic:RecalculateClipping() end

function MaskableGraphic:RecalculateMasking() end

return MaskableGraphic
