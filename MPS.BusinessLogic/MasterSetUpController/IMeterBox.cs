using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
public    interface IMeterBox
    {
        void Save(MeterBox mb);
        void UpdateMeterBox(MeterBox mb);
        void DeleteMeterBox(MeterBox mb);
    }
}
