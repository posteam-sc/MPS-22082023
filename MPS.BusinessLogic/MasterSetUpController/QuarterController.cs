using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class QuarterController : IQuarter
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteByQuarter(Quarter q)
        {
            Quarter quarter = mBMSEntities.Quarters.Where(x => x.QuarterID == q.QuarterID).SingleOrDefault();
            quarter.Active = q.Active;
            quarter.DeletedDate = DateTime.Now;
            quarter.DeletedUserID = q.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Quarter q)
        {
            mBMSEntities.Quarters.Add(q);
            mBMSEntities.SaveChanges();
        }

        public void UpdateByQuarter(Quarter q)
        {
            Quarter quarter = mBMSEntities.Quarters.Where(x => x.QuarterID == q.QuarterID).SingleOrDefault();
            quarter.QuarterCode =  q.QuarterCode;
            quarter.QuarterNameInEng = q.QuarterNameInEng;
            quarter.QuarterNameInMM = q.QuarterNameInMM;
            quarter.Address = q.Address;
            quarter.TownshipID = q.TownshipID;
            quarter.UpdatedUserID = q.UpdatedUserID;
            quarter.UpdatedDate = q.UpdatedDate;
            mBMSEntities.Quarters.AddOrUpdate(quarter); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
