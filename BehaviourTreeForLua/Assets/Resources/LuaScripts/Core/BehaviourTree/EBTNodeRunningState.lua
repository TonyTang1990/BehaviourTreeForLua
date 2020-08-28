-------------------------------------------------------
-- File Name:       EBTNodeRunningState.lua
-- Description:     节点运行状态(同步映射CS那一侧的EBTNodeRunningState)
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class EBTNodeRunningState @节点运行状态(同步映射CS那一侧的EBTNodeRunningState)
---@field Invalide number @无效状态
---@field Running number @运行中
---@field Success number @成功
---@field Failed number @失败
local EBTNodeRunningState =
{
    Invalide = 1,
    Running = 2,
    Success = 3,
    Failed = 4,
}

---@type EBTNodeRunningState @节点运行状态(同步映射CS那一侧的EBTNodeRunningState)
_G.EBTNodeRunningState = EBTNodeRunningState

---@return EBTNodeRunningState @节点运行状态(同步映射CS那一侧的EBTNodeRunningState)
return _G.EBTNodeRunningState