using System;

namespace FinalProject_RAD
{
    public class TaskItem
    {
        public int Id { get; set; }            // Primary key (auto-incremented by the database)
        public string Description { get; set; } // Task description
        public string Category { get; set; }    // Task category
        public DateTime StartDate { get; set; } // Start date of the task
        public DateTime EndDate { get; set; }   // End date of the task
        public string Status { get; set; }      // Task status (e.g., Pending, Complete)
    }
}
