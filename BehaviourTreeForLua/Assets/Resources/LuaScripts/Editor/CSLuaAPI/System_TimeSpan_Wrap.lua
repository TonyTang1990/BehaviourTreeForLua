---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.TimeSpan
---@field public Ticks int64
---@field public Days int32
---@field public Hours int32
---@field public Milliseconds int32
---@field public Minutes int32
---@field public Seconds int32
---@field public TotalDays number
---@field public TotalHours number
---@field public TotalMilliseconds number
---@field public TotalMinutes number
---@field public TotalSeconds number
---@field static TicksPerMillisecond int64
---@field static TicksPerSecond int64
---@field static TicksPerMinute int64
---@field static TicksPerHour int64
---@field static TicksPerDay int64
---@field static Zero System.TimeSpan
---@field static MaxValue System.TimeSpan
---@field static MinValue System.TimeSpan
local TimeSpan = {}

---@param ts System.TimeSpan
---@return System.TimeSpan
function TimeSpan:Add(ts) end

---@param value System.Object
---@return int32
function TimeSpan:CompareTo(value) end

---@param value System.TimeSpan
---@return int32
function TimeSpan:CompareTo(value) end

---@return System.TimeSpan
function TimeSpan:Duration() end

---@param value System.Object
---@return System.Boolean
function TimeSpan:Equals(value) end

---@param obj System.TimeSpan
---@return System.Boolean
function TimeSpan:Equals(obj) end

---@return int32
function TimeSpan:GetHashCode() end

---@return System.TimeSpan
function TimeSpan:Negate() end

---@param ts System.TimeSpan
---@return System.TimeSpan
function TimeSpan:Subtract(ts) end

---@return string
function TimeSpan:ToString() end

---@param format string
---@return string
function TimeSpan:ToString(format) end

---@param format string
---@param formatProvider System.IFormatProvider
---@return string
function TimeSpan:ToString(format,formatProvider) end

---@param t1 System.TimeSpan
---@param t2 System.TimeSpan
---@return int32
function TimeSpan.Compare(t1,t2) end

---@param value number
---@return System.TimeSpan
function TimeSpan.FromDays(value) end

---@param t1 System.TimeSpan
---@param t2 System.TimeSpan
---@return System.Boolean
function TimeSpan.Equals(t1,t2) end

---@param value number
---@return System.TimeSpan
function TimeSpan.FromHours(value) end

---@param value number
---@return System.TimeSpan
function TimeSpan.FromMilliseconds(value) end

---@param value number
---@return System.TimeSpan
function TimeSpan.FromMinutes(value) end

---@param value number
---@return System.TimeSpan
function TimeSpan.FromSeconds(value) end

---@param value int64
---@return System.TimeSpan
function TimeSpan.FromTicks(value) end

---@param s string
---@return System.TimeSpan
function TimeSpan.Parse(s) end

---@param input string
---@param formatProvider System.IFormatProvider
---@return System.TimeSpan
function TimeSpan.Parse(input,formatProvider) end

---@param input string
---@param format string
---@param formatProvider System.IFormatProvider
---@return System.TimeSpan
function TimeSpan.ParseExact(input,format,formatProvider) end

---@param input string
---@param formats System.String[]
---@param formatProvider System.IFormatProvider
---@return System.TimeSpan
function TimeSpan.ParseExact(input,formats,formatProvider) end

---@param input string
---@param format string
---@param formatProvider System.IFormatProvider
---@param styles System.Globalization.TimeSpanStyles
---@return System.TimeSpan
function TimeSpan.ParseExact(input,format,formatProvider,styles) end

---@param input string
---@param formats System.String[]
---@param formatProvider System.IFormatProvider
---@param styles System.Globalization.TimeSpanStyles
---@return System.TimeSpan
function TimeSpan.ParseExact(input,formats,formatProvider,styles) end

---@param s string
---@return System.Boolean
function TimeSpan.TryParse(s) end

---@param input string
---@param formatProvider System.IFormatProvider
---@return System.Boolean
function TimeSpan.TryParse(input,formatProvider) end

---@param input string
---@param format string
---@param formatProvider System.IFormatProvider
---@return System.Boolean
function TimeSpan.TryParseExact(input,format,formatProvider) end

---@param input string
---@param formats System.String[]
---@param formatProvider System.IFormatProvider
---@return System.Boolean
function TimeSpan.TryParseExact(input,formats,formatProvider) end

---@param input string
---@param format string
---@param formatProvider System.IFormatProvider
---@param styles System.Globalization.TimeSpanStyles
---@return System.Boolean
function TimeSpan.TryParseExact(input,format,formatProvider,styles) end

---@param input string
---@param formats System.String[]
---@param formatProvider System.IFormatProvider
---@param styles System.Globalization.TimeSpanStyles
---@return System.Boolean
function TimeSpan.TryParseExact(input,formats,formatProvider,styles) end

return TimeSpan
