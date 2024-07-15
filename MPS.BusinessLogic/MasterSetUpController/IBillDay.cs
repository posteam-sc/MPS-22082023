using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
  public   interface IBillDay
    {
        void Save(BillDay bd);
        void Update(BillDay bd);
        void Delete(BillDay bd);

    }
}
