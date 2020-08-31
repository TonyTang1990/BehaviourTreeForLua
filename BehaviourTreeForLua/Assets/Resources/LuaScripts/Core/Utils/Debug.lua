-- _G.Debug = { }

-- log的开放等级
_G.eLogLevel = {
    All = 0,
    Debug = 1,
    Info = 2,
    Warning = 3,
    Error = 4,
    Off = 5
}
local CS = _G.CS

---普通级Unity打印
---@param context string 内容
---@param description string 说明
function _G.Log(context, description)
    CS.UnityEngine.Debug.Log(debug.traceback(_G.dump(context, description), 2))
end

---警告级Unity打印
---@param context string 内容
---@param description string 说明
function _G.LogWarning(context, description)
    CS.UnityEngine.Debug.LogWarning(debug.traceback(_G.dump(context, description), 2))
end

---报错级Unity打印
---@param context string 内容
---@param description string 说明
function _G.LogError(context, description)
    CS.UnityEngine.Debug.LogError(debug.traceback(_G.dump(context, description), 2))
end

function _G.LogFatal(context)
    error(context)
end

-- @function  dump()
-- @param value table 内容
-- @param description string 描述
-- @param nesting int 深度
-- @end
function _G.dump(value, description, nesting)
    local _str
    if type(nesting) ~= "number" then
        nesting = 20
    end

    local lookupTable = {}
    local result = {}
    local function _v(v)
        if type(v) == "string" then
            v = '"' .. v .. '"'
        end
        return tostring(v)
    end

    local function _dump(_value, _description, indent, nest, keylen)
        _description = _description or "<var>"
        local spc = ""
        if type(keylen) == "number" then
            spc = string.rep(" ", keylen - string.len(_v(_description)))
        end

        if type(_value) ~= "table" then
            result[#result + 1] = string.format("%s%s%s = %s", indent, _v(_description), spc, _v(_value))
        elseif lookupTable[_value] then
            result[#result + 1] = string.format("%s%s%s = *REF*", indent, _description, spc)
        else
            lookupTable[_value] = true
            if nest > nesting then
                result[#result + 1] = string.format("%s%s = *MAX NESTING*", indent, _description)
            else
                result[#result + 1] = string.format("%s%s = {", indent, _v(_description))
                local indent2 = indent .. "    "
                local keys = {}
                local key_len = 0
                local values = {}
                for k, v in pairs(_value) do
                    keys[#keys + 1] = k
                    local vk = _v(k)
                    local vk1 = string.len(vk)
                    if vk1 > key_len then
                        key_len = vk1
                    end
                    values[k] = v
                end
                table.sort(
                    keys,
                    function(a, b)
                        if type(a) == "number" and type(b) == "number" then
                            return a < b
                        else
                            return tostring(a) < tostring(b)
                        end
                    end
                )

                for _, k in pairs(keys) do
                    _dump(values[k], k, indent2, nest + 1, key_len)
                end
                result[#result + 1] = string.format("%s}", indent)
            end
        end
    end
    _dump(value, description, "- ", 1)
    _str = table.concat(result, "\n")
    return _str
end