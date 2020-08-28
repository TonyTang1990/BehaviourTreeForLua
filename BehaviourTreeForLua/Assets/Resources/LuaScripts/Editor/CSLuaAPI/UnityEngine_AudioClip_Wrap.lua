---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.AudioClip : UnityEngine.Object
---@field public length number
---@field public samples int32
---@field public channels int32
---@field public frequency int32
---@field public loadType UnityEngine.AudioClipLoadType
---@field public preloadAudioData System.Boolean
---@field public ambisonic System.Boolean
---@field public loadState UnityEngine.AudioDataLoadState
---@field public loadInBackground System.Boolean
local AudioClip = {}

---@return System.Boolean
function AudioClip:LoadAudioData() end

---@return System.Boolean
function AudioClip:UnloadAudioData() end

---@param data System.Single[]
---@param offsetSamples int32
---@return System.Boolean
function AudioClip:GetData(data,offsetSamples) end

---@param data System.Single[]
---@param offsetSamples int32
---@return System.Boolean
function AudioClip:SetData(data,offsetSamples) end

---@param name string
---@param lengthSamples int32
---@param channels int32
---@param frequency int32
---@param stream System.Boolean
---@return UnityEngine.AudioClip
function AudioClip.Create(name,lengthSamples,channels,frequency,stream) end

---@param name string
---@param lengthSamples int32
---@param channels int32
---@param frequency int32
---@param stream System.Boolean
---@param pcmreadercallback UnityEngine.AudioClip.PCMReaderCallback
---@return UnityEngine.AudioClip
function AudioClip.Create(name,lengthSamples,channels,frequency,stream,pcmreadercallback) end

---@param name string
---@param lengthSamples int32
---@param channels int32
---@param frequency int32
---@param stream System.Boolean
---@param pcmreadercallback UnityEngine.AudioClip.PCMReaderCallback
---@param pcmsetpositioncallback UnityEngine.AudioClip.PCMSetPositionCallback
---@return UnityEngine.AudioClip
function AudioClip.Create(name,lengthSamples,channels,frequency,stream,pcmreadercallback,pcmsetpositioncallback) end

return AudioClip
