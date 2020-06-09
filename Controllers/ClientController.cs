using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GuptaAccounting.Data;
using GuptaAccounting.Data.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            //To do
            //Need to determine where i am on the site so i can return consultation clients
            //for the consultaiton clients page too
            return Json(new
            {
                data = await _db.Client.Where(Client => Client.IsConsultationClient == true).ToListAsync()
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var ClientFromDb = await _db.Client.FindAsync(id);
            if(ClientFromDb == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Unable to delete client"
                });
            }

            _db.Client.Remove(ClientFromDb);
            await _db.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Client successfully deleted"
            });
        }
    }
}