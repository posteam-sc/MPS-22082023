using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.ViewModels {
  public  class PunishmentCustomerVM {
      
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string   TownshipName { get; set; }
        public string QuarterName { get; set; }
        public string PunishmentCustomerID { get; set; }
        public System.DateTime ForMonth { get; set; }
        public string PunishmentRuleID { get; set; }
        public string MeterBillID { get; set; }
        public decimal PunishmentAmount { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string CreatedUserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }

        public virtual MeterBill MeterBill { get; set; }
        public virtual PunishmentRule PunishmentRule { get; set; }
        }
    }
