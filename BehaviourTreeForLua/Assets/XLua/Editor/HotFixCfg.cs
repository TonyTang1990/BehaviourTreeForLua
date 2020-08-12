using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XLua;
using UnityEngine;

public static class HotFixCfg
{
    /// <summary>
    /// 所有.Dll的白名单
    /// </summary>
    [Hotfix]
    public static List<Type> by_property
    {
        get
        {
            List<Type> rt = new List<Type>();
#if HOTFIX_ENABLE
            rt.Add(typeof(LauncherLoading));
            rt.Add(typeof(SDKManager));
            rt.AddRange(FindAsmTypes("/Plugins/Youkia/BattleSystem.dll"));
            rt.AddRange(FindAsmTypes("/Plugins/Youkia/YoukiaCore.dll"));
#endif
            return rt;
        }
    }

    private static List<Type> FindAsmTypes(string assemNamePatch)
    {
        Debug.Log(assemNamePatch);
        Assembly _assembly = Assembly.LoadFrom(Application.dataPath + assemNamePatch);
       return _assembly.GetTypes().ToList();
    }


    public static List<Type> GetAsmTypes(Assembly asm)
    {
        return asm.GetTypes().ToList();
    }
}


