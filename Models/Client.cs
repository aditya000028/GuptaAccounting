using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuptaAccounting.Model
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Bookkeeping")]
        public bool Bookkeeping { get; set; }

        [Required]
        [DisplayName("Personal Income Taxation")]
        public bool Personal_Income_Taxation { get; set; }

        [Required]
        [DisplayName("Self-Employed Business Taxes")]
        public bool Self_Employed_Business_Taxes { get; set; }

        [Required]
        [DisplayName("GST/PST/WCB Returns")]
        public bool GST_PST_WCB_Returns { get; set; }

        [Required]
        [DisplayName("Tax Returns")]
        public bool Tax_Returns { get; set; }

        [Required]
        [DisplayName("Payroll Services")]
        public bool Payroll_Services { get; set; }

        [Required]
        [DisplayName("Previous Year Filings")]
        public bool Previous_Year_Filings { get; set; }

        [Required]
        [DisplayName("Govt. Requisite Form Applicaitons")]
        public bool Government_Requisite_Form_Applications { get; set; }

        public string Other { get; set; }

        [DisplayName("Next Step")]
        public string NextStep { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid contact number")]
        public string ContactNumber { get; set; }

        [Required]
        [DisplayName("Consultation Client")]
        public bool IsConsultationClient { get; set; }
    }
}
