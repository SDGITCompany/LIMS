using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KCZYLIMS.Models;

namespace KCZYLIMS.BLL
{
    public interface IEntityBO
    {
        long Insert(EntityMD instance);
        bool Update(EntityMD instance);
        EntityMD GetInstance(EntityMD instance);
        bool Delete(EntityMD instance);
    }
}
