using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet("notfound")] //Get:baseUrl/api/buggy/notfound
        public IActionResult GetNotFoundResponse()
        {
            //logic
            return NotFound();
        }

        [HttpGet("badrequest")] //Get:baseUrl/api/buggy/badrequest
        public IActionResult BadRequestResponse()
        {
            //logic
            return BadRequest();
        }

        [HttpGet("validationerror/{id}")] //Get:baseUrl/api/buggy/validationerror
        public IActionResult ValidationErrorResponse(int id)
        {
            return BadRequestResponse();
        }

        [HttpGet("servererror")] //Get:baseUrl/api/buggy/servererror
        public IActionResult ServerError()
        {
            throw new Exception();
        }

        [HttpGet("unauthorized")] //Get:baseUrl/api/buggy/unauthorized
        public IActionResult GetUnauthorizedResponse()
        {
            //logic
            return Unauthorized();
        }
    }
}