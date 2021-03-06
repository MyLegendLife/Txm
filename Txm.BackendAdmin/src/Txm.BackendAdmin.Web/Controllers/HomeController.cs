using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Txm.BackendAdmin.Web.Models;

namespace Txm.BackendAdmin.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Apollo")]
        public ActionResult<IEnumerable<string>> Apollo()
        {
            var title = _configuration.GetValue<string>("consul");

            return new string[] { "value1", "value2", title };
        }

        [HttpGet]
        [Authorize]
        [Route("Secure")]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

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
