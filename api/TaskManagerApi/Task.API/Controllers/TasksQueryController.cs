using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tasks.API.DTOs;
using System.Linq;
using System;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksQueryController : ControllerBase
    {
        private readonly ILogger<TasksQueryController> _logger;

        public TasksQueryController(ILogger<TasksQueryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TaskDTO> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new TaskDTO
            {
                DueDate = DateTime.Now.AddDays(index),
                Title = $"Title {index}",
                Assignment = $"Assignment {index}",
                Status = $"Status  {index}"
            }).ToArray();
        }
    }
}
