---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Animation : UnityEngine.Behaviour
---@field public clip UnityEngine.AnimationClip
---@field public playAutomatically System.Boolean
---@field public wrapMode UnityEngine.WrapMode
---@field public isPlaying System.Boolean
---@field public Item UnityEngine.AnimationState
---@field public animatePhysics System.Boolean
---@field public cullingType UnityEngine.AnimationCullingType
---@field public localBounds UnityEngine.Bounds
local Animation = {}

function Animation:Stop() end

---@param name string
function Animation:Stop(name) end

---@param name string
function Animation:Rewind(name) end

function Animation:Rewind() end

function Animation:Sample() end

---@param name string
---@return System.Boolean
function Animation:IsPlaying(name) end

---@return System.Boolean
function Animation:Play() end

---@param mode UnityEngine.PlayMode
---@return System.Boolean
function Animation:Play(mode) end

---@param animation string
---@param mode UnityEngine.PlayMode
---@return System.Boolean
function Animation:Play(animation,mode) end

---@param animation string
---@return System.Boolean
function Animation:Play(animation) end

---@param animation string
---@param fadeLength number
---@param mode UnityEngine.PlayMode
function Animation:CrossFade(animation,fadeLength,mode) end

---@param animation string
---@param fadeLength number
function Animation:CrossFade(animation,fadeLength) end

---@param animation string
function Animation:CrossFade(animation) end

---@param animation string
---@param targetWeight number
---@param fadeLength number
function Animation:Blend(animation,targetWeight,fadeLength) end

---@param animation string
---@param targetWeight number
function Animation:Blend(animation,targetWeight) end

---@param animation string
function Animation:Blend(animation) end

---@param animation string
---@param fadeLength number
---@param queue UnityEngine.QueueMode
---@param mode UnityEngine.PlayMode
---@return UnityEngine.AnimationState
function Animation:CrossFadeQueued(animation,fadeLength,queue,mode) end

---@param animation string
---@param fadeLength number
---@param queue UnityEngine.QueueMode
---@return UnityEngine.AnimationState
function Animation:CrossFadeQueued(animation,fadeLength,queue) end

---@param animation string
---@param fadeLength number
---@return UnityEngine.AnimationState
function Animation:CrossFadeQueued(animation,fadeLength) end

---@param animation string
---@return UnityEngine.AnimationState
function Animation:CrossFadeQueued(animation) end

---@param animation string
---@param queue UnityEngine.QueueMode
---@param mode UnityEngine.PlayMode
---@return UnityEngine.AnimationState
function Animation:PlayQueued(animation,queue,mode) end

---@param animation string
---@param queue UnityEngine.QueueMode
---@return UnityEngine.AnimationState
function Animation:PlayQueued(animation,queue) end

---@param animation string
---@return UnityEngine.AnimationState
function Animation:PlayQueued(animation) end

---@param clip UnityEngine.AnimationClip
---@param newName string
function Animation:AddClip(clip,newName) end

---@param clip UnityEngine.AnimationClip
---@param newName string
---@param firstFrame int32
---@param lastFrame int32
---@param addLoopFrame System.Boolean
function Animation:AddClip(clip,newName,firstFrame,lastFrame,addLoopFrame) end

---@param clip UnityEngine.AnimationClip
---@param newName string
---@param firstFrame int32
---@param lastFrame int32
function Animation:AddClip(clip,newName,firstFrame,lastFrame) end

---@param clip UnityEngine.AnimationClip
function Animation:RemoveClip(clip) end

---@param clipName string
function Animation:RemoveClip(clipName) end

---@return int32
function Animation:GetClipCount() end

---@param layer int32
function Animation:SyncLayer(layer) end

---@return System.Collections.IEnumerator
function Animation:GetEnumerator() end

---@param name string
---@return UnityEngine.AnimationClip
function Animation:GetClip(name) end

return Animation
