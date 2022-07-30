using Microsoft.AspNetCore.Mvc;
using projectapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Controllers
{
    [ApiController]
    public class DataController : Controller
    {
        
        private readonly IRepos repository;
        
        public DataController(IRepos repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllData()
        {
            var students = repository.GetData();
            return Ok(students);
        }

    }
}
