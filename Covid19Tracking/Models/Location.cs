using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19Tracking
{

    [Table("Location")]
    class Location
    {
        [Key] 
        public string Addr { get; set; }
        public Municipality municipality { get; set; }
        public List<CitizenLocation> citizenLocations { get; set; }
        public int MunicipalityID { get; set; }
    }
}
