---===================== Author Qcbf 这是自动生成的代码 =====================

---@class System.Type : System.Reflection.MemberInfo
---@field public MemberType System.Reflection.MemberTypes
---@field public DeclaringType System.Type
---@field public DeclaringMethod System.Reflection.MethodBase
---@field public ReflectedType System.Type
---@field public StructLayoutAttribute System.Runtime.InteropServices.StructLayoutAttribute
---@field public GUID System.Guid
---@field public Module System.Reflection.Module
---@field public Assembly System.Reflection.Assembly
---@field public TypeHandle System.RuntimeTypeHandle
---@field public FullName string
---@field public Namespace string
---@field public AssemblyQualifiedName string
---@field public BaseType System.Type
---@field public TypeInitializer System.Reflection.ConstructorInfo
---@field public IsNested System.Boolean
---@field public Attributes System.Reflection.TypeAttributes
---@field public GenericParameterAttributes System.Reflection.GenericParameterAttributes
---@field public IsVisible System.Boolean
---@field public IsNotPublic System.Boolean
---@field public IsPublic System.Boolean
---@field public IsNestedPublic System.Boolean
---@field public IsNestedPrivate System.Boolean
---@field public IsNestedFamily System.Boolean
---@field public IsNestedAssembly System.Boolean
---@field public IsNestedFamANDAssem System.Boolean
---@field public IsNestedFamORAssem System.Boolean
---@field public IsAutoLayout System.Boolean
---@field public IsLayoutSequential System.Boolean
---@field public IsExplicitLayout System.Boolean
---@field public IsClass System.Boolean
---@field public IsInterface System.Boolean
---@field public IsValueType System.Boolean
---@field public IsAbstract System.Boolean
---@field public IsSealed System.Boolean
---@field public IsEnum System.Boolean
---@field public IsSpecialName System.Boolean
---@field public IsImport System.Boolean
---@field public IsSerializable System.Boolean
---@field public IsAnsiClass System.Boolean
---@field public IsUnicodeClass System.Boolean
---@field public IsAutoClass System.Boolean
---@field public IsArray System.Boolean
---@field public IsGenericType System.Boolean
---@field public IsGenericTypeDefinition System.Boolean
---@field public IsConstructedGenericType System.Boolean
---@field public IsGenericParameter System.Boolean
---@field public GenericParameterPosition int32
---@field public ContainsGenericParameters System.Boolean
---@field public IsByRef System.Boolean
---@field public IsPointer System.Boolean
---@field public IsPrimitive System.Boolean
---@field public IsCOMObject System.Boolean
---@field public HasElementType System.Boolean
---@field public IsContextful System.Boolean
---@field public IsMarshalByRef System.Boolean
---@field public GenericTypeArguments System.Type[]
---@field public IsSecurityCritical System.Boolean
---@field public IsSecuritySafeCritical System.Boolean
---@field public IsSecurityTransparent System.Boolean
---@field public UnderlyingSystemType System.Type
---@field public IsSZArray System.Boolean
---@field static DefaultBinder System.Reflection.Binder
---@field static FilterAttribute System.Reflection.MemberFilter
---@field static FilterName System.Reflection.MemberFilter
---@field static FilterNameIgnoreCase System.Reflection.MemberFilter
---@field static Missing System.Object
---@field static Delimiter System.Char
---@field static EmptyTypes System.Type[]
local Type = {}

---@return System.Type
function Type:MakePointerType() end

---@return System.Type
function Type:MakeByRefType() end

---@return System.Type
function Type:MakeArrayType() end

---@param rank int32
---@return System.Type
function Type:MakeArrayType(rank) end

---@param name string
---@param invokeAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param target System.Object
---@param args System.Object[]
---@param modifiers System.Reflection.ParameterModifier[]
---@param culture System.Globalization.CultureInfo
---@param namedParameters System.String[]
---@return System.Object
function Type:InvokeMember(name,invokeAttr,binder,target,args,modifiers,culture,namedParameters) end

---@param name string
---@param invokeAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param target System.Object
---@param args System.Object[]
---@param culture System.Globalization.CultureInfo
---@return System.Object
function Type:InvokeMember(name,invokeAttr,binder,target,args,culture) end

---@param name string
---@param invokeAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param target System.Object
---@param args System.Object[]
---@return System.Object
function Type:InvokeMember(name,invokeAttr,binder,target,args) end

---@return int32
function Type:GetArrayRank() end

---@param bindingAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param callConvention System.Reflection.CallingConventions
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.ConstructorInfo
function Type:GetConstructor(bindingAttr,binder,callConvention,types,modifiers) end

---@param bindingAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.ConstructorInfo
function Type:GetConstructor(bindingAttr,binder,types,modifiers) end

---@param types System.Type[]
---@return System.Reflection.ConstructorInfo
function Type:GetConstructor(types) end

---@return System.Reflection.ConstructorInfo[]
function Type:GetConstructors() end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.ConstructorInfo[]
function Type:GetConstructors(bindingAttr) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param callConvention System.Reflection.CallingConventions
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.MethodInfo
function Type:GetMethod(name,bindingAttr,binder,callConvention,types,modifiers) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.MethodInfo
function Type:GetMethod(name,bindingAttr,binder,types,modifiers) end

---@param name string
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.MethodInfo
function Type:GetMethod(name,types,modifiers) end

---@param name string
---@param types System.Type[]
---@return System.Reflection.MethodInfo
function Type:GetMethod(name,types) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.MethodInfo
function Type:GetMethod(name,bindingAttr) end

---@param name string
---@return System.Reflection.MethodInfo
function Type:GetMethod(name) end

---@return System.Reflection.MethodInfo[]
function Type:GetMethods() end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.MethodInfo[]
function Type:GetMethods(bindingAttr) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.FieldInfo
function Type:GetField(name,bindingAttr) end

---@param name string
---@return System.Reflection.FieldInfo
function Type:GetField(name) end

---@return System.Reflection.FieldInfo[]
function Type:GetFields() end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.FieldInfo[]
function Type:GetFields(bindingAttr) end

---@param name string
---@return System.Type
function Type:GetInterface(name) end

---@param name string
---@param ignoreCase System.Boolean
---@return System.Type
function Type:GetInterface(name,ignoreCase) end

---@return System.Type[]
function Type:GetInterfaces() end

---@param filter System.Reflection.TypeFilter
---@param filterCriteria System.Object
---@return System.Type[]
function Type:FindInterfaces(filter,filterCriteria) end

---@param name string
---@return System.Reflection.EventInfo
function Type:GetEvent(name) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.EventInfo
function Type:GetEvent(name,bindingAttr) end

---@return System.Reflection.EventInfo[]
function Type:GetEvents() end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.EventInfo[]
function Type:GetEvents(bindingAttr) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@param binder System.Reflection.Binder
---@param returnType System.Type
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name,bindingAttr,binder,returnType,types,modifiers) end

---@param name string
---@param returnType System.Type
---@param types System.Type[]
---@param modifiers System.Reflection.ParameterModifier[]
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name,returnType,types,modifiers) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name,bindingAttr) end

---@param name string
---@param returnType System.Type
---@param types System.Type[]
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name,returnType,types) end

---@param name string
---@param types System.Type[]
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name,types) end

---@param name string
---@param returnType System.Type
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name,returnType) end

---@param name string
---@return System.Reflection.PropertyInfo
function Type:GetProperty(name) end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.PropertyInfo[]
function Type:GetProperties(bindingAttr) end

---@return System.Reflection.PropertyInfo[]
function Type:GetProperties() end

---@return System.Type[]
function Type:GetNestedTypes() end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Type[]
function Type:GetNestedTypes(bindingAttr) end

---@param name string
---@return System.Type
function Type:GetNestedType(name) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Type
function Type:GetNestedType(name,bindingAttr) end

---@param name string
---@return System.Reflection.MemberInfo[]
function Type:GetMember(name) end

---@param name string
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.MemberInfo[]
function Type:GetMember(name,bindingAttr) end

---@param name string
---@param type System.Reflection.MemberTypes
---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.MemberInfo[]
function Type:GetMember(name,type,bindingAttr) end

---@return System.Reflection.MemberInfo[]
function Type:GetMembers() end

---@param bindingAttr System.Reflection.BindingFlags
---@return System.Reflection.MemberInfo[]
function Type:GetMembers(bindingAttr) end

---@return System.Reflection.MemberInfo[]
function Type:GetDefaultMembers() end

---@param memberType System.Reflection.MemberTypes
---@param bindingAttr System.Reflection.BindingFlags
---@param filter System.Reflection.MemberFilter
---@param filterCriteria System.Object
---@return System.Reflection.MemberInfo[]
function Type:FindMembers(memberType,bindingAttr,filter,filterCriteria) end

---@return System.Type[]
function Type:GetGenericParameterConstraints() end

---@param typeArguments System.Type[]
---@return System.Type
function Type:MakeGenericType(typeArguments) end

---@return System.Type
function Type:GetElementType() end

---@return System.Type[]
function Type:GetGenericArguments() end

---@return System.Type
function Type:GetGenericTypeDefinition() end

---@return System.String[]
function Type:GetEnumNames() end

---@return System.Array
function Type:GetEnumValues() end

---@return System.Type
function Type:GetEnumUnderlyingType() end

---@param value System.Object
---@return System.Boolean
function Type:IsEnumDefined(value) end

---@param value System.Object
---@return string
function Type:GetEnumName(value) end

---@param c System.Type
---@return System.Boolean
function Type:IsSubclassOf(c) end

---@param o System.Object
---@return System.Boolean
function Type:IsInstanceOfType(o) end

---@param c System.Type
---@return System.Boolean
function Type:IsAssignableFrom(c) end

---@param other System.Type
---@return System.Boolean
function Type:IsEquivalentTo(other) end

---@return string
function Type:ToString() end

---@param o System.Object
---@return System.Boolean
function Type:Equals(o) end

---@param o System.Type
---@return System.Boolean
function Type:Equals(o) end

---@return int32
function Type:GetHashCode() end

---@param interfaceType System.Type
---@return System.Reflection.InterfaceMapping
function Type:GetInterfaceMap(interfaceType) end

---@return System.Type
function Type:GetType() end

---@param typeName string
---@param assemblyResolver System.Func
---@param typeResolver System.Func
---@return System.Type
function Type.GetType(typeName,assemblyResolver,typeResolver) end

---@param typeName string
---@param assemblyResolver System.Func
---@param typeResolver System.Func
---@param throwOnError System.Boolean
---@return System.Type
function Type.GetType(typeName,assemblyResolver,typeResolver,throwOnError) end

---@param typeName string
---@param assemblyResolver System.Func
---@param typeResolver System.Func
---@param throwOnError System.Boolean
---@param ignoreCase System.Boolean
---@return System.Type
function Type.GetType(typeName,assemblyResolver,typeResolver,throwOnError,ignoreCase) end

---@param progID string
---@return System.Type
function Type.GetTypeFromProgID(progID) end

---@param progID string
---@param throwOnError System.Boolean
---@return System.Type
function Type.GetTypeFromProgID(progID,throwOnError) end

---@param progID string
---@param server string
---@return System.Type
function Type.GetTypeFromProgID(progID,server) end

---@param progID string
---@param server string
---@param throwOnError System.Boolean
---@return System.Type
function Type.GetTypeFromProgID(progID,server,throwOnError) end

---@param type System.Type
---@return System.TypeCode
function Type.GetTypeCode(type) end

---@param o System.Object
---@return System.RuntimeTypeHandle
function Type.GetTypeHandle(o) end

---@param args System.Object[]
---@return System.Type[]
function Type.GetTypeArray(args) end

---@param typeName string
---@return System.Type
function Type.GetType(typeName) end

---@param typeName string
---@param throwOnError System.Boolean
---@return System.Type
function Type.GetType(typeName,throwOnError) end

---@param typeName string
---@param throwOnError System.Boolean
---@param ignoreCase System.Boolean
---@return System.Type
function Type.GetType(typeName,throwOnError,ignoreCase) end

---@param typeName string
---@param throwIfNotFound System.Boolean
---@param ignoreCase System.Boolean
---@return System.Type
function Type.ReflectionOnlyGetType(typeName,throwIfNotFound,ignoreCase) end

---@param handle System.RuntimeTypeHandle
---@return System.Type
function Type.GetTypeFromHandle(handle) end

return Type
