using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.LedgerController
{
 public    interface ILedger
    {
        void Save(Ledger l);
        void UpdateLedger(Ledger l);
        void DeleteLedger(Ledger l);
    }
}
