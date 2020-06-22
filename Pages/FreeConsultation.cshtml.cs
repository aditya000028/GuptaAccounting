using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using GuptaAccounting.Data;
using GuptaAccounting.Model;
using GuptaAccounting.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using MimeKit.Utils;

namespace GuptaAccounting.Pages
{
    public class FreeConsultationModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public bool FormPosted { get; set; }

        public FreeConsultationModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client { get; set; }

        public void OnGet()
        {
            FormPosted = false;
        }

        private void SendEmail()
        {
            var SMTP = _db.SMTP.FirstOrDefault();

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(SMTP.EmailFromName,
            SMTP.EmailFrom);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(SMTP.EmailToName,
            SMTP.EmailTo);
            message.To.Add(to);

            message.Subject = "New Client";

            BodyBuilder bodyBuilder = new BodyBuilder();

            string Other;
            if (Client.Other == null)
                Other = "NONE";
            else
                Other= Client.Other;

            string Bookkeeping;
            if (Client.Bookkeeping == true)
                Bookkeeping = "YES";
            else
                Bookkeeping = "NO";

            string Personal_Income_Taxation;
            if (Client.Personal_Income_Taxation == true)
                Personal_Income_Taxation = "YES";
            else
                Personal_Income_Taxation = "NO";

            string Self_Employed_Business_Taxes;
            if (Client.Self_Employed_Business_Taxes == true)
                Self_Employed_Business_Taxes = "YES";
            else
                Self_Employed_Business_Taxes = "NO";

            string GST_PST_WCB_Returns;
            if (Client.Bookkeeping == true)
                GST_PST_WCB_Returns = "YES";
            else
                GST_PST_WCB_Returns = "NO";

            string Tax_Returns;
            if (Client.Tax_Returns == true)
                Tax_Returns = "YES";
            else
                Tax_Returns = "NO";

            string Payroll_Services;
            if (Client.Payroll_Services == true)
                Payroll_Services = "YES";
            else
                Payroll_Services = "NO";

            string Previous_Year_Filings;
            if (Client.Previous_Year_Filings == true)
                Previous_Year_Filings = "YES";
            else
                Previous_Year_Filings = "NO";

            string Government_Requisite_Form_Applications;
            if (Client.Government_Requisite_Form_Applications == true)
                Government_Requisite_Form_Applications = "YES";
            else
                Government_Requisite_Form_Applications = "NO";

            var image = bodyBuilder.LinkedResources.Add(@"wwwroot/images/logo_transparent.png");
            image.ContentId = MimeUtils.GenerateMessageId();

            string contents = string.Format(@"

<head>
    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
    <title>
        New Client
    </title>

</head>

<header style="""">
    <img src=""cid:{0}"" style=""display:inline-block;width:200px;height:200px;"" />
    <p style=""display:inline-block;font-size:40px;color:#1872a4;font-family:Arial;"">Here for you</p>
     <hr/>
         <br/>
     </header>
     <body>
     
         <center style=""background-color:lightgrey;border:solid;border-color:black;border-width:thin;font-family:Arial;padding-bottom:10px;"">
     
             <h2 style=""font-size:30px;font-family:Arial;"">Hi Vijay, you have a new consultation request</h2>
             <br/>

             <h1>Client Info</h1>

             <table>
                 <tr>
                     <th style=""padding:10px;"">Name</th>
                     <th style=""padding:10px;"">Contact Number</th>
                     <th style=""padding:10px;"">Submission Time</th>
                 </tr>
                 <tr>
                     <td style=""padding:10px;"">" + Client.Name+ @"</td>
                     <td style=""padding:10px;"">" + (Client.ContactNumber.ToString())+ @"</td>
                     <td style=""padding:10px;"">"+(DateTime.Now.ToString())+@"</td>
                 </tr>
             </table>
             <br/>
     
             <h3>Work Type</h3>
     
             <table style=""text-align:left;display:inline-block;padding:10px"">
            <tr>
                <th>
                    Bookkeeping
                </th>
                <th>" +Bookkeeping+ @"</th>
            </tr>
            <tr>
                <th>
                    Personal Income Taxation
                </th>
                <th>"+Personal_Income_Taxation+ @"</th>
            </tr>
            <tr>
                <th>
                    Self-Employed Business Taxes
                </th>
                <th>"+Self_Employed_Business_Taxes+ @"</th>
            </tr>
            <tr>
                <th>
                    GST/PST/WCB Returns
                </th>
                <th>"+GST_PST_WCB_Returns+ @"</th>
            </tr>
            <tr>
                <th>
                    Other:
                </th>
                <th>"+Other+@"</th>
            </tr>
        </table>
        <table style=""text-align:left;display:inline-block;padding:10px"">
            <tr>
                <th>
                    Tax Returns
                </th>
                <th>" +Tax_Returns+ @"</th>
            </tr>
            <tr>
                <th>
                    Payroll Services
                </th>
                <th>"+Payroll_Services+ @"</th>
            </tr>
            <tr>
                <th>
                    Previous Year Filings
                </th>
                <th>"+Previous_Year_Filings+ @"</th>
            </tr>
            <tr>
                <th>
                    Govt. Requisite Form Applicaitons
                </th>
                <th>"+Government_Requisite_Form_Applications+ @"</th>
            </tr>
            <tr>
                <th>
                    
                </th>
                <th>

                </th>
            </tr>
        </table>
         </center>
<br/>
     </body> "
, image.ContentId);
            bodyBuilder.HtmlBody = contents;
            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect(SMTP.ServerAddress, SMTP.PortNumber, SMTP.SSLRequired);
            client.Authenticate(SMTP.AuthenticationEmail, SMTP.AuthenticationPassword);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                Client.IsConsultationClient = true;
                await _db.Client.AddAsync(Client);
                await _db.SaveChangesAsync();
                FormPosted = true;
                SendEmail();
            }
        }
    }
}