
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
  public  class ConsumerMaster {
        [DbColumn]
        public string csm_id { get; set; }
        [DbColumn]
        public string csm_name { get; set; }
        [DbColumn]
        public string csm_village_code { get; set; }
        [DbColumn]
        public string csm_village_name { get; set; }
        [DbColumn]
        public string csm_address_code { get; set; }
        [DbColumn]
        public string csm_address_name { get; set; }
        [DbColumn]
        public string csm_meter_id { get; set; }
        [DbColumn]
        public string csm_gps_h { get; set; }
        [DbColumn]
        public string csm_gps_l { get; set; }
      
        }
    }
