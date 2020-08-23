/*
 * Description:             BTDecorationNode.cs
 * Author:                  TONYTANG
 * Create Date:             2020/08/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// BTDecorationNode.cs
    /// 修饰节点
    /// </summary>
    public class BTDecorationNode : BTNode
    {
        /// <summary>
        /// 装饰的子节点
        /// </summary>
        public BTNode ChildNode;

        public BTDecorationNode(BTNode node, TBehaviourTree btowner) : base(node, btowner)
        {

        }
    }
}