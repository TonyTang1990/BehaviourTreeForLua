print("EBTActionNodeName.lua")

---@class EBTActionNodeName @行为树行为节点名字
local EBTActionNodeNameSource = 
{
    "LogAction",
}

_G.EBTActionNodeName = _G.CreatEnumTable(EBTActionNodeNameSource)

---@type EBTActionNodeName @行为树行为节点名字
return _G.EBTActionNodeName