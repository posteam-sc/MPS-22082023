
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
  public  class NodeMeter {
        [DbColumn]
        public string nod_id { get; set; }
        [DbColumn]
        public int nod_comm { get; set; }
        [DbColumn]
        public string nod_csm_id { get; set; }
        [DbColumn]
        public string nod_csm_name { get; set; }
        [DbColumn]
        public string nod_village_code { get; set; }
        [DbColumn]
        public string nod_village_name { get; set; }
        [DbColumn]
        public string nod_address_code { get; set; }
        [DbColumn]
        public string nod_address_name { get; set; }
        [DbColumn]
        public double nod_bill_month { get; set; }
        [DbColumn]
        public string nod_bill_from { get; set; }
        [DbColumn]
        public string nod_bill_to { get; set; }
        [DbColumn]
        public double nod_pres_eng { get; set; }
        [DbColumn]
        public int nod_status { get; set; }
        [DbColumn]
        public string nod_model { get; set; }
        [DbColumn]
        public string nod_gps_l { get; set; }
        [DbColumn]
        public string nod_gps_h { get; set; }

        }
    }
