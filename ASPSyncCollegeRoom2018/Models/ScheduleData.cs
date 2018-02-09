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
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string Comments { get; set; }
        public DateTime ProgramStartTime { get; set; }
        public DateTime ProgramEndTime { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsRecurrence { get; set; }
        public string RecurrenceRule { get; set; }

        // Method that passes the Scheduler appointment data
        public List<ScheduleData> getSchedulerData()
        {
            List<ScheduleData> data = new List<ScheduleData> {
                new ScheduleData {
                    ProgramName = "Turtle Walk",
                    Comments = "Night out with turtles",
                    ProgramStartTime = new DateTime(2016, 6, 2, 3, 0, 0),
                    ProgramEndTime = new DateTime(2016, 6, 2, 4, 0, 0),
                    IsAllDay = true
                },
                new ScheduleData {
                    ProgramName = "Winter Sleepers",
                    Comments = "Long sleep during winter season",
                    ProgramStartTime = new DateTime(2016, 6, 3, 1, 0, 0),
                    ProgramEndTime = new DateTime(2016, 6, 3, 2, 0, 0)
                }
            };
            return data;
        }


    }
}
