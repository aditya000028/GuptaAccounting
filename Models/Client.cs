using GuptaAccounting.Utilities;
using Microsoft.AspNetCore.Mvc;
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
        [StringLength(50, ErrorMessage = "Cannot exceed more than 50 characters")]
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

        [StringLength(220, ErrorMessage = "Cannot exceed more than 220 characters")]
        public string Other { get; set; }

        [StringLength(150, ErrorMessage = "Cannot exceed more than 150 characters")]
        [DisplayName("Next Step")]
        public string NextStep { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid contact number")]
        public string ContactNumber { get; set; }

        [Required]
        [DisplayName("Consultation Client")]
        public bool IsConsultationClient { get; set; }

        [CheckboxAndOtherValidation(nameof(Bookkeeping),
    nameof(Personal_Income_Taxation),
    nameof(Self_Employed_Business_Taxes),
    nameof(GST_PST_WCB_Returns),
    nameof(Tax_Returns),
    nameof(Payroll_Services),
    nameof(Previous_Year_Filings),
    nameof(Government_Requisite_Form_Applications), ErrorMessage = "At least one of the checkboxes or the 'Other' field must be filled")]
        public bool AreCheckboxesAndOtherValid { get; set; }
    }
}
