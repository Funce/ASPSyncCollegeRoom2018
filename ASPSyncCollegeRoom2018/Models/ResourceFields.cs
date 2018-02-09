using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPSyncCollegeRoom2018.Models
{// Define the below class, whenever the multiple resources and grouping feature is used in your sample project.
    public class ResourceFieldsTest
    {
        public string Text { set; get; }
        public string Id { set; get; }
        public string GroupId { set; get; }
        public string Color { set; get; }
        public int WorkHourStart { set; get; }
        public int WorkHourEnd { set; get; }
        public List<string> CustomDays { set; get; }
    }
}
