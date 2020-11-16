using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19Tracking
{
    class CitizenLocation
    {
        [Key]
        public string SSN { get; set; }
        public string Addr { get; set; }

        public DateTime date { get; set; }
        public Location location;
        public Citizen citizen;
        
    }
}
