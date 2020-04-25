// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function CheckCheckboxes() {
    var Tax_Returns = document.getElementById("Client_Tax_Returns").checked;
    var Bookkeeping = document.getElementById("Client_Bookkeeping").checked;
    var Personal_Income_Taxation = document.getElementById("Client_Personal_Income_Taxation").checked;
    var Self_Employed_Business_Taxes = document.getElementById("Client_Self_Employed_Business_Taxes").checked;
    var GST_PST_WCB_Returns = document.getElementById("Client_GST_PST_WCB_Returns").checked;
    var Payroll_Services = document.getElementById("Client_Payroll_Services").checked;
    var Previous_Year_Filings = document.getElementById("Client_Previous_Year_Filings").checked;
    var Government_Requisite_Form_Applications = document.getElementById("Client_Government_Requisite_Form_Applications").checked;
    var Other = document.getElementById("Client_Other");

    if (Bookkeeping == false &&
        Personal_Income_Taxation == false &&
        Self_Employed_Business_Taxes == false &&
        GST_PST_WCB_Returns == false &&
        Tax_Returns == false &&
        Payroll_Services == false &&
        Previous_Year_Filings == false &&
        Government_Requisite_Form_Applications == false &&
        Other.value == "") {
        var CheckboxError = document.getElementById("CheckboxError");
        CheckboxError.innerHTML = "At least one checkbox or the 'Other' field must be filled";
        return false;
    }
    else {
        return true;
    }
};