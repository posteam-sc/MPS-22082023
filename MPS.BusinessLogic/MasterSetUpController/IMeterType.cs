using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
  public  interface IMeterType
    {
        void Save(MeterType mt);
        void UpdateMeterType(MeterType mt);
        void DeleteMeterType(MeterType mt);
    }
}
