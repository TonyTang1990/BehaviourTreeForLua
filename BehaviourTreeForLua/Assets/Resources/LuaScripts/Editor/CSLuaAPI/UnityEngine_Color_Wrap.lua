---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Color
---@field public grayscale number
---@field public linear UnityEngine.Color
---@field public gamma UnityEngine.Color
---@field public maxColorComponent number
---@field public Item number
---@field public r number
---@field public g number
---@field public b number
---@field public a number
---@field static red UnityEngine.Color
---@field static green UnityEngine.Color
---@field static blue UnityEngine.Color
---@field static white UnityEngine.Color
---@field static black UnityEngine.Color
---@field static yellow UnityEngine.Color
---@field static cyan UnityEngine.Color
---@field static magenta UnityEngine.Color
---@field static gray UnityEngine.Color
---@field static grey UnityEngine.Color
---@field static clear UnityEngine.Color
local Color = {}

---@return string
function Color:ToString() end

---@param format string
---@return string
function Color:ToString(format) end

---@return int32
function Color:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Color:Equals(other) end

---@param other UnityEngine.Color
---@return System.Boolean
function Color:Equals(other) end

---@param a UnityEngine.Color
---@param b UnityEngine.Color
---@param t number
---@return UnityEngine.Color
function Color.Lerp(a,b,t) end

---@param a UnityEngine.Color
---@param b UnityEngine.Color
---@param t number
---@return UnityEngine.Color
function Color.LerpUnclamped(a,b,t) end

---@param rgbColor UnityEngine.Color
function Color.RGBToHSV(rgbColor) end

---@param H number
---@param S number
---@param V number
---@return UnityEngine.Color
function Color.HSVToRGB(H,S,V) end

---@param H number
---@param S number
---@param V number
---@param hdr System.Boolean
---@return UnityEngine.Color
function Color.HSVToRGB(H,S,V,hdr) end

return Color
