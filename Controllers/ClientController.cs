using System.Linq;
using System.Threading.Tasks;
using GuptaAccounting.Data;
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
            return Json(new
            {
                data = await _db.Client.ToListAsync()
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