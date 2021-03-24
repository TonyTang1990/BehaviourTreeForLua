print("BehaviourTreeUtil.lua")

local ObjectPool = require("Core.Pool.ObjectPool")

---@class BehaviourTreeUtil @行为树工具类
local BehaviourTreeUtil = BaseClass("BehaviourTreeUtil")

--- 创建Lua测行为树节点
---@param btnode LuaBehaviourTree.BTNode @CS测的行为树对应的节点
---@param instanceid number @实例对象ID
---@return number @Lua行为节点UID
function BehaviourTreeUtil.LuaCreateLuaBTnode(btnode, instanceid)
    print("创建Lua节点!")
    print(btnode.NodeName)
    print(btnode.UID)
    local luabtnodecls = require(string.format("Core.BehaviourTree.%s", btnode.NodeName))
    ---@type LuaBTNode
    local luabtnodeinstance = ObjectPool:GetInstance():Pop(luabtnodecls, btnode, instanceid)
    --- 为了避免LuaBTNode传到CS测，绑定放在Lua测，解绑放在了CS测
    BehaviourTreeUtil.BindLuaBTNodeCall(luabtnodeinstance)
    return luabtnodeinstance.UID
end

--- 释放Lua测行为节点(Lua测调用)
---@param luabtnode LuaBTNode @Lua测行为树节点
function BehaviourTreeUtil.LuaReleaseLuaBTnode(luabtnode)
    print("释放Lua节点!")
    print(luabtnode.UID)
    ObjectPool:GetInstance():Push(luabtnode)
end

--- 行为树委托回调绑定Map
local BehaviourTreeCallMap = {}

--- 绑定Lua行为树节点委托回调(Lua测调用)
---@param luabtnode LuaBTNode @需要绑定的Lua行为树节点
function BehaviourTreeUtil.BindLuaBTNodeCall(luabtnode)
    print(string.format("绑定Lua行为树节点UID:%s委托回调!", luabtnode.UID))
    if BehaviourTreeCallMap[luabtnode.InstanceID] == nil then
        BehaviourTreeCallMap[luabtnode.InstanceID] = {}
    end
    BehaviourTreeCallMap[luabtnode.InstanceID][luabtnode.UID] = luabtnode
end

--- 解除Lua行为树节点委托回调绑定
---@param instanceid number @实例对象ID
---@param luabtnodeuid number @Lue行为树节点UID
function BehaviourTreeUtil.UnbindLuaBTNodeCall(instanceid, luabtnodeuid)
    print(string.format("解除Lua行为树节点UID:%s委托回调绑定!", luabtnodeuid))
    local luabtnode = BehaviourTreeCallMap[instanceid][luabtnodeuid]
    BehaviourTreeCallMap[instanceid][luabtnodeuid] = nil
    ---解绑的那一刻就是不再使用的那一刻，进池
    BehaviourTreeUtil.LuaReleaseLuaBTnode(luabtnode)
end

--- 清除空table(为了避免InstanceID做Key导致的table数量不断增长，在切场景等适当时机做清理)
function BehaviourTreeUtil.ClearEmptyCBTable()
    for instanceid, instanceidtable in pairs(BehaviourTreeCallMap) do
        if table.count(instanceidtable) == 0 then
            BehaviourTreeCallMap[instanceid] = nil
        end
    end
end

--- 行为树节点暂停统一回调绑定
---@param instanceid number @实体对象ID
---@param uid number @行为树节点UID
---@param ispause boolean @是否暂停
function BehaviourTreeUtil.OnPause(instanceid, uid, ispause)
    --print(string.format("BehaviourTreeUtil.OnPause(%s)", uid))
    local luabtnode = BehaviourTreeCallMap[instanceid][uid]
    assert(luabtnode, "OnPause() LuaBTNode 对应对象为nil ")
    luabtnode:OnPause(ispause)
end

--- 行为树节点重置统一回调绑定
---@param instanceid number @实体对象ID
---@param uid number @行为树节点UID
function BehaviourTreeUtil.Reset(instanceid, uid)
    --print(string.format("BehaviourTreeUtil.Reset(%s)", uid))
    local luabtnode = BehaviourTreeCallMap[instanceid][uid]
    assert(luabtnode, "Reset() LuaBTNode 对应对象为nil ")
    luabtnode:Reset()
end

--- 行为树节点进入统一回调绑定
---@param instanceid number @实体对象ID
---@param uid number @行为树节点UID
---@param scrollindexvalue number @当前滚动到的行为树节点索引值
function BehaviourTreeUtil.OnEnter(instanceid, uid)
    --print(string.format("BehaviourTreeUtil.OnEnter(%s)", uid))
    local luabtnode = BehaviourTreeCallMap[instanceid][uid]
    assert(luabtnode, "OnEnter() LuaBTNode 对应对象为nil ")
    luabtnode:OnEnter()
end

--- 行为树节点执行统一回调绑定
---@param instanceid number @实体对象ID
---@param uid number @行为树节点UID
---@return EBTNodeRunningState @执行结果状态
function BehaviourTreeUtil.OnExecute(instanceid, uid)
    --print(string.format("BehaviourTreeUtil.OnExecute(%s)", uid))
    local luabtnode = BehaviourTreeCallMap[instanceid][uid]
    assert(luabtnode, "OnExecute() LuaBTNode 对应对象为nil ")
    return luabtnode:OnExecute()
end

--- 行为树节点退出统一回调绑定
---@param instanceid number @实体对象ID
---@param uid number @行为树节点UID
function BehaviourTreeUtil.OnExit(instanceid, uid)
    --print(string.format("BehaviourTreeUtil.OnExit(%s)", uid))
    local luabtnode = BehaviourTreeCallMap[instanceid][uid]
    assert(luabtnode, "OnExit() LuaBTNode 对应对象为nil ")
    luabtnode:OnExit()
end

--- 行为树节点释放统一回调绑定
---@param instanceid number @实体对象ID
---@param uid number @行为树节点UID
function BehaviourTreeUtil.Dispose(instanceid, uid)
    --printstring.format("BehaviourTreeUtil.Dispose(%s)", uid))
    local luabtnode = BehaviourTreeCallMap[instanceid][uid]
    assert(luabtnode, "Dispose() LuaBTNode 对应对象为nil ")
    luabtnode:Dispose()
end

--- 打印当前绑定的所有行为树节点信息
function BehaviourTreeUtil.PrintAllBindLuaBTNodeInfo()
    print("BehaviourTreeUtil.PrintAllBindLuaCellInfo()")
    for instanceid, luabtnodetable in pairs(BehaviourTreeCallMap) do
        if luabtnodetable ~= nil then
            for uid, luabtnode in pairs(luabtnodetable) do
                print(string.format("当前绑定的Lua行为树节点InstanceID:%s UID:%s", luabtnode.InstanceID, luabtnode.UID))
            end
        end
    end
end

CS.LuaBehaviourTree.TBehaviourTreeManager.LuaCreateLuaBTnode = BehaviourTreeUtil.LuaCreateLuaBTnode
---释放时机改到解绑Lua节点时
---CS.LuaBehaviourTree.TBehaviourTreeManager.LuaReleaseLuaBTnode = BehaviourTreeUtil.LuaReleaseLuaBTnode
---绑定改到Lua测了，不需要在
---CS.LuaBehaviourTree.TBehaviourTreeManager.BindLuaBTNodeCall = BehaviourTreeUtil.BindLuaBTNodeCall
CS.LuaBehaviourTree.TBehaviourTreeManager.UnbindLuaBTNodeCall = BehaviourTreeUtil.UnbindLuaBTNodeCall

CS.LuaBehaviourTree.BTNode.LuaOnPause = BehaviourTreeUtil.OnPause
CS.LuaBehaviourTree.BTNode.LuaReset = BehaviourTreeUtil.Reset
CS.LuaBehaviourTree.BTNode.LuaOnEnter = BehaviourTreeUtil.OnEnter
CS.LuaBehaviourTree.BTNode.LuaOnExecute = BehaviourTreeUtil.OnExecute
CS.LuaBehaviourTree.BTNode.LuaOnExit = BehaviourTreeUtil.OnExit
CS.LuaBehaviourTree.BTNode.LuaDispose = BehaviourTreeUtil.Dispose

---@type BehaviourTreeUtil @行为树工具类
_G.BehaviourTreeUtil = BehaviourTreeUtil

---@return BehaviourTreeUtil
return _G.BehaviourTreeUtil