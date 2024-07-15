using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{

    public class BillDayController : IBillDay
    {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public void Save(BillDay bd)
        {
            mBMSEntities.BillDays.Add(bd);
            mBMSEntities.SaveChanges();
        }

        public void Update(BillDay bd)
        {
            //BillDay billDay = mBMSEntities.BillDays.Where(x => x.BillDayID == bd.BillDayID).SingleOrDefault();
            //billDay.BillDayGroupCode = bd.BillDayGroupCode;
            //billDay.ExpireDate = bd.ExpireDate;
            //billDay.GroupType = bd.GroupType;
            //billDay.UpdatedUserID = bd.UpdatedUserID;
            //billDay.UpdatedDate = DateTime.Now;
            //mBMSEntities.BillDays.AddOrUpdate(billDay); //requires using System.Data.Entity.Migrations;
            //mBMSEntities.SaveChanges();
        }

        public void Delete(BillDay bd)
        {
            //BillDay billDay = mBMSEntities.BillDays.Where(x => x.BillDayID == bd.BillDayID).SingleOrDefault();
            //billDay.Active =bd.Active;
            //billDay.DeletedDate = DateTime.Now;
            //billDay.DeletedUserID = bd.DeletedUserID;
            //mBMSEntities.SaveChanges();
        }
    }
}
