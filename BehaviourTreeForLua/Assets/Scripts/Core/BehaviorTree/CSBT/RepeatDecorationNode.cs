/*
 * Description:             RepeatDecorationNode.cs
 * Author:                  TONYTANG
 * Create Date:             2019/11/04
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 重复执行修饰节点
    /// </summary>
    public class RepeatDecorationNode : DecorationNode
    {
        /// <summary>
        /// 重复次数
        /// </summary>
        public int RepeatedTimes;

        public RepeatDecorationNode() : base()
        {

        }

        public RepeatDecorationNode(string nodename, BaseNode dtnode, BehaviorTree bt, int repeatedtimes = 0, ENodeAbortType aborttype = ENodeAbortType.AbortAll) : base(nodename, dtnode, bt, aborttype)
        {
            RepeatedTimes = repeatedtimes;
        }

        protected override ENodeRunningState OnExecute()
        {
            if (ShouldAbortRunning())
            {
                return ENodeRunningState.Failed;
            }

            for (int i = 0; i <= RepeatedTimes; i++)
            {
                var childnodestate = ChildNode.Update();
                if(childnodestate == ENodeRunningState.Failed)
                {
                    return ENodeRunningState.Failed;
                }
            }
            return ENodeRunningState.Success;
        }
    }
}