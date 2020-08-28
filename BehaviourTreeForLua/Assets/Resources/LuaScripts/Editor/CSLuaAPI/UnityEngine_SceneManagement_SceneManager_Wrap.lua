---===================== Author Qcbf 这是自动生成的代码 =====================

---@class UnityEngine.SceneManagement.SceneManager
---@field static sceneCount int32
---@field static sceneCountInBuildSettings int32
local SceneManager = {}

---@return UnityEngine.SceneManagement.Scene
function SceneManager.GetActiveScene() end

---@param scene UnityEngine.SceneManagement.Scene
---@return System.Boolean
function SceneManager.SetActiveScene(scene) end

---@param scenePath string
---@return UnityEngine.SceneManagement.Scene
function SceneManager.GetSceneByPath(scenePath) end

---@param name string
---@return UnityEngine.SceneManagement.Scene
function SceneManager.GetSceneByName(name) end

---@param buildIndex int32
---@return UnityEngine.SceneManagement.Scene
function SceneManager.GetSceneByBuildIndex(buildIndex) end

---@param index int32
---@return UnityEngine.SceneManagement.Scene
function SceneManager.GetSceneAt(index) end

---@param sceneName string
---@param parameters UnityEngine.SceneManagement.CreateSceneParameters
---@return UnityEngine.SceneManagement.Scene
function SceneManager.CreateScene(sceneName,parameters) end

---@param sourceScene UnityEngine.SceneManagement.Scene
---@param destinationScene UnityEngine.SceneManagement.Scene
function SceneManager.MergeScenes(sourceScene,destinationScene) end

---@param go UnityEngine.GameObject
---@param scene UnityEngine.SceneManagement.Scene
function SceneManager.MoveGameObjectToScene(go,scene) end

---@param sceneName string
---@return UnityEngine.SceneManagement.Scene
function SceneManager.CreateScene(sceneName) end

---@param sceneName string
---@param mode UnityEngine.SceneManagement.LoadSceneMode
function SceneManager.LoadScene(sceneName,mode) end

---@param sceneName string
function SceneManager.LoadScene(sceneName) end

---@param sceneName string
---@param parameters UnityEngine.SceneManagement.LoadSceneParameters
---@return UnityEngine.SceneManagement.Scene
function SceneManager.LoadScene(sceneName,parameters) end

---@param sceneBuildIndex int32
---@param mode UnityEngine.SceneManagement.LoadSceneMode
function SceneManager.LoadScene(sceneBuildIndex,mode) end

---@param sceneBuildIndex int32
function SceneManager.LoadScene(sceneBuildIndex) end

---@param sceneBuildIndex int32
---@param parameters UnityEngine.SceneManagement.LoadSceneParameters
---@return UnityEngine.SceneManagement.Scene
function SceneManager.LoadScene(sceneBuildIndex,parameters) end

---@param sceneBuildIndex int32
---@param mode UnityEngine.SceneManagement.LoadSceneMode
---@return UnityEngine.AsyncOperation
function SceneManager.LoadSceneAsync(sceneBuildIndex,mode) end

---@param sceneBuildIndex int32
---@return UnityEngine.AsyncOperation
function SceneManager.LoadSceneAsync(sceneBuildIndex) end

---@param sceneBuildIndex int32
---@param parameters UnityEngine.SceneManagement.LoadSceneParameters
---@return UnityEngine.AsyncOperation
function SceneManager.LoadSceneAsync(sceneBuildIndex,parameters) end

---@param sceneName string
---@param mode UnityEngine.SceneManagement.LoadSceneMode
---@return UnityEngine.AsyncOperation
function SceneManager.LoadSceneAsync(sceneName,mode) end

---@param sceneName string
---@return UnityEngine.AsyncOperation
function SceneManager.LoadSceneAsync(sceneName) end

---@param sceneName string
---@param parameters UnityEngine.SceneManagement.LoadSceneParameters
---@return UnityEngine.AsyncOperation
function SceneManager.LoadSceneAsync(sceneName,parameters) end

---@param sceneBuildIndex int32
---@return UnityEngine.AsyncOperation
function SceneManager.UnloadSceneAsync(sceneBuildIndex) end

---@param sceneName string
---@return UnityEngine.AsyncOperation
function SceneManager.UnloadSceneAsync(sceneName) end

---@param scene UnityEngine.SceneManagement.Scene
---@return UnityEngine.AsyncOperation
function SceneManager.UnloadSceneAsync(scene) end

---@param sceneBuildIndex int32
---@param options UnityEngine.SceneManagement.UnloadSceneOptions
---@return UnityEngine.AsyncOperation
function SceneManager.UnloadSceneAsync(sceneBuildIndex,options) end

---@param sceneName string
---@param options UnityEngine.SceneManagement.UnloadSceneOptions
---@return UnityEngine.AsyncOperation
function SceneManager.UnloadSceneAsync(sceneName,options) end

---@param scene UnityEngine.SceneManagement.Scene
---@param options UnityEngine.SceneManagement.UnloadSceneOptions
---@return UnityEngine.AsyncOperation
function SceneManager.UnloadSceneAsync(scene,options) end

return SceneManager
