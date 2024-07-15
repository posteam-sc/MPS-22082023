using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPS.ViewModels;
namespace MPS.BusinessLogic.MeterBillCalculationController {
  public  interface IMeterBillCalculateServices {
        List<MeterUnitCollect> MeterUnitCollect(DateTime fromDate, DateTime toDate,string transformerID,string QuarterID);
        void MeterBillCalculate(List<MeterBill> _meterBill,DateTime fromDate,DateTime toDate);
        List<Transformer> GetTransformer();
        List<Township> GetTownship();
        List<Transformer> GetTransformerByQuarterID(string QuarterID);
        List<Quarter> GetQuarter();
        BillCode7Layer GetBillCode7LayerByBillCode(long billCodeNo);
       // int GetMeterLossessByMeterID(string meterID);
        List<BillCode7LayerDetail> GetBillCode7LayerDetailByBillCode7LayerID(string BillCode7LayerID);
        List<MeterBillInvoiceVM> GetmeterBillInvoices(DateTime fromDate, DateTime toDate,string TransformerID, string QuarterID,string CustomerID,string MeterBillCodeNo);
        bool UpdateMeterBill(MeterBill _meterbill);
        bool checkIsPaidStatusBeforeCalculate(DateTime fromDate, DateTime toDate,string transformerID);
        bool checkAdvanceMoneyCustomerListBeforeCalculate(DateTime fromDate, DateTime toDate);
        bool checkPunishmentCustomerListBeforeCalculate(DateTime fromDate, DateTime toDate); 
        }
    }
