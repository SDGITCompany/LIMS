using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{
    public class UserCenterMD
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string SubmitDate { get; set; }
        public string Text { get; set; }
        public string History { get; set; }
        public int Specialty { get; set; }
        public int OrigID { get; set; }
    }
}