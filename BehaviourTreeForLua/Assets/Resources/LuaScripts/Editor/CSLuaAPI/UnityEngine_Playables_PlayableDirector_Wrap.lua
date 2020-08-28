---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Playables.PlayableDirector : UnityEngine.Behaviour
---@field public state UnityEngine.Playables.PlayState
---@field public extrapolationMode UnityEngine.Playables.DirectorWrapMode
---@field public playableAsset UnityEngine.Playables.PlayableAsset
---@field public playableGraph UnityEngine.Playables.PlayableGraph
---@field public playOnAwake System.Boolean
---@field public timeUpdateMode UnityEngine.Playables.DirectorUpdateMode
---@field public time number
---@field public initialTime number
---@field public duration number
local PlayableDirector = {}

function PlayableDirector:DeferredEvaluate() end

---@param asset UnityEngine.Playables.PlayableAsset
function PlayableDirector:Play(asset) end

---@param asset UnityEngine.Playables.PlayableAsset
---@param mode UnityEngine.Playables.DirectorWrapMode
function PlayableDirector:Play(asset,mode) end

---@param key UnityEngine.Object
---@param value UnityEngine.Object
function PlayableDirector:SetGenericBinding(key,value) end

function PlayableDirector:Evaluate() end

function PlayableDirector:Play() end

function PlayableDirector:Stop() end

function PlayableDirector:Pause() end

function PlayableDirector:Resume() end

function PlayableDirector:RebuildGraph() end

---@param id UnityEngine.PropertyName
function PlayableDirector:ClearReferenceValue(id) end

---@param id UnityEngine.PropertyName
---@param value UnityEngine.Object
function PlayableDirector:SetReferenceValue(id,value) end

---@param id UnityEngine.PropertyName
---@return UnityEngine.Object
function PlayableDirector:GetReferenceValue(id) end

---@param key UnityEngine.Object
---@return UnityEngine.Object
function PlayableDirector:GetGenericBinding(key) end

---@param key UnityEngine.Object
function PlayableDirector:ClearGenericBinding(key) end

function PlayableDirector:RebindPlayableGraphOutputs() end

return PlayableDirector
