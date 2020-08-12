using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using XLua;


[Hotfix]
[LuaCallCSharp]
public class XLuaManager : SingletonMonoBehaviourTemplate<XLuaManager>
{
    /// <summary>
    /// Lua脚本文件夹名
    /// </summary>
    public const string LuaScriptsFolder = "LuaScripts";

    /// <summary>
    /// Lua启动脚本名
    /// </summary>
    private const string GameMainScriptName = "GameMain";

    /// <summary>
    /// Lua唯一Env
    /// </summary>
    private LuaEnv mLuaEnv = null;

    /// <summary>
    /// Lua脚本Asset缓存
    /// </summary>
    private Dictionary<string, byte[]> mAssetsLuaCaching = new Dictionary<string, byte[]>();
    
    /// <summary>
    /// Lua测游戏开始方法绑定
    /// </summary>
    private Action mLuaGameStart = null;

    /// <summary>
    /// Lua测游戏停止方法绑定
    /// </summary>
    private Action mLuaGameStop = null;

    /// <summary>
    /// Lua测Update方法绑定
    /// </summary>
    private Action<float, float> mLuaUpdate = null;

    /// <summary>
    /// Lua测LateUpdate方法绑定
    /// </summary>
    private Action mLuaLateUpdate = null;

    /// <summary>
    /// Lua测FixedUpdate方法绑定
    /// </summary>
    private Action<float> mLuaFixedUpdate = null;

    private void Start()
    {
        Debug.Log($"XLuaManager:Start()");
        mLuaEnv = new LuaEnv();
        if (mLuaEnv != null)
        {
            mLuaEnv.AddLoader(CustomLoader);
        }
        else
        {
            Debug.LogError("InitLuaEnv null!!!");
        }
        LoadScript(GameMainScriptName);
        mLuaGameStart = mLuaEnv.Global.Get<Action>("Start");
        mLuaGameStop = mLuaEnv.Global.Get<Action>("Stop");
        mLuaUpdate = mLuaEnv.Global.Get<Action<float, float>>("Update");
        mLuaLateUpdate = mLuaEnv.Global.Get<Action>("LateUpdate");
        mLuaFixedUpdate = mLuaEnv.Global.Get<Action<float>>("FixedUpdate");
        mLuaGameStart();
    }

    public LuaEnv GetLuaEnv()
    {
        return mLuaEnv;
    }

    public void LoadScript(string scriptname)
    {
        SafeDoString(string.Format("require('{0}')", scriptname));
    }

    public byte[] CustomLoader(ref string filepath)
    {
        filepath = filepath.Replace(".", "/");
        var luanames = filepath.Split('/');
        var luaname = luanames[luanames.Length - 1];
        byte[] bytes = null;
        if(!mAssetsLuaCaching.TryGetValue(luaname, out bytes))
        {
            var luafilefullpath = $"{Application.dataPath}/Resources/{LuaScriptsFolder}/{luaname}.lua";
            bytes = File.ReadAllBytes(luafilefullpath);
            if(bytes == null)
            {
                Debug.LogError($"找不到Lua文件路径:{luafilefullpath}");
            }
            else
            {
                Debug.Log($"加载Lua文件路径:{luafilefullpath}");
                mAssetsLuaCaching.Add(luaname, bytes);
            }
        }
        return bytes;
    }

    private void Update()
    {
        if (mLuaEnv != null)
        {
            mLuaEnv.Tick();
            if (mLuaUpdate != null)
            {
                mLuaUpdate(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }
    }

    private void LateUpdate()
    {
        if (mLuaEnv != null && mLuaLateUpdate != null)
        {
            mLuaLateUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (mLuaEnv != null && mLuaFixedUpdate != null)
        {
            mLuaFixedUpdate(Time.fixedDeltaTime);
        }
    }

    private void OnDestroy()
    {
        Debug.Log($"XLuaManager:OnDestroy()");
        mLuaGameStart = null;
        mLuaGameStop();
        mLuaGameStop = null;
        mLuaUpdate = null;
        mLuaLateUpdate = null;
        mLuaFixedUpdate = null;
        StopLuaEnv();
    }

    /// <summary>
    /// 停止虚拟机
    /// </summary>
    public void StopLuaEnv()
    {
        if (mLuaEnv != null)
        {
            mLuaEnv.Dispose();
        }
        mLuaEnv = null;
    }

    public void SafeDoString(string scriptContent)
    {
        if (mLuaEnv != null)
        {
            try
            {
                mLuaEnv.DoString(scriptContent);
            }
            catch (System.Exception ex)
            {
                string msg = string.Format("xLua exception : {2} >> {0}\n {1}", ex.Message, ex.StackTrace, scriptContent);
                Debug.LogError(msg, null);
            }
        }
    }

    public LuaTable CreateNewTable()
    {
        return mLuaEnv.NewTable();
    }
}
