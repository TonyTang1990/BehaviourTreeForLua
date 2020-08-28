---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.Graphic : UnityEngine.EventSystems.UIBehaviour
---@field public color UnityEngine.Color
---@field public raycastTarget System.Boolean
---@field public depth int32
---@field public rectTransform UnityEngine.RectTransform
---@field public canvas UnityEngine.Canvas
---@field public canvasRenderer UnityEngine.CanvasRenderer
---@field public defaultMaterial UnityEngine.Material
---@field public material UnityEngine.Material
---@field public materialForRendering UnityEngine.Material
---@field public mainTexture UnityEngine.Texture
---@field static defaultGraphicMaterial UnityEngine.Material
local Graphic = {}

function Graphic:SetAllDirty() end

function Graphic:SetLayoutDirty() end

function Graphic:SetVerticesDirty() end

function Graphic:SetMaterialDirty() end

function Graphic:OnCullingChanged() end

---@param update UnityEngine.UI.CanvasUpdate
function Graphic:Rebuild(update) end

function Graphic:LayoutComplete() end

function Graphic:GraphicUpdateComplete() end

function Graphic:OnRebuildRequested() end

function Graphic:SetNativeSize() end

---@param sp UnityEngine.Vector2
---@param eventCamera UnityEngine.Camera
---@return System.Boolean
function Graphic:Raycast(sp,eventCamera) end

---@param point UnityEngine.Vector2
---@return UnityEngine.Vector2
function Graphic:PixelAdjustPoint(point) end

---@return UnityEngine.Rect
function Graphic:GetPixelAdjustedRect() end

---@param targetColor UnityEngine.Color
---@param duration number
---@param ignoreTimeScale System.Boolean
---@param useAlpha System.Boolean
function Graphic:CrossFadeColor(targetColor,duration,ignoreTimeScale,useAlpha) end

---@param targetColor UnityEngine.Color
---@param duration number
---@param ignoreTimeScale System.Boolean
---@param useAlpha System.Boolean
---@param useRGB System.Boolean
function Graphic:CrossFadeColor(targetColor,duration,ignoreTimeScale,useAlpha,useRGB) end

---@param alpha number
---@param duration number
---@param ignoreTimeScale System.Boolean
function Graphic:CrossFadeAlpha(alpha,duration,ignoreTimeScale) end

---@param action UnityEngine.Events.UnityAction
function Graphic:RegisterDirtyLayoutCallback(action) end

---@param action UnityEngine.Events.UnityAction
function Graphic:UnregisterDirtyLayoutCallback(action) end

---@param action UnityEngine.Events.UnityAction
function Graphic:RegisterDirtyVerticesCallback(action) end

---@param action UnityEngine.Events.UnityAction
function Graphic:UnregisterDirtyVerticesCallback(action) end

---@param action UnityEngine.Events.UnityAction
function Graphic:RegisterDirtyMaterialCallback(action) end

---@param action UnityEngine.Events.UnityAction
function Graphic:UnregisterDirtyMaterialCallback(action) end

return Graphic
