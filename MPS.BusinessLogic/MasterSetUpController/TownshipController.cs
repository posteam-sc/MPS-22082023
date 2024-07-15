using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
  public  class TownshipController : ITownship
    {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public void DeletedByTownship(Township t)
        {
            Township township = mBMSEntities.Townships.Where(x => x.TownshipID == t.TownshipID).SingleOrDefault();
            township.Active =t.Active ;
            township.DeletedDate = DateTime.Now;
            township.DeletedUserID = t.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Township t)
        {
            mBMSEntities.Townships.Add(t);
            mBMSEntities.SaveChanges();
        }

        public void UpdatedByTownshipID(Township t)
        {
            Township township = mBMSEntities.Townships.Where(x => x.TownshipID == t.TownshipID).SingleOrDefault();
            township.TownshipNameInEng = t.TownshipNameInEng;
            township.TownshipNameInMM = t.TownshipNameInMM;
            township.TownshipCode = t.TownshipCode;
            township.UpdatedUserID = t.UpdatedUserID;
            township.UpdatedDate = DateTime.Now;
            mBMSEntities.Townships.AddOrUpdate(township); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
