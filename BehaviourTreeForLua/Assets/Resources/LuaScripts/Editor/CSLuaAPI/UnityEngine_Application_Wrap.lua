---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Application
---@field static isPlaying System.Boolean
---@field static isFocused System.Boolean
---@field static platform UnityEngine.RuntimePlatform
---@field static buildGUID string
---@field static isMobilePlatform System.Boolean
---@field static isConsolePlatform System.Boolean
---@field static runInBackground System.Boolean
---@field static isBatchMode System.Boolean
---@field static dataPath string
---@field static streamingAssetsPath string
---@field static persistentDataPath string
---@field static temporaryCachePath string
---@field static absoluteURL string
---@field static unityVersion string
---@field static version string
---@field static installerName string
---@field static identifier string
---@field static installMode UnityEngine.ApplicationInstallMode
---@field static sandboxType UnityEngine.ApplicationSandboxType
---@field static productName string
---@field static companyName string
---@field static cloudProjectId string
---@field static targetFrameRate int32
---@field static systemLanguage UnityEngine.SystemLanguage
---@field static consoleLogPath string
---@field static backgroundLoadingPriority UnityEngine.ThreadPriority
---@field static internetReachability UnityEngine.NetworkReachability
---@field static genuine System.Boolean
---@field static genuineCheckAvailable System.Boolean
---@field static isEditor System.Boolean
local Application = {}

---@param exitCode int32
function Application.Quit(exitCode) end

function Application.Quit() end

function Application.Unload() end

---@param levelIndex int32
---@return System.Boolean
function Application.CanStreamedLevelBeLoaded(levelIndex) end

---@param levelName string
---@return System.Boolean
function Application.CanStreamedLevelBeLoaded(levelName) end

---@param obj UnityEngine.Object
---@return System.Boolean
function Application.IsPlaying(obj) end

---@return System.String[]
function Application.GetBuildTags() end

---@param buildTags System.String[]
function Application.SetBuildTags(buildTags) end

---@return System.Boolean
function Application.HasProLicense() end

---@param delegateMethod UnityEngine.Application.AdvertisingIdentifierCallback
---@return System.Boolean
function Application.RequestAdvertisingIdentifierAsync(delegateMethod) end

---@param url string
function Application.OpenURL(url) end

---@param logType UnityEngine.LogType
---@return UnityEngine.StackTraceLogType
function Application.GetStackTraceLogType(logType) end

---@param logType UnityEngine.LogType
---@param stackTraceType UnityEngine.StackTraceLogType
function Application.SetStackTraceLogType(logType,stackTraceType) end

---@param mode UnityEngine.UserAuthorization
---@return UnityEngine.AsyncOperation
function Application.RequestUserAuthorization(mode) end

---@param mode UnityEngine.UserAuthorization
---@return System.Boolean
function Application.HasUserAuthorization(mode) end

return Application
