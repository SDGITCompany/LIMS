using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KCZYLIMS.Models;

namespace KCZYLIMS.BLL.Utility
{
    public interface ISelector
    {
       string ConvertToJavaScriptArray(List<EntityMD> lstAns, string strStates);
       List<EntityMD> GetSelfAndDescendantChildrenGroups(List<long> lstInGroupID);
       List<EntityMD> GetDescendantChildrenGroups(int myID);
    }
}
