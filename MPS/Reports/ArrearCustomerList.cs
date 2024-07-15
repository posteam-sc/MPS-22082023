using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Reports
{
   public  class ArrearCustomerList
    {
        public DateTime LastBillPaidDate { get; set; }
        public string LedgerNo { get; set; }
        public string BillCodeNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal CreditAmt { get; set; }
    }
}
