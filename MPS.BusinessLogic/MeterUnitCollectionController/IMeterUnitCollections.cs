using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MeterUnitCollectionController {
 public   interface IMeterUnitCollections {
        void MeterUnitProces(MeterUnitCollect meterUnitCollect);
        void MeterUnitCollectionsProces(List<MeterUnitCollect> meterUnitCollect);
        }
    }
