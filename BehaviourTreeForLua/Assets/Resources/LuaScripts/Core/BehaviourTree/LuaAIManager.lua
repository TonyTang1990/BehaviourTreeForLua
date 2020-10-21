-------------------------------------------------------
-- File Name:       LuaAIManager.lua
-- Description:     Lua测的AI管理单例类
-- Author:          TangHuan
-- Create Date:     2020/09/05
-------------------------------------------------------

local Events = require("Events")
local LogUtilities = require("LogUtilities")
local BehaviourTreeUtil = require("BehaviourTreeUtil")

---@class LuaAIManager @Lua测的AI管理单例类
---@field GetInstance fun() : LuaAIManager
---@field CSTBehaviourTreeManager LuaBehaviourTree.TBehaviourTreeManager @CS测的行为树管理单例类
local LuaAIManager = _G.BaseClass("LuaAIManager", _G.Singleton)
LuaAIManager.CSTBehaviourTreeManager = nil

function LuaAIManager:__init()
    self.CSTBehaviourTreeManager = CS.LuaBehaviourTree.TBehaviourTreeManager.Instance
end

--- 响应剧情开播
---@param story Story @开播剧情
function LuaAIManager:OnStartPlayStory(story)
    LogUtilities.Log(_G.EModuleName.BehaviourTreeModule, "AIManager响应剧情开播!")
    self:AbortAll()
    self:PauseAll()
end

--- 暂停所有行为树
function LuaAIManager:PauseAll()
    self.CSTBehaviourTreeManager:PauseAll()
end

--- 继续所有行为树
function LuaAIManager:ResumeAll()
    self.CSTBehaviourTreeManager:ResumeAll()
end

--- 终止所有行为树
function LuaAIManager:AbortAll()
    self.CSTBehaviourTreeManager:AbortAll()
end

---析构函数
function LuaAIManager:Dispose()
    self.CSTBehaviourTreeManager = nil
end

---@return LuaAIManager @Lua测的AI管理单例类
return LuaAIManager