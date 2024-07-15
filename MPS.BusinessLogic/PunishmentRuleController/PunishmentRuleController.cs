using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.PunishmentRuleController {
    public class PunishmentRuleController : IPunishmentRuleServices {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public PunishmentRule getPunishment(string punishmentRuleCode) {
            return mBMSEntities.PunishmentRules.Where(x => x.Active == true && x.PunishmentCode == punishmentRuleCode).SingleOrDefault();
            }

        public List<PunishmentRule> getPunishmentList() {
            return mBMSEntities.PunishmentRules.Where(x => x.Active == true).OrderByDescending(y=>y.Amount).ToList();
        }
    }
    }
