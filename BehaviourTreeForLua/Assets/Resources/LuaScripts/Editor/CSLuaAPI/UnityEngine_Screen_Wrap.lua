---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Screen
---@field static width int32
---@field static height int32
---@field static dpi number
---@field static orientation UnityEngine.ScreenOrientation
---@field static sleepTimeout int32
---@field static autorotateToPortrait System.Boolean
---@field static autorotateToPortraitUpsideDown System.Boolean
---@field static autorotateToLandscapeLeft System.Boolean
---@field static autorotateToLandscapeRight System.Boolean
---@field static currentResolution UnityEngine.Resolution
---@field static fullScreen System.Boolean
---@field static fullScreenMode UnityEngine.FullScreenMode
---@field static safeArea UnityEngine.Rect
---@field static resolutions UnityEngine.Resolution[]
local Screen = {}

---@param width int32
---@param height int32
---@param fullscreenMode UnityEngine.FullScreenMode
---@param preferredRefreshRate int32
function Screen.SetResolution(width,height,fullscreenMode,preferredRefreshRate) end

---@param width int32
---@param height int32
---@param fullscreenMode UnityEngine.FullScreenMode
function Screen.SetResolution(width,height,fullscreenMode) end

---@param width int32
---@param height int32
---@param fullscreen System.Boolean
---@param preferredRefreshRate int32
function Screen.SetResolution(width,height,fullscreen,preferredRefreshRate) end

---@param width int32
---@param height int32
---@param fullscreen System.Boolean
function Screen.SetResolution(width,height,fullscreen) end

return Screen
