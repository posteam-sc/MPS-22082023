using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.LedgerController
{
    public class LedgerController : ILedger
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteLedger(Ledger l)
        {
            Ledger ledger = mBMSEntities.Ledgers.Where(x => x.LedgerID == l.LedgerID).SingleOrDefault();
            ledger.Active = l.Active;
            ledger.DeletedDate = DateTime.Now;
            ledger.DeletedUserID = l.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Ledger l)
        {
            mBMSEntities.Ledgers.Add(l);
            mBMSEntities.SaveChanges();
        }

        public void UpdateLedger(Ledger l)
        {
            Ledger ledger = mBMSEntities.Ledgers.Where(x => x.LedgerID == l.LedgerID).SingleOrDefault();
            ledger.LedgerCode =l.LedgerCode;
            ledger.BookCode = l.BookCode ;
            ledger.TransformerID = l.TransformerID;
            ledger.UpdatedUserID = l.UpdatedUserID;
            ledger.UpdatedDate = l.UpdatedDate;
            mBMSEntities.Ledgers.AddOrUpdate(ledger); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
