using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuptaAccounting.Data;
using GuptaAccounting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GuptaAccounting.Pages.Clients
{
    public class ConsultationRequestsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ConsultationRequestsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Client> Clients { get; set; }

        public async Task OnGet()
        {
            Clients = await _db.Client.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Client_to_delete = await _db.Client.FindAsync(id);

            if (Client_to_delete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Client.Remove(Client_to_delete);
                await _db.SaveChangesAsync();

                return RedirectToPage("ConsultationRequests");
            }
        }
    }
}