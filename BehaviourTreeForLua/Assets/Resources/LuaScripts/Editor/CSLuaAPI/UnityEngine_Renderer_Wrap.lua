---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Renderer : UnityEngine.Component
---@field public bounds UnityEngine.Bounds
---@field public enabled System.Boolean
---@field public isVisible System.Boolean
---@field public shadowCastingMode UnityEngine.Rendering.ShadowCastingMode
---@field public receiveShadows System.Boolean
---@field public motionVectorGenerationMode UnityEngine.MotionVectorGenerationMode
---@field public lightProbeUsage UnityEngine.Rendering.LightProbeUsage
---@field public reflectionProbeUsage UnityEngine.Rendering.ReflectionProbeUsage
---@field public renderingLayerMask uint32
---@field public rendererPriority int32
---@field public sortingLayerName string
---@field public sortingLayerID int32
---@field public sortingOrder int32
---@field public allowOcclusionWhenDynamic System.Boolean
---@field public isPartOfStaticBatch System.Boolean
---@field public worldToLocalMatrix UnityEngine.Matrix4x4
---@field public localToWorldMatrix UnityEngine.Matrix4x4
---@field public lightProbeProxyVolumeOverride UnityEngine.GameObject
---@field public probeAnchor UnityEngine.Transform
---@field public lightmapIndex int32
---@field public realtimeLightmapIndex int32
---@field public lightmapScaleOffset UnityEngine.Vector4
---@field public realtimeLightmapScaleOffset UnityEngine.Vector4
---@field public materials UnityEngine.Material[]
---@field public material UnityEngine.Material
---@field public sharedMaterial UnityEngine.Material
---@field public sharedMaterials UnityEngine.Material[]
local Renderer = {}

---@return System.Boolean
function Renderer:HasPropertyBlock() end

---@param properties UnityEngine.MaterialPropertyBlock
function Renderer:SetPropertyBlock(properties) end

---@param properties UnityEngine.MaterialPropertyBlock
---@param materialIndex int32
function Renderer:SetPropertyBlock(properties,materialIndex) end

---@param properties UnityEngine.MaterialPropertyBlock
function Renderer:GetPropertyBlock(properties) end

---@param properties UnityEngine.MaterialPropertyBlock
---@param materialIndex int32
function Renderer:GetPropertyBlock(properties,materialIndex) end

---@param m System.Collections.Generic.List
function Renderer:GetMaterials(m) end

---@param m System.Collections.Generic.List
function Renderer:GetSharedMaterials(m) end

---@param result System.Collections.Generic.List
function Renderer:GetClosestReflectionProbes(result) end

return Renderer
