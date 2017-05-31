using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HW3PartyPlanning.Models
{
    public class EventsTodo
    {
        public string categoryName {get;set;}
        public double price{get; set;}
        public bool permit{get; set;}
        public bool available{get; set;}
        public int numAttending{get; set;}
        // public List <EventsTodo> myToDoList {get; set;}
    }
}