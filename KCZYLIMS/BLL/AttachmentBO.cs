using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlDataAccess;
using KCZYLIMS.Models;
using KCZYLIMS.BLL.Utility;
using System.IO;


namespace KCZYLIMS.BLL
{
    public class AttachmentBO : EntityBO
    {
        /// <summary>
        /// 根据RelateID和Type获取附件的list
        /// </summary>
        /// <param name="RelatedID"></param>
        /// <param name="RelatedType"></param>
        /// <returns></returns>
        public List<AttachmentMD> GetInstancesByRelatedID(int RelatedID, int RelatedType)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            { 
                var linq = from tb in dc.Attachment
                           where tb.RelatedID == RelatedID && tb.RelatedType == RelatedType
                           select tb;
                List<AttachmentMD> lstAns = new List<AttachmentMD>();
                foreach (var obj in linq)
                {
                    AttachmentMD objMem = new AttachmentMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    lstAns.Add(objMem);
                }

                return lstAns;
            }//end of using
        }//end of func

        /// <summary>
        /// 批量插入操作
        /// </summary>
        /// <param name="lstAns"></param>
        public void InsertInstances(List<AttachmentMD> lstAns)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {                
                foreach (var objMem in lstAns)
                {
                    var objDb = new Attachment();
                    EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                    dc.Attachment.InsertOnSubmit(objDb);
                    dc.SubmitChanges();
                }//end foreach                
            }//end of using
        }//end of func


        /// <summary>
        /// 批量更新附件
        /// </summary>
        /// <param name="lstAns"></param>
        /// <returns></returns>
        public bool UpdateInstances(List<AttachmentMD> lstAns)
        {
            bool blnAns = false;
            try
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                foreach (var objMem in lstAns)
                {
                    //MyID等于是数据库中还没有，要插入的
                    if (objMem.AttachID == 0 && !string.IsNullOrEmpty(objMem.MyName))
                    {
                        Attachment objDb = new Attachment();
                        EntityHelper<object>.SetInstanceDefaultValue(objMem);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.Attachment.InsertOnSubmit(objDb);
                        dc.SubmitChanges();
                    }
                    else if (objMem.AttachID > 0) //更新的情况
                    {
                        Attachment objDb = dc.Attachment.FirstOrDefault(x => x.AttachID == objMem.AttachID);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.SubmitChanges();
                    }
                }
                blnAns = true;
            }
            catch (Exception ex)
            {
                blnAns = false;
            }
            return blnAns;
        }//end of func


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AttachID"></param>
        /// <param name="md"></param>
        /// <returns></returns>
        public byte[] GetFileContent(int AttachID, AttachmentMD md)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var attObj = dc.Attachment.FirstOrDefault(x => x.AttachID == AttachID);
            if (attObj != null)
            {
                EntityHelper<object>.SetInstanceProperties(md, attObj);
                var filePath = attObj.OrigPath;
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Dispose();
                return bytes;
            }
            else 
            {
                return null;
            }
        }//end of func




    }//end of func
}