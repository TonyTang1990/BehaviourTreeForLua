---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.ParticleSystem : UnityEngine.Component
---@field public isPlaying System.Boolean
---@field public isEmitting System.Boolean
---@field public isStopped System.Boolean
---@field public isPaused System.Boolean
---@field public particleCount int32
---@field public time number
---@field public randomSeed uint32
---@field public useAutoRandomSeed System.Boolean
---@field public proceduralSimulationSupported System.Boolean
---@field public main UnityEngine.ParticleSystem.MainModule
---@field public emission UnityEngine.ParticleSystem.EmissionModule
---@field public shape UnityEngine.ParticleSystem.ShapeModule
---@field public velocityOverLifetime UnityEngine.ParticleSystem.VelocityOverLifetimeModule
---@field public limitVelocityOverLifetime UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule
---@field public inheritVelocity UnityEngine.ParticleSystem.InheritVelocityModule
---@field public forceOverLifetime UnityEngine.ParticleSystem.ForceOverLifetimeModule
---@field public colorOverLifetime UnityEngine.ParticleSystem.ColorOverLifetimeModule
---@field public colorBySpeed UnityEngine.ParticleSystem.ColorBySpeedModule
---@field public sizeOverLifetime UnityEngine.ParticleSystem.SizeOverLifetimeModule
---@field public sizeBySpeed UnityEngine.ParticleSystem.SizeBySpeedModule
---@field public rotationOverLifetime UnityEngine.ParticleSystem.RotationOverLifetimeModule
---@field public rotationBySpeed UnityEngine.ParticleSystem.RotationBySpeedModule
---@field public externalForces UnityEngine.ParticleSystem.ExternalForcesModule
---@field public noise UnityEngine.ParticleSystem.NoiseModule
---@field public collision UnityEngine.ParticleSystem.CollisionModule
---@field public trigger UnityEngine.ParticleSystem.TriggerModule
---@field public subEmitters UnityEngine.ParticleSystem.SubEmittersModule
---@field public textureSheetAnimation UnityEngine.ParticleSystem.TextureSheetAnimationModule
---@field public lights UnityEngine.ParticleSystem.LightsModule
---@field public trails UnityEngine.ParticleSystem.TrailModule
---@field public customData UnityEngine.ParticleSystem.CustomDataModule
local ParticleSystem = {}

---@param customData System.Collections.Generic.List
---@param streamIndex UnityEngine.ParticleSystemCustomData
function ParticleSystem:SetCustomParticleData(customData,streamIndex) end

---@param customData System.Collections.Generic.List
---@param streamIndex UnityEngine.ParticleSystemCustomData
---@return int32
function ParticleSystem:GetCustomParticleData(customData,streamIndex) end

---@param subEmitterIndex int32
function ParticleSystem:TriggerSubEmitter(subEmitterIndex) end

---@param subEmitterIndex int32
function ParticleSystem:TriggerSubEmitter(subEmitterIndex) end

---@param subEmitterIndex int32
---@param particles System.Collections.Generic.List
function ParticleSystem:TriggerSubEmitter(subEmitterIndex,particles) end

---@param size int32
---@param offset int32
function ParticleSystem:SetParticles(size,offset) end

---@param size int32
function ParticleSystem:SetParticles(size) end

function ParticleSystem:SetParticles() end

---@param size int32
---@param offset int32
---@return int32
function ParticleSystem:GetParticles(size,offset) end

---@param size int32
---@return int32
function ParticleSystem:GetParticles(size) end

---@return int32
function ParticleSystem:GetParticles() end

---@param t number
---@param withChildren System.Boolean
---@param restart System.Boolean
---@param fixedTimeStep System.Boolean
function ParticleSystem:Simulate(t,withChildren,restart,fixedTimeStep) end

---@param t number
---@param withChildren System.Boolean
---@param restart System.Boolean
function ParticleSystem:Simulate(t,withChildren,restart) end

---@param t number
---@param withChildren System.Boolean
function ParticleSystem:Simulate(t,withChildren) end

---@param t number
function ParticleSystem:Simulate(t) end

---@param withChildren System.Boolean
function ParticleSystem:Play(withChildren) end

function ParticleSystem:Play() end

---@param withChildren System.Boolean
function ParticleSystem:Pause(withChildren) end

function ParticleSystem:Pause() end

---@param withChildren System.Boolean
---@param stopBehavior UnityEngine.ParticleSystemStopBehavior
function ParticleSystem:Stop(withChildren,stopBehavior) end

---@param withChildren System.Boolean
function ParticleSystem:Stop(withChildren) end

function ParticleSystem:Stop() end

---@param withChildren System.Boolean
function ParticleSystem:Clear(withChildren) end

function ParticleSystem:Clear() end

---@param withChildren System.Boolean
---@return System.Boolean
function ParticleSystem:IsAlive(withChildren) end

---@return System.Boolean
function ParticleSystem:IsAlive() end

---@param count int32
function ParticleSystem:Emit(count) end

---@param emitParams UnityEngine.ParticleSystem.EmitParams
---@param count int32
function ParticleSystem:Emit(emitParams,count) end

function ParticleSystem.ResetPreMappedBufferMemory() end

return ParticleSystem
