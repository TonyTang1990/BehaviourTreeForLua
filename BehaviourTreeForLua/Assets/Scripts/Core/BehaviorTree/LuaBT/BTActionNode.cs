/*
 * Description:             BTActionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTActionNode.cs
    /// 行为节点
    /// </summary>
    public class BTActionNode : BTNode
    {
        #region 运行时部分
        public BTActionNode(BTNode node, TBehaviourTree btowner) : base(node, btowner)
        {

        }
        #endregion
    }
}