---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Component : UnityEngine.Object
---@field public transform UnityEngine.Transform
---@field public gameObject UnityEngine.GameObject
---@field public tag string
local Component = {}

---@param type System.Type
---@return UnityEngine.Component
function Component:GetComponent(type) end

---@param type string
---@return UnityEngine.Component
function Component:GetComponent(type) end

---@param t System.Type
---@param includeInactive System.Boolean
---@return UnityEngine.Component
function Component:GetComponentInChildren(t,includeInactive) end

---@param t System.Type
---@return UnityEngine.Component
function Component:GetComponentInChildren(t) end

---@param t System.Type
---@param includeInactive System.Boolean
---@return UnityEngine.Component[]
function Component:GetComponentsInChildren(t,includeInactive) end

---@param t System.Type
---@return UnityEngine.Component[]
function Component:GetComponentsInChildren(t) end

---@param t System.Type
---@return UnityEngine.Component
function Component:GetComponentInParent(t) end

---@param t System.Type
---@param includeInactive System.Boolean
---@return UnityEngine.Component[]
function Component:GetComponentsInParent(t,includeInactive) end

---@param t System.Type
---@return UnityEngine.Component[]
function Component:GetComponentsInParent(t) end

---@param type System.Type
---@return UnityEngine.Component[]
function Component:GetComponents(type) end

---@param type System.Type
---@param results System.Collections.Generic.List
function Component:GetComponents(type,results) end

---@param tag string
---@return System.Boolean
function Component:CompareTag(tag) end

---@param methodName string
---@param value System.Object
---@param options UnityEngine.SendMessageOptions
function Component:SendMessageUpwards(methodName,value,options) end

---@param methodName string
---@param value System.Object
function Component:SendMessageUpwards(methodName,value) end

---@param methodName string
function Component:SendMessageUpwards(methodName) end

---@param methodName string
---@param options UnityEngine.SendMessageOptions
function Component:SendMessageUpwards(methodName,options) end

---@param methodName string
---@param value System.Object
function Component:SendMessage(methodName,value) end

---@param methodName string
function Component:SendMessage(methodName) end

---@param methodName string
---@param value System.Object
---@param options UnityEngine.SendMessageOptions
function Component:SendMessage(methodName,value,options) end

---@param methodName string
---@param options UnityEngine.SendMessageOptions
function Component:SendMessage(methodName,options) end

---@param methodName string
---@param parameter System.Object
---@param options UnityEngine.SendMessageOptions
function Component:BroadcastMessage(methodName,parameter,options) end

---@param methodName string
---@param parameter System.Object
function Component:BroadcastMessage(methodName,parameter) end

---@param methodName string
function Component:BroadcastMessage(methodName) end

---@param methodName string
---@param options UnityEngine.SendMessageOptions
function Component:BroadcastMessage(methodName,options) end

return Component
