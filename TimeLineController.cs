using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Models;


namespace mvc.Controllers
{ // The purpose of this project is toact as an organizer for anyone who is planning an event or party
    public class TimeLineController : Controller
    {

        private readonly GuestContext1 _context;

        public TimeLineController(GuestContext1 context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Index2()
        {
            // grab information from the form
            TimeLine t = new TimeLine();

            //properties from TimeLine.cs class             names in form   
            t.datetime = Request.Form["eventTime"].ToString();
            t.description = Request.Form["eventDescript"].ToString();
            
            

            // Insert into db

            _context.TimeLine.Add(t);
            // Saving into the db
            _context.SaveChanges();
            // like quering into db 
            var timeline = _context.TimeLine.ToList();

            //   showing the query that we did
            return View(timeline);
        }











    }
}