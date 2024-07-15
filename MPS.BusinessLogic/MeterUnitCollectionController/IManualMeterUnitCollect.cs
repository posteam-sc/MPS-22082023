using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MeterUnitCollectionController
{
   public  interface IManualMeterUnitCollect
    {
        void Save(List<ManualMeterUnitCollect> mc);
    }
}
