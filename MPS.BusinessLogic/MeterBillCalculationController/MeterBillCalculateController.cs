using System;
using System.Collections.Generic;
using System.Linq;
using MBMS.DAL;
using System.Data.Objects;
using MPS.ViewModels;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MeterBillCalculationController
{
    public class MeterBillCalculateController : IMeterBillCalculateServices
    {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public bool checkAdvanceMoneyCustomerListBeforeCalculate(DateTime fromDate, DateTime toDate)
        {
            return mBMSEntities.AdvanceMoneyCustomers.Any(x => EntityFunctions.TruncateTime(x.ForMonth) >= fromDate.Date && EntityFunctions.TruncateTime(x.ForMonth) <= toDate.Date);
        }

        public bool checkIsPaidStatusBeforeCalculate(DateTime fromDate, DateTime toDate, string transformerID)
        {
            return mBMSEntities.MeterBills.Any(x => x.isPaid == true && EntityFunctions.TruncateTime(x.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(x.InvoiceDate) <= toDate.Date && x.MeterUnitCollect.TransformerID == transformerID);
        }

        public bool checkPunishmentCustomerListBeforeCalculate(DateTime fromDate, DateTime toDate)
        {
            return mBMSEntities.PunishmentCustomers.Any(x => EntityFunctions.TruncateTime(x.ForMonth) >= fromDate.Date && EntityFunctions.TruncateTime(x.ForMonth) <= toDate.Date);
        }

        public BillCode7Layer GetBillCode7LayerByBillCode(long billCodeNo)
        {
            BillCode7Layer _billCode7Layer = mBMSEntities.BillCode7Layer.Where(x => x.BillCode7LayerNo == billCodeNo && x.Active == true).SingleOrDefault();
            return _billCode7Layer;
        }

        public List<BillCode7LayerDetail> GetBillCode7LayerDetailByBillCode7LayerID(string BillCode7LayerID)
        {
            List<BillCode7LayerDetail> _billcode7LayerDetialList = mBMSEntities.BillCode7LayerDetail.Where(x => x.BillCode7LayerID == BillCode7LayerID && x.Active == true).ToList();
            return _billcode7LayerDetialList;
        }


        public List<MeterBillInvoiceVM> GetmeterBillInvoices(DateTime fromDate, DateTime toDate, string TransformerID, string QuarterID, string CustomerID, string MeterBillCodeNo)
        {
            List<MeterBillInvoiceVM> data = new List<MeterBillInvoiceVM>();
            //get data by Quarter and Township id with date range
            if (TransformerID !="0" && QuarterID!="0")
            {
                data = (from mb in mBMSEntities.MeterBills
                        join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
                        join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
                        where (mb.InvoiceDate >= fromDate.Date && mb.InvoiceDate <= toDate.Date) &&
                        mbu.TransformerID == TransformerID  &&
                        custo.QuarterID == QuarterID && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            QuarterName = custo.Quarter.QuarterNameInEng,
                            TransformerName = mbu.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
           else if (TransformerID != "0" && QuarterID != "0" && string.IsNullOrWhiteSpace(CustomerID))
            {
                data = (from mb in mBMSEntities.MeterBills
                        join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
                        join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
                        where (mb.InvoiceDate >= fromDate.Date && mb.InvoiceDate <= toDate.Date) &&
                        mbu.TransformerID == TransformerID &&
                        custo.QuarterID == QuarterID&&custo.CustomerID==CustomerID && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            QuarterName = custo.Quarter.QuarterNameInEng,
                            TransformerName = mbu.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            else if (!string.IsNullOrEmpty(CustomerID) && QuarterID!="0")
            {
                data = (from mb in mBMSEntities.MeterBills
                        join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
                        join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
                        where EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date
                        && (custo.CustomerID== CustomerID
                        && custo.QuarterID == QuarterID) && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            QuarterName = custo.Quarter.QuarterNameInEng,
                            TransformerName = mbu.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            //else if (TransformerID!="0" || QuarterID != "0")
            //{
            //    data = (from mb in mBMSEntities.MeterBills
            //            join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
            //            join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
            //            where EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date
            //            && (custo.Transformer.TransformerID == TransformerID
            //            || custo.QuarterID == QuarterID) && mb.isPaid == false
            //            select new MeterBillInvoiceVM
            //            {
            //                MeterBillID = mb.MeterBillID,
            //                CustomerCode = custo.CustomerCode,
            //                CustomerName = custo.CustomerNameInEng,
            //                QuarterName = custo.Quarter.QuarterNameInEng,
            //                TransformerName = mbu.Transformer.TransformerName,
            //                MeterBillCode = mb.MeterBillCode,
            //                InvoiceDate = mb.InvoiceDate,
            //                LastBillPaidDate = mb.LastBillPaidDate,
            //                ServicesFees = mb.ServicesFees,
            //                MeterFees = mb.MeterFees,
            //                StreetLightFees = mb.StreetLightFees,
            //                TotalFees = mb.TotalFees,
            //                UsageUnit = mb.UsageUnit,
            //                CurrentMonthUnit = mb.CurrentMonthUnit,
            //                PreviousMonthUnit = mb.PreviousMonthUnit,
            //                AdvanceMoney = mb.AdvanceMoney,
            //                CreditAmount = mb.CreditAmount,
            //                Remark = mb.Remark,
            //                isPaid = mb.isPaid,
            //                RecivedAmount = mb.RecivedAmount,
            //                HorsePowerFees = mb.HorsePowerFees,
            //                AdditionalFees1 = mb.AdditionalFees1,
            //                AdditionalFees2 = mb.AdditionalFees2,
            //                AdditionalFees3 = mb.AdditionalFees3,
            //                MeterUnitCollectID = mb.MeterUnitCollectID,
            //                Active = mb.Active,
            //                CreatedUserID = mb.CreatedUserID,
            //                CreatedDate = mb.CreatedDate
            //            }
            // ).ToList();
            //}
            //get data by customer id (code or name) and date range)
            else if (!string.IsNullOrEmpty(CustomerID))
            {
                data = (from mb in mBMSEntities.MeterBills
                        join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
                        join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
                        where EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date
                        && custo.CustomerID == CustomerID && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            QuarterName = custo.Quarter.QuarterNameInEng,
                            TransformerName = mbu.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            else if (TransformerID!="0")
            {
                data = (from mb in mBMSEntities.MeterBills
                        join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
                        join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
                        where EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date
                        && custo.TransformerID == TransformerID && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            QuarterName = custo.Quarter.QuarterNameInEng,
                            TransformerName = mbu.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            else if (QuarterID!="0")
            {
                data = (from mb in mBMSEntities.MeterBills
                        join mbu in mBMSEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbu.MeterUnitCollectID
                        join custo in mBMSEntities.Customers on mbu.CustomerID equals custo.CustomerID
                        where EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date
                        && custo.QuarterID == QuarterID && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            QuarterName = custo.Quarter.QuarterNameInEng,
                            TransformerName = mbu.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            //get data by meter bill code no and data range
            else if (fromDate.Date != DateTime.MinValue && toDate.Date != DateTime.MinValue && MeterBillCodeNo != string.Empty)
            {
                data = (from mb in mBMSEntities.MeterBills
                        where (EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date)
                       && mb.MeterBillCode == MeterBillCodeNo && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerName = mb.MeterUnitCollect.Customer.CustomerNameInEng,
                            QuarterName = mb.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                            TransformerName = mb.MeterUnitCollect.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            CustomerCode = mb.MeterUnitCollect.Customer.CustomerCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            //get all data by date range
            else
            {
                data = (from mb in mBMSEntities.MeterBills
                        where EntityFunctions.TruncateTime(mb.InvoiceDate) >= fromDate.Date
                        && EntityFunctions.TruncateTime(mb.InvoiceDate) <= toDate.Date && mb.isPaid == false
                        select new MeterBillInvoiceVM
                        {
                            MeterBillID = mb.MeterBillID,
                            CustomerCode = mb.MeterUnitCollect.Customer.CustomerCode,
                            CustomerName = mb.MeterUnitCollect.Customer.CustomerNameInEng,
                            QuarterName = mb.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                            TransformerName = mb.MeterUnitCollect.Transformer.TransformerName,
                            MeterBillCode = mb.MeterBillCode,
                            InvoiceDate = mb.InvoiceDate,
                            LastBillPaidDate = mb.LastBillPaidDate,
                            ServicesFees = mb.ServicesFees,
                            MeterFees = mb.MeterFees,
                            StreetLightFees = mb.StreetLightFees,
                            TotalFees = mb.TotalFees,
                            UsageUnit = mb.UsageUnit,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            AdvanceMoney = mb.AdvanceMoney,
                            CreditAmount = mb.CreditAmount,
                            Remark = mb.Remark,
                            isPaid = mb.isPaid,
                            RecivedAmount = mb.RecivedAmount,
                            HorsePowerFees = mb.HorsePowerFees,
                            AdditionalFees1 = mb.AdditionalFees1,
                            AdditionalFees2 = mb.AdditionalFees2,
                            AdditionalFees3 = mb.AdditionalFees3,
                            MeterUnitCollectID = mb.MeterUnitCollectID,
                            Active = mb.Active,
                            CreatedUserID = mb.CreatedUserID,
                            CreatedDate = mb.CreatedDate
                        }
             ).ToList();
            }
            return data;
        }

        public List<Quarter> GetQuarter()
        {
            return mBMSEntities.Quarters.Where(x => x.Active == true).ToList();
        }

        public List<Township> GetTownship()
        {
            return mBMSEntities.Townships.Where(x => x.Active == true).ToList();
        }

        public List<Transformer> GetTransformer()
        {
            return mBMSEntities.Transformers.Where(x => x.Active == true).ToList();
        }

        public List<Transformer> GetTransformerByQuarterID(string QuarterID)
        {
            return mBMSEntities.Transformers.Where(x => x.Active == true && x.QuarterID == QuarterID).ToList();
        }

        public void MeterBillCalculate(List<MeterBill> meterBillList, DateTime fromDate, DateTime toDate)
        {
            //mBMSEntities.MeterBill_DeleteByFromDateToDate(fromDate, toDate);
            foreach (MeterBill item in meterBillList)
            {
                mBMSEntities.MeterBills.Add(item);
                mBMSEntities.SaveChanges();
            }
        }

        public List<MeterUnitCollect> MeterUnitCollect(DateTime fromDate, DateTime toDate, string transformerID, string QuarterID)
        {
            List<MeterUnitCollect> data;
            if (!string.IsNullOrEmpty(transformerID))
            {
                data = mBMSEntities.MeterUnitCollects.Where(x => EntityFunctions.TruncateTime(x.FromDate) >= fromDate.Date && EntityFunctions.TruncateTime(x.ToDate) <= toDate.Date && x.TransformerID == transformerID).ToList();
            }
            else
            {
                data = mBMSEntities.MeterUnitCollects.Where(x => EntityFunctions.TruncateTime(x.FromDate) >= fromDate.Date && EntityFunctions.TruncateTime(x.ToDate) <= toDate.Date).ToList();
            }
            return data;
        }

        public bool UpdateMeterBill(MeterBill _meterbill)
        {
            try
            {
                mBMSEntities.MeterBills.AddOrUpdate(_meterbill);
                mBMSEntities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
