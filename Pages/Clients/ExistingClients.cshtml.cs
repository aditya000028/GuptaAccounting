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
    public class ExistingClientsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ExistingClientsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Client> Clients { get; set; }

        public async Task OnGet()
        {
            Clients = await _db.Client.ToListAsync();
        }
    }
}