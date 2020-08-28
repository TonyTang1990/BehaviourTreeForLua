---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Material : UnityEngine.Object
---@field public shader UnityEngine.Shader
---@field public color UnityEngine.Color
---@field public mainTexture UnityEngine.Texture
---@field public mainTextureOffset UnityEngine.Vector2
---@field public mainTextureScale UnityEngine.Vector2
---@field public renderQueue int32
---@field public globalIlluminationFlags UnityEngine.MaterialGlobalIlluminationFlags
---@field public doubleSidedGI System.Boolean
---@field public enableInstancing System.Boolean
---@field public passCount int32
---@field public shaderKeywords System.String[]
local Material = {}

---@param nameID int32
---@return System.Boolean
function Material:HasProperty(nameID) end

---@param name string
---@return System.Boolean
function Material:HasProperty(name) end

---@param keyword string
function Material:EnableKeyword(keyword) end

---@param keyword string
function Material:DisableKeyword(keyword) end

---@param keyword string
---@return System.Boolean
function Material:IsKeywordEnabled(keyword) end

---@param passName string
---@param enabled System.Boolean
function Material:SetShaderPassEnabled(passName,enabled) end

---@param passName string
---@return System.Boolean
function Material:GetShaderPassEnabled(passName) end

---@param pass int32
---@return string
function Material:GetPassName(pass) end

---@param passName string
---@return int32
function Material:FindPass(passName) end

---@param tag string
---@param val string
function Material:SetOverrideTag(tag,val) end

---@param tag string
---@param searchFallbacks System.Boolean
---@param defaultValue string
---@return string
function Material:GetTag(tag,searchFallbacks,defaultValue) end

---@param tag string
---@param searchFallbacks System.Boolean
---@return string
function Material:GetTag(tag,searchFallbacks) end

---@param start UnityEngine.Material
---@param end_ UnityEngine.Material
---@param t number
function Material:Lerp(start,end_,t) end

---@param pass int32
---@return System.Boolean
function Material:SetPass(pass) end

---@param mat UnityEngine.Material
function Material:CopyPropertiesFromMaterial(mat) end

---@return System.String[]
function Material:GetTexturePropertyNames() end

---@return System.Int32[]
function Material:GetTexturePropertyNameIDs() end

---@param outNames System.Collections.Generic.List
function Material:GetTexturePropertyNames(outNames) end

---@param outNames System.Collections.Generic.List
function Material:GetTexturePropertyNameIDs(outNames) end

---@param name string
---@param value number
function Material:SetFloat(name,value) end

---@param nameID int32
---@param value number
function Material:SetFloat(nameID,value) end

---@param name string
---@param value int32
function Material:SetInt(name,value) end

---@param nameID int32
---@param value int32
function Material:SetInt(nameID,value) end

---@param name string
---@param value UnityEngine.Color
function Material:SetColor(name,value) end

---@param nameID int32
---@param value UnityEngine.Color
function Material:SetColor(nameID,value) end

---@param name string
---@param value UnityEngine.Vector4
function Material:SetVector(name,value) end

---@param nameID int32
---@param value UnityEngine.Vector4
function Material:SetVector(nameID,value) end

---@param name string
---@param value UnityEngine.Matrix4x4
function Material:SetMatrix(name,value) end

---@param nameID int32
---@param value UnityEngine.Matrix4x4
function Material:SetMatrix(nameID,value) end

---@param name string
---@param value UnityEngine.Texture
function Material:SetTexture(name,value) end

---@param nameID int32
---@param value UnityEngine.Texture
function Material:SetTexture(nameID,value) end

---@param name string
---@param value UnityEngine.ComputeBuffer
function Material:SetBuffer(name,value) end

---@param nameID int32
---@param value UnityEngine.ComputeBuffer
function Material:SetBuffer(nameID,value) end

---@param name string
---@param values System.Collections.Generic.List
function Material:SetFloatArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:SetFloatArray(nameID,values) end

---@param name string
---@param values System.Single[]
function Material:SetFloatArray(name,values) end

---@param nameID int32
---@param values System.Single[]
function Material:SetFloatArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Material:SetColorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:SetColorArray(nameID,values) end

---@param name string
---@param values UnityEngine.Color[]
function Material:SetColorArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Color[]
function Material:SetColorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Material:SetVectorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:SetVectorArray(nameID,values) end

---@param name string
---@param values UnityEngine.Vector4[]
function Material:SetVectorArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Vector4[]
function Material:SetVectorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Material:SetMatrixArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:SetMatrixArray(nameID,values) end

---@param name string
---@param values UnityEngine.Matrix4x4[]
function Material:SetMatrixArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Matrix4x4[]
function Material:SetMatrixArray(nameID,values) end

---@param name string
---@return number
function Material:GetFloat(name) end

---@param nameID int32
---@return number
function Material:GetFloat(nameID) end

---@param name string
---@return int32
function Material:GetInt(name) end

---@param nameID int32
---@return int32
function Material:GetInt(nameID) end

---@param name string
---@return UnityEngine.Color
function Material:GetColor(name) end

---@param nameID int32
---@return UnityEngine.Color
function Material:GetColor(nameID) end

---@param name string
---@return UnityEngine.Vector4
function Material:GetVector(name) end

---@param nameID int32
---@return UnityEngine.Vector4
function Material:GetVector(nameID) end

---@param name string
---@return UnityEngine.Matrix4x4
function Material:GetMatrix(name) end

---@param nameID int32
---@return UnityEngine.Matrix4x4
function Material:GetMatrix(nameID) end

---@param name string
---@return UnityEngine.Texture
function Material:GetTexture(name) end

---@param nameID int32
---@return UnityEngine.Texture
function Material:GetTexture(nameID) end

---@param name string
---@return System.Single[]
function Material:GetFloatArray(name) end

---@param nameID int32
---@return System.Single[]
function Material:GetFloatArray(nameID) end

---@param name string
---@return UnityEngine.Color[]
function Material:GetColorArray(name) end

---@param nameID int32
---@return UnityEngine.Color[]
function Material:GetColorArray(nameID) end

---@param name string
---@return UnityEngine.Vector4[]
function Material:GetVectorArray(name) end

---@param nameID int32
---@return UnityEngine.Vector4[]
function Material:GetVectorArray(nameID) end

---@param name string
---@return UnityEngine.Matrix4x4[]
function Material:GetMatrixArray(name) end

---@param nameID int32
---@return UnityEngine.Matrix4x4[]
function Material:GetMatrixArray(nameID) end

---@param name string
---@param values System.Collections.Generic.List
function Material:GetFloatArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:GetFloatArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Material:GetColorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:GetColorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Material:GetVectorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:GetVectorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function Material:GetMatrixArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function Material:GetMatrixArray(nameID,values) end

---@param name string
---@param value UnityEngine.Vector2
function Material:SetTextureOffset(name,value) end

---@param nameID int32
---@param value UnityEngine.Vector2
function Material:SetTextureOffset(nameID,value) end

---@param name string
---@param value UnityEngine.Vector2
function Material:SetTextureScale(name,value) end

---@param nameID int32
---@param value UnityEngine.Vector2
function Material:SetTextureScale(nameID,value) end

---@param name string
---@return UnityEngine.Vector2
function Material:GetTextureOffset(name) end

---@param nameID int32
---@return UnityEngine.Vector2
function Material:GetTextureOffset(nameID) end

---@param name string
---@return UnityEngine.Vector2
function Material:GetTextureScale(name) end

---@param nameID int32
---@return UnityEngine.Vector2
function Material:GetTextureScale(nameID) end

return Material
