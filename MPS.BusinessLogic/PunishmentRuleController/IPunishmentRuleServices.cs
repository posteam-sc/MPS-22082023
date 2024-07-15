using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.PunishmentRuleController {
   public interface IPunishmentRuleServices {
        PunishmentRule getPunishment(string punishmentRuleCode);
        List<PunishmentRule> getPunishmentList();
        }
    }
