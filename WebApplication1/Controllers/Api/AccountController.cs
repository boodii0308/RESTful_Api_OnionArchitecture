using AutoMapper;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Provider;
using WebApplication1.Service.Module;

namespace WebApplication1.Controllers.Api
{
    public class AccountController : ApiController
    {
        private readonly UserService userService;
        public AccountController()
        {
        }
    }
}
