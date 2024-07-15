using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
   public interface IQuarter
    {
        void Save(Quarter q);
        void UpdateByQuarter(Quarter q);
        void DeleteByQuarter(Quarter q);
    }
}
