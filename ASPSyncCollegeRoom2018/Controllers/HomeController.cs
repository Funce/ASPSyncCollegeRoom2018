#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASPSyncCollegeRoom2018.Data;
using Microsoft.AspNetCore.Mvc;
using ASPSyncCollegeRoom2018.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.Models;
using Color = System.Drawing.Color;

namespace ASPSyncCollegeRoom2018.Controllers
{
    public class HomeController : Controller
    {

        //https://help.syncfusion.com/aspnet-core/schedule/getting-started

        //CRUD https://help.syncfusion.com/aspnet-core/datamanager/getting-started

        public CalendarDBContext _dbContext { get; }

        public HomeController(CalendarDBContext DBContext)
        {
            _dbContext = DBContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<ResourceFields> Rooms = new List<ResourceFields>();
            Rooms.Add(new ResourceFields { Text = "ROOM 1", Id = "1", Color = "#cb6bb2" });
            Rooms.Add(new ResourceFields { Text = "ROOM 2", Id = "2", Color = Color.AntiqueWhite.ToString() });
            Rooms.Add(new ResourceFields { Text = "ROOM 3", Id = "3", Color = Color.Beige.ToString() });
            Rooms.Add(new ResourceFields { Text = "ROOM 4", Id = "4", Color = "#56ca85" });
            Rooms.Add(new ResourceFields { Text = "ROOM 5", Id = "5", Color = "#cb6bb2" });
            Rooms.Add(new ResourceFields { Text = "ROOM 6", Id = "6", Color = "#56ca85" });
            Rooms.Add(new ResourceFields { Text = "ROOM 7", Id = "7", Color = "#cb6bb2" });
            Rooms.Add(new ResourceFields { Text = "ROOM 8", Id = "8", Color = "#56ca85" });

            List<ResourceFields> Owners = new List<ResourceFields>();


            //https://help.syncfusion.com/aspnet-core/schedule/resources
            for (int i = 1; i < Rooms.Count + 1; i++)
            {
                string RoomCount = i.ToString();


                Owners.Add(new ResourceFields { Text = "Ultimate 1", Id = "2", GroupId = RoomCount, Color = "#f8a398" });
                Owners.Add(new ResourceFields { Text = "Ultimate 2", Id = "3", GroupId = RoomCount, Color = "#7499e1" });
                Owners.Add(new ResourceFields { Text = "Ultimate 3", Id = "5", GroupId = RoomCount, Color = "#f8a398" });
                Owners.Add(new ResourceFields { Text = "Ultimate 4", Id = "6", GroupId = RoomCount, Color = "#7499e1" });
                Owners.Add(new ResourceFields { Text = "Counselling 1", Id = "1", GroupId = RoomCount, Color = "#ffaa00" });
                Owners.Add(new ResourceFields { Text = "Counselling 2", Id = "4", GroupId = RoomCount, Color = "#ffaa00" });

            }

            List<Categorize> categorizeValue = new List<Categorize>();
            categorizeValue.Add(new Categorize { text = "Ultimate 1", id = 1, color = "#43b496", fontColor = "#ffffff" });
            categorizeValue.Add(new Categorize { text = "Ultimate 2", id = 2, color = "#7f993e", fontColor = "#ffffff" });
            categorizeValue.Add(new Categorize { text = "Ultimate 3", id = 3, color = "#cc8638", fontColor = "#ffffff" });
            categorizeValue.Add(new Categorize { text = "Ultimate 4", id = 4, color = "#ab54a0", fontColor = "#ffffff" });
            categorizeValue.Add(new Categorize { text = "Counselling 1", id = 5, color = "#dd654e", fontColor = "#ffffff" });
            categorizeValue.Add(new Categorize { text = "Yellow Category", id = 6, color = "#d0af2b", fontColor = "#ffffff" });

            ViewBag.categorizeData = categorizeValue;


            //  ViewBag.CalDBpath = new DataSource();
            ViewBag.Grouping = new List<String>() { "Rooms" };
            ViewBag.RoomData = Rooms;
            ViewBag.OwnerData = Owners;

            DateTime now = DateTime.Now;
            ViewBag.CurrentDate = now.Date;








            return View();
        }
        //return all saved appointmemts to calendar
        public IEnumerable<ScheduleData> GetData()
        {
            List<ScheduleData> data = _dbContext.ScheduleData.Take(500).ToList();

            ViewBag.GetData = data; //not used
            return data;
        }

        public List<ScheduleData> Batch([FromBody] EditParams param)
        {
            if (param.action == "insert" || (param.action == "batch" && (param.added.Count > 0))) // this block of code will execute while inserting the appointments
            {
                ScheduleData appoint = new ScheduleData();
                object result;
                if (param.action == "insert")
                {
                    var value = param.value;
                    foreach (var fieldName in value.GetType().GetProperties())
                    {
                        var newName = fieldName.ToString().Split(null);
                        if (newName[1] == "Id") result = (_dbContext.ScheduleData.ToList().Count > 0 ? _dbContext.ScheduleData.ToList().Max(p => p.Id) : 1) + 1;
                        else if (newName[1] == "StartTime" || newName[1] == "EndTime") result = Convert.ToDateTime(fieldName.GetValue(value));
                        else result = fieldName.GetValue(value);
                        fieldName.SetValue(appoint, result);
                    }
                    _dbContext.ScheduleData.Add(appoint);
                }
                else
                {
                    foreach (var item in param.added.Select((x, i) => new { Value = x, Index = i }))
                    {
                        var value = item.Value;
                        foreach (var fieldName in value.GetType().GetProperties())
                        {
                            var newName = fieldName.ToString().Split(null);
                            if (newName[1] == "Id") result = (_dbContext.ScheduleData.ToList().Count > 0 ? _dbContext.ScheduleData.ToList().Max(p => p.Id) : 1) + 1 + item.Index;
                            else if (newName[1] == "StartTime" || newName[1] == "EndTime") result = Convert.ToDateTime(fieldName.GetValue(value));
                            else result = fieldName.GetValue(value);
                            fieldName.SetValue(appoint, result);
                        }
                        _dbContext.ScheduleData.Add(appoint);
                    }
                }
                _dbContext.SaveChanges();
            }
            if ((param.action == "remove") || (param.action == "batch" && (param.deleted.Count > 0))) // this block of code will execute while removing the appointment
            {
                if (param.action == "remove")
                {
                    ScheduleData app = _dbContext.ScheduleData.Where(c => c.Id == Convert.ToInt32(param.key)).FirstOrDefault();
                    if (app != null) _dbContext.ScheduleData.Remove(app);
                }
                else
                {
                    foreach (var a in param.deleted)
                    {
                        var app = _dbContext.ScheduleData.ToList().Where(c => c.Id == Convert.ToInt32(a.Id)).FirstOrDefault();
                        if (app != null) _dbContext.ScheduleData.Remove(app);
                    }
                }
                _dbContext.SaveChanges();
            }
            if (param.action == "update" || (param.action == "batch" && (param.changed.Count > 0))) // this block of code will execute while updating the appointment
            {
                var value = param.action == "update" ? param.value : param.changed[0];
                var filterData = _dbContext.ScheduleData.Where(c => c.Id == Convert.ToInt32(value.Id));
                if (filterData.Count() > 0)
                {
                    ScheduleData appoint = _dbContext.ScheduleData.Single(A => A.Id == Convert.ToInt32(value.Id));
                    appoint.StartTime = Convert.ToDateTime(value.StartTime);
                    appoint.EndTime = Convert.ToDateTime(value.EndTime);
                    appoint.Subject = value.Subject;
                    appoint.Recurrence = value.Recurrence;
                    appoint.AllDay = value.AllDay;
                    appoint.RecurrenceRule = value.RecurrenceRule;
                    appoint.RoomId = value.RoomId;
                    appoint.OwnerId = value.OwnerId;
                }
                _dbContext.SaveChanges();
            }

            List<ScheduleData> data = GetData().ToList();//  _dbContext.ScheduleData.Take(500).ToList();
            return data;
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
