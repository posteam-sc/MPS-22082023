using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.MeterUnitCollectionController
{

    public class ManualMeterUnitCollectController : IManualMeterUnitCollect
    {
        MBMSEntities mbsEntities = new MBMSEntities();

        public void Save(List<ManualMeterUnitCollect> mc)
        {
            foreach (ManualMeterUnitCollect item in mc)
            {
                mbsEntities.ManualMeterUnit_DeleteByCustomerIDFromDateToDate(item.CustomerID, item.FromDate, item.ToDate);
                mbsEntities.ManualMeterUnitCollects.Add(item);
                mbsEntities.SaveChanges();
            }
        }

    }
}
