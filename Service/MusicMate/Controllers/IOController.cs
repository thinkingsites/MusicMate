﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicMate.Controllers
{
    public class IOController : BaseController
    {
        [Route("api/io")]
        public string Get()
        {
            return "test";
        }
    }
}