---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.DateTime
---@field public Date System.DateTime
---@field public Day int32
---@field public DayOfWeek System.DayOfWeek
---@field public DayOfYear int32
---@field public Hour int32
---@field public Kind System.DateTimeKind
---@field public Millisecond int32
---@field public Minute int32
---@field public Month int32
---@field public Second int32
---@field public Ticks int64
---@field public TimeOfDay System.TimeSpan
---@field public Year int32
---@field static Now System.DateTime
---@field static UtcNow System.DateTime
---@field static Today System.DateTime
---@field static MinValue System.DateTime
---@field static MaxValue System.DateTime
local DateTime = {}

---@param value System.TimeSpan
---@return System.DateTime
function DateTime:Add(value) end

---@param value number
---@return System.DateTime
function DateTime:AddDays(value) end

---@param value number
---@return System.DateTime
function DateTime:AddHours(value) end

---@param value number
---@return System.DateTime
function DateTime:AddMilliseconds(value) end

---@param value number
---@return System.DateTime
function DateTime:AddMinutes(value) end

---@param months int32
---@return System.DateTime
function DateTime:AddMonths(months) end

---@param value number
---@return System.DateTime
function DateTime:AddSeconds(value) end

---@param value int64
---@return System.DateTime
function DateTime:AddTicks(value) end

---@param value int32
---@return System.DateTime
function DateTime:AddYears(value) end

---@param value System.Object
---@return int32
function DateTime:CompareTo(value) end

---@param value System.DateTime
---@return int32
function DateTime:CompareTo(value) end

---@param value System.Object
---@return System.Boolean
function DateTime:Equals(value) end

---@param value System.DateTime
---@return System.Boolean
function DateTime:Equals(value) end

---@return System.Boolean
function DateTime:IsDaylightSavingTime() end

---@return int64
function DateTime:ToBinary() end

---@return int32
function DateTime:GetHashCode() end

---@param value System.DateTime
---@return System.TimeSpan
function DateTime:Subtract(value) end

---@param value System.TimeSpan
---@return System.DateTime
function DateTime:Subtract(value) end

---@return number
function DateTime:ToOADate() end

---@return int64
function DateTime:ToFileTime() end

---@return int64
function DateTime:ToFileTimeUtc() end

---@return System.DateTime
function DateTime:ToLocalTime() end

---@return string
function DateTime:ToLongDateString() end

---@return string
function DateTime:ToLongTimeString() end

---@return string
function DateTime:ToShortDateString() end

---@return string
function DateTime:ToShortTimeString() end

---@return string
function DateTime:ToString() end

---@param format string
---@return string
function DateTime:ToString(format) end

---@param provider System.IFormatProvider
---@return string
function DateTime:ToString(provider) end

---@param format string
---@param provider System.IFormatProvider
---@return string
function DateTime:ToString(format,provider) end

---@return System.DateTime
function DateTime:ToUniversalTime() end

---@return System.String[]
function DateTime:GetDateTimeFormats() end

---@param provider System.IFormatProvider
---@return System.String[]
function DateTime:GetDateTimeFormats(provider) end

---@param format System.Char
---@return System.String[]
function DateTime:GetDateTimeFormats(format) end

---@param format System.Char
---@param provider System.IFormatProvider
---@return System.String[]
function DateTime:GetDateTimeFormats(format,provider) end

---@return System.TypeCode
function DateTime:GetTypeCode() end

---@param t1 System.DateTime
---@param t2 System.DateTime
---@return int32
function DateTime.Compare(t1,t2) end

---@param year int32
---@param month int32
---@return int32
function DateTime.DaysInMonth(year,month) end

---@param t1 System.DateTime
---@param t2 System.DateTime
---@return System.Boolean
function DateTime.Equals(t1,t2) end

---@param dateData int64
---@return System.DateTime
function DateTime.FromBinary(dateData) end

---@param fileTime int64
---@return System.DateTime
function DateTime.FromFileTime(fileTime) end

---@param fileTime int64
---@return System.DateTime
function DateTime.FromFileTimeUtc(fileTime) end

---@param d number
---@return System.DateTime
function DateTime.FromOADate(d) end

---@param value System.DateTime
---@param kind System.DateTimeKind
---@return System.DateTime
function DateTime.SpecifyKind(value,kind) end

---@param year int32
---@return System.Boolean
function DateTime.IsLeapYear(year) end

---@param s string
---@return System.DateTime
function DateTime.Parse(s) end

---@param s string
---@param provider System.IFormatProvider
---@return System.DateTime
function DateTime.Parse(s,provider) end

---@param s string
---@param provider System.IFormatProvider
---@param styles System.Globalization.DateTimeStyles
---@return System.DateTime
function DateTime.Parse(s,provider,styles) end

---@param s string
---@param format string
---@param provider System.IFormatProvider
---@return System.DateTime
function DateTime.ParseExact(s,format,provider) end

---@param s string
---@param format string
---@param provider System.IFormatProvider
---@param style System.Globalization.DateTimeStyles
---@return System.DateTime
function DateTime.ParseExact(s,format,provider,style) end

---@param s string
---@param formats System.String[]
---@param provider System.IFormatProvider
---@param style System.Globalization.DateTimeStyles
---@return System.DateTime
function DateTime.ParseExact(s,formats,provider,style) end

---@param s string
---@return System.Boolean
function DateTime.TryParse(s) end

---@param s string
---@param provider System.IFormatProvider
---@param styles System.Globalization.DateTimeStyles
---@return System.Boolean
function DateTime.TryParse(s,provider,styles) end

---@param s string
---@param format string
---@param provider System.IFormatProvider
---@param style System.Globalization.DateTimeStyles
---@return System.Boolean
function DateTime.TryParseExact(s,format,provider,style) end

---@param s string
---@param formats System.String[]
---@param provider System.IFormatProvider
---@param style System.Globalization.DateTimeStyles
---@return System.Boolean
function DateTime.TryParseExact(s,formats,provider,style) end

return DateTime
