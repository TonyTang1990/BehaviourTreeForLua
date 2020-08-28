---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Canvas : UnityEngine.Behaviour
---@field public renderMode UnityEngine.RenderMode
---@field public isRootCanvas System.Boolean
---@field public pixelRect UnityEngine.Rect
---@field public scaleFactor number
---@field public referencePixelsPerUnit number
---@field public overridePixelPerfect System.Boolean
---@field public pixelPerfect System.Boolean
---@field public planeDistance number
---@field public renderOrder int32
---@field public overrideSorting System.Boolean
---@field public sortingOrder int32
---@field public targetDisplay int32
---@field public sortingLayerID int32
---@field public cachedSortingLayerValue int32
---@field public additionalShaderChannels UnityEngine.AdditionalCanvasShaderChannels
---@field public sortingLayerName string
---@field public rootCanvas UnityEngine.Canvas
---@field public worldCamera UnityEngine.Camera
---@field public normalizedSortingGridSize number
local Canvas = {}

---@return UnityEngine.Material
function Canvas.GetDefaultCanvasMaterial() end

---@return UnityEngine.Material
function Canvas.GetETC1SupportedCanvasMaterial() end

function Canvas.ForceUpdateCanvases() end

return Canvas
