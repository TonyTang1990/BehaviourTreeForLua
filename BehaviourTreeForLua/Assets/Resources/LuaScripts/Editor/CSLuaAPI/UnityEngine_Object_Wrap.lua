---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Object
---@field public name string
---@field public hideFlags UnityEngine.HideFlags
local Object = {}

---@return int32
function Object:GetInstanceID() end

---@return int32
function Object:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Object:Equals(other) end

---@return string
function Object:ToString() end

---@param original UnityEngine.Object
---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
---@return UnityEngine.Object
function Object.Instantiate(original,position,rotation) end

---@param original UnityEngine.Object
---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
---@param parent UnityEngine.Transform
---@return UnityEngine.Object
function Object.Instantiate(original,position,rotation,parent) end

---@param original UnityEngine.Object
---@return UnityEngine.Object
function Object.Instantiate(original) end

---@param original UnityEngine.Object
---@param parent UnityEngine.Transform
---@return UnityEngine.Object
function Object.Instantiate(original,parent) end

---@param original UnityEngine.Object
---@param parent UnityEngine.Transform
---@param instantiateInWorldSpace System.Boolean
---@return UnityEngine.Object
function Object.Instantiate(original,parent,instantiateInWorldSpace) end

---@param obj UnityEngine.Object
---@param t number
function Object.Destroy(obj,t) end

---@param obj UnityEngine.Object
function Object.Destroy(obj) end

---@param obj UnityEngine.Object
---@param allowDestroyingAssets System.Boolean
function Object.DestroyImmediate(obj,allowDestroyingAssets) end

---@param obj UnityEngine.Object
function Object.DestroyImmediate(obj) end

---@param type System.Type
---@return UnityEngine.Object[]
function Object.FindObjectsOfType(type) end

---@param target UnityEngine.Object
function Object.DontDestroyOnLoad(target) end

---@param type System.Type
---@return UnityEngine.Object
function Object.FindObjectOfType(type) end

return Object
