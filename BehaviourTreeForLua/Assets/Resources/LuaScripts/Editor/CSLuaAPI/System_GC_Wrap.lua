---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.GC
---@field static MaxGeneration int32
local GC = {}

---@param bytesAllocated int64
function GC.AddMemoryPressure(bytesAllocated) end

---@param bytesAllocated int64
function GC.RemoveMemoryPressure(bytesAllocated) end

---@param generation int32
function GC.Collect(generation) end

---@param obj System.Object
function GC.KeepAlive(obj) end

function GC.WaitForPendingFinalizers() end

---@param forceFullCollection System.Boolean
---@return int64
function GC.GetTotalMemory(forceFullCollection) end

---@param maxGenerationThreshold int32
---@param largeObjectHeapThreshold int32
function GC.RegisterForFullGCNotification(maxGenerationThreshold,largeObjectHeapThreshold) end

function GC.CancelFullGCNotification() end

---@return System.GCNotificationStatus
function GC.WaitForFullGCApproach() end

---@param millisecondsTimeout int32
---@return System.GCNotificationStatus
function GC.WaitForFullGCApproach(millisecondsTimeout) end

---@return System.GCNotificationStatus
function GC.WaitForFullGCComplete() end

---@param millisecondsTimeout int32
---@return System.GCNotificationStatus
function GC.WaitForFullGCComplete(millisecondsTimeout) end

---@param totalSize int64
---@return System.Boolean
function GC.TryStartNoGCRegion(totalSize) end

---@param totalSize int64
---@param lohSize int64
---@return System.Boolean
function GC.TryStartNoGCRegion(totalSize,lohSize) end

---@param totalSize int64
---@param disallowFullBlockingGC System.Boolean
---@return System.Boolean
function GC.TryStartNoGCRegion(totalSize,disallowFullBlockingGC) end

---@param totalSize int64
---@param lohSize int64
---@param disallowFullBlockingGC System.Boolean
---@return System.Boolean
function GC.TryStartNoGCRegion(totalSize,lohSize,disallowFullBlockingGC) end

function GC.EndNoGCRegion() end

return GC
