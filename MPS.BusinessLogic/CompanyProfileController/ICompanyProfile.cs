using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.CompanyProfileController
{
    public interface ICompanyProfile
    {
        void Save(CompanyProfile cp);
        void UpdateCompanyProfile(CompanyProfile cp);
        void DeleteCompanyProfile(CompanyProfile cp);
    }
}
