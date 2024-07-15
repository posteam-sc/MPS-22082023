using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Objects;

namespace MPS.BusinessLogic.MeterUnitCollectionController {
    public class MeterUnitCollectionController : IMeterUnitCollections {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void MeterUnitProces(MeterUnitCollect meterUnitCollect) {
            mBMSEntities.MeterUnitCollects.Add(meterUnitCollect);
            mBMSEntities.SaveChanges();
            }
        public void MeterUnitCollectionsProces(List<MeterUnitCollect> meterUnitCollect) {
            foreach(MeterUnitCollect item in meterUnitCollect) {                    
                mBMSEntities.MeterUnitCollect_DeleteByCustomerIDFromDateToDate(item.CustomerID, item.FromDate, item.ToDate);
                mBMSEntities.MeterUnitCollects.Add(item);
                mBMSEntities.SaveChanges();
                }
          
            }
        }
    }
