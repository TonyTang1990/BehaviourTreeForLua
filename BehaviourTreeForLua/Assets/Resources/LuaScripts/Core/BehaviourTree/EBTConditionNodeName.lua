print("EBTConditionNodeName.lua")

---@class EBTConditionNodeName @行为树条件节点名字
local EBTConditionNodeNameSource = 
{
    "ActiveSelfCondition",
}

_G.EBTConditionNodeName = _G.CreatEnumTable(EBTConditionNodeNameSource)

---@type EBTConditionNodeName @行为树条件节点名字
return _G.EBTConditionNodeName