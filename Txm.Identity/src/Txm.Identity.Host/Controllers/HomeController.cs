using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Txm.Identity.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("a")]
        public async Task<IActionResult> A()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        [Authorize(Policy = "Policy1")]
        [Route("b")]
        public async Task<IActionResult> B()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        [Authorize(Policy = "Policy2")]
        [Route("c")]
        public async Task<IActionResult> C()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [Authorize(Roles = "admin")]
        [Route("d")]
        public async Task<IActionResult> D()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [Authorize(Roles = "admin22")]
        [Route("e")]
        public async Task<IActionResult> E()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [Authorize(Roles = "abc")]
        [Route("f")]
        public async Task<IActionResult> F()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        [Route("z")]
        public async Task<IActionResult> Z()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
