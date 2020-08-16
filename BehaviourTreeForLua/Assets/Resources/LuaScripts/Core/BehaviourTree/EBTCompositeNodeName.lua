print("EBTCompositeNodeName.lua")

---@class EBTCompositeNodeName @行为树组合节点名字
local EBTCompositeNodeNameSource = 
{
    "SelectorNode",
    "SequenceNode",
    "ParalNode",
}

_G.EBTCompositeNodeName = _G.CreatEnumTable(EBTCompositeNodeNameSource)

---@type EBTCompositeNodeName @行为树组合节点名字
return _G.EBTCompositeNodeName