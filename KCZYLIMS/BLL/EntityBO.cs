using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;

namespace KCZYLIMS.BLL
{
    public class EntityBO : IEntityMD
    {
        
        public TMD Insert<TLinqEntity, TMD>(TMD tmd) where TLinqEntity : class where TMD : EntityMD
        {
            return tmd.Insert<TLinqEntity, TMD>(tmd);
        }

        public bool Update<TLinqEntity, TMD>(TMD tmd) where TLinqEntity : class where TMD : EntityMD
        {
            return tmd.Update<TLinqEntity, TMD>(tmd);
        }

        public TMD GetInstance<TLinqEntity, TMD>(TMD tmd) where TLinqEntity : class where TMD : EntityMD
        {
            return tmd.GetInstance<TLinqEntity, TMD>(tmd);
        }

        public bool Delete<TLinqEntity, TMD>(TMD tmd) where TLinqEntity : class where TMD : EntityMD
        {
            return tmd.Delete<TLinqEntity, TMD>(tmd);
        }
    }
}