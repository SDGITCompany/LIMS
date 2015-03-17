using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlDataAccess
{
    public partial class DataClassesKCZYSDataContext : System.Data.Linq.DataContext
    {
         //不要改动这个函数，删XFormDataClasses.designer.cs中的同名函数
        public DataClassesKCZYSDataContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString, mappingSource)
        {
            OnCreated();
        
        }
    }
}
