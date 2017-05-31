using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using HW3PartyPlanning.Models;

namespace HW3PartyPlanning.Controllers
{
    public class RealList:Controller
    {
        public IActionResult Index()
        {
            // Console.WriteLine("Testing my EventList Controller.");
            // List <EventsTodo> myToDoList = new List <EventsTodo>();
            // myToDoList.Add( new EventsTodo(){categoryName="VenueBooking", price=4299.00, numAttending = 250, available = true, });
            // myToDoList.Add( new EventsTodo(){categoryName="caterer", price= 8820.00,numAttending = 250, available = true,});
            return View();
        }

    }
}