using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
   public interface IPurnishmentRule
    {
        void Save(PunishmentRule r);
        void UpdatePurnishmentRule(PunishmentRule r);
        void DeletePrunishmentRule(PunishmentRule r);
    }
}
