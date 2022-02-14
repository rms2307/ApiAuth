﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiAuth.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"User {User.Identity.Name} autenticado.";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee, manager")]
        public string Employee() => $"Funcionário {User.Identity.Name} entrou.";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => $"Gerente {User.Identity.Name} entrou.";
    }
}
