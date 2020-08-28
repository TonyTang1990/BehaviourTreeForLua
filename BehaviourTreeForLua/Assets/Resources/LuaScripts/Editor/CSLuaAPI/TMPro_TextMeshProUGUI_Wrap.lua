---===================== Author Qcbf 这是自动生成的代码 =====================

---@class TMPro.TextMeshProUGUI : TMPro.TMP_Text
---@field public materialForRendering UnityEngine.Material
---@field public autoSizeTextContainer System.Boolean
---@field public mesh UnityEngine.Mesh
---@field public canvasRenderer UnityEngine.CanvasRenderer
---@field public maskOffset UnityEngine.Vector4
---@field public materialForRendering UnityEngine.Material
---@field public autoSizeTextContainer System.Boolean
---@field public mesh UnityEngine.Mesh
---@field public canvasRenderer UnityEngine.CanvasRenderer
---@field public maskOffset UnityEngine.Vector4
local TextMeshProUGUI = {}

function TextMeshProUGUI:CalculateLayoutInputHorizontal() end

function TextMeshProUGUI:CalculateLayoutInputVertical() end

function TextMeshProUGUI:SetVerticesDirty() end

function TextMeshProUGUI:SetLayoutDirty() end

function TextMeshProUGUI:SetMaterialDirty() end

function TextMeshProUGUI:SetAllDirty() end

---@param update UnityEngine.UI.CanvasUpdate
function TextMeshProUGUI:Rebuild(update) end

---@param baseMaterial UnityEngine.Material
---@return UnityEngine.Material
function TextMeshProUGUI:GetModifiedMaterial(baseMaterial) end

function TextMeshProUGUI:RecalculateClipping() end

function TextMeshProUGUI:RecalculateMasking() end

---@param clipRect UnityEngine.Rect
---@param validRect System.Boolean
function TextMeshProUGUI:Cull(clipRect,validRect) end

function TextMeshProUGUI:UpdateMeshPadding() end

function TextMeshProUGUI:ForceMeshUpdate() end

---@param ignoreInactive System.Boolean
function TextMeshProUGUI:ForceMeshUpdate(ignoreInactive) end

---@param text string
---@return TMPro.TMP_TextInfo
function TextMeshProUGUI:GetTextInfo(text) end

function TextMeshProUGUI:ClearMesh() end

---@param mesh UnityEngine.Mesh
---@param index int32
function TextMeshProUGUI:UpdateGeometry(mesh,index) end

---@param flags TMPro.TMP_VertexDataUpdateFlags
function TextMeshProUGUI:UpdateVertexData(flags) end

function TextMeshProUGUI:UpdateVertexData() end

function TextMeshProUGUI:UpdateFontAsset() end

function TextMeshProUGUI:ComputeMarginSize() end

function TextMeshProUGUI:CalculateLayoutInputHorizontal() end

function TextMeshProUGUI:CalculateLayoutInputVertical() end

function TextMeshProUGUI:SetVerticesDirty() end

function TextMeshProUGUI:SetLayoutDirty() end

function TextMeshProUGUI:SetMaterialDirty() end

function TextMeshProUGUI:SetAllDirty() end

---@param update UnityEngine.UI.CanvasUpdate
function TextMeshProUGUI:Rebuild(update) end

---@param baseMaterial UnityEngine.Material
---@return UnityEngine.Material
function TextMeshProUGUI:GetModifiedMaterial(baseMaterial) end

function TextMeshProUGUI:RecalculateClipping() end

function TextMeshProUGUI:RecalculateMasking() end

---@param clipRect UnityEngine.Rect
---@param validRect System.Boolean
function TextMeshProUGUI:Cull(clipRect,validRect) end

function TextMeshProUGUI:UpdateMeshPadding() end

function TextMeshProUGUI:ForceMeshUpdate() end

---@param ignoreInactive System.Boolean
function TextMeshProUGUI:ForceMeshUpdate(ignoreInactive) end

---@param text string
---@return TMPro.TMP_TextInfo
function TextMeshProUGUI:GetTextInfo(text) end

function TextMeshProUGUI:ClearMesh() end

---@param mesh UnityEngine.Mesh
---@param index int32
function TextMeshProUGUI:UpdateGeometry(mesh,index) end

---@param flags TMPro.TMP_VertexDataUpdateFlags
function TextMeshProUGUI:UpdateVertexData(flags) end

function TextMeshProUGUI:UpdateVertexData() end

function TextMeshProUGUI:UpdateFontAsset() end

function TextMeshProUGUI:ComputeMarginSize() end

return TextMeshProUGUI
