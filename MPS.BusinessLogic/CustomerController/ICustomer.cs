using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.CustomerController
{
 public   interface ICustomer
    {
        void Save(Customer c);
        void UpdateCustomer(Customer c);
        void DeleteCustomer(Customer c);
        void SaveRange(List<Customer> customerList);
        bool GetCustomerCustomerCode(string CustomerCode);
        bool GetCustomerBySMDNo(string SMDNo);
        bool GetCustomerByMeterID(string MeterID);
        Township GetTownshipByTownshipCode(string townshipCode);
        Quarter GetQuarterByQarterCode(string QarterCode);
        Meter GetMeterByQarterNo(string MeterNo);
        Ledger GetLedgerByLedgerCode(int LedgerCode);
        BillCode7Layer GetBillCode7LayerByBillCodeNo(long BillCodeNo);
        }
}
