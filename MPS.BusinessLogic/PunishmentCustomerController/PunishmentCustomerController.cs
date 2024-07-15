using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using MPS.BusinessLogic.ViewModels;
using System.Data.Objects;

namespace MPS.BusinessLogic.PunishmentCustomerController {
    public class PunishmentCustomerController : IPunishmentCustomerServices {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public List<PunishmentCustomerVM> GetPunishmentCustomer() {
            return mBMSEntities.PunishmentCustomers.Where(x => x.Active == true).Select(y => new PunishmentCustomerVM {
                PunishmentCustomerID = y.PunishmentCustomerID,
                CustomerCode = y.MeterBill.MeterUnitCollect.Customer.CustomerCode,
                CustomerName = y.MeterBill.MeterUnitCollect.Customer.CustomerNameInEng,
                //TownshipName = y.MeterBill.MeterUnitCollect.Customer.Township.TownshipNameInEng,
                QuarterName = y.MeterBill.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                ForMonth = y.ForMonth,
                PunishmentAmount = y.PunishmentAmount
                }).ToList();
            }

        public List<PunishmentCustomerVM> GetPunishmentCustomerByFromDateCustomerID(DateTime fromDate, DateTime toDate) {
            return mBMSEntities.PunishmentCustomers.Where(x => x.Active == true && EntityFunctions.TruncateTime(x.ForMonth) >= fromDate.Date && EntityFunctions.TruncateTime(x.ForMonth) <= toDate.Date).Select(y => new PunishmentCustomerVM {
                PunishmentCustomerID = y.PunishmentCustomerID,
                CustomerCode = y.MeterBill.MeterUnitCollect.Customer.CustomerCode,
                CustomerName = y.MeterBill.MeterUnitCollect.Customer.CustomerNameInEng,
                //TownshipName = y.MeterBill.MeterUnitCollect.Customer.Township.TownshipNameInEng,
                QuarterName = y.MeterBill.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                ForMonth = y.ForMonth,
                PunishmentAmount = y.PunishmentAmount
                }).ToList();
            }

        public bool Save(PunishmentCustomer punishmentcustomer) {
            try {
                mBMSEntities.PunishmentCustomers.Add(punishmentcustomer);
                mBMSEntities.SaveChanges();
                }catch(Exception ex) {
                return false;
                }
            return true;
            }
        }
    }
