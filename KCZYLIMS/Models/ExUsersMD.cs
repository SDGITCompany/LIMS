using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{
    public partial class ChangeUsersMD
    {
        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public string ConfirmOldPassword { get; set; }
    }
}