---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Camera : UnityEngine.Behaviour
---@field public nearClipPlane number
---@field public farClipPlane number
---@field public fieldOfView number
---@field public renderingPath UnityEngine.RenderingPath
---@field public actualRenderingPath UnityEngine.RenderingPath
---@field public allowHDR System.Boolean
---@field public allowMSAA System.Boolean
---@field public allowDynamicResolution System.Boolean
---@field public forceIntoRenderTexture System.Boolean
---@field public orthographicSize number
---@field public orthographic System.Boolean
---@field public opaqueSortMode UnityEngine.Rendering.OpaqueSortMode
---@field public transparencySortMode UnityEngine.TransparencySortMode
---@field public transparencySortAxis UnityEngine.Vector3
---@field public depth number
---@field public aspect number
---@field public velocity UnityEngine.Vector3
---@field public cullingMask int32
---@field public eventMask int32
---@field public layerCullSpherical System.Boolean
---@field public cameraType UnityEngine.CameraType
---@field public layerCullDistances System.Single[]
---@field public useOcclusionCulling System.Boolean
---@field public cullingMatrix UnityEngine.Matrix4x4
---@field public backgroundColor UnityEngine.Color
---@field public clearFlags UnityEngine.CameraClearFlags
---@field public depthTextureMode UnityEngine.DepthTextureMode
---@field public clearStencilAfterLightingPass System.Boolean
---@field public usePhysicalProperties System.Boolean
---@field public sensorSize UnityEngine.Vector2
---@field public lensShift UnityEngine.Vector2
---@field public focalLength number
---@field public gateFit UnityEngine.Camera.GateFitMode
---@field public rect UnityEngine.Rect
---@field public pixelRect UnityEngine.Rect
---@field public pixelWidth int32
---@field public pixelHeight int32
---@field public scaledPixelWidth int32
---@field public scaledPixelHeight int32
---@field public targetTexture UnityEngine.RenderTexture
---@field public activeTexture UnityEngine.RenderTexture
---@field public targetDisplay int32
---@field public cameraToWorldMatrix UnityEngine.Matrix4x4
---@field public worldToCameraMatrix UnityEngine.Matrix4x4
---@field public projectionMatrix UnityEngine.Matrix4x4
---@field public nonJitteredProjectionMatrix UnityEngine.Matrix4x4
---@field public useJitteredProjectionMatrixForTransparentRendering System.Boolean
---@field public previousViewProjectionMatrix UnityEngine.Matrix4x4
---@field public scene UnityEngine.SceneManagement.Scene
---@field public stereoEnabled System.Boolean
---@field public stereoSeparation number
---@field public stereoConvergence number
---@field public areVRStereoViewMatricesWithinSingleCullTolerance System.Boolean
---@field public stereoTargetEye UnityEngine.StereoTargetEyeMask
---@field public stereoActiveEye UnityEngine.Camera.MonoOrStereoscopicEye
---@field public commandBufferCount int32
---@field static main UnityEngine.Camera
---@field static current UnityEngine.Camera
---@field static allCamerasCount int32
---@field static allCameras UnityEngine.Camera[]
---@field static onPreCull UnityEngine.Camera.CameraCallback
---@field static onPreRender UnityEngine.Camera.CameraCallback
---@field static onPostRender UnityEngine.Camera.CameraCallback
local Camera = {}

function Camera:Reset() end

function Camera:ResetTransparencySortSettings() end

function Camera:ResetAspect() end

function Camera:ResetCullingMatrix() end

---@param shader UnityEngine.Shader
---@param replacementTag string
function Camera:SetReplacementShader(shader,replacementTag) end

function Camera:ResetReplacementShader() end

---@param colorBuffer UnityEngine.RenderBuffer
---@param depthBuffer UnityEngine.RenderBuffer
function Camera:SetTargetBuffers(colorBuffer,depthBuffer) end

---@param colorBuffer UnityEngine.RenderBuffer[]
---@param depthBuffer UnityEngine.RenderBuffer
function Camera:SetTargetBuffers(colorBuffer,depthBuffer) end

function Camera:ResetWorldToCameraMatrix() end

function Camera:ResetProjectionMatrix() end

---@param clipPlane UnityEngine.Vector4
---@return UnityEngine.Matrix4x4
function Camera:CalculateObliqueMatrix(clipPlane) end

---@param position UnityEngine.Vector3
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@return UnityEngine.Vector3
function Camera:WorldToScreenPoint(position,eye) end

---@param position UnityEngine.Vector3
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@return UnityEngine.Vector3
function Camera:WorldToViewportPoint(position,eye) end

---@param position UnityEngine.Vector3
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@return UnityEngine.Vector3
function Camera:ViewportToWorldPoint(position,eye) end

---@param position UnityEngine.Vector3
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@return UnityEngine.Vector3
function Camera:ScreenToWorldPoint(position,eye) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Camera:WorldToScreenPoint(position) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Camera:WorldToViewportPoint(position) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Camera:ViewportToWorldPoint(position) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Camera:ScreenToWorldPoint(position) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Camera:ScreenToViewportPoint(position) end

---@param position UnityEngine.Vector3
---@return UnityEngine.Vector3
function Camera:ViewportToScreenPoint(position) end

---@param pos UnityEngine.Vector3
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@return UnityEngine.Ray
function Camera:ViewportPointToRay(pos,eye) end

---@param pos UnityEngine.Vector3
---@return UnityEngine.Ray
function Camera:ViewportPointToRay(pos) end

---@param pos UnityEngine.Vector3
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@return UnityEngine.Ray
function Camera:ScreenPointToRay(pos,eye) end

---@param pos UnityEngine.Vector3
---@return UnityEngine.Ray
function Camera:ScreenPointToRay(pos) end

---@param viewport UnityEngine.Rect
---@param z number
---@param eye UnityEngine.Camera.MonoOrStereoscopicEye
---@param outCorners UnityEngine.Vector3[]
function Camera:CalculateFrustumCorners(viewport,z,eye,outCorners) end

---@param eye UnityEngine.Camera.StereoscopicEye
---@return UnityEngine.Matrix4x4
function Camera:GetStereoNonJitteredProjectionMatrix(eye) end

---@param eye UnityEngine.Camera.StereoscopicEye
---@return UnityEngine.Matrix4x4
function Camera:GetStereoViewMatrix(eye) end

---@param eye UnityEngine.Camera.StereoscopicEye
function Camera:CopyStereoDeviceProjectionMatrixToNonJittered(eye) end

---@param eye UnityEngine.Camera.StereoscopicEye
---@return UnityEngine.Matrix4x4
function Camera:GetStereoProjectionMatrix(eye) end

---@param eye UnityEngine.Camera.StereoscopicEye
---@param matrix UnityEngine.Matrix4x4
function Camera:SetStereoProjectionMatrix(eye,matrix) end

function Camera:ResetStereoProjectionMatrices() end

---@param eye UnityEngine.Camera.StereoscopicEye
---@param matrix UnityEngine.Matrix4x4
function Camera:SetStereoViewMatrix(eye,matrix) end

function Camera:ResetStereoViewMatrices() end

---@param cubemap UnityEngine.Cubemap
---@param faceMask int32
---@return System.Boolean
function Camera:RenderToCubemap(cubemap,faceMask) end

---@param cubemap UnityEngine.Cubemap
---@return System.Boolean
function Camera:RenderToCubemap(cubemap) end

---@param cubemap UnityEngine.RenderTexture
---@param faceMask int32
---@return System.Boolean
function Camera:RenderToCubemap(cubemap,faceMask) end

---@param cubemap UnityEngine.RenderTexture
---@return System.Boolean
function Camera:RenderToCubemap(cubemap) end

---@param cubemap UnityEngine.RenderTexture
---@param faceMask int32
---@param stereoEye UnityEngine.Camera.MonoOrStereoscopicEye
---@return System.Boolean
function Camera:RenderToCubemap(cubemap,faceMask,stereoEye) end

function Camera:Render() end

---@param shader UnityEngine.Shader
---@param replacementTag string
function Camera:RenderWithShader(shader,replacementTag) end

function Camera:RenderDontRestore() end

---@param other UnityEngine.Camera
function Camera:CopyFrom(other) end

---@param evt UnityEngine.Rendering.CameraEvent
function Camera:RemoveCommandBuffers(evt) end

function Camera:RemoveAllCommandBuffers() end

---@param evt UnityEngine.Rendering.CameraEvent
---@param buffer UnityEngine.Rendering.CommandBuffer
function Camera:AddCommandBuffer(evt,buffer) end

---@param evt UnityEngine.Rendering.CameraEvent
---@param buffer UnityEngine.Rendering.CommandBuffer
---@param queueType UnityEngine.Rendering.ComputeQueueType
function Camera:AddCommandBufferAsync(evt,buffer,queueType) end

---@param evt UnityEngine.Rendering.CameraEvent
---@param buffer UnityEngine.Rendering.CommandBuffer
function Camera:RemoveCommandBuffer(evt,buffer) end

---@param evt UnityEngine.Rendering.CameraEvent
---@return UnityEngine.Rendering.CommandBuffer[]
function Camera:GetCommandBuffers(evt) end

---@param focalLength number
---@param sensorSize UnityEngine.Vector2
---@param lensShift UnityEngine.Vector2
---@param nearClip number
---@param farClip number
---@param gateFitParameters UnityEngine.Camera.GateFitParameters
function Camera.CalculateProjectionMatrixFromPhysicalProperties(focalLength,sensorSize,lensShift,nearClip,farClip,gateFitParameters) end

---@param focalLength number
---@param sensorSize number
---@return number
function Camera.FocalLengthToFOV(focalLength,sensorSize) end

---@param fov number
---@param sensorSize number
---@return number
function Camera.FOVToFocalLength(fov,sensorSize) end

---@param cameras UnityEngine.Camera[]
---@return int32
function Camera.GetAllCameras(cameras) end

---@param cur UnityEngine.Camera
function Camera.SetupCurrent(cur) end

return Camera
