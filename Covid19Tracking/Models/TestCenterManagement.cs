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
        [Key]
        public int phoneNum { get; set; }
        public TestCenter testCenter { get; set; }
        public string email { get; set; }
        public string centerName { get; set; }

    }
}
