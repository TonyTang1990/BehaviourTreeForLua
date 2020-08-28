---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Transform : UnityEngine.Component
---@field public position UnityEngine.Vector3
---@field public localPosition UnityEngine.Vector3
---@field public eulerAngles UnityEngine.Vector3
---@field public localEulerAngles UnityEngine.Vector3
---@field public right UnityEngine.Vector3
---@field public up UnityEngine.Vector3
---@field public forward UnityEngine.Vector3
---@field public rotation UnityEngine.Quaternion
---@field public localRotation UnityEngine.Quaternion
---@field public localScale UnityEngine.Vector3
---@field public parent UnityEngine.Transform
---@field public worldToLocalMatrix UnityEngine.Matrix4x4
---@field public localToWorldMatrix UnityEngine.Matrix4x4
---@field public root UnityEngine.Transform
---@field public childCount int32
---@field public lossyScale UnityEngine.Vector3
---@field public hasChanged System.Boolean
---@field public hierarchyCapacity int32
---@field public hierarchyCount int32
---@field public position UnityEngine.Vector3
---@field public localPosition UnityEngine.Vector3
---@field public eulerAngles UnityEngine.Vector3
---@field public localEulerAngles UnityEngine.Vector3
---@field public right UnityEngine.Vector3
---@field public up UnityEngine.Vector3
---@field public forward UnityEngine.Vector3
---@field public rotation UnityEngine.Quaternion
---@field public localRotation UnityEngine.Quaternion
---@field public localScale UnityEngine.Vector3
---@field public parent UnityEngine.Transform
---@field public worldToLocalMatrix UnityEngine.Matrix4x4
---@field public localToWorldMatrix UnityEngine.Matrix4x4
---@field public root UnityEngine.Transform
---@field public childCount int32
---@field public lossyScale UnityEngine.Vector3
---@field public hasChanged System.Boolean
---@field public hierarchyCapacity int32
---@field public hierarchyCount int32
local Transform = {}

---@param p UnityEngine.Transform
function Transform:SetParent(p) end

---@param parent UnityEngine.Transform
---@param worldPositionStays System.Boolean
function Transform:SetParent(parent,worldPositionStays) end

---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
function Transform:SetPositionAndRotation(position,rotation) end

---@param translation UnityEngine.Vector3
---@param relativeTo UnityEngine.Space
function Transform:Translate(translation,relativeTo) end

---@param translation UnityEngine.Vector3
function Transform:Translate(translation) end

---@param x number
---@param y number
---@param z number
---@param relativeTo UnityEngine.Space
function Transform:Translate(x,y,z,relativeTo) end

---@param x number
---@param y number
---@param z number
function Transform:Translate(x,y,z) end

---@param translation UnityEngine.Vector3
---@param relativeTo UnityEngine.Transform
function Transform:Translate(translation,relativeTo) end

---@param x number
---@param y number
---@param z number
---@param relativeTo UnityEngine.Transform
function Transform:Translate(x,y,z,relativeTo) end

---@param eulers UnityEngine.Vector3
---@param relativeTo UnityEngine.Space
function Transform:Rotate(eulers,relativeTo) end

---@param eulers UnityEngine.Vector3
function Transform:Rotate(eulers) end

---@param xAngle number
---@param yAngle number
---@param zAngle number
---@param relativeTo UnityEngine.Space
function Transform:Rotate(xAngle,yAngle,zAngle,relativeTo) end

---@param xAngle number
---@param yAngle number
---@param zAngle number
function Transform:Rotate(xAngle,yAngle,zAngle) end

---@param axis UnityEngine.Vector3
---@param angle number
---@param relativeTo UnityEngine.Space
function Transform:Rotate(axis,angle,relativeTo) end

---@param axis UnityEngine.Vector3
---@param angle number
function Transform:Rotate(axis,angle) end

---@param point UnityEngine.Vector3
---@param axis UnityEngine.Vector3
---@param angle number
function Transform:RotateAround(point,axis,angle) end

---@param target UnityEngine.Transform
---@param worldUp UnityEngine.Vector3
function Transform:LookAt(target,worldUp) end

---@param target UnityEngine.Transform
function Transform:LookAt(target) end

---@param worldPosition UnityEngine.Vector3
---@param worldUp UnityEngine.Vector3
function Transform:LookAt(worldPosition,worldUp) end

---@param worldPosition UnityEngine.Vector3
function Transform:LookAt(worldPosition) end

---@param direction UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:TransformDirection(direction) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:TransformDirection(x,y,z) end

---@param direction UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:InverseTransformDirection(direction) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:InverseTransformDirection(x,y,z) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:TransformVector(vector) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:TransformVector(x,y,z) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:InverseTransformVector(vector) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:InverseTransformVector(x,y,z) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:TransformPoint(position) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:TransformPoint(x,y,z) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:InverseTransformPoint(position) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:InverseTransformPoint(x,y,z) end

function Transform:DetachChildren() end

function Transform:SetAsFirstSibling() end

function Transform:SetAsLastSibling() end

---@param index int32
function Transform:SetSiblingIndex(index) end

---@return int32
function Transform:GetSiblingIndex() end

---@param n string
---@return UnityEngine.Transform
function Transform:Find(n) end

---@param parent UnityEngine.Transform
---@return System.Boolean
function Transform:IsChildOf(parent) end

---@return System.Collections.IEnumerator
function Transform:GetEnumerator() end

---@param index int32
---@return UnityEngine.Transform
function Transform:GetChild(index) end

---@param p UnityEngine.Transform
function Transform:SetParent(p) end

---@param parent UnityEngine.Transform
---@param worldPositionStays System.Boolean
function Transform:SetParent(parent,worldPositionStays) end

---@param position UnityEngine.Vector3
---@param rotation UnityEngine.Quaternion
function Transform:SetPositionAndRotation(position,rotation) end

---@param translation UnityEngine.Vector3
---@param relativeTo UnityEngine.Space
function Transform:Translate(translation,relativeTo) end

---@param translation UnityEngine.Vector3
function Transform:Translate(translation) end

---@param x number
---@param y number
---@param z number
---@param relativeTo UnityEngine.Space
function Transform:Translate(x,y,z,relativeTo) end

---@param x number
---@param y number
---@param z number
function Transform:Translate(x,y,z) end

---@param translation UnityEngine.Vector3
---@param relativeTo UnityEngine.Transform
function Transform:Translate(translation,relativeTo) end

---@param x number
---@param y number
---@param z number
---@param relativeTo UnityEngine.Transform
function Transform:Translate(x,y,z,relativeTo) end

---@param eulers UnityEngine.Vector3
---@param relativeTo UnityEngine.Space
function Transform:Rotate(eulers,relativeTo) end

---@param eulers UnityEngine.Vector3
function Transform:Rotate(eulers) end

---@param xAngle number
---@param yAngle number
---@param zAngle number
---@param relativeTo UnityEngine.Space
function Transform:Rotate(xAngle,yAngle,zAngle,relativeTo) end

---@param xAngle number
---@param yAngle number
---@param zAngle number
function Transform:Rotate(xAngle,yAngle,zAngle) end

---@param axis UnityEngine.Vector3
---@param angle number
---@param relativeTo UnityEngine.Space
function Transform:Rotate(axis,angle,relativeTo) end

---@param axis UnityEngine.Vector3
---@param angle number
function Transform:Rotate(axis,angle) end

---@param point UnityEngine.Vector3
---@param axis UnityEngine.Vector3
---@param angle number
function Transform:RotateAround(point,axis,angle) end

---@param target UnityEngine.Transform
---@param worldUp UnityEngine.Vector3
function Transform:LookAt(target,worldUp) end

---@param target UnityEngine.Transform
function Transform:LookAt(target) end

---@param worldPosition UnityEngine.Vector3
---@param worldUp UnityEngine.Vector3
function Transform:LookAt(worldPosition,worldUp) end

---@param worldPosition UnityEngine.Vector3
function Transform:LookAt(worldPosition) end

---@param direction UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:TransformDirection(direction) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:TransformDirection(x,y,z) end

---@param direction UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:InverseTransformDirection(direction) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:InverseTransformDirection(x,y,z) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:TransformVector(vector) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:TransformVector(x,y,z) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:InverseTransformVector(vector) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:InverseTransformVector(x,y,z) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:TransformPoint(position) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:TransformPoint(x,y,z) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Transform:InverseTransformPoint(position) end

---@param x number
---@param y number
---@param z number
---@return UnityEngine.Vector3
function Transform:InverseTransformPoint(x,y,z) end

function Transform:DetachChildren() end

function Transform:SetAsFirstSibling() end

function Transform:SetAsLastSibling() end

---@param index int32
function Transform:SetSiblingIndex(index) end

---@return int32
function Transform:GetSiblingIndex() end

---@param n string
---@return UnityEngine.Transform
function Transform:Find(n) end

---@param parent UnityEngine.Transform
---@return System.Boolean
function Transform:IsChildOf(parent) end

---@return System.Collections.IEnumerator
function Transform:GetEnumerator() end

---@param index int32
---@return UnityEngine.Transform
function Transform:GetChild(index) end

return Transform
