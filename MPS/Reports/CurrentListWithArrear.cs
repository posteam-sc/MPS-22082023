using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Reports
{
    public class CurrentListWithArrear

    {
       
        public string LedgerNo { get; set; }
        public int PageNo { get; set; }
        public int LineNo { get; set; }
        public string BillCodeNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal MeterFees { get; set; }
        public decimal CreditAmt { get; set; }
        public decimal AdditionalFees { get; set; }
        public decimal TotalFees { get; set; }

        public decimal StreetLightFees { get; set; }

    }
}
