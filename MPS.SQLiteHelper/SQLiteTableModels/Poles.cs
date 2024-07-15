
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
 public   class Poles {
        [DbColumn]
        public string pol_id { get; set; }
        [DbColumn]
        public string pol_gps_x { get; set; }
        [DbColumn]
        public string pol_gps_y { get; set; }
        [DbColumn]
        public string pol_etc1 { get; set; }
        [DbColumn]
        public string pol_etc4 { get; set; }//reference with village code ,will be use as village code
        }
    }
