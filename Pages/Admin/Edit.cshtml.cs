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
                DbClient.Bookkeeping = Client.Bookkeeping;
                DbClient.Payroll_Services = Client.Payroll_Services;
                DbClient.Personal_Income_Taxation = Client.Personal_Income_Taxation;
                DbClient.Previous_Year_Filings = Client.Previous_Year_Filings;
                DbClient.Self_Employed_Business_Taxes= Client.Self_Employed_Business_Taxes;
                DbClient.Tax_Returns = Client.Tax_Returns;
                DbClient.GST_PST_WCB_Returns = Client.GST_PST_WCB_Returns;
                DbClient.Government_Requisite_Form_Applications = Client.Government_Requisite_Form_Applications;
                DbClient.ContactNumber = Client.ContactNumber;
                DbClient.NextStep = Client.NextStep;
                DbClient.Other = Client.Other;
                DbClient.IsConsultationClient = Client.IsConsultationClient;

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