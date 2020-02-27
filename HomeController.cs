using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIapp.Service;

// for this project, only need to service layer since there is no data invole
namespace WebAPIapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ITestService _testService;

        public HomeController(ITestService testService)
        {
            _testService = testService;
        }

        // GET api/values/4
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Calc
        [HttpPost]
        [Route("getscore")]
        public async Task<ActionResult> GetScore()
        {
            //using StreamReader to make API accept non JSon data as passing in raw text
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var stringinput = await reader.ReadToEndAsync();
                var output = _testService.StreamProcessingScore(stringinput);
                return Ok(output);
            }
        }

    }



}