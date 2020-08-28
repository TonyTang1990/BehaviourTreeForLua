---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Texture2D : UnityEngine.Texture
---@field public mipmapCount int32
---@field public format UnityEngine.TextureFormat
---@field public isReadable System.Boolean
---@field public streamingMipmaps System.Boolean
---@field public streamingMipmapsPriority int32
---@field public requestedMipmapLevel int32
---@field public desiredMipmapLevel int32
---@field public loadingMipmapLevel int32
---@field public loadedMipmapLevel int32
---@field public alphaIsTransparency System.Boolean
---@field static whiteTexture UnityEngine.Texture2D
---@field static blackTexture UnityEngine.Texture2D
local Texture2D = {}

---@param highQuality System.Boolean
function Texture2D:Compress(highQuality) end

function Texture2D:ClearRequestedMipmapLevel() end

---@return System.Boolean
function Texture2D:IsRequestedMipmapLevelLoaded() end

---@param nativeTex System.IntPtr
function Texture2D:UpdateExternalTexture(nativeTex) end

---@return System.Byte[]
function Texture2D:GetRawTextureData() end

---@param x int32
---@param y int32
---@param blockWidth int32
---@param blockHeight int32
---@param miplevel int32
---@return UnityEngine.Color[]
function Texture2D:GetPixels(x,y,blockWidth,blockHeight,miplevel) end

---@param x int32
---@param y int32
---@param blockWidth int32
---@param blockHeight int32
---@return UnityEngine.Color[]
function Texture2D:GetPixels(x,y,blockWidth,blockHeight) end

---@param miplevel int32
---@return UnityEngine.Color32[]
function Texture2D:GetPixels32(miplevel) end

---@return UnityEngine.Color32[]
function Texture2D:GetPixels32() end

---@param textures UnityEngine.Texture2D[]
---@param padding int32
---@param maximumAtlasSize int32
---@param makeNoLongerReadable System.Boolean
---@return UnityEngine.Rect[]
function Texture2D:PackTextures(textures,padding,maximumAtlasSize,makeNoLongerReadable) end

---@param textures UnityEngine.Texture2D[]
---@param padding int32
---@param maximumAtlasSize int32
---@return UnityEngine.Rect[]
function Texture2D:PackTextures(textures,padding,maximumAtlasSize) end

---@param textures UnityEngine.Texture2D[]
---@param padding int32
---@return UnityEngine.Rect[]
function Texture2D:PackTextures(textures,padding) end

---@param x int32
---@param y int32
---@param color UnityEngine.Color
function Texture2D:SetPixel(x,y,color) end

---@param x int32
---@param y int32
---@param blockWidth int32
---@param blockHeight int32
---@param colors UnityEngine.Color[]
---@param miplevel int32
function Texture2D:SetPixels(x,y,blockWidth,blockHeight,colors,miplevel) end

---@param x int32
---@param y int32
---@param blockWidth int32
---@param blockHeight int32
---@param colors UnityEngine.Color[]
function Texture2D:SetPixels(x,y,blockWidth,blockHeight,colors) end

---@param colors UnityEngine.Color[]
---@param miplevel int32
function Texture2D:SetPixels(colors,miplevel) end

---@param colors UnityEngine.Color[]
function Texture2D:SetPixels(colors) end

---@param x int32
---@param y int32
---@return UnityEngine.Color
function Texture2D:GetPixel(x,y) end

---@param x number
---@param y number
---@return UnityEngine.Color
function Texture2D:GetPixelBilinear(x,y) end

---@param data System.IntPtr
---@param size int32
function Texture2D:LoadRawTextureData(data,size) end

---@param data System.Byte[]
function Texture2D:LoadRawTextureData(data) end

---@param updateMipmaps System.Boolean
---@param makeNoLongerReadable System.Boolean
function Texture2D:Apply(updateMipmaps,makeNoLongerReadable) end

---@param updateMipmaps System.Boolean
function Texture2D:Apply(updateMipmaps) end

function Texture2D:Apply() end

---@param width int32
---@param height int32
---@return System.Boolean
function Texture2D:Resize(width,height) end

---@param width int32
---@param height int32
---@param format UnityEngine.TextureFormat
---@param hasMipMap System.Boolean
---@return System.Boolean
function Texture2D:Resize(width,height,format,hasMipMap) end

---@param source UnityEngine.Rect
---@param destX int32
---@param destY int32
---@param recalculateMipMaps System.Boolean
function Texture2D:ReadPixels(source,destX,destY,recalculateMipMaps) end

---@param source UnityEngine.Rect
---@param destX int32
---@param destY int32
function Texture2D:ReadPixels(source,destX,destY) end

---@param colors UnityEngine.Color32[]
---@param miplevel int32
function Texture2D:SetPixels32(colors,miplevel) end

---@param colors UnityEngine.Color32[]
function Texture2D:SetPixels32(colors) end

---@param x int32
---@param y int32
---@param blockWidth int32
---@param blockHeight int32
---@param colors UnityEngine.Color32[]
---@param miplevel int32
function Texture2D:SetPixels32(x,y,blockWidth,blockHeight,colors,miplevel) end

---@param x int32
---@param y int32
---@param blockWidth int32
---@param blockHeight int32
---@param colors UnityEngine.Color32[]
function Texture2D:SetPixels32(x,y,blockWidth,blockHeight,colors) end

---@param miplevel int32
---@return UnityEngine.Color[]
function Texture2D:GetPixels(miplevel) end

---@return UnityEngine.Color[]
function Texture2D:GetPixels() end

---@param width int32
---@param height int32
---@param format UnityEngine.TextureFormat
---@param mipChain System.Boolean
---@param linear System.Boolean
---@param nativeTex System.IntPtr
---@return UnityEngine.Texture2D
function Texture2D.CreateExternalTexture(width,height,format,mipChain,linear,nativeTex) end

---@param sizes UnityEngine.Vector2[]
---@param padding int32
---@param atlasSize int32
---@param results System.Collections.Generic.List
---@return System.Boolean
function Texture2D.GenerateAtlas(sizes,padding,atlasSize,results) end

return Texture2D
