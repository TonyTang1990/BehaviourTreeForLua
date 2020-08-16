/*
 * Description:             TBehaviourTree.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/16
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TBehaviourTree.cs
/// Lua行为树挂载驱动组件
/// </summary>
[DisallowMultipleComponent]
public class TBehaviourTree : MonoBehaviour
{
    /// <summary>
    /// 行为树图数据
    /// </summary>
    public TextAsset BTGraphAsset;

    /// <summary>
    /// 行为树图对象
    /// </summary>
    public BTGraph BTGraphData
    {
        get;
        private set;
    }

    /// <summary>
    /// Lua测行为树对象
    /// </summary>
    public TLuaBehaviourTree LuaBehaviourTree
    {
        get;
        private set;
    }

    /// <summary>
    /// 行为树是否开启
    /// </summary>
    public bool IsBTEnable
    {
        get;
        private set;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        IsBTEnable = true;
    }

    private void OnDisable()
    {
        IsBTEnable = false;
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        IsBTEnable = false;
    }

    /// <summary>
    /// 加载行为树图数据
    /// </summary>
    /// <param name="assetname"></param>
    public void LoadBTGraphAsset(string assetname)
    {
        BTGraphAsset = Resources.Load<TextAsset>($"{BTData.BTNodeSaveFolderRelativePath}/{assetname}.json");
        BTGraphData = JsonUtility.FromJson<BTGraph>(BTGraphAsset.text);
    }
}