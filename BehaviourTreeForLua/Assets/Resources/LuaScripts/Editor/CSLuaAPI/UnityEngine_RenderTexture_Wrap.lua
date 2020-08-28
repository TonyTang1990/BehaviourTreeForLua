---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.RenderTexture : UnityEngine.Texture
---@field public width int32
---@field public height int32
---@field public dimension UnityEngine.Rendering.TextureDimension
---@field public useMipMap System.Boolean
---@field public sRGB System.Boolean
---@field public format UnityEngine.RenderTextureFormat
---@field public vrUsage UnityEngine.VRTextureUsage
---@field public memorylessMode UnityEngine.RenderTextureMemoryless
---@field public autoGenerateMips System.Boolean
---@field public volumeDepth int32
---@field public antiAliasing int32
---@field public bindTextureMS System.Boolean
---@field public enableRandomWrite System.Boolean
---@field public useDynamicScale System.Boolean
---@field public isPowerOfTwo System.Boolean
---@field public colorBuffer UnityEngine.RenderBuffer
---@field public depthBuffer UnityEngine.RenderBuffer
---@field public depth int32
---@field public descriptor UnityEngine.RenderTextureDescriptor
---@field static active UnityEngine.RenderTexture
local RenderTexture = {}

---@return System.IntPtr
function RenderTexture:GetNativeDepthBufferPtr() end

---@param discardColor System.Boolean
---@param discardDepth System.Boolean
function RenderTexture:DiscardContents(discardColor,discardDepth) end

function RenderTexture:MarkRestoreExpected() end

function RenderTexture:DiscardContents() end

function RenderTexture:ResolveAntiAliasedSurface() end

---@param target UnityEngine.RenderTexture
function RenderTexture:ResolveAntiAliasedSurface(target) end

---@param propertyName string
function RenderTexture:SetGlobalShaderProperty(propertyName) end

---@return System.Boolean
function RenderTexture:Create() end

function RenderTexture:Release() end

---@return System.Boolean
function RenderTexture:IsCreated() end

function RenderTexture:GenerateMips() end

---@param equirect UnityEngine.RenderTexture
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
function RenderTexture:ConvertToEquirect(equirect,eye) end

---@param rt UnityEngine.RenderTexture
---@return System.Boolean
function RenderTexture.SupportsStencil(rt) end

---@param temp UnityEngine.RenderTexture
function RenderTexture.ReleaseTemporary(temp) end

---@param desc UnityEngine.RenderTextureDescriptor
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(desc) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@param format UnityEngine.RenderTextureFormat
---@param readWrite UnityEngine.RenderTextureReadWrite
---@param antiAliasing int32
---@param memorylessMode UnityEngine.RenderTextureMemoryless
---@param vrUsage UnityEngine.VRTextureUsage
---@param useDynamicScale System.Boolean
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer,format,readWrite,antiAliasing,memorylessMode,vrUsage,useDynamicScale) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@param format UnityEngine.RenderTextureFormat
---@param readWrite UnityEngine.RenderTextureReadWrite
---@param antiAliasing int32
---@param memorylessMode UnityEngine.RenderTextureMemoryless
---@param vrUsage UnityEngine.VRTextureUsage
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer,format,readWrite,antiAliasing,memorylessMode,vrUsage) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@param format UnityEngine.RenderTextureFormat
---@param readWrite UnityEngine.RenderTextureReadWrite
---@param antiAliasing int32
---@param memorylessMode UnityEngine.RenderTextureMemoryless
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer,format,readWrite,antiAliasing,memorylessMode) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@param format UnityEngine.RenderTextureFormat
---@param readWrite UnityEngine.RenderTextureReadWrite
---@param antiAliasing int32
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer,format,readWrite,antiAliasing) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@param format UnityEngine.RenderTextureFormat
---@param readWrite UnityEngine.RenderTextureReadWrite
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer,format,readWrite) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@param format UnityEngine.RenderTextureFormat
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer,format) end

---@param width int32
---@param height int32
---@param depthBuffer int32
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height,depthBuffer) end

---@param width int32
---@param height int32
---@return UnityEngine.RenderTexture
function RenderTexture.GetTemporary(width,height) end

return RenderTexture
