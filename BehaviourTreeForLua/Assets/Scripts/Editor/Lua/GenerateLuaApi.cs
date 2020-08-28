//==================={By Qcbf|qcbf@qq.com|7/8/2019 10:29:01 AM}===================

using FFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class GenerateLuaApi
{
    /// <summary>
    /// 生成CS的Lua API
    /// </summary>
    /// <param name="outputfolderpath">输出目录</param>
    //[GenCodeMenu]
    public static void GenLuaApi(string outputfolderpath)
    {
        var outputfolderfullpath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, outputfolderpath));
        Debug.Log($"输出目录:{outputfolderfullpath}");
        if (Directory.Exists(outputfolderfullpath))
        {
            Directory.Delete(outputfolderfullpath, true);
        }
        Directory.CreateDirectory(outputfolderfullpath);
        if (EditorUtility.DisplayDialog("", "是否生成CS Lua API?", "ok", "cancel"))
        {
            GenerateAll(outputfolderpath);
        }
    }

    /// <summary>
    /// 生成所有CS的Lua API
    /// </summary>
    /// <param name="outputfolderpath">输出目录</param>
    public static void GenerateAll(string outputfolderpath)
    {
        Debug.Log("Generate All LuaUnityApi Wrap Files");
        string baseDir = $"Assets/{outputfolderpath}";
        for (int i = 0; i < 10; i++)
        {
            try
            {
                if(Directory.Exists(baseDir))
                {
                    Directory.Delete(baseDir);
                }
                Directory.CreateDirectory(baseDir);
                break;
            }
            catch (Exception err)
            {
                if (i == 9)
                {
                    Debug.LogError(err);
                }
            }
        }
        //string blacktypefullnamematch = "(iOS|Android|Experimental|HumanTrait|Network|Caching|CrashReport|DynamicGI|" +
        //    "HumanTrait|Matrix4x4|ReflectionProbe|Playables|Apple|tvOS|Scripting|WSA|Profiling|GUI|Social|Analytics|Physics2D|" +
        //    "VR|XR|TestTools|ProBuilder|SystemMethodExtensions|FEditor|SetTimeout|Debug.Log|Microphone|Accessibility|" +
        //    "ComputeBuffer|Cursor|EventProvider|ScalableBufferManager|Diagnostics|iPhone|ProceduralMaterial|TextCore|" +
        //    "UISystemProfilerApi|RemoteSettings|WWW|SpatialTracking|BuildCompression|WebCamTexture|Internal|UnityEngine.Windows|" +
        //    "YieldInstruction|WorldBaseItem|WorldTrigger|WorldObj|WorldBox|WorldCollect|WorldFragile|WorldDoor|WorldNPC)";

        //// 用于少数因为条件过滤到又需要生成的类(比如 部分内部类)
        //string typefullnamewhitelistmatch = "(UnityEngine.UI.Button.ButtonClickedEvent|UnityEngine.UI.Toggle.ToggleEvent|TextMeshProUGUI)";

        //string assemblenamewhitelist = "(UnityEngine|UnityEngine.AudioModule|UnityEngine.InputModule" +
        //    "|UnityEngine.ParticleSystemModule|UnityEngine.PhysicsModule|UnityEngine.ScreenCptureModule" +
        //    "|UnityEngine.TimelineModule|UnityEngine.UIModule|UnityEngine.UI|UnityEngine.Timeline" +
        //    "|Assembly-CSharp" +
        //    "|DOTween|DOTween43|DOTween46" +
        //    "|YoukiaCore" + "|DoDynamicPath" +"|Unity.TextMeshPro"+
        //    ")";

        //// var allassemblies = AppDomain.CurrentDomain.GetAssemblies();
        //// Debug.Log($"Assemble总数量:{allassemblies.Length}");
        //// foreach(var assemble in allassemblies)
        //// {
        ////    Debug.Log($"Assemble Name:{assemble.GetName().Name}");
        //// } 

        //// 这里只生成指定Assemble集以及指定黑名单且非接口非泛型类的Lua API文档定义
        //// 枚举定义单独输出对应文件定义
        //var alltypes = (from asm in AppDomain.CurrentDomain.GetAssemblies()
        //                where !(asm.ManifestModule is System.Reflection.Emit.ModuleBuilder) && Regex.IsMatch(asm.GetName().Name, assemblenamewhitelist)
        //                from type in asm.GetExportedTypes()
        //                where Regex.IsMatch(type.FullName, typefullnamewhitelistmatch) || (!type.IsInterface && !type.IsGenericType && !type.IsNested)
        //                //where !typeof(Enum).IsAssignableFrom(type)
        //                where ((type != null && type.Namespace == null) || (type != null && type.Namespace != null && !type.Namespace.StartsWith("XLua")))
        //                    && (!Regex.IsMatch(type.FullName, blacktypefullnamematch)||Regex.IsMatch(type.FullName, typefullnamewhitelistmatch))//)
        //                where !type.FullName.Contains("Unsafe")
        //                select type).ToArray();

        // 主要用于Lua测不需要访问，不会添加到LuaCallCSharp里
        // 但又想要生成代码提示的类(e.g. Text_Text)
        List<Type> typewhitelist = new List<Type>
        {
            typeof(Graphic),
            typeof(AudioBehaviour),
        };
        
        var alltypes = GenConfig.LuaCallCSharp;
        foreach (var whitetype in typewhitelist)
        {
            if (alltypes.Contains(whitetype) == false)
            {
                alltypes.Add(whitetype);
            }
        }

        var allnoneenumtypes = new List<Type>();
        var allenumtypes = new List<Type>();

        // gen lua wrap
        var head = new StringBuilder();
        #region head
        head.Append((char)45, 3);
        head.Append((char)61, 21);
        head.Append(new char[] { (char)32, (char)65, (char)117, (char)116, (char)104, (char)111, (char)114, (char)32, (char)81, (char)99, (char)98, (char)102, (char)32 });
        head.Append("这是自动生成的代码");
        head.Append(' ');
        head.Append((char)61, 21);
        head.Append((char)10);
        head.Append('\n');
        #endregion

        #region 分类记录举类全部需要的数据
        var staticmethods = new Dictionary<Type, List<MethodInfo>>(512);
        var staticfields = new Dictionary<Type, List<FieldOrPropertyInfo>>(512);
        // Note: 扩展方法当实例方法处理
        var instancemethods = new Dictionary<Type, List<MethodInfo>>(512);
        var instancefields = new Dictionary<Type, List<FieldOrPropertyInfo>>(512);

        // 枚举类定义单独处理，输出对应单独文件
        var enumtypefields = new Dictionary<Type, List<string>>(100);

        var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        foreach (var t in alltypes)
        {
            // 枚举类单独生成
            if (!typeof(Enum).IsAssignableFrom(t))
            {
                allnoneenumtypes.Add(t);
                foreach (var method in t.GetMethods(flags))
                {
                    if (method.IsDefined(typeof(ObsoleteAttribute)) || method.IsSpecialName || method.IsGenericMethod || method.IsSecuritySafeCritical)
                    {
                        continue;
                    }
                    bool isEx = method.IsDefined(typeof(ExtensionAttribute));
                    if (method.IsStatic && !isEx)
                    {
                        if (!staticmethods.TryGetValue(t, out var methods))
                        {
                            methods = new List<MethodInfo>(10);
                            staticmethods.Add(t, methods);
                        }
                        methods.Add(method);
                    }
                    else
                    {
                        var instanceType = isEx ? method.GetParameters()[0].ParameterType : t;
                        if (!instancemethods.TryGetValue(instanceType, out var methods))
                        {
                            methods = new List<MethodInfo>(20);
                            instancemethods.Add(instanceType, methods);
                        }
                        methods.Add(method);
                    }
                }

                foreach (var field in FieldOrPropertyInfo.GetFieldOrPropertInfos(t, flags))
                {
                    if (field.IsDefineAttribute<ObsoleteAttribute>() || field.Name == "Null")
                    {
                        continue;
                    }
                    if (field.IsStatic)
                    {
                        if (!staticfields.TryGetValue(t, out var stafields))
                        {
                            stafields = new List<FieldOrPropertyInfo>(10);
                            staticfields.Add(t, stafields);
                        }
                        stafields.Add(field);
                    }
                    else
                    {
                        if (!instancefields.TryGetValue(t, out var insfields))
                        {
                            insfields = new List<FieldOrPropertyInfo>(20);
                            instancefields.Add(t, insfields);
                        }
                        insfields.Add(field);
                    }
                }
            }
            else
            {
                allenumtypes.Add(t);
                if (!enumtypefields.TryGetValue(t, out var enufields))
                {
                    enufields = new List<string>(5);
                    enumtypefields.Add(t, enufields);
                }
                enufields.AddRange(Enum.GetNames(t));
            }
        }
        #endregion

        var utf8 = new UTF8Encoding(false);
        var buffer = new StringBuilder(512);

        // 静态方法和字段修改成和对应类文件生成在一起(无需单独生成)
        #region 写入静态方法和字段 CS.* 系列 
        ////写入头
        //buffer.Append(head);
        //buffer.Append("---@class CS\n");
        //buffer.Append("local CS = {}\n");
        ////写入字段
        //var DefineNames = new HashSet<string>();
        //foreach (var field in staticFields)
        //{
        //    DefineNames.Add("CS." + GetLuaTypeFullname(field.DeclaringType) + " = {}");
        //    DefineNames.Add("CS." + GetLuaTypeFullname(field.DeclaringType) + '.' + field.Name + " = {}");
        //}
        //foreach (var t in allTypes)
        //{
        //    DefineNames.Add("CS." + t.Namespace + " = {}");
        //    DefineNames.Add("CS." + GetLuaTypeFullname(t) + " = {}");
        //}
        //var tmp = DefineNames.ToList();
        //tmp.Sort();
        //buffer.Append(string.Join("\n", tmp));
        //buffer.Append("\n\n");
        ////写入方法
        //foreach (var method in staticMethods)
        //{
        //    buffer.Append(GetMethodTxt("CS." + GetLuaTypeFullname(method.DeclaringType), method) + '\n');
        //}
        //buffer.Append("\nreturn CS;\n");
        //File.WriteAllText(baseDir + "StaticsWrap.lua", buffer.ToString(), utf8);
        #endregion

        #region 写入非枚举类的方法和字段
        // 类定义生成结构:
        // 类类型定义
        // 实例成员定义
        // 静态成员定义
        // 类表定义
        // 实例方法定义
        // 静态方法定义
        foreach (var t in allnoneenumtypes)
        {
            var classname = t.Name;
            var luaclassname = GetLuaTypeFullname(t);
            buffer.Clear().Append(head);
            // 类类型定义
            if (t.BaseType != null && (t.BaseType != typeof(object) && t.BaseType != typeof(ValueType)))
            {
                buffer.Append($"---@class {luaclassname} : {GetLuaTypeFullname(t.BaseType)}\n");
            }
            else
            {
                buffer.Append($"---@class {luaclassname}\n");
            }
            // 实例成员定义
            if (instancefields.TryGetValue(t, out var insfields))
            {
                buffer.Append(string.Join("\n", from field in insfields select $"---@field public {field.Name} {GetLuaTypeFullname(field.ValueType)}"));
            }
            // 静态成员定义
            if (staticfields.TryGetValue(t, out var stafields))
            {
                buffer.Append(insfields != null ? "\n" : string.Empty);
                buffer.Append(string.Join("\n", from field in stafields select $"---@field static {field.Name} {GetLuaTypeFullname(field.ValueType)}"));
            }
            // 类表定义
            buffer.Append((insfields != null || stafields != null) ? $"\nlocal {classname} = " + "{}\n\n" : $"local {classname} = " + "{}\n\n");
            // 实例方法定义
            if (instancemethods.TryGetValue(t, out var insmethods))
            {
                buffer.Append(string.Join("\n", from method in insmethods select GetMethodTxt(classname, method)));
            }
            // 静态方法定义
            if (staticmethods.TryGetValue(t, out var stamethods))
            {
                buffer.Append(insmethods != null ? "\n" : string.Empty);
                buffer.Append(string.Join("\n", from method in stamethods select GetMethodTxt(classname, method)));
            }
            buffer.Append($"\nreturn {classname}\n");

            File.WriteAllText(baseDir + GetLuaTypeFullname(t).Replace('.', '_') + "_Wrap.lua", buffer.ToString(), utf8);
        }
        #endregion

        #region 写入枚举定义和字段
        // 枚举定义生成结构:
        // 枚举类型定义
        // 枚举成员定义
        foreach (var t in allenumtypes)
        {
            var classname = t.Name;
            var luaclassname = GetLuaTypeFullname(t);
            var enumvalueluaclassname = GetLuaTypeFullname(Enum.GetUnderlyingType(t));
            buffer.Clear().Append(head);
            // 类类型定义
            buffer.Append($"---@class {luaclassname}\n");
            // 枚举成员定义
            if (enumtypefields.TryGetValue(t, out var enumfields))
            {
                buffer.Append(string.Join("\n", from field in enumfields select $"---@field public {field} {enumvalueluaclassname}"));
            }
            // 枚举表定义
            buffer.Append($"\nlocal {classname} = " + "{}\n\n");
            buffer.Append($"\nreturn {classname}\n");

            File.WriteAllText(baseDir + GetLuaTypeFullname(t).Replace('.', '_') + "_Enum_Wrap.lua", buffer.ToString(), utf8);
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t"></param>
    private static string GetLuaTypeFullname(Type t)
    {
        if (t != null)
        {
            string result;
            if (t.IsGenericType)
            {
                if (t.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    result = GetLuaTypeFullname(t.GetGenericArguments()[0]);
                }
                else
                {
                    result = t.Name;
                    result = t.Namespace + "." + result.Substring(0, result.Length - 2);
                }
            }
            else
            {
                if (t == typeof(float) || t == typeof(double))
                {
                    result = "number";
                }
                else if (t == typeof(int) || t == typeof(string) || t == typeof(uint) || t == typeof(long) || t == typeof(ulong)
                    || t == typeof(short) || t == typeof(ushort) || t == typeof(byte) || t == typeof(sbyte))
                {
                    result = t.Name.ToLower();
                }
                else
                {
                    result = t.FullName;
                }
            }
            if (result != null)
            {
                result = result.Replace('+', '.').Replace("[,]", "[][]").Replace("[,,]", "[][][]");
            }

            return result;
        }
        else
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private static string GetMethodTxt(string className, MethodInfo method)
    {
        var isExMethod = method.IsDefined(typeof(ExtensionAttribute));
        var methodParams = from p in method.GetParameters()
                           where !p.IsOut
                           where !p.ParameterType.IsByRef
                           select p;
        if (isExMethod)
        {
            methodParams = methodParams.Skip(1);
        }

        string funcStr = "function " + className + (method.IsStatic && !isExMethod ? "." : ":") + method.Name + "(";
        string funcParamsStr = "";
        foreach (var item in methodParams)
        {
            string typeStr = GetLuaTypeFullname(item.ParameterType);
            if (typeStr != null)
            {
                string name = item.Name;
                if (name == "end")
                {
                    name += "_";
                }
                funcParamsStr += $"---@param {name} {typeStr}\n";
                funcStr += name + ",";
            }
        }
        if (funcStr[funcStr.Length - 1] == ',')
        {
            funcStr = funcStr.Substring(0, funcStr.Length - 1);
        }
        funcStr += ") end\n";

        var returnType = method.ReturnType;
        if (returnType != typeof(void))
        {
            funcParamsStr += "---@return " + GetLuaTypeFullname(method.ReturnType) + "\n";
        }

        return funcParamsStr + funcStr;
    }



}
