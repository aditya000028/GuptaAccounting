using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuptaAccounting.Data;
using GuptaAccounting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuptaAccounting.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client {get; set;}

        public async Task OnGet(int id)
        {
            Client = await _db.Client.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var DbClient = await _db.Client.FindAsync(Client.Id);
                DbClient.Name = Client.Name;
                DbClient.WorkType = Client.WorkType;
                DbClient.NextStep = Client.NextStep;
                DbClient.ContactNumber = Client.ContactNumber;

                await _db.SaveChangesAsync();

                return RedirectToPage("ExistingClients");
            }
            else
            {
                return Page();
            }
        }
    }
}