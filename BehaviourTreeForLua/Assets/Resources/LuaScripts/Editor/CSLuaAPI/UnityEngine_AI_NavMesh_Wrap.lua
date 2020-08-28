---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.AI.NavMesh
---@field static avoidancePredictionTime number
---@field static pathfindingIterationsPerFrame int32
---@field static AllAreas int32
---@field static onPreUpdate UnityEngine.AI.NavMesh.OnNavMeshPreUpdate
local NavMesh = {}

---@param sourcePosition UnityEngine.Vector3
---@param targetPosition UnityEngine.Vector3
---@param areaMask int32
---@return System.Boolean
function NavMesh.Raycast(sourcePosition,targetPosition,areaMask) end

---@param sourcePosition UnityEngine.Vector3
---@param targetPosition UnityEngine.Vector3
---@param areaMask int32
---@param path UnityEngine.AI.NavMeshPath
---@return System.Boolean
function NavMesh.CalculatePath(sourcePosition,targetPosition,areaMask,path) end

---@param sourcePosition UnityEngine.Vector3
---@param areaMask int32
---@return System.Boolean
function NavMesh.FindClosestEdge(sourcePosition,areaMask) end

---@param sourcePosition UnityEngine.Vector3
---@param maxDistance number
---@param areaMask int32
---@return System.Boolean
function NavMesh.SamplePosition(sourcePosition,maxDistance,areaMask) end

---@param areaIndex int32
---@param cost number
function NavMesh.SetAreaCost(areaIndex,cost) end

---@param areaIndex int32
---@return number
function NavMesh.GetAreaCost(areaIndex) end

---@param areaName string
---@return int32
function NavMesh.GetAreaFromName(areaName) end

---@return UnityEngine.AI.NavMeshTriangulation
function NavMesh.CalculateTriangulation() end

---@param navMeshData UnityEngine.AI.NavMeshData
---@return UnityEngine.AI.NavMeshDataInstance
function NavMesh.AddNavMeshData(navMeshData) end

---@param navMeshData UnityEngine.AI.NavMeshData
---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
---@return UnityEngine.AI.NavMeshDataInstance
function NavMesh.AddNavMeshData(navMeshData,position,rotation) end

---@param handle UnityEngine.AI.NavMeshDataInstance
function NavMesh.RemoveNavMeshData(handle) end

---@param link UnityEngine.AI.NavMeshLinkData
---@return UnityEngine.AI.NavMeshLinkInstance
function NavMesh.AddLink(link) end

---@param link UnityEngine.AI.NavMeshLinkData
---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
---@return UnityEngine.AI.NavMeshLinkInstance
function NavMesh.AddLink(link,position,rotation) end

---@param handle UnityEngine.AI.NavMeshLinkInstance
function NavMesh.RemoveLink(handle) end

---@param sourcePosition UnityEngine.Vector3
---@param maxDistance number
---@param filter UnityEngine.AI.NavMeshQueryFilter
---@return System.Boolean
function NavMesh.SamplePosition(sourcePosition,maxDistance,filter) end

---@param sourcePosition UnityEngine.Vector3
---@param filter UnityEngine.AI.NavMeshQueryFilter
---@return System.Boolean
function NavMesh.FindClosestEdge(sourcePosition,filter) end

---@param sourcePosition UnityEngine.Vector3
---@param targetPosition UnityEngine.Vector3
---@param filter UnityEngine.AI.NavMeshQueryFilter
---@return System.Boolean
function NavMesh.Raycast(sourcePosition,targetPosition,filter) end

---@param sourcePosition UnityEngine.Vector3
---@param targetPosition UnityEngine.Vector3
---@param filter UnityEngine.AI.NavMeshQueryFilter
---@param path UnityEngine.AI.NavMeshPath
---@return System.Boolean
function NavMesh.CalculatePath(sourcePosition,targetPosition,filter,path) end

---@return UnityEngine.AI.NavMeshBuildSettings
function NavMesh.CreateSettings() end

---@param agentTypeID int32
function NavMesh.RemoveSettings(agentTypeID) end

---@param agentTypeID int32
---@return UnityEngine.AI.NavMeshBuildSettings
function NavMesh.GetSettingsByID(agentTypeID) end

---@return int32
function NavMesh.GetSettingsCount() end

---@param index int32
---@return UnityEngine.AI.NavMeshBuildSettings
function NavMesh.GetSettingsByIndex(index) end

---@param agentTypeID int32
---@return string
function NavMesh.GetSettingsNameFromID(agentTypeID) end

function NavMesh.RemoveAllNavMeshData() end

return NavMesh
