---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.Animator : UnityEngine.Behaviour
---@field public isOptimizable System.Boolean
---@field public isHuman System.Boolean
---@field public hasRootMotion System.Boolean
---@field public humanScale number
---@field public isInitialized System.Boolean
---@field public deltaPosition UnityEngine.Vector3
---@field public deltaRotation UnityEngine.Quaternion
---@field public velocity UnityEngine.Vector3
---@field public angularVelocity UnityEngine.Vector3
---@field public rootPosition UnityEngine.Vector3
---@field public rootRotation UnityEngine.Quaternion
---@field public applyRootMotion System.Boolean
---@field public updateMode UnityEngine.AnimatorUpdateMode
---@field public hasTransformHierarchy System.Boolean
---@field public gravityWeight number
---@field public bodyPosition UnityEngine.Vector3
---@field public bodyRotation UnityEngine.Quaternion
---@field public stabilizeFeet System.Boolean
---@field public layerCount int32
---@field public parameters UnityEngine.AnimatorControllerParameter[]
---@field public parameterCount int32
---@field public feetPivotActive number
---@field public pivotWeight number
---@field public pivotPosition UnityEngine.Vector3
---@field public isMatchingTarget System.Boolean
---@field public speed number
---@field public targetPosition UnityEngine.Vector3
---@field public targetRotation UnityEngine.Quaternion
---@field public cullingMode UnityEngine.AnimatorCullingMode
---@field public playbackTime number
---@field public recorderStartTime number
---@field public recorderStopTime number
---@field public recorderMode UnityEngine.AnimatorRecorderMode
---@field public runtimeAnimatorController UnityEngine.RuntimeAnimatorController
---@field public hasBoundPlayables System.Boolean
---@field public avatar UnityEngine.Avatar
---@field public playableGraph UnityEngine.Playables.PlayableGraph
---@field public layersAffectMassCenter System.Boolean
---@field public leftFeetBottomHeight number
---@field public rightFeetBottomHeight number
---@field public logWarnings System.Boolean
---@field public fireEvents System.Boolean
---@field public keepAnimatorControllerStateOnDisable System.Boolean
local Animator = {}

---@param name string
---@return number
function Animator:GetFloat(name) end

---@param id int32
---@return number
function Animator:GetFloat(id) end

---@param name string
---@param value number
function Animator:SetFloat(name,value) end

---@param name string
---@param value number
---@param dampTime number
---@param deltaTime number
function Animator:SetFloat(name,value,dampTime,deltaTime) end

---@param id int32
---@param value number
function Animator:SetFloat(id,value) end

---@param id int32
---@param value number
---@param dampTime number
---@param deltaTime number
function Animator:SetFloat(id,value,dampTime,deltaTime) end

---@param name string
---@return System.Boolean
function Animator:GetBool(name) end

---@param id int32
---@return System.Boolean
function Animator:GetBool(id) end

---@param name string
---@param value System.Boolean
function Animator:SetBool(name,value) end

---@param id int32
---@param value System.Boolean
function Animator:SetBool(id,value) end

---@param name string
---@return int32
function Animator:GetInteger(name) end

---@param id int32
---@return int32
function Animator:GetInteger(id) end

---@param name string
---@param value int32
function Animator:SetInteger(name,value) end

---@param id int32
---@param value int32
function Animator:SetInteger(id,value) end

---@param name string
function Animator:SetTrigger(name) end

---@param id int32
function Animator:SetTrigger(id) end

---@param name string
function Animator:ResetTrigger(name) end

---@param id int32
function Animator:ResetTrigger(id) end

---@param name string
---@return System.Boolean
function Animator:IsParameterControlledByCurve(name) end

---@param id int32
---@return System.Boolean
function Animator:IsParameterControlledByCurve(id) end

---@param goal UnityEngine.AvatarIKGoal
---@return UnityEngine.Vector3
function Animator:GetIKPosition(goal) end

---@param goal UnityEngine.AvatarIKGoal
---@param goalPosition UnityEngine.Vector3
function Animator:SetIKPosition(goal,goalPosition) end

---@param goal UnityEngine.AvatarIKGoal
---@return UnityEngine.Quaternion
function Animator:GetIKRotation(goal) end

---@param goal UnityEngine.AvatarIKGoal
---@param goalRotation UnityEngine.Quaternion
function Animator:SetIKRotation(goal,goalRotation) end

---@param goal UnityEngine.AvatarIKGoal
---@return number
function Animator:GetIKPositionWeight(goal) end

---@param goal UnityEngine.AvatarIKGoal
---@param value number
function Animator:SetIKPositionWeight(goal,value) end

---@param goal UnityEngine.AvatarIKGoal
---@return number
function Animator:GetIKRotationWeight(goal) end

---@param goal UnityEngine.AvatarIKGoal
---@param value number
function Animator:SetIKRotationWeight(goal,value) end

---@param hint UnityEngine.AvatarIKHint
---@return UnityEngine.Vector3
function Animator:GetIKHintPosition(hint) end

---@param hint UnityEngine.AvatarIKHint
---@param hintPosition UnityEngine.Vector3
function Animator:SetIKHintPosition(hint,hintPosition) end

---@param hint UnityEngine.AvatarIKHint
---@return number
function Animator:GetIKHintPositionWeight(hint) end

---@param hint UnityEngine.AvatarIKHint
---@param value number
function Animator:SetIKHintPositionWeight(hint,value) end

---@param lookAtPosition UnityEngine.Vector3
function Animator:SetLookAtPosition(lookAtPosition) end

---@param weight number
function Animator:SetLookAtWeight(weight) end

---@param weight number
---@param bodyWeight number
function Animator:SetLookAtWeight(weight,bodyWeight) end

---@param weight number
---@param bodyWeight number
---@param headWeight number
function Animator:SetLookAtWeight(weight,bodyWeight,headWeight) end

---@param weight number
---@param bodyWeight number
---@param headWeight number
---@param eyesWeight number
function Animator:SetLookAtWeight(weight,bodyWeight,headWeight,eyesWeight) end

---@param weight number
---@param bodyWeight number
---@param headWeight number
---@param eyesWeight number
---@param clampWeight number
function Animator:SetLookAtWeight(weight,bodyWeight,headWeight,eyesWeight,clampWeight) end

---@param humanBoneId UnityEngine.HumanBodyBones
---@param rotation UnityEngine.Quaternion
function Animator:SetBoneLocalRotation(humanBoneId,rotation) end

---@param fullPathHash int32
---@param layerIndex int32
---@return UnityEngine.StateMachineBehaviour[]
function Animator:GetBehaviours(fullPathHash,layerIndex) end

---@param layerIndex int32
---@return string
function Animator:GetLayerName(layerIndex) end

---@param layerName string
---@return int32
function Animator:GetLayerIndex(layerName) end

---@param layerIndex int32
---@return number
function Animator:GetLayerWeight(layerIndex) end

---@param layerIndex int32
---@param weight number
function Animator:SetLayerWeight(layerIndex,weight) end

---@param layerIndex int32
---@return UnityEngine.AnimatorStateInfo
function Animator:GetCurrentAnimatorStateInfo(layerIndex) end

---@param layerIndex int32
---@return UnityEngine.AnimatorStateInfo
function Animator:GetNextAnimatorStateInfo(layerIndex) end

---@param layerIndex int32
---@return UnityEngine.AnimatorTransitionInfo
function Animator:GetAnimatorTransitionInfo(layerIndex) end

---@param layerIndex int32
---@return int32
function Animator:GetCurrentAnimatorClipInfoCount(layerIndex) end

---@param layerIndex int32
---@return int32
function Animator:GetNextAnimatorClipInfoCount(layerIndex) end

---@param layerIndex int32
---@return UnityEngine.AnimatorClipInfo[]
function Animator:GetCurrentAnimatorClipInfo(layerIndex) end

---@param layerIndex int32
---@return UnityEngine.AnimatorClipInfo[]
function Animator:GetNextAnimatorClipInfo(layerIndex) end

---@param layerIndex int32
---@param clips System.Collections.Generic.List
function Animator:GetCurrentAnimatorClipInfo(layerIndex,clips) end

---@param layerIndex int32
---@param clips System.Collections.Generic.List
function Animator:GetNextAnimatorClipInfo(layerIndex,clips) end

---@param layerIndex int32
---@return System.Boolean
function Animator:IsInTransition(layerIndex) end

---@param index int32
---@return UnityEngine.AnimatorControllerParameter
function Animator:GetParameter(index) end

---@param matchPosition UnityEngine.Vector3
---@param matchRotation UnityEngine.Quaternion
---@param targetBodyPart UnityEngine.AvatarTarget
---@param weightMask UnityEngine.MatchTargetWeightMask
---@param startNormalizedTime number
function Animator:MatchTarget(matchPosition,matchRotation,targetBodyPart,weightMask,startNormalizedTime) end

---@param matchPosition UnityEngine.Vector3
---@param matchRotation UnityEngine.Quaternion
---@param targetBodyPart UnityEngine.AvatarTarget
---@param weightMask UnityEngine.MatchTargetWeightMask
---@param startNormalizedTime number
---@param targetNormalizedTime number
function Animator:MatchTarget(matchPosition,matchRotation,targetBodyPart,weightMask,startNormalizedTime,targetNormalizedTime) end

function Animator:InterruptMatchTarget() end

---@param completeMatch System.Boolean
function Animator:InterruptMatchTarget(completeMatch) end

---@param stateName string
---@param fixedTransitionDuration number
function Animator:CrossFadeInFixedTime(stateName,fixedTransitionDuration) end

---@param stateName string
---@param fixedTransitionDuration number
---@param layer int32
function Animator:CrossFadeInFixedTime(stateName,fixedTransitionDuration,layer) end

---@param stateName string
---@param fixedTransitionDuration number
---@param layer int32
---@param fixedTimeOffset number
function Animator:CrossFadeInFixedTime(stateName,fixedTransitionDuration,layer,fixedTimeOffset) end

---@param stateName string
---@param fixedTransitionDuration number
---@param layer int32
---@param fixedTimeOffset number
---@param normalizedTransitionTime number
function Animator:CrossFadeInFixedTime(stateName,fixedTransitionDuration,layer,fixedTimeOffset,normalizedTransitionTime) end

---@param stateHashName int32
---@param fixedTransitionDuration number
---@param layer int32
---@param fixedTimeOffset number
function Animator:CrossFadeInFixedTime(stateHashName,fixedTransitionDuration,layer,fixedTimeOffset) end

---@param stateHashName int32
---@param fixedTransitionDuration number
---@param layer int32
function Animator:CrossFadeInFixedTime(stateHashName,fixedTransitionDuration,layer) end

---@param stateHashName int32
---@param fixedTransitionDuration number
function Animator:CrossFadeInFixedTime(stateHashName,fixedTransitionDuration) end

---@param stateHashName int32
---@param fixedTransitionDuration number
---@param layer int32
---@param fixedTimeOffset number
---@param normalizedTransitionTime number
function Animator:CrossFadeInFixedTime(stateHashName,fixedTransitionDuration,layer,fixedTimeOffset,normalizedTransitionTime) end

function Animator:WriteDefaultValues() end

---@param stateName string
---@param normalizedTransitionDuration number
---@param layer int32
---@param normalizedTimeOffset number
function Animator:CrossFade(stateName,normalizedTransitionDuration,layer,normalizedTimeOffset) end

---@param stateName string
---@param normalizedTransitionDuration number
---@param layer int32
function Animator:CrossFade(stateName,normalizedTransitionDuration,layer) end

---@param stateName string
---@param normalizedTransitionDuration number
function Animator:CrossFade(stateName,normalizedTransitionDuration) end

---@param stateName string
---@param normalizedTransitionDuration number
---@param layer int32
---@param normalizedTimeOffset number
---@param normalizedTransitionTime number
function Animator:CrossFade(stateName,normalizedTransitionDuration,layer,normalizedTimeOffset,normalizedTransitionTime) end

---@param stateHashName int32
---@param normalizedTransitionDuration number
---@param layer int32
---@param normalizedTimeOffset number
---@param normalizedTransitionTime number
function Animator:CrossFade(stateHashName,normalizedTransitionDuration,layer,normalizedTimeOffset,normalizedTransitionTime) end

---@param stateHashName int32
---@param normalizedTransitionDuration number
---@param layer int32
---@param normalizedTimeOffset number
function Animator:CrossFade(stateHashName,normalizedTransitionDuration,layer,normalizedTimeOffset) end

---@param stateHashName int32
---@param normalizedTransitionDuration number
---@param layer int32
function Animator:CrossFade(stateHashName,normalizedTransitionDuration,layer) end

---@param stateHashName int32
---@param normalizedTransitionDuration number
function Animator:CrossFade(stateHashName,normalizedTransitionDuration) end

---@param stateName string
---@param layer int32
function Animator:PlayInFixedTime(stateName,layer) end

---@param stateName string
function Animator:PlayInFixedTime(stateName) end

---@param stateName string
---@param layer int32
---@param fixedTime number
function Animator:PlayInFixedTime(stateName,layer,fixedTime) end

---@param stateNameHash int32
---@param layer int32
---@param fixedTime number
function Animator:PlayInFixedTime(stateNameHash,layer,fixedTime) end

---@param stateNameHash int32
---@param layer int32
function Animator:PlayInFixedTime(stateNameHash,layer) end

---@param stateNameHash int32
function Animator:PlayInFixedTime(stateNameHash) end

---@param stateName string
---@param layer int32
function Animator:Play(stateName,layer) end

---@param stateName string
function Animator:Play(stateName) end

---@param stateName string
---@param layer int32
---@param normalizedTime number
function Animator:Play(stateName,layer,normalizedTime) end

---@param stateNameHash int32
---@param layer int32
---@param normalizedTime number
function Animator:Play(stateNameHash,layer,normalizedTime) end

---@param stateNameHash int32
---@param layer int32
function Animator:Play(stateNameHash,layer) end

---@param stateNameHash int32
function Animator:Play(stateNameHash) end

---@param targetIndex UnityEngine.AvatarTarget
---@param targetNormalizedTime number
function Animator:SetTarget(targetIndex,targetNormalizedTime) end

---@param humanBoneId UnityEngine.HumanBodyBones
---@return UnityEngine.Transform
function Animator:GetBoneTransform(humanBoneId) end

function Animator:StartPlayback() end

function Animator:StopPlayback() end

---@param frameCount int32
function Animator:StartRecording(frameCount) end

function Animator:StopRecording() end

---@param layerIndex int32
---@param stateID int32
---@return System.Boolean
function Animator:HasState(layerIndex,stateID) end

---@param deltaTime number
function Animator:Update(deltaTime) end

function Animator:Rebind() end

function Animator:ApplyBuiltinRootMotion() end

---@param name string
---@return int32
function Animator.StringToHash(name) end

return Animator
