using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Reports
{
  public class BillCodeSummaryList
    {
        public string BillCodeNo { get; set; }
        public string CustomerCount { get; set; }
        public decimal TotalFees { get; set; }
        public decimal CreditAmt { get; set; }
        public decimal AdvancedMoney { get; set; }
        public decimal AdditionalFees { get; set; }
    }
}
