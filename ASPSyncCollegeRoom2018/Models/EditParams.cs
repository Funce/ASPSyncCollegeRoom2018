using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPSyncCollegeRoom2018.Models
{
    public class EditParams
    {
        public string key { get; set; }
        public string action { get; set; }
        public List<ScheduleData> added { get; set; }
        public List<ScheduleData> changed { get; set; }
        public List<ScheduleData> deleted { get; set; }
        public ScheduleData value { get; set; }


    }
}
