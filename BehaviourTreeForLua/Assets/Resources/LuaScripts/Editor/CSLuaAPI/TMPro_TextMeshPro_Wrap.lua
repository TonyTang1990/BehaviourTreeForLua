---===================== Author Qcbf 这是自动生成的代码 =====================

---@class TMPro.TextMeshPro : TMPro.TMP_Text
---@field public sortingLayerID int32
---@field public sortingOrder int32
---@field public autoSizeTextContainer System.Boolean
---@field public transform UnityEngine.Transform
---@field public renderer UnityEngine.Renderer
---@field public mesh UnityEngine.Mesh
---@field public meshFilter UnityEngine.MeshFilter
---@field public maskType TMPro.MaskingTypes
local TextMeshPro = {}

---@param type TMPro.MaskingTypes
---@param maskCoords UnityEngine.Vector4
function TextMeshPro:SetMask(type,maskCoords) end

---@param type TMPro.MaskingTypes
---@param maskCoords UnityEngine.Vector4
---@param softnessX number
---@param softnessY number
function TextMeshPro:SetMask(type,maskCoords,softnessX,softnessY) end

function TextMeshPro:SetVerticesDirty() end

function TextMeshPro:SetLayoutDirty() end

function TextMeshPro:SetMaterialDirty() end

function TextMeshPro:SetAllDirty() end

---@param update UnityEngine.UI.CanvasUpdate
function TextMeshPro:Rebuild(update) end

function TextMeshPro:UpdateMeshPadding() end

function TextMeshPro:ForceMeshUpdate() end

---@param ignoreInactive System.Boolean
function TextMeshPro:ForceMeshUpdate(ignoreInactive) end

---@param text string
---@return TMPro.TMP_TextInfo
function TextMeshPro:GetTextInfo(text) end

---@param updateMesh System.Boolean
function TextMeshPro:ClearMesh(updateMesh) end

---@param mesh UnityEngine.Mesh
---@param index int32
function TextMeshPro:UpdateGeometry(mesh,index) end

---@param flags TMPro.TMP_VertexDataUpdateFlags
function TextMeshPro:UpdateVertexData(flags) end

function TextMeshPro:UpdateVertexData() end

function TextMeshPro:UpdateFontAsset() end

function TextMeshPro:CalculateLayoutInputHorizontal() end

function TextMeshPro:CalculateLayoutInputVertical() end

function TextMeshPro:ComputeMarginSize() end

return TextMeshPro
