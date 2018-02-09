using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPSyncCollegeRoom2018.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.JavaScript.Models;
using Appointment = ASPSyncCollegeRoom2018.Models.Appointment;
using Cells = ASPSyncCollegeRoom2018.Models.Cells;

namespace ASPSyncCollegeRoom2018.Data
{
    public class CalendarDBContext : DbContext
    {

        public CalendarDBContext(DbContextOptions options) : base(options)
        {
        }

        protected CalendarDBContext()
        {
        }


        public DbSet<Appointment> Appointment { get; set; }
        //   public DbSet<Cells> Cells { get; set; }
        public DbSet<ScheduleData> ScheduleData { get; set; }
        //  public DbSet<ResourceFields> ResourceFields { get; set; }
        //  public DbSet<ErrorViewModel> ErrorViewModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=cal.db");
        }


    }
}
