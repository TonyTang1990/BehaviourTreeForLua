---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.Diagnostics.Stopwatch
---@field public Elapsed System.TimeSpan
---@field public ElapsedMilliseconds int64
---@field public ElapsedTicks int64
---@field public IsRunning System.Boolean
---@field static Frequency int64
---@field static IsHighResolution System.Boolean
local Stopwatch = {}

function Stopwatch:Reset() end

function Stopwatch:Start() end

function Stopwatch:Stop() end

function Stopwatch:Restart() end

---@return int64
function Stopwatch.GetTimestamp() end

---@return System.Diagnostics.Stopwatch
function Stopwatch.StartNew() end

return Stopwatch
