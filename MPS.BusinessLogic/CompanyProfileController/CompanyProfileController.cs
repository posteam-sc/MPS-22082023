using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.CompanyProfileController
{
    public class CompanyProfileController : ICompanyProfile
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteCompanyProfile(CompanyProfile cp)
        {
            CompanyProfile companyProfile = mBMSEntities.CompanyProfiles.Where(x => x.CompanyProfileID == cp.CompanyProfileID).SingleOrDefault();
            companyProfile.Active = cp.Active;
            companyProfile.DeletedDate = DateTime.Now;
            companyProfile.DeletedUserID = cp.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(CompanyProfile cp)
        {
            mBMSEntities.CompanyProfiles.Add(cp);
            mBMSEntities.SaveChanges();
        }

        public void UpdateCompanyProfile(CompanyProfile cp)
        {
            CompanyProfile companyProfile = mBMSEntities.CompanyProfiles.Where(x => x.CompanyProfileID == cp.CompanyProfileID).SingleOrDefault();
            companyProfile.CompanyName =cp.CompanyName;
            companyProfile.AddressEng =cp.AddressEng;
            companyProfile.AddressMM =cp.AddressMM;
            companyProfile.PhoneNumber = cp.PhoneNumber;
            companyProfile.LogoURL = cp.LogoURL;
            companyProfile.CompanyEmail = cp.CompanyEmail;
            companyProfile.CompanyWebsite = cp.CompanyWebsite;
            companyProfile.UpdatedUserID = cp.UpdatedUserID;
            companyProfile.UpdatedDate = cp.UpdatedDate;
            mBMSEntities.CompanyProfiles.AddOrUpdate(companyProfile); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
