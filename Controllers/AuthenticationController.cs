using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comisionesapi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace comisionesapi.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        public AuthenticationController(ILogger<AuthenticationController> _logger)
        {
            this.logger = _logger;
        }
        public Response Login(LoginDto loginDto)
        {
            return new Response
            {
                Status = 0,
                Message = "correcto",
                data = null
            };
        }
    }
}