---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.MonoBehaviour : UnityEngine.Behaviour
---@field public useGUILayout System.Boolean
---@field public runInEditMode System.Boolean
local MonoBehaviour = {}

---@return System.Boolean
function MonoBehaviour:IsInvoking() end

function MonoBehaviour:CancelInvoke() end

---@param methodName string
---@param time number
function MonoBehaviour:Invoke(methodName,time) end

---@param methodName string
---@param time number
---@param repeatRate number
function MonoBehaviour:InvokeRepeating(methodName,time,repeatRate) end

---@param methodName string
function MonoBehaviour:CancelInvoke(methodName) end

---@param methodName string
---@return System.Boolean
function MonoBehaviour:IsInvoking(methodName) end

---@param methodName string
---@return UnityEngine.Coroutine
function MonoBehaviour:StartCoroutine(methodName) end

---@param methodName string
---@param value System.Object
---@return UnityEngine.Coroutine
function MonoBehaviour:StartCoroutine(methodName,value) end

---@param routine System.Collections.IEnumerator
---@return UnityEngine.Coroutine
function MonoBehaviour:StartCoroutine(routine) end

---@param routine System.Collections.IEnumerator
function MonoBehaviour:StopCoroutine(routine) end

---@param routine UnityEngine.Coroutine
function MonoBehaviour:StopCoroutine(routine) end

---@param methodName string
function MonoBehaviour:StopCoroutine(methodName) end

function MonoBehaviour:StopAllCoroutines() end

---@param message System.Object
function MonoBehaviour.print(message) end

return MonoBehaviour
