using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApi.Controller
{
    [Produces("application/json")]
    [Route("api/Food")]
    public class FoodController : Controller
    {
    }
}