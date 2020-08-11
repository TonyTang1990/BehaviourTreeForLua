/*
 * Description:             BehaviorTree.cs
 * Author:                  TANGHUAN
 * Create Date:             2019/10/29
 */

using System;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树抽象
    /// </summary>
    public class BehaviorTree
    {
        /// <summary>
        /// 数据共享黑板
        /// </summary>
        public Blackboard BTBlackBoard
        {
            get;
            set;
        }

        /// <summary>
        /// 行为树根节点
        /// </summary>
        public BaseNode RootNode
        {
            get;
            set;
        }

        public BehaviorTree(Blackboard bb)
        {
            BTBlackBoard = bb;
        }

        public void Update()
        {
            if(RootNode != null && !RootNode.IsTerminated)
            {
                RootNode.Update();
            }
        }
    }
}
