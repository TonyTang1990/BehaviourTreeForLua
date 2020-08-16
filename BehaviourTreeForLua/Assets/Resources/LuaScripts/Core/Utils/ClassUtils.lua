-- 包名：        Core.Util.ClassUtils
-- File Name:    ClassUtils.lua
-- Description:    Class工具类
-- Author:       TangHuan
-- Create Date:    2019/12/11

---Note:
---这里的类判定是针对使用BaseClass定义的类

print("ClassUtils.lua")

---@field 打印table详细数据
function print_table ( t )  
    local print_r_cache={}
    local function sub_print_r(t,indent)
        if (print_r_cache[tostring(t)]) then
            print(indent.."*"..tostring(t))
        else
            print_r_cache[tostring(t)]=true
            if (type(t)=="table") then
                for pos,val in pairs(t) do
                    if (type(val)=="table") then
                        print(indent.."["..pos.."] => "..tostring(t).." {")
                        sub_print_r(val,indent..string.rep(" ",string.len(pos)+8))
                        print(indent..string.rep(" ",string.len(pos)+6).."}")
                    elseif (type(val)=="string") then
                        print(indent.."["..pos..'] => "'..val..'"')
                    else
                        print(indent.."["..pos.."] => "..tostring(val))
                    end
                end
            else
                print(indent..tostring(t))
            end
        end
    end
    if (type(t)=="table") then
        print(tostring(t).." {")
        sub_print_r(t,"  ")
        print("}")
    else
        sub_print_r(t,"  ")
    end
    print()
end

---判定是否是指定类或者继承至该类
---@param cls BaseClass @类实例对象或者类定义
---@param cname string | BaseClass @类名或者类定义table
function IsClass(cls, cname)
    --print_table(cls)
    --[[
    Log("IsClassDefinition(cls) = ", IsClassDefinition(cls))
    Log("IsClassInstance(cls) = ", IsClassInstance(cls))
    Log("IsClassSingleton(cls) = ", IsClassSingleton(cls))
    Log("IsClassDefinition(cname) = ", IsClassDefinition(cname))
    Log("IsClassSingleton(cname) = ", IsClassSingleton(cname))
    ]]--
    if not IsClassDefinition(cls) and not IsClassInstance(cls) and not IsClassSingleton(cls) then
        --Log("self:", self, " type(self):", type(self), "无效")
        return false;
    elseif cname == nil or (type(cname) ~= "string" and not IsClassDefinition(cname) and not IsClassSingleton(cname)) then
        --Log("cname:", cname, " type(cname):", type(cname), "无效")
        return false
    end

    --[[
    Log("cls = ", cls)
    Log("cls._class_type = ", cls._class_type)
    Log("cname = ", cname)
    ]]--
    if type(cname) == "table" then
        if cls == cname or cls._class_type == cname then
            return true;
        elseif cls.super then
            return IsClass(cls.super, cname);
        end
    elseif type(cname) == "string" then
        if cls.__cname == cname then
            return true;
        elseif cls.super then
            return IsClass(cls.super, cname);
        end
    end
    return false;
end

---判定是否是指定对象是否是类定义
---@param cls BaseClass @类对象或类定义
function IsClassDefinition(cls)
    if cls ~= nil and type(cls) == "table" and cls.__ctype == ClassType.class and cls._class_type == nil then
        --Log("cls:", cls, " type(cls):", type(cls), "是类定义对象")
        return true;
    else
        --Log("cls:", cls, " type(cls):", type(cls), "不是类定义对象")
        return false
    end
end

---判定是否是指定对象是否是类实例对象(Note: 不含继承至Singleton的单例对象)
---@param instance BaseClass @类实例对象
function IsClassInstance(instance)
    if instance ~= nil and type(instance) == "table" and instance.__ctype == ClassType.instance and instance._class_type["Instance"] ~= instance then
        --Log("instance:", instance, " type(instance):", type(instance), "是类实例对象")
        return true;
    else
        --Log("instance:", instance, " type(instance):", type(instance), "不是类实例对象")
        return false
    end
end

---判定是否是指定对象是否是类单例对象(继承至Singleton的单例对象)
---@param instance BaseClass @类实例对象
function IsClassSingleton(instance)
    if instance ~= nil and type(instance) == "table" and instance.__ctype == ClassType.instance and instance._class_type["Instance"] == instance then
        --Log("instance:", instance, " type(instance):", type(instance), "是类单例对象")
        return true;
    else
        --Log("instance:", instance, " type(instance):", type(instance), "不是类实例对象")
        return false
    end
end

 
---检查传入对象是否为方法
---@return boolean
function IsFunction(fuc)
    if type(fuc) == "function" then
        return true
    else
        return false
    end
end

---检查传入对象是否为数值
---@return boolean
function IsNumber(num)
    if type(num) == "number" then
        return true
    else
        return false
    end
end

---检查传入对象是否为字符串
---@return boolean
function IsString(str)
    if type(str) == "string" then
        return true
    else
        return false
    end
end

---检查传入对象是否为table
---@return boolean
function IsTable(tab)
    if type(tab) == "table" then
        return true
    end
    return false
end
