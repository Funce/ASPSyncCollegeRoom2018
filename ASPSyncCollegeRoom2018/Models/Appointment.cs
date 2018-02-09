using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPSyncCollegeRoom2018.Models
{
    public class Appointment
    {
        [Key]
        public string Text { set; get; }
        public string Id { set; get; }
    }
}
