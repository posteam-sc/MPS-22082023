using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class MeterTypeController : IMeterType
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteMeterType(MeterType mt)
        {
            MeterType metertype = mBMSEntities.MeterTypes.Where(x => x.MeterTypeID == mt.MeterTypeID).SingleOrDefault();
            metertype.Active = mt.Active;
            metertype.DeletedDate = DateTime.Now;
            metertype.DeletedUserID = mt.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(MeterType mt)
        {
            mBMSEntities.MeterTypes.Add(mt);
            mBMSEntities.SaveChanges();
        }

        public void UpdateMeterType(MeterType mt)
        {
            MeterType meterType = mBMSEntities.MeterTypes.Where(x => x.MeterTypeID == mt.MeterTypeID).SingleOrDefault();
            meterType.MeterTypeCode = mt.MeterTypeCode;
            meterType.MeterTypeDescription = mt.MeterTypeDescription;
            meterType.UpdatedUserID = mt.UpdatedUserID;
            meterType.UpdatedDate = DateTime.Now;
            mBMSEntities.MeterTypes.AddOrUpdate(meterType); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
