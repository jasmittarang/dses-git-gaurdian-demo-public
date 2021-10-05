using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DsesDemoApp.Data;
using DsesDemoApp.Models;
using System.Linq;
using System.IO.Compression;
using System;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DsesDemoApp.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DsesDemoAppContext _context;

        public LoginController(DsesDemoAppContext context)
        {
            _context = context;
        }

        // POST: /login
        [Route("/login")]
        [HttpPost]
        public ActionResult<List<User>> PostUser([FromBody] Dictionary<string,string> loginRequest)
        {
            if (loginRequest != null)
            {
                var username = loginRequest["username"];
                var password = loginRequest["password"];
                return _context
                    .User
                    .FromSqlRaw(
                        $"SELECT * FROM User WHERE Username == '{username}' AND Password == {password}"
                    ).ToList();
            }
            return Unauthorized();
        }
    }
}
