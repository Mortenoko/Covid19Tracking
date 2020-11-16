using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Covid19Tracking
{
    class TestedAt
    {
        public string status { get; set; }
        public DateTime date { get; set; }
        public string result { get; set; }
        public Citizen citizen;
        public TestCenter testCenter;

        [Key]
        public string SSN { get; set; }
        public string centerName { get; set; }
    }
}
