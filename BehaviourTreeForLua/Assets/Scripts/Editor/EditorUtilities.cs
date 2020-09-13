/*
 * Description:             EditorUtilities.cs
 * Author:                  TONYTANG
 * Create Date:             2020/09/11
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EditorUtilities.cs
/// 静态编辑器工具类
/// </summary>
public static class EditorUtilities
{
    /// <summary>
    /// 显示指定文本指定颜色间隔宽高等信息
    /// </summary>
    /// <param name="title"></param>
    /// <param name="color"></param>
    /// <param name="space"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public static void DisplayDIYGUILable(string title, Color color, float space, float width, float height)
    {
        var precolor = GUI.color;
        GUI.color = color;
        GUILayout.Space(space);
        GUILayout.Label(title, "box", GUILayout.Width(width), GUILayout.Height(height));
        GUI.color = precolor;
    }
}