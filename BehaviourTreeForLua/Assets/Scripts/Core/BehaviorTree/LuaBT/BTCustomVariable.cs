/*
 * Description:             BTCustomVariable.cs
 * Author:                  TANGHUAN
 * Create Date:             2020/09/29
 */

using System;

namespace LuaBehaviourTree
{
    /// <summary>
    /// 变量类型枚举
    /// </summary>
    public enum EVariableType
    {
        Invalide = 0,       // 无效类型
        Bool,               // bool类型
        String,             // string类型
        Float,              // float类型
        Int,                // int类型
    }

    /// <summary>
    /// 自定义变量数据基类
    /// </summary>
    [Serializable]
    public abstract class CustomVariableData
    {
        /// <summary>
        /// 变量名字
        /// </summary>
        public string VariableName;

        /// <summary>
        /// 变量类型
        /// </summary>
        public EVariableType VariableType;

        public CustomVariableData(string variablename, EVariableType variabletype)
        {
            VariableName = variablename;
            VariableType = variabletype;
        }
    }

    /// <summary>
    /// 自定义Bool变量数据
    /// </summary>
    [Serializable]
    public class CustomBoolVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public bool VariableValue;

        public CustomBoolVariableData(string variablename, EVariableType variabletype, bool variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义Int变量数据
    /// </summary>
    [Serializable]
    public class CustomIntVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public int VariableValue;

        public CustomIntVariableData(string variablename, EVariableType variabletype, int variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义float变量数据
    /// </summary>
    [Serializable]
    public class CustomFloatVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public float VariableValue;

        public CustomFloatVariableData(string variablename, EVariableType variabletype, float variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义string变量数据
    /// </summary>
    [Serializable]
    public class CustomStringVariableData : CustomVariableData
    {
        /// <summary>
        /// 变量值
        /// </summary>
        public string VariableValue;

        public CustomStringVariableData(string variablename, EVariableType variabletype, string variablevalue) : base(variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义变量节点数据基类
    /// </summary>
    [Serializable]
    public class CustomVariableNodeData
    {
        /// <summary>
        /// 节点UID
        /// </summary>
        public int NodeUID;

        /// <summary>
        /// 变量名
        /// </summary>
        public string VariableName;

        /// <summary>
        /// 变量类型
        /// </summary>
        public EVariableType VariableType;

        public CustomVariableNodeData(int nodeuid, string variablename, EVariableType variabletype)
        {
            NodeUID = nodeuid;
            VariableName = variablename;
            VariableType = variabletype;
        }
    }

    /// <summary>
    /// 自定义Bool变量节点数据
    /// </summary>
    [Serializable]
    public class CustomBoolVariableNodeData : CustomVariableNodeData
    {
        /// <summary>
        /// 数据
        /// </summary>
        public bool VariableValue;

        public CustomBoolVariableNodeData(int nodeuid, string variablename, EVariableType variabletype, bool variablevalue) : base(nodeuid, variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义Int变量节点数据
    /// </summary>
    [Serializable]
    public class CustomIntVariableNodeData : CustomVariableNodeData
    {
        /// <summary>
        /// 数据
        /// </summary>
        public int VariableValue;

        public CustomIntVariableNodeData(int nodeuid, string variablename, EVariableType variabletype, int variablevalue) : base(nodeuid, variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义Float变量节点数据
    /// </summary>
    [Serializable]
    public class CustomFloatVariableNodeData : CustomVariableNodeData
    {
        /// <summary>
        /// 数据
        /// </summary>
        public float VariableValue;

        public CustomFloatVariableNodeData(int nodeuid, string variablename, EVariableType variabletype, float variablevalue) : base(nodeuid, variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }

    /// <summary>
    /// 自定义String变量节点数据
    /// </summary>
    [Serializable]
    public class CustomStringVariableNodeData : CustomVariableNodeData
    {
        /// <summary>
        /// 数据
        /// </summary>
        public string VariableValue;

        public CustomStringVariableNodeData(int nodeuid, string variablename, EVariableType variabletype, string variablevalue) : base(nodeuid, variablename, variabletype)
        {
            VariableValue = variablevalue;
        }
    }
}