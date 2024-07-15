using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.MasterSetUpController
{
    interface ITownship
    {
        void Save(Township t);
        void UpdatedByTownshipID(Township t);
        void DeletedByTownship(Township t);
    }
}
