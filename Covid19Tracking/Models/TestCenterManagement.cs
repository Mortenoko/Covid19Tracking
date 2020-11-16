using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19Tracking
{
    [Table("Testcentermanagement")]
    class TestCenterManagement
    {
        public TestCenter testCenter { get; set; }

        [Key]
        public int phoneNum { get; set; }
        public string email { get; set; }
        public int manageID { get; set; }
    }
}
