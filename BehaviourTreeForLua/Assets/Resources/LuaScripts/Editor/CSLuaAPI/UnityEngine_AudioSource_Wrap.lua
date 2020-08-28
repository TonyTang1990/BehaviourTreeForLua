---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.AudioSource : UnityEngine.AudioBehaviour
---@field public volume number
---@field public pitch number
---@field public time number
---@field public timeSamples int32
---@field public clip UnityEngine.AudioClip
---@field public outputAudioMixerGroup UnityEngine.Audio.AudioMixerGroup
---@field public isPlaying System.Boolean
---@field public isVirtual System.Boolean
---@field public loop System.Boolean
---@field public ignoreListenerVolume System.Boolean
---@field public playOnAwake System.Boolean
---@field public ignoreListenerPause System.Boolean
---@field public velocityUpdateMode UnityEngine.AudioVelocityUpdateMode
---@field public panStereo number
---@field public spatialBlend number
---@field public spatialize System.Boolean
---@field public spatializePostEffects System.Boolean
---@field public reverbZoneMix number
---@field public bypassEffects System.Boolean
---@field public bypassListenerEffects System.Boolean
---@field public bypassReverbZones System.Boolean
---@field public dopplerLevel number
---@field public spread number
---@field public priority int32
---@field public mute System.Boolean
---@field public minDistance number
---@field public maxDistance number
---@field public rolloffMode UnityEngine.AudioRolloffMode
local AudioSource = {}

---@param delay uint64
function AudioSource:Play(delay) end

function AudioSource:Play() end

---@param delay number
function AudioSource:PlayDelayed(delay) end

---@param time number
function AudioSource:PlayScheduled(time) end

---@param time number
function AudioSource:SetScheduledStartTime(time) end

---@param time number
function AudioSource:SetScheduledEndTime(time) end

function AudioSource:Stop() end

function AudioSource:Pause() end

function AudioSource:UnPause() end

---@param clip UnityEngine.AudioClip
function AudioSource:PlayOneShot(clip) end

---@param clip UnityEngine.AudioClip
---@param volumeScale number
function AudioSource:PlayOneShot(clip,volumeScale) end

---@param type UnityEngine.AudioSourceCurveType
---@param curve UnityEngine.AnimationCurve
function AudioSource:SetCustomCurve(type,curve) end

---@param type UnityEngine.AudioSourceCurveType
---@return UnityEngine.AnimationCurve
function AudioSource:GetCustomCurve(type) end

---@param samples System.Single[]
---@param channel int32
function AudioSource:GetOutputData(samples,channel) end

---@param samples System.Single[]
---@param channel int32
---@param window UnityEngine.FFTWindow
function AudioSource:GetSpectrumData(samples,channel,window) end

---@param index int32
---@param value number
---@return System.Boolean
function AudioSource:SetSpatializerFloat(index,value) end

---@param index int32
---@return System.Boolean
function AudioSource:GetSpatializerFloat(index) end

---@param index int32
---@param value number
---@return System.Boolean
function AudioSource:SetAmbisonicDecoderFloat(index,value) end

---@param index int32
---@return System.Boolean
function AudioSource:GetAmbisonicDecoderFloat(index) end

---@param clip UnityEngine.AudioClip
---@param position UnityEngine.Vector3
function AudioSource.PlayClipAtPoint(clip,position) end

---@param clip UnityEngine.AudioClip
---@param position UnityEngine.Vector3
---@param volume number
function AudioSource.PlayClipAtPoint(clip,position,volume) end

return AudioSource
