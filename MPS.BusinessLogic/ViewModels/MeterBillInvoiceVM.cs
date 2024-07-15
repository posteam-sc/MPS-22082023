using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.ViewModels {
 public class MeterBillInvoiceVM {
        public string MeterBillID { get; set; }
        public string MeterBillCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string TransformerName { get; set; }
        public string QuarterName { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public System.DateTime LastBillPaidDate { get; set; }
        public Nullable<decimal> ServicesFees { get; set; }
        public decimal MeterFees { get; set; }
        public Nullable<decimal> StreetLightFees { get; set; }
        public decimal TotalFees { get; set; }
        public decimal UsageUnit { get; set; }
        public decimal CurrentMonthUnit { get; set; }
        public decimal PreviousMonthUnit { get; set; }
        public Nullable<decimal> AdvanceMoney { get; set; }
        public Nullable<decimal> CreditAmount { get; set; }
        public bool isPaid { get; set; }
        public string Remark { get; set; }
        public string CustomerAddress { get; set; }
        public string MeterNo { get; set; }
        public string BillCodeNo { get; set; }
        public string Barcode { get; set; }
        public decimal RecivedAmount { get; set; }
        public Nullable<decimal> HorsePowerFees { get; set; }
        public Nullable<decimal> AdditionalFees1 { get; set; }
        public Nullable<decimal> AdditionalFees2 { get; set; }
        public Nullable<decimal> AdditionalFees3 { get; set; }
        public string MeterUnitCollectID { get; set; }
        public bool Active { get; set; }
        public string CreatedUserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        }
    }
