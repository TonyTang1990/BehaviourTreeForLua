/*
 * Description:             TBehaviourTreeManager.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/08/31
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// ��Ϊ����������
    /// </summary>
    public class TBehaviourTreeManager : SingletonMonoBehaviourTemplate<TBehaviourTreeManager>
    {
        /// <summary>
        /// ������Ч����Ϊ���б�
        /// </summary>
        public List<TBehaviourTree> AllBehaviourTreeList
        {
            get;
            set;
        }

        /// <summary>
        /// �Ƿ���ͣ����
        /// </summary>
        public bool IsPauseAll
        {
            get;
            set;
        }

        public TBehaviourTreeManager()
        {
            AllBehaviourTreeList = new List<TBehaviourTree>();
            IsPauseAll = false;
        }

        private void Update()
        {
            if (!IsPauseAll)
            {
                for (int i = AllBehaviourTreeList.Count - 1; i >= 0; i--)
                {
                    AllBehaviourTreeList[i].OnUpdate();
                }
            }
        }

        /// <summary>
        /// ע��ָ����Ϊ������
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public bool RegisterTBehaviourTree(TBehaviourTree bt)
        {
            if(AllBehaviourTreeList.Contains(bt) == false)
            {
                Debug.Log($"ע��ָ����Ϊ�������ض�����:{bt.name}");
                AllBehaviourTreeList.Add(bt);
                return true;
            }
            else
            {
                Debug.LogError($"�ظ�ע��ָ����Ϊ�������ض�����:{bt.name}!");
                return false;
            }
        }

        /// <summary>
        /// ȡ��ע��ָ����Ϊ������
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public bool UnregisterTBhaviourTree(TBehaviourTree bt)
        {
#if UNITY_EDITOR
            Debug.Log($"ȡ��ע��ָ����Ϊ�������ض�����:{bt.name}");
#endif
            return AllBehaviourTreeList.Remove(bt);
        }

        /// <summary>
        /// ��ͣ������Ϊ��
        /// </summary>
        public void PauseAll()
        {
            IsPauseAll = true;
            foreach(var bt in AllBehaviourTreeList)
            {
                bt.Pause();
            }
        }

        /// <summary>
        /// ����������Ϊ��
        /// </summary>
        public void ResumeAll()
        {
            IsPauseAll = false;
            foreach (var bt in AllBehaviourTreeList)
            {
                bt.Resume();
            }
        }
    }
}