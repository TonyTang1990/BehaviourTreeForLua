---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.SkinnedMeshRenderer : UnityEngine.Renderer
---@field public quality UnityEngine.SkinQuality
---@field public updateWhenOffscreen System.Boolean
---@field public forceMatrixRecalculationPerRender System.Boolean
---@field public rootBone UnityEngine.Transform
---@field public bones UnityEngine.Transform[]
---@field public sharedMesh UnityEngine.Mesh
---@field public skinnedMotionVectors System.Boolean
---@field public localBounds UnityEngine.Bounds
local SkinnedMeshRenderer = {}

---@param index int32
---@return number
function SkinnedMeshRenderer:GetBlendShapeWeight(index) end

---@param index int32
---@param value number
function SkinnedMeshRenderer:SetBlendShapeWeight(index,value) end

---@param mesh UnityEngine.Mesh
function SkinnedMeshRenderer:BakeMesh(mesh) end

return SkinnedMeshRenderer
