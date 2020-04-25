using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuptaAccounting.Utilities
{
    public class CheckboxValidation
    {
        public CheckboxValidation()
        {
                
        }

        public bool CheckCheckboxes(bool Bookkeeping,
                                    bool GST_PST_WCB_Returns,
                                    bool Personal_Income_Taxation,
                                    bool Self_Employed_Business_Taxes,
                                    bool Tax_Returns,
                                    bool Payroll_Services,
                                    bool Previous_Year_Filings,
                                    bool Government_Requisite_Form_Applications,
                                    string Other)
        {
            if (Bookkeeping == false &&
                GST_PST_WCB_Returns == false &&
                Personal_Income_Taxation == false &&
                Self_Employed_Business_Taxes == false &&
                Tax_Returns == false &&
                Payroll_Services == false &&
                Previous_Year_Filings == false &&
                Government_Requisite_Form_Applications == false &&
                Other == null)
                return false;
            else return true;
        }
    }
}
