---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.Collections.Generic.List
---@field public Capacity int32
---@field public Count int32
---@field public Item UnityEngine.GameObject
local List`1 = {}

---@param item UnityEngine.GameObject
function List`1:Add(item) end

---@param collection System.Collections.Generic.IEnumerable
function List`1:AddRange(collection) end

---@return System.Collections.ObjectModel.ReadOnlyCollection
function List`1:AsReadOnly() end

---@param index int32
---@param count int32
---@param item UnityEngine.GameObject
---@param comparer System.Collections.Generic.IComparer
---@return int32
function List`1:BinarySearch(index,count,item,comparer) end

---@param item UnityEngine.GameObject
---@return int32
function List`1:BinarySearch(item) end

---@param item UnityEngine.GameObject
---@param comparer System.Collections.Generic.IComparer
---@return int32
function List`1:BinarySearch(item,comparer) end

function List`1:Clear() end

---@param item UnityEngine.GameObject
---@return System.Boolean
function List`1:Contains(item) end

---@param array UnityEngine.GameObject[]
function List`1:CopyTo(array) end

---@param index int32
---@param array UnityEngine.GameObject[]
---@param arrayIndex int32
---@param count int32
function List`1:CopyTo(index,array,arrayIndex,count) end

---@param array UnityEngine.GameObject[]
---@param arrayIndex int32
function List`1:CopyTo(array,arrayIndex) end

---@param match System.Predicate
---@return System.Boolean
function List`1:Exists(match) end

---@param match System.Predicate
---@return UnityEngine.GameObject
function List`1:Find(match) end

---@param match System.Predicate
---@return System.Collections.Generic.List
function List`1:FindAll(match) end

---@param match System.Predicate
---@return int32
function List`1:FindIndex(match) end

---@param startIndex int32
---@param match System.Predicate
---@return int32
function List`1:FindIndex(startIndex,match) end

---@param startIndex int32
---@param count int32
---@param match System.Predicate
---@return int32
function List`1:FindIndex(startIndex,count,match) end

---@param match System.Predicate
---@return UnityEngine.GameObject
function List`1:FindLast(match) end

---@param match System.Predicate
---@return int32
function List`1:FindLastIndex(match) end

---@param startIndex int32
---@param match System.Predicate
---@return int32
function List`1:FindLastIndex(startIndex,match) end

---@param startIndex int32
---@param count int32
---@param match System.Predicate
---@return int32
function List`1:FindLastIndex(startIndex,count,match) end

---@param action System.Action
function List`1:ForEach(action) end

---@return System.Collections.Generic.Enumerat
function List`1:GetEnumerator() end

---@param index int32
---@param count int32
---@return System.Collections.Generic.List
function List`1:GetRange(index,count) end

---@param item UnityEngine.GameObject
---@return int32
function List`1:IndexOf(item) end

---@param item UnityEngine.GameObject
---@param index int32
---@return int32
function List`1:IndexOf(item,index) end

---@param item UnityEngine.GameObject
---@param index int32
---@param count int32
---@return int32
function List`1:IndexOf(item,index,count) end

---@param index int32
---@param item UnityEngine.GameObject
function List`1:Insert(index,item) end

---@param index int32
---@param collection System.Collections.Generic.IEnumerable
function List`1:InsertRange(index,collection) end

---@param item UnityEngine.GameObject
---@return int32
function List`1:LastIndexOf(item) end

---@param item UnityEngine.GameObject
---@param index int32
---@return int32
function List`1:LastIndexOf(item,index) end

---@param item UnityEngine.GameObject
---@param index int32
---@param count int32
---@return int32
function List`1:LastIndexOf(item,index,count) end

---@param item UnityEngine.GameObject
---@return System.Boolean
function List`1:Remove(item) end

---@param match System.Predicate
---@return int32
function List`1:RemoveAll(match) end

---@param index int32
function List`1:RemoveAt(index) end

---@param index int32
---@param count int32
function List`1:RemoveRange(index,count) end

function List`1:Reverse() end

---@param index int32
---@param count int32
function List`1:Reverse(index,count) end

function List`1:Sort() end

---@param comparer System.Collections.Generic.IComparer
function List`1:Sort(comparer) end

---@param index int32
---@param count int32
---@param comparer System.Collections.Generic.IComparer
function List`1:Sort(index,count,comparer) end

---@param comparison System.Comparison
function List`1:Sort(comparison) end

---@return UnityEngine.GameObject[]
function List`1:ToArray() end

function List`1:TrimExcess() end

---@param match System.Predicate
---@return System.Boolean
function List`1:TrueForAll(match) end

return List`1
