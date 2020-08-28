---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.Array
---@field public LongLength int64
---@field public IsFixedSize System.Boolean
---@field public IsReadOnly System.Boolean
---@field public IsSynchronized System.Boolean
---@field public SyncRoot System.Object
---@field public Length int32
---@field public Rank int32
local Array = {}

---@param array System.Array
---@param index int32
function Array:CopyTo(array,index) end

---@return System.Object
function Array:Clone() end

---@param array System.Array
---@param index int64
function Array:CopyTo(array,index) end

---@param dimension int32
---@return int64
function Array:GetLongLength(dimension) end

---@param index int64
---@return System.Object
function Array:GetValue(index) end

---@param index1 int64
---@param index2 int64
---@return System.Object
function Array:GetValue(index1,index2) end

---@param index1 int64
---@param index2 int64
---@param index3 int64
---@return System.Object
function Array:GetValue(index1,index2,index3) end

---@param indices System.Int64[]
---@return System.Object
function Array:GetValue(indices) end

---@param value System.Object
---@param index int64
function Array:SetValue(value,index) end

---@param value System.Object
---@param index1 int64
---@param index2 int64
function Array:SetValue(value,index1,index2) end

---@param value System.Object
---@param index1 int64
---@param index2 int64
---@param index3 int64
function Array:SetValue(value,index1,index2,index3) end

---@param value System.Object
---@param indices System.Int64[]
function Array:SetValue(value,indices) end

---@return System.Collections.IEnumerator
function Array:GetEnumerator() end

---@param dimension int32
---@return int32
function Array:GetLength(dimension) end

---@param dimension int32
---@return int32
function Array:GetLowerBound(dimension) end

---@param indices System.Int32[]
---@return System.Object
function Array:GetValue(indices) end

---@param value System.Object
---@param indices System.Int32[]
function Array:SetValue(value,indices) end

---@param dimension int32
---@return int32
function Array:GetUpperBound(dimension) end

---@param index int32
---@return System.Object
function Array:GetValue(index) end

---@param index1 int32
---@param index2 int32
---@return System.Object
function Array:GetValue(index1,index2) end

---@param index1 int32
---@param index2 int32
---@param index3 int32
---@return System.Object
function Array:GetValue(index1,index2,index3) end

---@param value System.Object
---@param index int32
function Array:SetValue(value,index) end

---@param value System.Object
---@param index1 int32
---@param index2 int32
function Array:SetValue(value,index1,index2) end

---@param value System.Object
---@param index1 int32
---@param index2 int32
---@param index3 int32
function Array:SetValue(value,index1,index2,index3) end

function Array:Initialize() end

---@param elementType System.Type
---@param lengths System.Int64[]
---@return System.Array
function Array.CreateInstance(elementType,lengths) end

---@param array System.Array
---@param value System.Object
---@return int32
function Array.BinarySearch(array,value) end

---@param sourceArray System.Array
---@param destinationArray System.Array
---@param length int64
function Array.Copy(sourceArray,destinationArray,length) end

---@param sourceArray System.Array
---@param sourceIndex int64
---@param destinationArray System.Array
---@param destinationIndex int64
---@param length int64
function Array.Copy(sourceArray,sourceIndex,destinationArray,destinationIndex,length) end

---@param array System.Array
---@param index int32
---@param length int32
---@param value System.Object
---@return int32
function Array.BinarySearch(array,index,length,value) end

---@param array System.Array
---@param value System.Object
---@param comparer System.Collections.IComparer
---@return int32
function Array.BinarySearch(array,value,comparer) end

---@param array System.Array
---@param index int32
---@param length int32
---@param value System.Object
---@param comparer System.Collections.IComparer
---@return int32
function Array.BinarySearch(array,index,length,value,comparer) end

---@param array System.Array
---@param value System.Object
---@return int32
function Array.IndexOf(array,value) end

---@param array System.Array
---@param value System.Object
---@param startIndex int32
---@return int32
function Array.IndexOf(array,value,startIndex) end

---@param array System.Array
---@param value System.Object
---@param startIndex int32
---@param count int32
---@return int32
function Array.IndexOf(array,value,startIndex,count) end

---@param array System.Array
---@param value System.Object
---@return int32
function Array.LastIndexOf(array,value) end

---@param array System.Array
---@param value System.Object
---@param startIndex int32
---@return int32
function Array.LastIndexOf(array,value,startIndex) end

---@param array System.Array
---@param value System.Object
---@param startIndex int32
---@param count int32
---@return int32
function Array.LastIndexOf(array,value,startIndex,count) end

---@param array System.Array
function Array.Reverse(array) end

---@param array System.Array
---@param index int32
---@param length int32
function Array.Reverse(array,index,length) end

---@param array System.Array
function Array.Sort(array) end

---@param array System.Array
---@param index int32
---@param length int32
function Array.Sort(array,index,length) end

---@param array System.Array
---@param comparer System.Collections.IComparer
function Array.Sort(array,comparer) end

---@param array System.Array
---@param index int32
---@param length int32
---@param comparer System.Collections.IComparer
function Array.Sort(array,index,length,comparer) end

---@param keys System.Array
---@param items System.Array
function Array.Sort(keys,items) end

---@param keys System.Array
---@param items System.Array
---@param comparer System.Collections.IComparer
function Array.Sort(keys,items,comparer) end

---@param keys System.Array
---@param items System.Array
---@param index int32
---@param length int32
function Array.Sort(keys,items,index,length) end

---@param keys System.Array
---@param items System.Array
---@param index int32
---@param length int32
---@param comparer System.Collections.IComparer
function Array.Sort(keys,items,index,length,comparer) end

---@param elementType System.Type
---@param length int32
---@return System.Array
function Array.CreateInstance(elementType,length) end

---@param elementType System.Type
---@param length1 int32
---@param length2 int32
---@return System.Array
function Array.CreateInstance(elementType,length1,length2) end

---@param elementType System.Type
---@param length1 int32
---@param length2 int32
---@param length3 int32
---@return System.Array
function Array.CreateInstance(elementType,length1,length2,length3) end

---@param elementType System.Type
---@param lengths System.Int32[]
---@return System.Array
function Array.CreateInstance(elementType,lengths) end

---@param elementType System.Type
---@param lengths System.Int32[]
---@param lowerBounds System.Int32[]
---@return System.Array
function Array.CreateInstance(elementType,lengths,lowerBounds) end

---@param array System.Array
---@param index int32
---@param length int32
function Array.Clear(array,index,length) end

---@param sourceArray System.Array
---@param destinationArray System.Array
---@param length int32
function Array.Copy(sourceArray,destinationArray,length) end

---@param sourceArray System.Array
---@param sourceIndex int32
---@param destinationArray System.Array
---@param destinationIndex int32
---@param length int32
function Array.Copy(sourceArray,sourceIndex,destinationArray,destinationIndex,length) end

---@param sourceArray System.Array
---@param sourceIndex int32
---@param destinationArray System.Array
---@param destinationIndex int32
---@param length int32
function Array.ConstrainedCopy(sourceArray,sourceIndex,destinationArray,destinationIndex,length) end

return Array
