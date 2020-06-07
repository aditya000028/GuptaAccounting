using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GuptaAccounting.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GuptaAccounting.Controllers
{
    //Need to add the route so server knows which path/url to go to
    [Route("api/Client")]
    //State that this is an api controller
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //To do
            //Need to determine where i am on the site so i can return consultation clients
            //for the consultaiton clients page too
            return Json(new
            {
                data = _db.Client.Where(Client => Client.IsConsultationClient == false).ToList()
            });
        }
    }
}