using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class ItemApprovalBO
    {
        public enum TypeStatus
        {
            Iterator = 2,
            History = 1
        }

        public List<UsersMD> GetActiveUsers(int intItemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.ItemApproval
                            from user in dc.Users
                            where tb.ItemID == intItemID && tb.Type == (int)TypeStatus.Iterator
                            && tb.UserID == user.UserID
                            select user);
                List<UsersMD> lstAns = new List<UsersMD>();
                foreach (var objDb in linq)
                {
                    UsersMD objMem = new UsersMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
                return lstAns;
            }//end of using
        }//end of func


        public List<Models.UserCenterMD> GetUserCenter(UsersMD user,string Type)
        {
            List<UserCenterMD> lstAns = new List<UserCenterMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                //当前用户的iter和history
                var linq = (from tb in dc.ItemApproval
                            from hist in dc.ItemApproval
                            from _item in dc.Items
                            from attorney in dc.kczy_ProjectAttorney
                            where  tb.UserID == user.UserID && tb.ItemID == hist.ItemID && hist.ItemID == _item.ItemID && attorney.OrigID==_item.OrigID && attorney.IsDeleted!=true
                            orderby  tb.MyID descending,tb.ItemID descending
                            select new
                            {
                                MyID = hist.MyID,
                                ItemID = _item.ItemID,
                                ItemName = _item.MyName,
                                UserID = hist.UserID,
                                UserName = hist.UserName,
                                Type = hist.Type,
                                UpdateDate = hist.SubmitDate,
                                ResultText = hist.ResultText,
                                MyNote = hist.MyNote,
                                Specialty=attorney.Specialty,
                                OrigID=attorney.OrigID
                            }).Distinct().ToList();



                for (int i = 0; i < linq.Count; i++)
                {
                    if (Type.ToLower().Equals("current") && linq[i].UserID == user.UserID && linq[i].Type == (int)ItemApprovalBO.TypeStatus.Iterator
                        && !lstAns.Select(x => x.ItemID).Contains((int)linq[i].ItemID)
                        )
                    {
                        UserCenterMD usercenter = new UserCenterMD();
                        usercenter.ItemID = (int)linq[i].ItemID;
                        usercenter.ItemName = linq[i].ItemName;
                        usercenter.Text = linq[i].ResultText;
                        usercenter.SubmitDate = linq[i].UpdateDate.ToString("yyyy-MM-dd");
                        usercenter.History = linq[i].UserName + "," + linq[i].ResultText;
                        usercenter.Specialty = linq[i].Specialty;
                        usercenter.OrigID = linq[i].OrigID;
                        for (int j = linq.Count-1; j > 0; j--)
                        {
                            if ( j!=i && linq[j].ItemID == linq[i].ItemID  )
                            {
                                usercenter.History =  linq[j].UserName+":"+ linq[j].ResultText + "->" + usercenter.History;
                            }
                        }//end for
                        lstAns.Add(usercenter);
                    }//end if
                    else if (Type.ToLower().Equals("finish") &&  !lstAns.Select(x => x.ItemID).Contains((int)linq[i].ItemID) && linq[i].Type == (int)ItemApprovalBO.TypeStatus.History)
                    {
                        UserCenterMD usercenter = new UserCenterMD();
                        usercenter.ItemID = (int)linq[i].ItemID;
                        usercenter.ItemName = linq[i].ItemName;
                        usercenter.Text = linq[i].ResultText;
                        usercenter.SubmitDate = linq[i].UpdateDate.ToString("yyyy-MM-dd");
                        usercenter.History = linq[i].UserName+","+linq[i].ResultText;
                        usercenter.Specialty = linq[i].Specialty;
                        usercenter.OrigID = linq[i].OrigID;
                        for (int j = linq.Count-1; j > 0; j--)
                        {
                            if ( j!=i && linq[j].ItemID == linq[i].ItemID)
                            {
                                usercenter.History = linq[j].UserName+"," + linq[j].ResultText + "->" + usercenter.History;
                            }
                        }//end for
                        lstAns.Add(usercenter);
                    }
                }//end for


            }//end of using
            lstAns = lstAns.OrderByDescending(x => x.ItemID).ToList();
            return lstAns;
        }//end of func


    }
}