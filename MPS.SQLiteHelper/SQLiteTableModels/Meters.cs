
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.SQLiteHelper {
  public  class Meters {
        [DbColumn]
        public string mtr_id { get; set; }
        [DbColumn]
        public string mtr_model { get; set; }
        [DbColumn]
        public string mtr_make { get; set; }
        [DbColumn]
        public string mtr_create { get; set; }
        [DbColumn]
        public string mtr_inst { get; set; }
        [DbColumn]
        public string mtr_csm_id { get; set; }
        [DbColumn]
        public string mtr_pole { get; set; }
        
        }
    }
