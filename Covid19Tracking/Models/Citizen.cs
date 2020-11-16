using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19Tracking
{
    [Table("Citizen")]
    class Citizen
    {
        [Key]
        public int age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int SSN { get; set; }
        public List<TestedAt> testedAts { get; set; }
        public List<CitizenLocation> citizenLocations { get; set; }
        public Municipality municipality { get; set; }
        public int MunicipalityID { get; set; }

    }
}
