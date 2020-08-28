-------------------------------------------------------
-- File Name:       BTData.lua
-- Description:     行为树数据
-- Author:          TangHuan
-- Create Date:     2020/08/28
-------------------------------------------------------

---@class BTData @行为树数据
---@filed BTLuaScriptRelativePackage string @行为树Lua脚本相对包名
local BTData = {}
BTData.BTLuaScriptRelativePath = "Core.BehaviourTree"

---@type BTData @行为树数据
_G.BTData = BTData

---@return BTData @行为树数据
return _G.BTData