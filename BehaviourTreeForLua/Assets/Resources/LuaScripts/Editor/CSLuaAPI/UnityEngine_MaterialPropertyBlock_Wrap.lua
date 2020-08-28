---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.MaterialPropertyBlock
---@field public isEmpty System.Boolean
local MaterialPropertyBlock = {}

function MaterialPropertyBlock:Clear() end

---@param name string
---@param value number
function MaterialPropertyBlock:SetFloat(name,value) end

---@param nameID int32
---@param value number
function MaterialPropertyBlock:SetFloat(nameID,value) end

---@param name string
---@param value int32
function MaterialPropertyBlock:SetInt(name,value) end

---@param nameID int32
---@param value int32
function MaterialPropertyBlock:SetInt(nameID,value) end

---@param name string
---@param value UnityEngine.Vector4
function MaterialPropertyBlock:SetVector(name,value) end

---@param nameID int32
---@param value UnityEngine.Vector4
function MaterialPropertyBlock:SetVector(nameID,value) end

---@param name string
---@param value UnityEngine.Color
function MaterialPropertyBlock:SetColor(name,value) end

---@param nameID int32
---@param value UnityEngine.Color
function MaterialPropertyBlock:SetColor(nameID,value) end

---@param name string
---@param value UnityEngine.Matrix4x4
function MaterialPropertyBlock:SetMatrix(name,value) end

---@param nameID int32
---@param value UnityEngine.Matrix4x4
function MaterialPropertyBlock:SetMatrix(nameID,value) end

---@param name string
---@param value UnityEngine.ComputeBuffer
function MaterialPropertyBlock:SetBuffer(name,value) end

---@param nameID int32
---@param value UnityEngine.ComputeBuffer
function MaterialPropertyBlock:SetBuffer(nameID,value) end

---@param name string
---@param value UnityEngine.Texture
function MaterialPropertyBlock:SetTexture(name,value) end

---@param nameID int32
---@param value UnityEngine.Texture
function MaterialPropertyBlock:SetTexture(nameID,value) end

---@param name string
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:SetFloatArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:SetFloatArray(nameID,values) end

---@param name string
---@param values System.Single[]
function MaterialPropertyBlock:SetFloatArray(name,values) end

---@param nameID int32
---@param values System.Single[]
function MaterialPropertyBlock:SetFloatArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:SetVectorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:SetVectorArray(nameID,values) end

---@param name string
---@param values UnityEngine.Vector4[]
function MaterialPropertyBlock:SetVectorArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Vector4[]
function MaterialPropertyBlock:SetVectorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:SetMatrixArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:SetMatrixArray(nameID,values) end

---@param name string
---@param values UnityEngine.Matrix4x4[]
function MaterialPropertyBlock:SetMatrixArray(name,values) end

---@param nameID int32
---@param values UnityEngine.Matrix4x4[]
function MaterialPropertyBlock:SetMatrixArray(nameID,values) end

---@param name string
---@return number
function MaterialPropertyBlock:GetFloat(name) end

---@param nameID int32
---@return number
function MaterialPropertyBlock:GetFloat(nameID) end

---@param name string
---@return int32
function MaterialPropertyBlock:GetInt(name) end

---@param nameID int32
---@return int32
function MaterialPropertyBlock:GetInt(nameID) end

---@param name string
---@return UnityEngine.Vector4
function MaterialPropertyBlock:GetVector(name) end

---@param nameID int32
---@return UnityEngine.Vector4
function MaterialPropertyBlock:GetVector(nameID) end

---@param name string
---@return UnityEngine.Color
function MaterialPropertyBlock:GetColor(name) end

---@param nameID int32
---@return UnityEngine.Color
function MaterialPropertyBlock:GetColor(nameID) end

---@param name string
---@return UnityEngine.Matrix4x4
function MaterialPropertyBlock:GetMatrix(name) end

---@param nameID int32
---@return UnityEngine.Matrix4x4
function MaterialPropertyBlock:GetMatrix(nameID) end

---@param name string
---@return UnityEngine.Texture
function MaterialPropertyBlock:GetTexture(name) end

---@param nameID int32
---@return UnityEngine.Texture
function MaterialPropertyBlock:GetTexture(nameID) end

---@param name string
---@return System.Single[]
function MaterialPropertyBlock:GetFloatArray(name) end

---@param nameID int32
---@return System.Single[]
function MaterialPropertyBlock:GetFloatArray(nameID) end

---@param name string
---@return UnityEngine.Vector4[]
function MaterialPropertyBlock:GetVectorArray(name) end

---@param nameID int32
---@return UnityEngine.Vector4[]
function MaterialPropertyBlock:GetVectorArray(nameID) end

---@param name string
---@return UnityEngine.Matrix4x4[]
function MaterialPropertyBlock:GetMatrixArray(name) end

---@param nameID int32
---@return UnityEngine.Matrix4x4[]
function MaterialPropertyBlock:GetMatrixArray(nameID) end

---@param name string
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:GetFloatArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:GetFloatArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:GetVectorArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:GetVectorArray(nameID,values) end

---@param name string
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:GetMatrixArray(name,values) end

---@param nameID int32
---@param values System.Collections.Generic.List
function MaterialPropertyBlock:GetMatrixArray(nameID,values) end

---@param lightProbes System.Collections.Generic.List
function MaterialPropertyBlock:CopySHCoefficientArraysFrom(lightProbes) end

---@param lightProbes UnityEngine.Rendering.SphericalHarmonicsL2[]
function MaterialPropertyBlock:CopySHCoefficientArraysFrom(lightProbes) end

---@param lightProbes System.Collections.Generic.List
---@param sourceStart int32
---@param destStart int32
---@param count int32
function MaterialPropertyBlock:CopySHCoefficientArraysFrom(lightProbes,sourceStart,destStart,count) end

---@param lightProbes UnityEngine.Rendering.SphericalHarmonicsL2[]
---@param sourceStart int32
---@param destStart int32
---@param count int32
function MaterialPropertyBlock:CopySHCoefficientArraysFrom(lightProbes,sourceStart,destStart,count) end

---@param occlusionProbes System.Collections.Generic.List
function MaterialPropertyBlock:CopyProbeOcclusionArrayFrom(occlusionProbes) end

---@param occlusionProbes UnityEngine.Vector4[]
function MaterialPropertyBlock:CopyProbeOcclusionArrayFrom(occlusionProbes) end

---@param occlusionProbes System.Collections.Generic.List
---@param sourceStart int32
---@param destStart int32
---@param count int32
function MaterialPropertyBlock:CopyProbeOcclusionArrayFrom(occlusionProbes,sourceStart,destStart,count) end

---@param occlusionProbes UnityEngine.Vector4[]
---@param sourceStart int32
---@param destStart int32
---@param count int32
function MaterialPropertyBlock:CopyProbeOcclusionArrayFrom(occlusionProbes,sourceStart,destStart,count) end

return MaterialPropertyBlock
