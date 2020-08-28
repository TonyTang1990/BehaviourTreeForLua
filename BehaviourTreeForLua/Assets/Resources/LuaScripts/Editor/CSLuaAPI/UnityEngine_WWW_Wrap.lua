---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.WWW : UnityEngine.CustomYieldInstruction
---@field public assetBundle UnityEngine.AssetBundle
---@field public bytes System.Byte[]
---@field public bytesDownloaded int32
---@field public error string
---@field public isDone System.Boolean
---@field public progress number
---@field public responseHeaders System.Collections.Generic.Dictionary
---@field public text string
---@field public texture UnityEngine.Texture2D
---@field public textureNonReadable UnityEngine.Texture2D
---@field public threadPriority UnityEngine.ThreadPriority
---@field public uploadProgress number
---@field public url string
---@field public keepWaiting System.Boolean
local WWW = {}

---@param texture UnityEngine.Texture2D
function WWW:LoadImageIntoTexture(texture) end

function WWW:Dispose() end

---@return UnityEngine.AudioClip
function WWW:GetAudioClip() end

---@param threeD System.Boolean
---@return UnityEngine.AudioClip
function WWW:GetAudioClip(threeD) end

---@param threeD System.Boolean
---@param stream System.Boolean
---@return UnityEngine.AudioClip
function WWW:GetAudioClip(threeD,stream) end

---@param threeD System.Boolean
---@param stream System.Boolean
---@param audioType UnityEngine.AudioType
---@return UnityEngine.AudioClip
function WWW:GetAudioClip(threeD,stream,audioType) end

---@return UnityEngine.AudioClip
function WWW:GetAudioClipCompressed() end

---@param threeD System.Boolean
---@return UnityEngine.AudioClip
function WWW:GetAudioClipCompressed(threeD) end

---@param threeD System.Boolean
---@param audioType UnityEngine.AudioType
---@return UnityEngine.AudioClip
function WWW:GetAudioClipCompressed(threeD,audioType) end

---@param s string
---@return string
function WWW.EscapeURL(s) end

---@param s string
---@param e System.Text.Encoding
---@return string
function WWW.EscapeURL(s,e) end

---@param s string
---@return string
function WWW.UnEscapeURL(s) end

---@param s string
---@param e System.Text.Encoding
---@return string
function WWW.UnEscapeURL(s,e) end

---@param url string
---@param version int32
---@return UnityEngine.WWW
function WWW.LoadFromCacheOrDownload(url,version) end

---@param url string
---@param version int32
---@param crc uint32
---@return UnityEngine.WWW
function WWW.LoadFromCacheOrDownload(url,version,crc) end

---@param url string
---@param hash UnityEngine.Hash128
---@return UnityEngine.WWW
function WWW.LoadFromCacheOrDownload(url,hash) end

---@param url string
---@param hash UnityEngine.Hash128
---@param crc uint32
---@return UnityEngine.WWW
function WWW.LoadFromCacheOrDownload(url,hash,crc) end

---@param url string
---@param cachedBundle UnityEngine.CachedAssetBundle
---@param crc uint32
---@return UnityEngine.WWW
function WWW.LoadFromCacheOrDownload(url,cachedBundle,crc) end

return WWW
