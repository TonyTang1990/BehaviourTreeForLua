---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Texture : UnityEngine.Object
---@field public width int32
---@field public height int32
---@field public dimension UnityEngine.Rendering.TextureDimension
---@field public isReadable System.Boolean
---@field public wrapMode UnityEngine.TextureWrapMode
---@field public wrapModeU UnityEngine.TextureWrapMode
---@field public wrapModeV UnityEngine.TextureWrapMode
---@field public wrapModeW UnityEngine.TextureWrapMode
---@field public filterMode UnityEngine.FilterMode
---@field public anisoLevel int32
---@field public mipMapBias number
---@field public texelSize UnityEngine.Vector2
---@field public updateCount uint32
---@field public imageContentsHash UnityEngine.Hash128
---@field static masterTextureLimit int32
---@field static anisotropicFiltering UnityEngine.AnisotropicFiltering
---@field static totalTextureMemory uint64
---@field static desiredTextureMemory uint64
---@field static targetTextureMemory uint64
---@field static currentTextureMemory uint64
---@field static nonStreamingTextureMemory uint64
---@field static streamingMipmapUploadCount uint64
---@field static streamingRendererCount uint64
---@field static streamingTextureCount uint64
---@field static nonStreamingTextureCount uint64
---@field static streamingTexturePendingLoadCount uint64
---@field static streamingTextureLoadingCount uint64
---@field static streamingTextureForceLoadAll System.Boolean
---@field static streamingTextureDiscardUnusedMips System.Boolean
local Texture = {}

---@return System.IntPtr
function Texture:GetNativeTexturePtr() end

function Texture:IncrementUpdateCount() end

---@param forcedMin int32
---@param globalMax int32
function Texture.SetGlobalAnisotropicFilteringLimits(forcedMin,globalMax) end

function Texture.SetStreamingTextureMaterialDebugProperties() end

return Texture
