using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{// The purpose of this project is toact as an organizer for anyone who is planning an event or party
    public class TODOController : Controller
    {
        private readonly GuestContext1 _TodoContext;

        public TODOController(GuestContext1 context)
        {
            _TodoContext = context;
        }
        public IActionResult TODO()
        {
            // grab information from the form
            TODO myTodo = new TODO();

            //properties from TimeLine.cs class             names in form   
            myTodo.taskname = Request.Form["taskname"].ToString();
            myTodo.description = Request.Form["description"].ToString();
            myTodo.taskdue = Request.Form["duetask"].ToString();

            // Insert into db

            _TodoContext.TODO.Add(myTodo);
            // Saving into the db
            _TodoContext.SaveChanges();
            // like quering into db 
            var todoList = _TodoContext.TODO.ToList();

            //   showing the query that we did
            return View(todoList);
        }
        public IActionResult Index()  {
           
            return View();
        }

        
    }
}