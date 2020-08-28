---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Events.UnityEventBase
local UnityEventBase = {}

---@return int32
function UnityEventBase:GetPersistentEventCount() end

---@param index int32
---@return UnityEngine.Object
function UnityEventBase:GetPersistentTarget(index) end

---@param index int32
---@return string
function UnityEventBase:GetPersistentMethodName(index) end

---@param index int32
---@param state UnityEngine.Events.UnityEventCallState
function UnityEventBase:SetPersistentListenerState(index,state) end

function UnityEventBase:RemoveAllListeners() end

---@return string
function UnityEventBase:ToString() end

---@param obj System.Object
---@param functionName string
---@param argumentTypes System.Type[]
---@return System.Reflection.MethodInfo
function UnityEventBase.GetValidMethodInfo(obj,functionName,argumentTypes) end

return UnityEventBase
