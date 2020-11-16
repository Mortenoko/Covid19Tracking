using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Covid19Tracking
{
    [Table("Municipality")]
    class Municipality
    {
        [Key] 
        public int MunicipalityID { get; set; }
        public string mName { get; set; }
        public string NationName { get; set; }
        public int Population { get; set; }
        public Nation nation { get; set; }
        public List<Location> locations { get; set; }
        public List<Citizen> citizens { get; set; }
        public List<TestCenter> testCenters { get; set; }

    }
}
