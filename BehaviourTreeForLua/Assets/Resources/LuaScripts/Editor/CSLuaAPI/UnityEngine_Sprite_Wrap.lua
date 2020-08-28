---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Sprite : UnityEngine.Object
---@field public bounds UnityEngine.Bounds
---@field public rect UnityEngine.Rect
---@field public border UnityEngine.Vector4
---@field public texture UnityEngine.Texture2D
---@field public pixelsPerUnit number
---@field public associatedAlphaSplitTexture UnityEngine.Texture2D
---@field public pivot UnityEngine.Vector2
---@field public packed System.Boolean
---@field public packingMode UnityEngine.SpritePackingMode
---@field public packingRotation UnityEngine.SpritePackingRotation
---@field public textureRect UnityEngine.Rect
---@field public textureRectOffset UnityEngine.Vector2
---@field public vertices UnityEngine.Vector2[]
---@field public triangles System.UInt16[]
---@field public uv UnityEngine.Vector2[]
local Sprite = {}

---@return int32
function Sprite:GetPhysicsShapeCount() end

---@param shapeIdx int32
---@return int32
function Sprite:GetPhysicsShapePointCount(shapeIdx) end

---@param shapeIdx int32
---@param physicsShape System.Collections.Generic.List
---@return int32
function Sprite:GetPhysicsShape(shapeIdx,physicsShape) end

---@param physicsShapes System.Collections.Generic.IList
function Sprite:OverridePhysicsShape(physicsShapes) end

---@param vertices UnityEngine.Vector2[]
---@param triangles System.UInt16[]
function Sprite:OverrideGeometry(vertices,triangles) end

---@param texture UnityEngine.Texture2D
---@param rect UnityEngine.Rect
---@param pivot UnityEngine.Vector2
---@param pixelsPerUnit number
---@param extrude uint32
---@param meshType UnityEngine.SpriteMeshType
---@param border UnityEngine.Vector4
---@param generateFallbackPhysicsShape System.Boolean
---@return UnityEngine.Sprite
function Sprite.Create(texture,rect,pivot,pixelsPerUnit,extrude,meshType,border,generateFallbackPhysicsShape) end

---@param texture UnityEngine.Texture2D
---@param rect UnityEngine.Rect
---@param pivot UnityEngine.Vector2
---@param pixelsPerUnit number
---@param extrude uint32
---@param meshType UnityEngine.SpriteMeshType
---@param border UnityEngine.Vector4
---@return UnityEngine.Sprite
function Sprite.Create(texture,rect,pivot,pixelsPerUnit,extrude,meshType,border) end

---@param texture UnityEngine.Texture2D
---@param rect UnityEngine.Rect
---@param pivot UnityEngine.Vector2
---@param pixelsPerUnit number
---@param extrude uint32
---@param meshType UnityEngine.SpriteMeshType
---@return UnityEngine.Sprite
function Sprite.Create(texture,rect,pivot,pixelsPerUnit,extrude,meshType) end

---@param texture UnityEngine.Texture2D
---@param rect UnityEngine.Rect
---@param pivot UnityEngine.Vector2
---@param pixelsPerUnit number
---@param extrude uint32
---@return UnityEngine.Sprite
function Sprite.Create(texture,rect,pivot,pixelsPerUnit,extrude) end

---@param texture UnityEngine.Texture2D
---@param rect UnityEngine.Rect
---@param pivot UnityEngine.Vector2
---@param pixelsPerUnit number
---@return UnityEngine.Sprite
function Sprite.Create(texture,rect,pivot,pixelsPerUnit) end

---@param texture UnityEngine.Texture2D
---@param rect UnityEngine.Rect
---@param pivot UnityEngine.Vector2
---@return UnityEngine.Sprite
function Sprite.Create(texture,rect,pivot) end

return Sprite
