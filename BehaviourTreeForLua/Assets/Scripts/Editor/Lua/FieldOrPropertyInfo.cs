//-----------------------------------------------------------------------
//| by:Qcbf                                                             |
//-----------------------------------------------------------------------

using FFramework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace FFramework
{
    public struct FieldOrPropertyInfo
    {
        /// <summary>
        /// 
        /// </summary>
		public FieldInfo Field;
        /// <summary>
        /// 
        /// </summary>
		public PropertyInfo Property;

        /// <summary>
        /// 
        /// </summary>
		public bool IsValid => Field != null || Property != null;

        /// <summary>
        /// 
        /// </summary>
		public bool IsField => Field != null;

        /// <summary>
        /// 
        /// </summary>
		public bool IsProperty => Property != null;

        /// <summary>
        /// 
        /// </summary>
		public Type ValueType => Field?.FieldType ?? Property.PropertyType;

        /// <summary>
        /// 
        /// </summary>
        public Type DeclaringType => Field?.DeclaringType ?? Property.DeclaringType;

        /// <summary>
        /// 
        /// </summary>
		public string Name => Field?.Name ?? Property.Name;

        /// <summary>
        /// 
        /// </summary>
        public bool IsStatic => Field?.IsStatic ?? Property.GetMethod?.IsStatic ?? Property.SetMethod.IsStatic;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        public FieldOrPropertyInfo(FieldInfo field)
        {
            Field = field;
            Property = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        public FieldOrPropertyInfo(PropertyInfo prop)
        {
            Field = null;
            Property = prop;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcType"></param>
        /// <param name="name"></param>
        /// <param name="flags"></param>
        /// <param name="throwException"></param>
        public FieldOrPropertyInfo(Type srcType, string name, BindingFlags flags, bool throwException = true)
        {
            Field = srcType.GetField(name, flags);
            if (Field == null)
            {
                Property = srcType.GetProperty(name, flags);
                if (Property == null && throwException)
                {
                    throw new Exception("not found field or property : " + srcType.Name + "." + name);
                }
            }
            else
            {
                Property = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inst"></param>
        /// <param name="v"></param>
		public void SetValue(object inst, object v)
        {
            if (Field != null)
            {
                Field.SetValue(inst, v);
            }
            else
            {
                Property.SetValue(inst, v, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inst"></param>
        /// <returns></returns>
		public T GetValue<T>(object inst) => (T)GetValue(inst);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inst"></param>
        /// <returns></returns>
		public object GetValue(object inst)
        {
            if (Field != null)
            {
                return Field.GetValue(inst);
            }
            else
            {
                return Property.GetValue(inst, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isInherit"></param>
        /// <returns></returns>
		public bool IsDefineAttribute<T>(bool isInherit = true) => IsDefineAttribute(typeof(T), isInherit);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="isInherit"></param>
        /// <returns></returns>
        public bool IsDefineAttribute(Type t, bool isInherit = true)
        {
            if (Field != null)
            {
                return Field.IsDefined(t, isInherit);
            }
            else
            {
                return Property.IsDefined(t, isInherit);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ValueType + " " + Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FieldOrPropertyInfo[] GetFieldOrPropertInfos(Type t, BindingFlags flags)
        {
            return (from prop in t.GetProperties(flags) select new FieldOrPropertyInfo(prop))
                .Concat(from field in t.GetFields(flags) select new FieldOrPropertyInfo(field))
                .ToArray();
        }

    }
}
