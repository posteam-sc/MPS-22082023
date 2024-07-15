using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController {
  public  interface IUser {
        void Save(User u);
        void UpdateUserID(User u);
        void DeleteUserID(User u);
        }
    }
