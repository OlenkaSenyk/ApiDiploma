﻿namespace api_diploma.Data.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public int UserId { get; set;}
        public User User { get; set; }
    }
}
