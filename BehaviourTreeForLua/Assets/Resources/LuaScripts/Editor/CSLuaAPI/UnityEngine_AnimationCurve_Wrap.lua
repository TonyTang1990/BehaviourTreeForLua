---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.AnimationCurve
---@field public keys UnityEngine.Keyframe[]
---@field public Item UnityEngine.Keyframe
---@field public length int32
---@field public preWrapMode UnityEngine.WrapMode
---@field public postWrapMode UnityEngine.WrapMode
local AnimationCurve = {}

---@param time number
---@return number
function AnimationCurve:Evaluate(time) end

---@param time number
---@param value number
---@return int32
function AnimationCurve:AddKey(time,value) end

---@param key UnityEngine.Keyframe
---@return int32
function AnimationCurve:AddKey(key) end

---@param index int32
---@param key UnityEngine.Keyframe
---@return int32
function AnimationCurve:MoveKey(index,key) end

---@param index int32
function AnimationCurve:RemoveKey(index) end

---@param index int32
---@param weight number
function AnimationCurve:SmoothTangents(index,weight) end

---@param o System.Object
---@return System.Boolean
function AnimationCurve:Equals(o) end

---@param other UnityEngine.AnimationCurve
---@return System.Boolean
function AnimationCurve:Equals(other) end

---@return int32
function AnimationCurve:GetHashCode() end

---@param timeStart number
---@param timeEnd number
---@param value number
---@return UnityEngine.AnimationCurve
function AnimationCurve.Constant(timeStart,timeEnd,value) end

---@param timeStart number
---@param valueStart number
---@param timeEnd number
---@param valueEnd number
---@return UnityEngine.AnimationCurve
function AnimationCurve.Linear(timeStart,valueStart,timeEnd,valueEnd) end

---@param timeStart number
---@param valueStart number
---@param timeEnd number
---@param valueEnd number
---@return UnityEngine.AnimationCurve
function AnimationCurve.EaseInOut(timeStart,valueStart,timeEnd,valueEnd) end

return AnimationCurve
