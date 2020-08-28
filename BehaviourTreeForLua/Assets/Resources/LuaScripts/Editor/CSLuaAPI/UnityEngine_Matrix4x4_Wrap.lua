---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Matrix4x4
---@field public rotation UnityEngine.Quaternion
---@field public lossyScale UnityEngine.Vector3
---@field public isIdentity System.Boolean
---@field public determinant number
---@field public decomposeProjection UnityEngine.FrustumPlanes
---@field public inverse UnityEngine.Matrix4x4
---@field public transpose UnityEngine.Matrix4x4
---@field public Item number
---@field public Item number
---@field public m00 number
---@field public m10 number
---@field public m20 number
---@field public m30 number
---@field public m01 number
---@field public m11 number
---@field public m21 number
---@field public m31 number
---@field public m02 number
---@field public m12 number
---@field public m22 number
---@field public m32 number
---@field public m03 number
---@field public m13 number
---@field public m23 number
---@field public m33 number
---@field static zero UnityEngine.Matrix4x4
---@field static identity UnityEngine.Matrix4x4
local Matrix4x4 = {}

---@return System.Boolean
function Matrix4x4:ValidTRS() end

---@param pos UnityEngine.Vector3
---@param q UnityEngine.Quaternion
---@param s UnityEngine.Vector3
function Matrix4x4:SetTRS(pos,q,s) end

---@return int32
function Matrix4x4:GetHashCode() end

---@param other System.Object
---@return System.Boolean
function Matrix4x4:Equals(other) end

---@param other UnityEngine.Matrix4x4
---@return System.Boolean
function Matrix4x4:Equals(other) end

---@param index int32
---@return UnityEngine.Vector4
function Matrix4x4:GetColumn(index) end

---@param index int32
---@return UnityEngine.Vector4
function Matrix4x4:GetRow(index) end

---@param index int32
---@param column UnityEngine.Vector4
function Matrix4x4:SetColumn(index,column) end

---@param index int32
---@param row UnityEngine.Vector4
function Matrix4x4:SetRow(index,row) end

---@param point UnityEngine.Vector3
---@return UnityEngine.Vector3
function Matrix4x4:MultiplyPoint(point) end

---@param point UnityEngine.Vector3
---@return UnityEngine.Vector3
function Matrix4x4:MultiplyPoint3x4(point) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Vector3
function Matrix4x4:MultiplyVector(vector) end

---@param plane UnityEngine.Plane
---@return UnityEngine.Plane
function Matrix4x4:TransformPlane(plane) end

---@return string
function Matrix4x4:ToString() end

---@param format string
---@return string
function Matrix4x4:ToString(format) end

---@param m UnityEngine.Matrix4x4
---@return number
function Matrix4x4.Determinant(m) end

---@param pos UnityEngine.Vector3
---@param q UnityEngine.Quaternion
---@param s UnityEngine.Vector3
---@return UnityEngine.Matrix4x4
function Matrix4x4.TRS(pos,q,s) end

---@param m UnityEngine.Matrix4x4
---@return UnityEngine.Matrix4x4
function Matrix4x4.Inverse(m) end

---@param m UnityEngine.Matrix4x4
---@return UnityEngine.Matrix4x4
function Matrix4x4.Transpose(m) end

---@param left number
---@param right number
---@param bottom number
---@param top number
---@param zNear number
---@param zFar number
---@return UnityEngine.Matrix4x4
function Matrix4x4.Ortho(left,right,bottom,top,zNear,zFar) end

---@param fov number
---@param aspect number
---@param zNear number
---@param zFar number
---@return UnityEngine.Matrix4x4
function Matrix4x4.Perspective(fov,aspect,zNear,zFar) end

---@param from UnityEngine.Vector3
---@param to UnityEngine.Vector3
---@param up UnityEngine.Vector3
---@return UnityEngine.Matrix4x4
function Matrix4x4.LookAt(from,to,up) end

---@param left number
---@param right number
---@param bottom number
---@param top number
---@param zNear number
---@param zFar number
---@return UnityEngine.Matrix4x4
function Matrix4x4.Frustum(left,right,bottom,top,zNear,zFar) end

---@param fp UnityEngine.FrustumPlanes
---@return UnityEngine.Matrix4x4
function Matrix4x4.Frustum(fp) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Matrix4x4
function Matrix4x4.Scale(vector) end

---@param vector UnityEngine.Vector3
---@return UnityEngine.Matrix4x4
function Matrix4x4.Translate(vector) end

---@param q UnityEngine.Quaternion
---@return UnityEngine.Matrix4x4
function Matrix4x4.Rotate(q) end

return Matrix4x4
