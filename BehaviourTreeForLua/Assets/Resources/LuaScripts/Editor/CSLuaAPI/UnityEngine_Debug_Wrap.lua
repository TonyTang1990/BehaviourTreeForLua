---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Debug
---@field static unityLogger UnityEngine.ILogger
---@field static developerConsoleVisible System.Boolean
---@field static isDebugBuild System.Boolean
local Debug = {}

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param color UnityEngine.Color
---@param duration number
function Debug.DrawLine(start,end_,color,duration) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param color UnityEngine.Color
function Debug.DrawLine(start,end_,color) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
function Debug.DrawLine(start,end_) end

---@param start UnityEngine.Vector3
---@param end_ UnityEngine.Vector3
---@param color UnityEngine.Color
---@param duration number
---@param depthTest System.Boolean
function Debug.DrawLine(start,end_,color,duration,depthTest) end

---@param start UnityEngine.Vector3
---@param dir UnityEngine.Vector3
---@param color UnityEngine.Color
---@param duration number
function Debug.DrawRay(start,dir,color,duration) end

---@param start UnityEngine.Vector3
---@param dir UnityEngine.Vector3
---@param color UnityEngine.Color
function Debug.DrawRay(start,dir,color) end

---@param start UnityEngine.Vector3
---@param dir UnityEngine.Vector3
function Debug.DrawRay(start,dir) end

---@param start UnityEngine.Vector3
---@param dir UnityEngine.Vector3
---@param color UnityEngine.Color
---@param duration number
---@param depthTest System.Boolean
function Debug.DrawRay(start,dir,color,duration,depthTest) end

function Debug.Break() end

function Debug.DebugBreak() end

---@param message System.Object
function Debug.Log(message) end

---@param message System.Object
---@param context UnityEngine.Object
function Debug.Log(message,context) end

---@param format string
---@param args System.Object[]
function Debug.LogFormat(format,args) end

---@param context UnityEngine.Object
---@param format string
---@param args System.Object[]
function Debug.LogFormat(context,format,args) end

---@param message System.Object
function Debug.LogError(message) end

---@param message System.Object
---@param context UnityEngine.Object
function Debug.LogError(message,context) end

---@param format string
---@param args System.Object[]
function Debug.LogErrorFormat(format,args) end

---@param context UnityEngine.Object
---@param format string
---@param args System.Object[]
function Debug.LogErrorFormat(context,format,args) end

function Debug.ClearDeveloperConsole() end

---@param exception System.Exception
function Debug.LogException(exception) end

---@param exception System.Exception
---@param context UnityEngine.Object
function Debug.LogException(exception,context) end

---@param message System.Object
function Debug.LogWarning(message) end

---@param message System.Object
---@param context UnityEngine.Object
function Debug.LogWarning(message,context) end

---@param format string
---@param args System.Object[]
function Debug.LogWarningFormat(format,args) end

---@param context UnityEngine.Object
---@param format string
---@param args System.Object[]
function Debug.LogWarningFormat(context,format,args) end

---@param condition System.Boolean
function Debug.Assert(condition) end

---@param condition System.Boolean
---@param context UnityEngine.Object
function Debug.Assert(condition,context) end

---@param condition System.Boolean
---@param message System.Object
function Debug.Assert(condition,message) end

---@param condition System.Boolean
---@param message string
function Debug.Assert(condition,message) end

---@param condition System.Boolean
---@param message System.Object
---@param context UnityEngine.Object
function Debug.Assert(condition,message,context) end

---@param condition System.Boolean
---@param message string
---@param context UnityEngine.Object
function Debug.Assert(condition,message,context) end

---@param condition System.Boolean
---@param format string
---@param args System.Object[]
function Debug.AssertFormat(condition,format,args) end

---@param condition System.Boolean
---@param context UnityEngine.Object
---@param format string
---@param args System.Object[]
function Debug.AssertFormat(condition,context,format,args) end

---@param message System.Object
function Debug.LogAssertion(message) end

---@param message System.Object
---@param context UnityEngine.Object
function Debug.LogAssertion(message,context) end

---@param format string
---@param args System.Object[]
function Debug.LogAssertionFormat(format,args) end

---@param context UnityEngine.Object
---@param format string
---@param args System.Object[]
function Debug.LogAssertionFormat(context,format,args) end

return Debug
