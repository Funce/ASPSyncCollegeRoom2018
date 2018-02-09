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
using Microsoft.AspNetCore.Mvc;
using ASPSyncCollegeRoom2018.Models;
using Syncfusion.JavaScript.Models;
using Color = System.Drawing.Color;

namespace ASPSyncCollegeRoom2018.Controllers
{
    public class HomeController : Controller
    {
        //https://help.syncfusion.com/aspnet-core/schedule/getting-started

        //CRUD https://help.syncfusion.com/aspnet-core/datamanager/getting-started


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

           ;

            ViewBag.Grouping = new List<String>() { "Rooms", "Owners" };
            ViewBag.RoomData = Rooms;
            ViewBag.OwnerData = Owners;
            ViewBag.appointments = new ScheduleData().getSchedulerData();
            DateTime now = DateTime.Now;
            ViewBag.CurrentDate = now.Date;
            return View();
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
