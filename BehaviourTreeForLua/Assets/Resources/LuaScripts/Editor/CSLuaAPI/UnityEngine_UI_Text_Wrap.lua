---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.UI.Text : UnityEngine.UI.MaskableGraphic
---@field public cachedTextGenerator UnityEngine.TextGenerator
---@field public cachedTextGeneratorForLayout UnityEngine.TextGenerator
---@field public mainTexture UnityEngine.Texture
---@field public font UnityEngine.Font
---@field public text string
---@field public supportRichText System.Boolean
---@field public resizeTextForBestFit System.Boolean
---@field public resizeTextMinSize int32
---@field public resizeTextMaxSize int32
---@field public alignment UnityEngine.TextAnchor
---@field public alignByGeometry System.Boolean
---@field public fontSize int32
---@field public horizontalOverflow UnityEngine.HorizontalWrapMode
---@field public verticalOverflow UnityEngine.VerticalWrapMode
---@field public lineSpacing number
---@field public fontStyle UnityEngine.FontStyle
---@field public pixelsPerUnit number
---@field public minWidth number
---@field public preferredWidth number
---@field public flexibleWidth number
---@field public minHeight number
---@field public preferredHeight number
---@field public flexibleHeight number
---@field public layoutPriority int32
local Text = {}

function Text:FontTextureChanged() end

---@param extents UnityEngine.Vector2
---@return UnityEngine.TextGenerationSettings
function Text:GetGenerationSettings(extents) end

function Text:CalculateLayoutInputHorizontal() end

function Text:CalculateLayoutInputVertical() end

function Text:OnRebuildRequested() end

---@param anchor UnityEngine.TextAnchor
---@return UnityEngine.Vector2
function Text.GetTextAnchorPivot(anchor) end

return Text
