using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.ViewModels {
  public  class AdvanceMoneyCustomerVM {
        public string AdvanceMoneyCustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string   TownshipName { get; set; }
        public string QuarterName { get; set; }
        public string MeterBillID { get; set; }
        public Nullable<System.DateTime> ForMonth { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string CreatedUserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }

        public virtual MeterBill MeterBill { get; set; }
        }
    }
