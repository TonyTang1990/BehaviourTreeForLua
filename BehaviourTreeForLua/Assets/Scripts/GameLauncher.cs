/*
 * Description:             游戏入口
 * Author:                  tanghuan
 * Create Date:             2018/03/12
 */

using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Game.BT;

/// <summary>
/// 游戏入口
/// </summary>
public class GameLauncher : MonoBehaviour {

    /// <summary>
    /// 单例方便访问
    /// </summary>
    public static GameLauncher Singleton;

    #region 行为树部分
    /// <summary>
    /// 行为树构建器
    /// </summary>
    private BehaviorTreeBuilder mBTT;

    /// <summary>
    /// 星期几的key
    /// </summary>
    public const string DayKey = "Day";

    /// <summary>
    /// 钱的Key
    /// </summary>
    public const string MoneyKey = "Money";

    /// <summary>
    /// 任务的key
    /// </summary>
    public const string TaskKey = "Task";
    #endregion

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
    #endregion

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }

        DontDestroyOnLoad(this);

        VisibleLogUtility visiblelog = gameObject.AddComponent<VisibleLogUtility>();
        visiblelog.setInstance(visiblelog);
        VisibleLogUtility.getInstance().mVisibleLogSwitch = FastUIEntry.LogSwitch;
        Application.logMessageReceived += VisibleLogUtility.getInstance().HandleLog;
    }

    private void Start () {
        Debug.Log("GameLauncher:Start()");
        TestBehaviorTree();
    }

    private void Update()
    {
        UpdateBlackboardData();
        mBTT.BT.Update();
    }

    /// <summary>
    /// 更新黑板数据
    /// </summary>
    private void UpdateBlackboardData()
    {
        var day = mBTT.BlackBoard.GetData<int>(DayKey);
        var newday = DdDay.value + 1;
        if (day != newday)
        {
            Debug.Log("更新到星期:" + newday);
            mBTT.BlackBoard.UpdateData<int>(DayKey, newday);
        }
        var money = mBTT.BlackBoard.GetData<int>(MoneyKey);
        var newmoney = IfMoney.text.IsNullOrEmpty() ? 0 : int.Parse(IfMoney.text);
        if (money != newmoney)
        {
            Debug.Log("更新拥有钱数:" + newmoney);
            mBTT.BlackBoard.UpdateData<int>(MoneyKey, newmoney);
        }
        var hastask = mBTT.BlackBoard.GetData<bool>(TaskKey);
        var newhastask = TgHasTask.isOn;
        if (hastask != newhastask)
        {
            Debug.Log("更新是否有任务:" + newhastask);
            mBTT.BlackBoard.UpdateData<bool>(TaskKey, newhastask);
        }
    }

    /// <summary>
    /// 测试行为树
    /// </summary>
    private void TestBehaviorTree()
    {
        Debug.Log("测试行为树!");
        mBTT = BehaviorTreeBuilder.CreateBehaviorTreeBuilder();
        // 初始化黑板数据
        mBTT.BlackBoard.AddData(DayKey, new BlackboardData<int>(1));
        mBTT.BlackBoard.AddData(MoneyKey, new BlackboardData<int>(600));
        mBTT.BlackBoard.AddData(TaskKey, new BlackboardData<bool>(false));
        Debug.Log("黑板数据:");
        Debug.Log(string.Format("日期:星期{0}", mBTT.BlackBoard.GetData<int>(DayKey)));
        Debug.Log(string.Format("钱:{0}", mBTT.BlackBoard.GetData<int>(MoneyKey)));
        Debug.Log(string.Format("任务:{0}", mBTT.BlackBoard.GetData<bool>(TaskKey)));

        // 初始化节点数据结构
        var rootselectnode = mBTT.CreateSelectorNode("根节点");
        mBTT.SetRootNode(rootselectnode);
        var workselectnode = mBTT.CreateSelectorNode("上班节点(选择节点)");                                                             // 上班节点(选择节点)
        workselectnode.Precondition = new WorkPrecondition();

        var worktasksequencenode = mBTT.CreateSequenceNode("工作任务(顺序节点)");                                                       // 工作任务(顺序节点)
        var hastaskconditionnode = mBTT.CreateConditionNode<HasTaskConditionNode>("有任务(条件节点)");                                  // 有任务(条件节点)
        var dotaskactionnode = mBTT.CreateActionNode<DoWorkTaskActionNode>("执行工作任务(动作节点)");                                   // 执行工作任务(动作节点)
        worktasksequencenode.AddChild(hastaskconditionnode);
        worktasksequencenode.AddChild(dotaskactionnode);

        var studysequencenode = mBTT.CreateSequenceNode("学习研究(顺序节点)");                                                          // 学习研究(顺序节点)
        var hastaskconditionnode2 = mBTT.CreateConditionNode<HasTaskConditionNode>("有任务(条件节点)2");                                // 有任务(条件节点)2
        var notaskconditionnode = mBTT.CreateDecorationNode<InverterDecorationNode>("有任务取反节点(装饰节点)", hastaskconditionnode2); // 有任务取反节点(装饰节点)
        var dostudyparalnode = mBTT.CreateParalNode("技术学习研究(并发节点)");                                                          // 技术学习研究(并发节点)
        var searchdataactionnode = mBTT.CreateActionNode<SearchDataActionNode>("查资料(动作节点)");                                     // 查资料(动作节点)
        var dodemoactionnode = mBTT.CreateActionNode<DoDemoActionNode>("写Demo(动作节点)");                                             // 写Demo(动作节点)
        var writeblogactionnode = mBTT.CreateActionNode<WriteBlogActionNode>("Blog总结(动作节点)");                                     // Blog总结(动作节点)
        dostudyparalnode.AddChild(searchdataactionnode);
        dostudyparalnode.AddChild(dodemoactionnode);
        dostudyparalnode.AddChild(writeblogactionnode);
        studysequencenode.AddChild(notaskconditionnode);
        studysequencenode.AddChild(dostudyparalnode);

        workselectnode.AddChild(worktasksequencenode);
        workselectnode.AddChild(studysequencenode);

        rootselectnode.AddChild(workselectnode);

        var holidaynode = mBTT.CreateSelectorNode("放假节点(选择节点)");                                        // 放假节点(选择节点)
        holidaynode.Precondition = new HolidayPrecondition();

        var dodatenode = mBTT.CreateSequenceNode("约会(顺序节点)");                                             // 约会(顺序节点)
        dodatenode.Precondition = new DatePrecondition();
        var moneyconditionnode = mBTT.CreateConditionNode<MoneyRequirementConditionNode>("约会钱>0(条件节点)"); // 约会钱>0(条件节点)
        var shoppingnode = mBTT.CreateActionNode<ShoppingActionNode>("逛街(动作节点)");                         // 逛街(动作节点)
        var eatnode = mBTT.CreateActionNode<EatActionNode>("吃饭(动作节点)");                                   // 吃饭(动作节点)
        var watchmoivenode = mBTT.CreateActionNode<WatchMovieActionNode>("看电影(动作节点)");                   // 看电影(动作节点)
        var gohomenode = mBTT.CreateActionNode<GoHomeActionNode>("回家(动作节点)");                             // 回家(动作节点)
        dodatenode.AddChild(moneyconditionnode);
        dodatenode.AddChild(shoppingnode);
        dodatenode.AddChild(eatnode);
        dodatenode.AddChild(watchmoivenode);
        dodatenode.AddChild(gohomenode);

        holidaynode.AddChild(dodatenode);

        var dostayhomenode = mBTT.CreateSequenceNode("在家(顺序节点)");                                          // 在家(顺序节点)
        dostayhomenode.Precondition = new StayHomePrecondition();
        var playgamenode = mBTT.CreateActionNode<PlayGameActionNode>("打游戏(动作节点)");                           // 打游戏(动作节点)
        var repeateddtnode = mBTT.CreateDecorationNode<RepeatDecorationNode>("重复节点(装饰节点)", playgamenode);                 // 重复节点(装饰节点)
        repeateddtnode.RepeatedTimes = 5;
        var sleepnode = mBTT.CreateActionNode<SleepActionNode>("睡觉(动作节点)");                                   // 睡觉(动作节点)
        dostayhomenode.AddChild(repeateddtnode);
        dostayhomenode.AddChild(sleepnode);

        holidaynode.AddChild(dostayhomenode);

        rootselectnode.AddChild(holidaynode);
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= VisibleLogUtility.getInstance().HandleLog;
    }
    
    #region 行为树前置条件
    /// <summary>
    /// 工作前置条件
    /// </summary>
    public class WorkPrecondition : NodePrecondition
    {
        public override bool Evaluate(Blackboard bb)
        {
            var day = bb.GetData<int>(DayKey);
            var result = day > 0 && day < 6;
            //Debug.Log(string.Format("是否满足工作前置条件:{0}", result));
            return result;
        }
    }

    /// <summary>
    /// 工作前置条件
    /// </summary>
    public class HolidayPrecondition : NodePrecondition
    {
        public override bool Evaluate(Blackboard bb)
        {
            var day = bb.GetData<int>(DayKey);
            var result = day > 5 && day < 8;
            //Debug.Log(string.Format("是否满足假期前置条件:{0}", result));
            return result;
        }
    }

    /// <summary>
    /// 约会前置条件
    /// </summary>
    public class DatePrecondition : NodePrecondition
    {
        public override bool Evaluate(Blackboard bb)
        {
            var money = bb.GetData<int>(MoneyKey);
            var result = money > 0;
            //Debug.Log(string.Format("是否满足约会前置条件:{0}", result));
            return result;
        }
    }

    /// <summary>
    /// 待在家前置条件
    /// </summary>
    public class StayHomePrecondition : NodePrecondition
    {
        public override bool Evaluate(Blackboard bb)
        {
            var money = bb.GetData<int>(MoneyKey);
            var result = money <= 0;
            //Debug.Log(string.Format("是否满足待在家前置条件:{0}", result));
            return result;
        }
    }
    #endregion
}
