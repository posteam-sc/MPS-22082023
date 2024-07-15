using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
 public   interface IRole
    {
        void Save(Role r);
        void UpdateByRoleID(Role r);
        void DeletedByRoleID(Role r);
    }
}
