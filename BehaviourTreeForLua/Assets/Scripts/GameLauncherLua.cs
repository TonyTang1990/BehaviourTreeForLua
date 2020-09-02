/*
 * Description:             游戏入口
 * Author:                  GameLauncherLua
 * Create Date:             2018/03/12
 */

using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Game.BT;
using LuaBehaviourTree;

/// <summary>
/// 游戏入口
/// </summary>
public class GameLauncherLua : MonoBehaviour {

    /// <summary>
    /// 单例方便访问
    /// </summary>
    public static GameLauncherLua Singleton;
    
    #region 可视化数据部分
    /// <summary>
    /// 日期选项
    /// </summary>
    public Dropdown DdDay;

    /// <summary>
    /// 拥有的钱数
    /// </summary>
    public InputField IfMoney;

    /// <summary>
    /// 是否拥有任务
    /// </summary>
    public Toggle TgHasTask;

    /// <summary>
    /// 暂停玩家行为树按钮
    /// </summary>
    public Button BtnPausePlayerAI;

    /// <summary>
    /// 继续玩家行为树按钮
    /// </summary>
    public Button BtnResumePlayerAI;

    /// <summary>
    /// 暂停所有行为树按钮
    /// </summary>
    public Button BtnPauseAllAI;

    /// <summary>
    /// 暂停所有行为树按钮
    /// </summary>
    public Button BtnResumeAllAI;
    #endregion

    #region 玩家控制表现部分
    /// <summary>
    /// 玩家
    /// </summary>
    public NavMeshAgent Player;

    /// <summary>
    /// 玩家描述
    /// </summary>
    public TextMesh PlayerTxt;

    /// <summary>
    /// 公司
    /// </summary>
    public Transform Company;

    /// <summary>
    /// 商场
    /// </summary>
    public Transform ShoppingMall;

    /// <summary>
    /// 家
    /// </summary>
    public Transform Home;

    /// <summary>
    /// 玩家行为树组件
    /// </summary>
    private TBehaviourTree mPlayerBT;
    #endregion

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }

        DontDestroyOnLoad(this);
        AddListeners();

        VisibleLogUtility visiblelog = gameObject.AddComponent<VisibleLogUtility>();
        visiblelog.setInstance(visiblelog);
        VisibleLogUtility.getInstance().mVisibleLogSwitch = FastUIEntry.LogSwitch;
        Application.logMessageReceived += VisibleLogUtility.getInstance().HandleLog;

        var xluamanager = gameObject.AddComponent<XLuaManager>();
        xluamanager.setInstance(xluamanager);

        var tbtmananger = new GameObject("TBehaviourManager").AddComponent<TBehaviourTreeManager>();
        tbtmananger.setInstance(tbtmananger);
        DontDestroyOnLoad(tbtmananger.gameObject);
    }

    private void Start () {
        Debug.Log("GameLauncherLua:Start()");
        // 测试Lua版行为树
        mPlayerBT = Player.gameObject.AddComponent<TBehaviourTree>();
        mPlayerBT.LoadBTGraphAsset("DefaultBT");
    }

    /// <summary>
    /// 添加监听
    /// </summary>
    private void AddListeners()
    {
        BtnPausePlayerAI.onClick.AddListener(OnBtnPausePlayerAI);
        BtnResumePlayerAI.onClick.AddListener(OnBtnResumePlayerAI);
        BtnPauseAllAI.onClick.AddListener(OnBtnPauseAllAI);
        BtnResumeAllAI.onClick.AddListener(OnBtnResumeAllAI);
    }

    private void OnBtnPausePlayerAI()
    {
        Debug.Log($"OnBtnPausePlayerAI()");
        var bt = Player.GetComponent<TBehaviourTree>();
        bt.Pause();
    }

    private void OnBtnResumePlayerAI()
    {
        Debug.Log($"OnBtnResumePlayerAI()");
        var bt = Player.GetComponent<TBehaviourTree>();
        bt.Resume();
    }

    private void OnBtnPauseAllAI()
    {
        Debug.Log($"OnBtnPauseAllAI()");
        TBehaviourTreeManager.getInstance().PauseAll();
    }

    private void OnBtnResumeAllAI()
    {
        Debug.Log($"OnBtnResumeAllAI()");
        TBehaviourTreeManager.getInstance().ResumeAll();
    }

    private void Update()
    {
    
    }
    
    private void OnDestroy()
    {
        Application.logMessageReceived -= VisibleLogUtility.getInstance().HandleLog;
    }
}
