using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using MPS.BusinessLogic.ViewModels;
using System.Data.Objects;

namespace MPS.BusinessLogic.AdvanceMoneyCustomerController {
    public class AdvanceMoneyCustomerController : IAdvanceMoneyCustomerServices {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public List<AdvanceMoneyCustomerVM> GetAdvanceMoneyCustomer() {
            return mBMSEntities.AdvanceMoneyCustomers.Where(x => x.Active == true).Select(y=>new AdvanceMoneyCustomerVM {
                AdvanceMoneyCustomerID=y.AdvanceMoneyCustomerID,
                CustomerCode=y.MeterBill.MeterUnitCollect.Customer.CustomerCode,
                CustomerName=y.MeterBill.MeterUnitCollect.Customer.CustomerNameInEng,
                TownshipName=y.MeterBill.MeterUnitCollect.Customer.Quarter.Township.TownshipNameInEng,
                QuarterName=y.MeterBill.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                ForMonth=y.ForMonth,
                Amount=y.AdvanceMonthAmount
                }).ToList();
            }

        public List<AdvanceMoneyCustomerVM> GetAdvanceMoneyCustomerByFromDateCustomerID(DateTime fromDate, DateTime toDate) {
            return mBMSEntities.AdvanceMoneyCustomers.Where(x => x.Active == true && EntityFunctions.TruncateTime(x.ForMonth) >= fromDate.Date && EntityFunctions.TruncateTime(x.ForMonth) <= toDate.Date).Select(y => new AdvanceMoneyCustomerVM {
                AdvanceMoneyCustomerID = y.AdvanceMoneyCustomerID,
                CustomerCode = y.MeterBill.MeterUnitCollect.Customer.CustomerCode,
                CustomerName = y.MeterBill.MeterUnitCollect.Customer.CustomerNameInEng,
                TownshipName = y.MeterBill.MeterUnitCollect.Customer.Quarter.Township.TownshipNameInEng,
                QuarterName = y.MeterBill.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                ForMonth = y.ForMonth,
                Amount = y.AdvanceMonthAmount
                }).ToList();

             
            }

        public bool SaveAdvanceMoney(AdvanceMoneyCustomer advanceMoneyCustomer) {
            try {
                mBMSEntities.AdvanceMoneyCustomers.Add(advanceMoneyCustomer);
                mBMSEntities.SaveChanges();
                }catch(Exception ex) {
                return false;
                }
            return true;
            }
        }
    }
