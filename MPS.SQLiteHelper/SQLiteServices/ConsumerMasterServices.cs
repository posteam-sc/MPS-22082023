
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper
{
    public class ConsumerMasterServices : BaseService<ConsumerMaster>
    {
        public ConsumerMasterServices() : base(Storage.ConnectionString)
        {

        }
    }
}
