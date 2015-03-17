using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataAccessLinq
{
    public partial class DataClassesXFormDataContext
    {
                //不要改动这个函数，删XFormDataClasses.designer.cs中的同名函数
        public DataClassesXFormDataContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString, mappingSource)
        {
            OnCreated();
        
        }
    }

}
