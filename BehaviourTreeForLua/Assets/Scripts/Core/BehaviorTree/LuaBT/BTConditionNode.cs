/*
 * Description:             BTConditionNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTConditionNode.cs
    /// �����ڵ�
    /// </summary>
    public class BTConditionNode : BTNode
    {
        public BTConditionNode(BTNode node, TBehaviourTree btowner) : base(node, btowner)
        {

        }
    }
}