
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
 public   class Villages {
        [DbColumn]
        public string vlg_code { get; set; }
        [DbColumn]
        public string vlg_name { get; set; }
        [DbColumn]
        public string vlg_address { get; set; }
        [DbColumn]
        public string vlg_value { get; set; }
        }
    }
