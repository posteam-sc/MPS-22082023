using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MeterController
{
    public class MeterController : IMeter
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeletedMeter(Meter m)
        {
            Meter meter = mBMSEntities.Meters.Where(x => x.MeterID == m.MeterID).SingleOrDefault();
            meter.Active = false;
            meter.DeletedDate = DateTime.Now;
            meter.DeletedUserID = m.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public MeterBox getMeterBoxByMeterBoxNo(string meterBoxNo)
        {
            return mBMSEntities.MeterBoxes.Where(x => x.Active == true && x.MeterBoxCode == meterBoxNo).SingleOrDefault();
        }

        public bool getMeterByMeterboxIdBoxSequence(string meterboxId, string boxSequence)
        {
            return mBMSEntities.Meters.Any(x => x.MeterBoxID == meterboxId && x.MeterBoxSequence == boxSequence && x.Active == true);
        }

        public bool getMeterByMeterNo(string meterNo)
        {
            return mBMSEntities.Meters.Any(x => x.Active == true && x.MeterNo == meterNo);
        }

        public MeterType getMeterTypeByMeterTypeCode(string metertypecode)
        {
            return mBMSEntities.MeterTypes.Where(x => x.Active == true && x.MeterTypeCode == metertypecode).SingleOrDefault();
        }

        public void RemoveMeter(MeterHistory meterhistoryEntity)
        {
            mBMSEntities.MeterHistories.Add(meterhistoryEntity);
            mBMSEntities.SaveChanges();
        }
       
        public void Save(Meter m)
        {
            mBMSEntities.Meters.Add(m);
            mBMSEntities.SaveChanges();
        }

        public void SaveRange(List<Meter> meterList)
        {
            foreach (Meter m in meterList)
            {
                this.Save(m);
            }
        }

        public void UpdateMeter(Meter m)
        {
            Meter meter = mBMSEntities.Meters.Where(x => x.MeterID == m.MeterID).SingleOrDefault();
            meter.MeterNo = m.MeterNo;
            meter.MeterTypeID = m.MeterTypeID;
            meter.Model = m.Model;
            meter.InstalledDate = m.InstalledDate;
            meter.Losses = m.Losses;
            meter.Multiplier = m.Multiplier;
            meter.HP = m.HP;
            meter.iMax = m.iMax;
            meter.BasicCurrent = m.BasicCurrent;
            meter.AvailableYear = m.AvailableYear;
            meter.Class = m.Class;
            meter.Constant = m.Constant;
            meter.Phrase = m.Phrase;
            meter.Wire = m.Wire;
            meter.Voltage = m.Voltage;
            meter.AMP = m.AMP;
            meter.Standard = m.Standard;
            meter.Status = m.Status;
            meter.KVA = m.KVA;
            meter.ManufactureBy = m.ManufactureBy;
            meter.Frequency = m.Frequency;
            meter.MeterBoxID = m.MeterBoxID;
            meter.MeterBoxSequence = m.MeterBoxSequence;
            meter.UpdatedUserID = m.UpdatedUserID;
            meter.UpdatedDate = m.UpdatedDate;
            mBMSEntities.Meters.AddOrUpdate(meter); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }

        public void UpdateMeterHistory(MeterHistory entity)
        {
            MeterHistory meterhistory = mBMSEntities.MeterHistories.Where(x => x.CustomerID == entity.CustomerID && x.MeterHistoryID == entity.MeterHistoryID).SingleOrDefault();
            meterhistory.MeterID = entity.MeterID;
            mBMSEntities.MeterHistories.AddOrUpdate(meterhistory); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
