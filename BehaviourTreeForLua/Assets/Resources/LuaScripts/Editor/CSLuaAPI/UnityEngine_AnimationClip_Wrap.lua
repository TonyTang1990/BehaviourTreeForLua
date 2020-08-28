---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.AnimationClip : UnityEngine.Motion
---@field public events UnityEngine.AnimationEvent[]
---@field public length number
---@field public frameRate number
---@field public wrapMode UnityEngine.WrapMode
---@field public localBounds UnityEngine.Bounds
---@field public legacy System.Boolean
---@field public humanMotion System.Boolean
---@field public empty System.Boolean
---@field public hasGenericRootTransform System.Boolean
---@field public hasMotionFloatCurves System.Boolean
---@field public hasMotionCurves System.Boolean
---@field public hasRootCurves System.Boolean
local AnimationClip = {}

---@param evt UnityEngine.AnimationEvent
function AnimationClip:AddEvent(evt) end

---@param go UnityEngine.GameObject
---@param time number
function AnimationClip:SampleAnimation(go,time) end

---@param relativePath string
---@param type System.Type
---@param propertyName string
---@param curve UnityEngine.AnimationCurve
function AnimationClip:SetCurve(relativePath,type,propertyName,curve) end

function AnimationClip:EnsureQuaternionContinuity() end

function AnimationClip:ClearCurves() end

return AnimationClip
