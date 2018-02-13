using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASPSyncCollegeRoom2018.Models
{
    public class ScheduleData
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public bool AllDay { get; set; }
        public bool Recurrence { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string RecurrenceRule { get; set; }
        public string RoomId { get; set; }
        public string OwnerId { get; set; }



        // Method that passes the Scheduler appointment data



    }
}
