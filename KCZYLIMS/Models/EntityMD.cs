using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KCZYLIMS.BLL.Utility;

namespace KCZYLIMS.Models
{
    public class EntityMD : IEntityMD
    {
        public string SearchFlag { set; get; }
        #region 通用操作
        public TMD Insert<TLinqEntity, TMD>(TMD tmd) 
            where TLinqEntity : class
            where TMD:EntityMD
        {
            var helper = new EntityHelper<TLinqEntity>();
            return helper.AddMDInstance(tmd);
        }
        public bool Update<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD
        {
            var helper = new EntityHelper<TLinqEntity>();
            return helper.UpdateMDInstance(tmd);
        }
        public TMD GetInstance<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD
        {
            var helper = new EntityHelper<TLinqEntity>();
            return helper.GetMDInstance(tmd);
            
        }
        public bool Delete<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD
        {
            var helper = new EntityHelper<TLinqEntity>();
            return helper.DeleteMDInstance(tmd);
        }

        public List<TMD> GetMDInstanceList<TLinqEntity,TMD>(TMD tmd, string propertyName, object propertyValue)
            where TLinqEntity : class
            where TMD : EntityMD
        {
            var helper = new EntityHelper<TLinqEntity>();
            return helper.GetMDInstanceList(tmd,propertyName,propertyValue);
        }
        public TMD GetMDInstance<TLinqEntity, TMD>(TMD tmd, string propertyName, object propertyValue)
            where TLinqEntity : class
            where TMD : EntityMD
        {
            var helper = new EntityHelper<TLinqEntity>();
            return helper.GetMDInstance(tmd, propertyName, propertyValue);
        }

        public static List<EntityMD> EntitySearch<T>(T entity, List<EntityMD> entityBaseInfos) where T : EntityMD, new()
        {
            if (entity != null)
            {
                string[] searchArray = { };
                if (entity.SearchFlag != null)
                    searchArray = entity.SearchFlag.Split(',');
                var predicate = PredicateBuilder.True<T>();
                var type = entity.GetType();
                PropertyInfo[] propertiesT = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var propertyInfo in propertiesT)
                {
                    var isSearch = searchArray.FirstOrDefault(s => s == propertyInfo.Name);
                    if (isSearch != null)
                    {
                        var propertyValue = propertyInfo.GetValue(entity, null);
                        if (propertyValue != null)
                        {
                            PropertyInfo pi = type.GetProperties().Single(o => o.Name == propertyInfo.Name);
                            object value = propertyValue;
/*                            if (pi.PropertyType == typeof (Int32) || pi.PropertyType == typeof (int))
                            {
                                predicate = predicate.AndExpress(p => Equers(pi, p, value));
                            }
                            else
                            {
                                predicate = predicate.AndExpress(p => Contains(pi, p, value));
                            }*/
                            predicate = predicate.AndExpress(p => Contains(pi, p, value));
                        }
                    }
                }
                var dataSetList = entityBaseInfos;
                var cList = dataSetList.OfType<T>().ToList();
                var rst = cList.Where(predicate.Compile());
                return rst.OfType<EntityMD>().ToList();
            }
            return null;

        }
        /// <summary>
        /// 包含关系
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pi"></param>
        /// <param name="t"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool Contains<T>(PropertyInfo pi, T t, object value)
        {
            bool rst = false;
            var strValue = pi.GetValue(t, null);
            if (strValue != null)
            {
                rst = pi.GetValue(t, null).ToString().Contains(value.ToString());
            }
            return rst;
        }
        /// <summary>
        /// 直等关系
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pi"></param>
        /// <param name="t"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool Equers<T>(PropertyInfo pi, T t, object value)
        {
            bool rst = false;
            var strValue = pi.GetValue(t, null);
            if (strValue != null)
            {
                rst = pi.GetValue(t, null).ToString().Equals(value.ToString());
            }
            return rst;
        }
        #endregion
    }
} 