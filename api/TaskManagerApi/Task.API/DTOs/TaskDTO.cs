using System;

namespace Tasks.API.DTOs
{
    public class TaskDTO
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Assignment { get; set; }
    }
}
