using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class PurnishmentRuleController : IPurnishmentRule
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
       

        public void DeletePrunishmentRule(PunishmentRule r)
        {
            PunishmentRule punishmentRule = mBMSEntities.PunishmentRules.Where(x => x.PunishmentRuleID == r.PunishmentRuleID).SingleOrDefault();
            punishmentRule.Active = r.Active;
            punishmentRule.DeletedDate = DateTime.Now;
            punishmentRule.DeletedUserID = r.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(PunishmentRule r)
        {
            mBMSEntities.PunishmentRules.Add(r);
            mBMSEntities.SaveChanges();
        }


        public void UpdatePurnishmentRule(PunishmentRule r)
        {
            PunishmentRule punishmentRule = mBMSEntities.PunishmentRules.Where(x => x.PunishmentRuleID == r.PunishmentRuleID).SingleOrDefault();
            punishmentRule.PunishmentCode = r.PunishmentCode;    
            punishmentRule.ExceedMonth = r.ExceedMonth;
            punishmentRule.Amount = r.Amount;
            punishmentRule.UpdatedUserID = r.UpdatedUserID;
            punishmentRule.UpdatedDate = DateTime.Now;
            mBMSEntities.PunishmentRules.AddOrUpdate(punishmentRule); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
