using MBMS.DAL;
using MPS.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.AdvanceMoneyCustomerController {
   public interface IAdvanceMoneyCustomerServices {
        bool SaveAdvanceMoney(AdvanceMoneyCustomer advanceMoneyCustomer);
        List<AdvanceMoneyCustomerVM> GetAdvanceMoneyCustomer();
        List<AdvanceMoneyCustomerVM> GetAdvanceMoneyCustomerByFromDateCustomerID(DateTime fromDate,DateTime toDate);
        }
    }
