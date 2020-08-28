---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.ParticleSystemRenderer : UnityEngine.Renderer
---@field public mesh UnityEngine.Mesh
---@field public meshCount int32
---@field public activeVertexStreamsCount int32
---@field public alignment UnityEngine.ParticleSystemRenderSpace
---@field public renderMode UnityEngine.ParticleSystemRenderMode
---@field public sortMode UnityEngine.ParticleSystemSortMode
---@field public lengthScale number
---@field public velocityScale number
---@field public cameraVelocityScale number
---@field public normalDirection number
---@field public shadowBias number
---@field public sortingFudge number
---@field public minParticleSize number
---@field public maxParticleSize number
---@field public pivot UnityEngine.Vector3
---@field public flip UnityEngine.Vector3
---@field public maskInteraction UnityEngine.SpriteMaskInteraction
---@field public trailMaterial UnityEngine.Material
---@field public enableGPUInstancing System.Boolean
---@field public allowRoll System.Boolean
local ParticleSystemRenderer = {}

---@param meshes UnityEngine.Mesh[]
---@return int32
function ParticleSystemRenderer:GetMeshes(meshes) end

---@param meshes UnityEngine.Mesh[]
function ParticleSystemRenderer:SetMeshes(meshes) end

---@param meshes UnityEngine.Mesh[]
---@param size int32
function ParticleSystemRenderer:SetMeshes(meshes,size) end

---@param streams System.Collections.Generic.List
function ParticleSystemRenderer:SetActiveVertexStreams(streams) end

---@param streams System.Collections.Generic.List
function ParticleSystemRenderer:GetActiveVertexStreams(streams) end

---@param mesh UnityEngine.Mesh
---@param useTransform System.Boolean
function ParticleSystemRenderer:BakeMesh(mesh,useTransform) end

---@param mesh UnityEngine.Mesh
---@param camera UnityEngine.Camera
---@param useTransform System.Boolean
function ParticleSystemRenderer:BakeMesh(mesh,camera,useTransform) end

---@param mesh UnityEngine.Mesh
---@param useTransform System.Boolean
function ParticleSystemRenderer:BakeTrailsMesh(mesh,useTransform) end

---@param mesh UnityEngine.Mesh
---@param camera UnityEngine.Camera
---@param useTransform System.Boolean
function ParticleSystemRenderer:BakeTrailsMesh(mesh,camera,useTransform) end

return ParticleSystemRenderer
