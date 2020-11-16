using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Covid19Tracking
{
    [Table("Testcenter")]
    class TestCenter
    {
        [Key] public int CenterId { get; set; }
        public string Hours { get; set; }
        public List<TestedAt> testedAts { get; set; }
        public TestCenterManagement testCenterMangement;
        public Municipality municipality;
        public int MunicipalityID { get; set; }


    }
}
