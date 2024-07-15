
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
   public class NodeMeterServices : BaseService<NodeMeter> {
        public NodeMeterServices() :base(Storage.ConnectionString){

            }
        }
    }
