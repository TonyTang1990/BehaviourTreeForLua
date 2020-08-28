---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Shader : UnityEngine.Object
---@field public maximumLOD int32
---@field public isSupported System.Boolean
---@field public renderQueue int32
---@field static globalMaximumLOD int32
---@field static globalRenderPipeline string
local Shader = {}

---@param name string
---@return UnityEngine.Shader
function Shader.Find(name) end

---@param keyword string
function Shader.EnableKeyword(keyword) end

---@param keyword string
function Shader.DisableKeyword(keyword) end

---@param keyword string
---@return System.Boolean
function Shader.IsKeywordEnabled(keyword) end

function Shader.WarmupAllShaders() end

---@param name string
---@return int32
function Shader.PropertyToID(name) end

---@param name string
---@param value number
function Shader.SetGlobalFloat(name,value) end

---@param nameID int32
---@param value number
function Shader.SetGlobalFloat(nameID,value) end

---@param name string
---@param value int32
function Shader.SetGlobalInt(name,value) end

---@param nameID int32
---@param value int32
function Shader.SetGlobalInt(nameID,value) end

---@param name string
---@param value UnityEngine.Vector4
function Shader.SetGlobalVector(name,value) end

---@param nameID int32
---@param value UnityEngine.Vector4
function Shader.SetGlobalVector(nameID,value) end

---@param name string
---@param value UnityEngine.Color
function Shader.SetGlobalColor(name,value) end

---@param nameID int32
---@param value UnityEngine.Color
function Shader.SetGlobalColor(nameID,value) end

---@param name string
---@param value UnityEngine.Matrix4x4
function Shader.SetGlobalMatrix(name,value) end

---@param nameID int32
---@param value UnityEngine.Matrix4x4
function Shader.SetGlobalMatrix(nameID,value) end

---@param name string
---@param value UnityEngine.Texture
function Shader.SetGlobalTexture(name,value) end

---@param nameID int32
---@param value UnityEngine.Texture
function Shader.SetGlobalTexture(nameID,value) end

---@param name string
---@param value UnityEngine.ComputeBuffer
function Shader.SetGlobalBuffer(name,value) end

---@param nameID int32
---@param value UnityEngine.ComputeBuffer
function Shader.SetGlobalBuffer(nameID,value) end

---@param name string
---@param values System.Collections.Generic.List
function Shader.SetGlobalFloatArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Shader.SetGlobalFloatArray(nameID,values) end

---@param name string
---@param values System.Single[]
function Shader.SetGlobalFloatArray(name,values) end

---@param nameID int32
---@param values System.Single[]
function Shader.SetGlobalFloatArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Shader.SetGlobalVectorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Shader.SetGlobalVectorArray(nameID,values) end

---@param name string
---@param values UnityEngine.Vector4[]
function Shader.SetGlobalVectorArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Vector4[]
function Shader.SetGlobalVectorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Shader.SetGlobalMatrixArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Shader.SetGlobalMatrixArray(nameID,values) end

---@param name string
---@param values UnityEngine.Matrix4x4[]
function Shader.SetGlobalMatrixArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Matrix4x4[]
function Shader.SetGlobalMatrixArray(nameID,values) end

---@param name string
---@return number
function Shader.GetGlobalFloat(name) end

---@param nameID int32
---@return number
function Shader.GetGlobalFloat(nameID) end

---@param name string
---@return int32
function Shader.GetGlobalInt(name) end

---@param nameID int32
---@return int32
function Shader.GetGlobalInt(nameID) end

---@param name string
---@return UnityEngine.Vector4
function Shader.GetGlobalVector(name) end

---@param nameID int32
---@return UnityEngine.Vector4
function Shader.GetGlobalVector(nameID) end

---@param name string
---@return UnityEngine.Color
function Shader.GetGlobalColor(name) end

---@param nameID int32
---@return UnityEngine.Color
function Shader.GetGlobalColor(nameID) end

---@param name string
---@return UnityEngine.Matrix4x4
function Shader.GetGlobalMatrix(name) end

---@param nameID int32
---@return UnityEngine.Matrix4x4
function Shader.GetGlobalMatrix(nameID) end

---@param name string
---@return UnityEngine.Texture
function Shader.GetGlobalTexture(name) end

---@param nameID int32
---@return UnityEngine.Texture
function Shader.GetGlobalTexture(nameID) end

---@param name string
---@return System.Single[]
function Shader.GetGlobalFloatArray(name) end

---@param nameID int32
---@return System.Single[]
function Shader.GetGlobalFloatArray(nameID) end

---@param name string
---@return UnityEngine.Vector4[]
function Shader.GetGlobalVectorArray(name) end

---@param nameID int32
---@return UnityEngine.Vector4[]
function Shader.GetGlobalVectorArray(nameID) end

---@param name string
---@return UnityEngine.Matrix4x4[]
function Shader.GetGlobalMatrixArray(name) end

---@param nameID int32
---@return UnityEngine.Matrix4x4[]
function Shader.GetGlobalMatrixArray(nameID) end

---@param name string
---@param values System.Collections.Generic.List
function Shader.GetGlobalFloatArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Shader.GetGlobalFloatArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Shader.GetGlobalVectorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Shader.GetGlobalVectorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Shader.GetGlobalMatrixArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Shader.GetGlobalMatrixArray(nameID,values) end

return Shader
