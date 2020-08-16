print("OtherUtils.lua")

---CreatEnumTable 创建枚举table
---@param tbl table 枚举Key值表
---@param index number 起始数字索引,index为null则为字符类型枚举
function _G.CreatEnumTable(tbl, index)
    local enumtbl = {}
    local enumindex = index
    for i, v in pairs(tbl) do
        if (enumindex ~= nil) then
            enumtbl[v] = enumindex + i - 1
        else
            enumtbl[v] = v
        end
    end
    return enumtbl
end