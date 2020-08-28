---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.GameObject : UnityEngine.Object
---@field public transform UnityEngine.Transform
---@field public layer int32
---@field public activeSelf System.Boolean
---@field public activeInHierarchy System.Boolean
---@field public isStatic System.Boolean
---@field public tag string
---@field public scene UnityEngine.SceneManagement.Scene
---@field public gameObject UnityEngine.GameObject
local GameObject = {}

---@param type System.Type
---@return UnityEngine.Component
function GameObject:GetComponent(type) end

---@param type string
---@return UnityEngine.Component
function GameObject:GetComponent(type) end

---@param type System.Type
---@param includeInactive System.Boolean
---@return UnityEngine.Component
function GameObject:GetComponentInChildren(type,includeInactive) end

---@param type System.Type
---@return UnityEngine.Component
function GameObject:GetComponentInChildren(type) end

---@param type System.Type
---@return UnityEngine.Component
function GameObject:GetComponentInParent(type) end

---@param type System.Type
---@return UnityEngine.Component[]
function GameObject:GetComponents(type) end

---@param type System.Type
---@param results System.Collections.Generic.List
function GameObject:GetComponents(type,results) end

---@param type System.Type
---@return UnityEngine.Component[]
function GameObject:GetComponentsInChildren(type) end

---@param type System.Type
---@param includeInactive System.Boolean
---@return UnityEngine.Component[]
function GameObject:GetComponentsInChildren(type,includeInactive) end

---@param type System.Type
---@return UnityEngine.Component[]
function GameObject:GetComponentsInParent(type) end

---@param type System.Type
---@param includeInactive System.Boolean
---@return UnityEngine.Component[]
function GameObject:GetComponentsInParent(type,includeInactive) end

---@param methodName string
---@param options UnityEngine.SendMessageOptions
function GameObject:SendMessageUpwards(methodName,options) end

---@param methodName string
---@param options UnityEngine.SendMessageOptions
function GameObject:SendMessage(methodName,options) end

---@param methodName string
---@param options UnityEngine.SendMessageOptions
function GameObject:BroadcastMessage(methodName,options) end

---@param componentType System.Type
---@return UnityEngine.Component
function GameObject:AddComponent(componentType) end

---@param value System.Boolean
function GameObject:SetActive(value) end

---@param tag string
---@return System.Boolean
function GameObject:CompareTag(tag) end

---@param methodName string
---@param value System.Object
---@param options UnityEngine.SendMessageOptions
function GameObject:SendMessageUpwards(methodName,value,options) end

---@param methodName string
---@param value System.Object
function GameObject:SendMessageUpwards(methodName,value) end

---@param methodName string
function GameObject:SendMessageUpwards(methodName) end

---@param methodName string
---@param value System.Object
---@param options UnityEngine.SendMessageOptions
function GameObject:SendMessage(methodName,value,options) end

---@param methodName string
---@param value System.Object
function GameObject:SendMessage(methodName,value) end

---@param methodName string
function GameObject:SendMessage(methodName) end

---@param methodName string
---@param parameter System.Object
---@param options UnityEngine.SendMessageOptions
function GameObject:BroadcastMessage(methodName,parameter,options) end

---@param methodName string
---@param parameter System.Object
function GameObject:BroadcastMessage(methodName,parameter) end

---@param methodName string
function GameObject:BroadcastMessage(methodName) end

---@param type UnityEngine.PrimitiveType
---@return UnityEngine.GameObject
function GameObject.CreatePrimitive(type) end

---@param tag string
---@return UnityEngine.GameObject
function GameObject.FindWithTag(tag) end

---@param tag string
---@return UnityEngine.GameObject
function GameObject.FindGameObjectWithTag(tag) end

---@param tag string
---@return UnityEngine.GameObject[]
function GameObject.FindGameObjectsWithTag(tag) end

---@param name string
---@return UnityEngine.GameObject
function GameObject.Find(name) end

return GameObject
