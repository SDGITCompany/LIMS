using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using SqlDataAccess;

namespace KCZYLIMS.BLL.Utility
{
    public class EntityHelper<T> where T : class
    {
        private readonly DataContext _dataContext;
         

        public EntityHelper(DataContext dataContext)
        {
            if (dataContext == null)
            {
                dataContext = new DataClassesKCZYSDataContext();
            }
            _dataContext = dataContext;
        }
        public EntityHelper()
        {
            if (_dataContext == null)
            {
                _dataContext = new DataClassesKCZYSDataContext();
            }
        }
        public Table<T> GetTable()
        {
            return _dataContext.GetTable<T>();
        }

        public T Add(T t)
        {
            SetInstanceDefaultValue(t);
            _dataContext.GetTable<T>().InsertOnSubmit(t);
            _dataContext.SubmitChanges();
            return t;
        }

        public T Delete(T t)
        {
            var table = _dataContext.GetTable<T>();
            table.Attach(t);
            table.DeleteOnSubmit(t);
            _dataContext.SubmitChanges();
            return t;
        }

        public T Update(T t)
        {
            var table = _dataContext.GetTable<T>();
            table.Attach(t);
            _dataContext.SubmitChanges();
            return t;
        }

        public List<T> Query(T t,PropertyInfo[] availPropertyInfos)
        {
            var table = _dataContext.GetTable<T>();
            var predicate = PredicateBuilder.True<T>();
            PropertyInfo[] propertiesT = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in availPropertyInfos)
            {
                var isSearch = propertiesT.FirstOrDefault(s => s.Name == propertyInfo.Name);
                if (isSearch != null)
                {
                    var propertyValue = propertyInfo.GetValue(t, null);
                    if (propertyValue != null)
                    {
                        PropertyInfo pi = typeof(T).GetProperties().Single(o => o.Name == propertyInfo.Name);
                        object value = propertyValue;
                        predicate = predicate.AndExpress(p => EqualsOperate(pi, p, value));
                    }
                }
            }
            var dataSetList = table;
            var rst = dataSetList.Where(predicate.Compile()).ToList();
            return rst;
        }
        public static bool EqualsOperate<TEnity>(PropertyInfo pi, TEnity t, object value)
        {
            bool rst = false;
            var strValue = pi.GetValue(t, null);
            if (strValue != null)
            {
                rst = pi.GetValue(t, null).ToString().Equals(value.ToString());
            }
            return rst;
        }

        private T GetLinqInstance<TMD>(TMD tmd)
        {
            var assem = Assembly.GetAssembly(_dataContext.GetType());
            var targetName = tmd.GetType().Name.Replace("MD", "");
            var namespaceStr = _dataContext.GetType().Namespace;
            var targetPath = namespaceStr + "." + targetName;
            var newInstance = assem.CreateInstance(targetPath);
            return newInstance as T;
        }

        public TMD GetMDInstance<TMD>(TMD tmd) where TMD : class
        {
            var table = _dataContext.GetTable<T>();
            var predicate = PredicateBuilder.True<T>();
            PropertyInfo[] propertiesMD = tmd.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] availPropertyInfos = GetInstancePrimaryKeys().ToArray();
            foreach (var propertyInfo in availPropertyInfos)
            {
                var isSearch = propertiesMD.FirstOrDefault(s => s.Name == propertyInfo.Name);
                if (isSearch != null)
                {
                    var propertyValue = isSearch.GetValue(tmd, null);
                    if (propertyValue != null)
                    {
                        PropertyInfo pi = propertyInfo;
                        object value = propertyValue;
                        predicate = predicate.AndExpress(p => EqualsOperate(pi, p, value));
                    }
                }
            }
            var dataSetList = table;
            var rst = dataSetList.Where(predicate.Compile()).FirstOrDefault();
            SetInstanceProperties(tmd, rst);
            return tmd;
        }
        /// <summary>
        /// 获取当前该实体的主键值，可能多个
        /// </summary>
        /// <param name="obj">当前实体</param>
        /// <returns>属性值集合</returns>
        public static List<PropertyInfo> GetInstancePrimaryKeys(object obj)
        {
            var rst = new List<PropertyInfo>();
            PropertyInfo[] propertiesT = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in propertiesT)
            {
                var attrs = propertyInfo.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false) as System.Data.Linq.Mapping.ColumnAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    var columnAttribute = attrs[0];
                    if (columnAttribute.IsPrimaryKey)
                    {
                        rst.Add(propertyInfo);
                    }
                }
            }
            return rst;
        }
        /// <summary>
        /// 默认读取T主键
        /// </summary>
        /// <returns></returns>
        public static List<PropertyInfo> GetInstancePrimaryKeys()
        {
            var rst = new List<PropertyInfo>();
            PropertyInfo[] propertiesT = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in propertiesT)
            {
                var attrs = propertyInfo.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false) as System.Data.Linq.Mapping.ColumnAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    var columnAttribute = attrs[0];
                    if (columnAttribute.IsPrimaryKey)
                    {
                        rst.Add(propertyInfo);
                    }
                }
            }
            return rst;
        }
        /// <summary>
        /// 对象默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object SetInstanceDefaultValue(object obj)
        {
            PropertyInfo[] propertiesT = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in propertiesT)
            {
                var getVal = propertyInfo.GetValue(obj, null);
                var pType = propertyInfo.PropertyType;
                //确认是否为不满足条件的时间值
                if (pType == typeof(DateTime))
                {
                    if (Convert.ToDateTime(getVal) == DateTime.MinValue)
                    {
                        //sqlserver 最小单位
                        DateTime defDateTime = DateTime.Parse("1900-01-01");
                        propertyInfo.SetValue(obj, defDateTime, null);
                    }
                }
                if (getVal == null)
                {
                    //设置初始默认值

                    if (pType == typeof(string))
                    {
                        propertyInfo.SetValue(obj, "", null);
                    }
                    else if (pType == typeof(DateTime))
                    {
                        propertyInfo.SetValue(obj, DateTime.Now, null);
                    }
                    else if (pType == typeof(bool))
                    {
                        propertyInfo.SetValue(obj, false, null);
                    }
                    else if (pType == typeof(int))
                    {
                        propertyInfo.SetValue(obj, 0, null);
                    }
                    else if (pType == typeof(long))
                    {
                        propertyInfo.SetValue(obj, 0, null);
                    }
                    else if (pType == typeof(short))
                    {
                        propertyInfo.SetValue(obj, 0, null);
                    }
                    else if (pType == typeof(byte))
                    {
                        propertyInfo.SetValue(obj, 0, null);
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// 获取当前该实体的主键值，可能多个
        /// </summary>
        /// <param name="obj">当前实体</param>
        /// <returns>属性值集合</returns>
        public static List<PropertyInfo> GetMDPrimaryKeys(object obj)
        {
            
            var rst = new List<PropertyInfo>();
            PropertyInfo[] propertiesT = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in propertiesT)
            {
                var attrs = propertyInfo.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false) as System.Data.Linq.Mapping.ColumnAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    var columnAttribute = attrs[0];
                    if (columnAttribute.IsPrimaryKey)
                    {
                        rst.Add(propertyInfo);
                    }
                }
            }
            return rst;
        }
        /// <summary> 
        /// 对两个实体相同属性名进行赋值,相当于
        /// leftVal = rightVal,右操作符赋值给左操作符
        /// 实体的子类而非父类diferent from “SetProperties”
        /// </summary>
        /// <typeparam name="CRight">赋值类</typeparam>
        /// <typeparam name="CLeft">被赋值类</typeparam>
        /// <param name="rightVal">赋值实体</param>
        /// <param name="leftVal">被赋值实体</param>
        /// 如有疑问请与wy联系wangyang@bgrimm.com
        public static void SetInstanceProperties<CLeft, CRight>(CLeft leftVal, CRight rightVal)
        {
            if (rightVal == null || leftVal == null)
            {
                return;
            }
            PropertyInfo[] propertiesT = rightVal.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] propertiesL = leftVal.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            /*  if (propertiesT.Length != propertiesL.Length || propertiesL.Length == 0)
            {
                return ;
            }*/
            foreach (PropertyInfo itemL in propertiesL)
            {
                foreach (PropertyInfo itemT in propertiesT)
                {
                    if (itemL.Name == itemT.Name && itemL.PropertyType == itemT.PropertyType)
                    {
                        object value = itemT.GetValue(rightVal, null);
                        itemL.SetValue(leftVal, value, null);
                    }
                }
            }
        } //end of func
        /// <summary>
        /// 插入MD数据
        /// </summary>
        /// <typeparam name="TMD">模型类</typeparam>
        /// <param name="tmd">模型实体</param>
        /// <returns>删除结果</returns>
        public TMD AddMDInstance<TMD>(TMD tmd) where TMD : class
        {
            var t = GetLinqInstance(tmd);
            SetInstanceProperties(t,tmd);
            SetInstanceDefaultValue(t);
            Add(t);
            SetInstanceProperties(tmd, t);
            return tmd;
        }
        /// <summary>
        /// 删除MD数据
        /// </summary>
        /// <typeparam name="TMD">模型类</typeparam>
        /// <param name="tmd">模型实体</param>
        /// <returns>返回更新后的实体</returns>
        public bool DeleteMDInstance<TMD>(TMD tmd) where TMD : class
        {
            try
            {
                var rst = GetLinqInstanceByPrimaryKey(tmd);
                if (rst != null)
                {
                    _dataContext.GetTable<T>().DeleteOnSubmit(rst);
                    _dataContext.SubmitChanges();
                }
                SetInstanceProperties(tmd, rst);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public bool UpdateMDInstance<TMD>(TMD tmd) where TMD : class
        {
            try
            {
                var rst = GetLinqInstanceByPrimaryKey(tmd);
                if (rst != null)
                {
                    SetInstanceDefaultValue(tmd);
                    SetInstanceProperties(rst,tmd);
                    _dataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }
        /// <summary>
        /// 通过主键获取实体（必须为主键）
        /// </summary>
        /// <typeparam name="TMD">实体类型</typeparam>
        /// <param name="tmd">实体</param>
        /// <returns>linq实体</returns>
        private T GetLinqInstanceByPrimaryKey<TMD>(TMD tmd) where TMD : class
        {
            var table = _dataContext.GetTable<T>();
            var predicate = PredicateBuilder.True<T>();
            PropertyInfo[] propertiesMD = tmd.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] availPropertyInfos = GetInstancePrimaryKeys().ToArray();
            foreach (var propertyInfo in availPropertyInfos)
            {
                var isSearch = propertiesMD.FirstOrDefault(s => s.Name == propertyInfo.Name);
                if (isSearch != null)
                {
                    var propertyValue = isSearch.GetValue(tmd, null);
                    if (propertyValue != null)
                    {
                        PropertyInfo pi = propertyInfo;
                        object value = propertyValue;
                        predicate = predicate.AndExpress(p => EqualsOperate(pi, p, value));
                    }
                }
            }
            var dataSetList = table;
            var rst = dataSetList.Where(predicate.Compile()).FirstOrDefault();
            return rst;
        }
        public TMD GetMDInstance<TMD>(TMD tmd,string propertyName,object propertyValue) where TMD : class
        {
            var table = _dataContext.GetTable<T>();
            var predicate = PredicateBuilder.True<T>();
            PropertyInfo[] propertiesT = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var isSearch = propertiesT.FirstOrDefault(s => s.Name == propertyName);
            if (isSearch != null)
            {
                if (propertyValue != null)
                {
                    predicate = predicate.AndExpress(p => EqualsOperate(isSearch, p, propertyValue));
                }
            }
            
            var dataSetList = table;
            var rst = dataSetList.Where(predicate.Compile()).FirstOrDefault();
            SetInstanceProperties(tmd, rst);
            return tmd;
        }
        public List<TMD> GetMDInstanceList<TMD>(TMD tmd, string propertyName, object propertyValue) where TMD : class
        {
            var table = _dataContext.GetTable<T>();
            var predicate = PredicateBuilder.True<T>();
            PropertyInfo[] propertiesMD = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var isSearch = propertiesMD.FirstOrDefault(s => s.Name == propertyName);
            if (isSearch != null)
            {
                if (propertyValue != null)
                {
                    predicate = predicate.AndExpress(p => EqualsOperate(isSearch, p, propertyValue));
                }
            }

            var dataSetList = table;
            var rst = dataSetList.Where(predicate.Compile());
            return new List<TMD>(rst.OfType<TMD>());
        }
    }
}