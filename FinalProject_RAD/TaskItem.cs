using System;

namespace FinalProject_RAD
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
