
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
   public class VillageServices : BaseService<Villages> {
        public VillageServices() :base(Storage.ConnectionString){

            }
        }
    }
