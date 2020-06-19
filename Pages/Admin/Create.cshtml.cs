using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuptaAccounting.Data;
using GuptaAccounting.Model;
using GuptaAccounting.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuptaAccounting.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Client.IsConsultationClient = false;
                await _db.Client.AddAsync(Client);
                await _db.SaveChangesAsync();
                return RedirectToPage("ManageClients");
            }
            else
            {
                return Page();
            }
        }
    }
}