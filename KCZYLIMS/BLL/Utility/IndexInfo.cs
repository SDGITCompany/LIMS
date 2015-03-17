using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.BLL.Utility
{
    public class IndexInfo
    {
        public string EntityName { set; get; }
        public int PageSize { set; get; }
        public int CurPage { set; get; }
        public int FirstPage { set; get; }
        public int LastPage { set; get; }
        public int NextPage { set; get; }
        public int TotalPage { set; get; }
        public int TotalCount { set; get; }
    }

    public class IndexInfoUserSearch : IndexInfo
    {
        public UserSearchParam EntityName { get; set; }
    }
    public class UserSearchParam
    {
        public int GroupID { get; set; }
        public string UserName { get; set; }
    }
}