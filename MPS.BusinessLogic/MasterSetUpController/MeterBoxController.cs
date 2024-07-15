using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class MeterBoxController : IMeterBox
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteMeterBox(MeterBox mb)
        {
            MeterBox meterBox = mBMSEntities.MeterBoxes.Where(x => x.MeterBoxID == mb.MeterBoxID).SingleOrDefault();
            meterBox.Active = mb.Active;
            meterBox.DeletedDate = DateTime.Now;
            meterBox.DeletedUserID = mb.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(MeterBox mb)
        {
            mBMSEntities.MeterBoxes.Add(mb);
            mBMSEntities.SaveChanges();
        }

        public void UpdateMeterBox(MeterBox mb)
        {
            MeterBox meterBox = mBMSEntities.MeterBoxes.Where(x => x.MeterBoxID == mb.MeterBoxID).SingleOrDefault();
            meterBox.MeterBoxCode = mb.MeterBoxCode;
            meterBox.Box = mb.Box;
            meterBox.MeterBoxName = mb.MeterBoxName;            
            meterBox.PoleID = mb.PoleID;
            meterBox.UpdatedUserID = mb.UpdatedUserID;
            meterBox.UpdatedDate = DateTime.Now;
            mBMSEntities.MeterBoxes.AddOrUpdate(meterBox); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
