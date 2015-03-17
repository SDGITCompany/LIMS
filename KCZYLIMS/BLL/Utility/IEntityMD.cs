using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KCZYLIMS.Models;

namespace KCZYLIMS.BLL.Utility
{
    interface IEntityMD
    {
        TMD Insert<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD;
        bool Update<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD;
        TMD GetInstance<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD;
        bool Delete<TLinqEntity, TMD>(TMD tmd)
            where TLinqEntity : class
            where TMD : EntityMD;
    }
}
