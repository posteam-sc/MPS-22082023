using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MeterController
{
 public   interface IMeter
    {
        void Save(Meter m);
        void SaveRange(List<Meter> meterList);
        void UpdateMeter(Meter m);
        void DeletedMeter(Meter m);
        void RemoveMeter(MeterHistory meterhistoryEntity);
        void UpdateMeterHistory(MeterHistory meterhistoryEntity);
        bool getMeterByMeterNo(string meterNo);
        MeterBox getMeterBoxByMeterBoxNo(string meterBoxNo);
        MeterType getMeterTypeByMeterTypeCode(string metertypecode);
        bool getMeterByMeterboxIdBoxSequence(string meterboxId, string boxSequence);
    }
}
