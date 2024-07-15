using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.BillingController
{
  public  interface IBillCode7Layer
    {
        void Save(BillCode7Layer bc);
        void UpdateBillCode7Layer(BillCode7Layer bc);
        void DeleteBillCode7Layer(BillCode7Layer bc);
    }
}
