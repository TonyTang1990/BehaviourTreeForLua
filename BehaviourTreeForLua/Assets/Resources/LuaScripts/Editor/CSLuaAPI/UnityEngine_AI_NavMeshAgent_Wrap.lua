---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.AI.NavMeshAgent : UnityEngine.Behaviour
---@field public destination UnityEngine.Vector3
---@field public stoppingDistance number
---@field public velocity UnityEngine.Vector3
---@field public nextPosition UnityEngine.Vector3
---@field public steeringTarget UnityEngine.Vector3
---@field public desiredVelocity UnityEngine.Vector3
---@field public remainingDistance number
---@field public baseOffset number
---@field public isOnOffMeshLink System.Boolean
---@field public currentOffMeshLinkData UnityEngine.AI.OffMeshLinkData
---@field public nextOffMeshLinkData UnityEngine.AI.OffMeshLinkData
---@field public autoTraverseOffMeshLink System.Boolean
---@field public autoBraking System.Boolean
---@field public autoRepath System.Boolean
---@field public hasPath System.Boolean
---@field public pathPending System.Boolean
---@field public isPathStale System.Boolean
---@field public pathStatus UnityEngine.AI.NavMeshPathStatus
---@field public pathEndPosition UnityEngine.Vector3
---@field public isStopped System.Boolean
---@field public path UnityEngine.AI.NavMeshPath
---@field public navMeshOwner UnityEngine.Object
---@field public agentTypeID int32
---@field public areaMask int32
---@field public speed number
---@field public angularSpeed number
---@field public acceleration number
---@field public updatePosition System.Boolean
---@field public updateRotation System.Boolean
---@field public updateUpAxis System.Boolean
---@field public radius number
---@field public height number
---@field public obstacleAvoidanceType UnityEngine.AI.ObstacleAvoidanceType
---@field public avoidancePriority int32
---@field public isOnNavMesh System.Boolean
local NavMeshAgent = {}

---@param target UnityEngine.Vector3
---@return System.Boolean
function NavMeshAgent:SetDestination(target) end

---@param activated System.Boolean
function NavMeshAgent:ActivateCurrentOffMeshLink(activated) end

function NavMeshAgent:CompleteOffMeshLink() end

---@param newPosition UnityEngine.Vector3
---@return System.Boolean
function NavMeshAgent:Warp(newPosition) end

---@param offset UnityEngine.Vector3
function NavMeshAgent:Move(offset) end

function NavMeshAgent:ResetPath() end

---@param path UnityEngine.AI.NavMeshPath
---@return System.Boolean
function NavMeshAgent:SetPath(path) end

---@return System.Boolean
function NavMeshAgent:FindClosestEdge() end

---@param targetPosition UnityEngine.Vector3
---@return System.Boolean
function NavMeshAgent:Raycast(targetPosition) end

---@param targetPosition UnityEngine.Vector3
---@param path UnityEngine.AI.NavMeshPath
---@return System.Boolean
function NavMeshAgent:CalculatePath(targetPosition,path) end

---@param areaMask int32
---@param maxDistance number
---@return System.Boolean
function NavMeshAgent:SamplePathPosition(areaMask,maxDistance) end

---@param areaIndex int32
---@param areaCost number
function NavMeshAgent:SetAreaCost(areaIndex,areaCost) end

---@param areaIndex int32
---@return number
function NavMeshAgent:GetAreaCost(areaIndex) end

return NavMeshAgent
