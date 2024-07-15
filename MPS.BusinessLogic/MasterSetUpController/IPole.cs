using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
 public   interface IPole
    {
        void Save(Pole p);
        void UpdatePole(Pole p);
        void DeletePole(Pole p);
    }
}
