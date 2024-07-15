using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Reports
{
   public class AdvancedMoney
    {
        public DateTime ForMonth { get; set; }
        public string  LedgerNo { get; set; }
        public string  BillCodeNo { get; set; }
        public string CustomerCode { get; set; }
        public string  CustomerName { get; set; }
        public decimal   AdvancedMonthAmount { get; set; }
        
    }
}
