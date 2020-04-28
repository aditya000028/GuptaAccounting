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

        public CheckboxValidation validation;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
            validation = new CheckboxValidation();
        }

        [BindProperty]
        public Client Client { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (validation.CheckCheckboxes(Client.Bookkeeping,
                    Client.Payroll_Services,
                    Client.Personal_Income_Taxation,
                    Client.Previous_Year_Filings,
                    Client.Self_Employed_Business_Taxes,
                    Client.Tax_Returns,
                    Client.GST_PST_WCB_Returns,
                    Client.Government_Requisite_Form_Applications,
                    Client.Other) == false)
                return Page();

            if (ModelState.IsValid)
            {
                Client.IsConsultationClient = false;
                await _db.Client.AddAsync(Client);
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