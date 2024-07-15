using MBMS.DAL;
using MPS.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.PunishmentCustomerController {
  public  interface IPunishmentCustomerServices {
        bool Save(PunishmentCustomer punishmentcustomer);
        List<PunishmentCustomerVM> GetPunishmentCustomer();
        List<PunishmentCustomerVM> GetPunishmentCustomerByFromDateCustomerID(DateTime fromDate, DateTime toDate);
        }
    }
