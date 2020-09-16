/*
 * Description:             Blackboard.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/09/16
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBehaviourTree
{
    /// <summary>
    /// �ڰ�ģʽ�����ݹ�������
    /// </summary>
    public class Blackboard
    {
        /// <summary>
        /// �ڰ����ݼ�������
        /// </summary>
        protected Dictionary<string, IBlackboardData> mBlackboardDataMap;

        public Blackboard()
        {
            mBlackboardDataMap = new Dictionary<string, IBlackboardData>();
        }

        /// <summary>
        /// ��Ӻڰ�����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddData(string key, IBlackboardData data)
        {
            IBlackboardData value;
            if (!mBlackboardDataMap.TryGetValue(key, out value))
            {
                mBlackboardDataMap.Add(key, data);
                return true;
            }
            else
            {
                Debug.LogError(string.Format("�ڰ��������Ѵ���Key:{0}�����ݣ��������ʧ��!", key));
                return false;
            }
        }

        /// <summary>
        /// �Ƴ��ڰ�����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveData(string key)
        {
            return mBlackboardDataMap.Remove(key);
        }

        /// <summary>
        /// ��ȡָ���ڰ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetData<T>(string key)
        {
            var value = GetBlackboardData(key);
            if (value != null)
            {
                return (value as BlackboardData<T>).Data;
            }
            else
            {
                Debug.LogError("����Ĭ��ֵ!");
                return default(T);
            }
        }

        /// <summary>
        /// ���ºڰ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateData<T>(string key, T data)
        {
            var value = GetBlackboardData(key);
            if (value != null)
            {
                (value as BlackboardData<T>).Data = data;
                return true;
            }
            else
            {
                Debug.LogError(string.Format("����Key:{0}������ʧ��!", key));
                return false;
            }
        }

        /// <summary>
        /// ����ڰ�����
        /// </summary>
        public void ClearData()
        {
            mBlackboardDataMap.Clear();
        }

        /// <summary>
        /// ��ȡ�ڰ�ָ������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private IBlackboardData GetBlackboardData(string key)
        {
            IBlackboardData value;
            if (!mBlackboardDataMap.TryGetValue(key, out value))
            {
                Debug.LogError(string.Format("�Ҳ���Key:{0}�ĺڰ�����!", key));
            }
            return value;
        }
    }

    /// <summary>
    /// �ڰ����ݽӿڳ���
    /// </summary>
    public interface IBlackboardData
    {

    }

    /// <summary>
    /// �ڰ����ݷ��ͻ���
    /// </summary>
    public class BlackboardData<T> : IBlackboardData
    {
        /// <summary>
        /// ����
        /// </summary>
        public T Data
        {
            get;
            set;
        }

        public BlackboardData(T data)
        {
            Data = data;
        }
    }

    #region �ڰ����ݳ����������Ͷ���
    /// <summary>
    /// �ڰ�������������
    /// </summary>
    public class IntBlackboardData : BlackboardData<int>
    {
        public IntBlackboardData(int data) : base(data)
        {
        }
    }

    /// <summary>
    /// �ڰ����ݸ���������
    /// </summary>
    public class FloatBlackboardData : BlackboardData<float>
    {
        public FloatBlackboardData(float data) : base(data)
        {
        }
    }

    /// <summary>
    /// �ڰ�����Boolean������
    /// </summary>
    public class BoolBlackboardData : BlackboardData<bool>
    {
        public BoolBlackboardData(bool data) : base(data)
        {
        }
    }

    /// <summary>
    /// �ڰ������ַ���������
    /// </summary>
    public class StringBlackboardData : BlackboardData<string>
    {
        public StringBlackboardData(string data) : base(data)
        {
        }
    }
    #endregion
}