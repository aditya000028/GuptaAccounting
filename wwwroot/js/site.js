// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function Validate() {
    var Tax_Returns = document.getElementById("Client_Tax_Returns").checked;
    var Bookkeeping = document.getElementById("Client_Bookkeeping").checked;
    var Personal_Income_Taxation = document.getElementById("Client_Personal_Income_Taxation").checked;
    var Self_Employed_Business_Taxes = document.getElementById("Client_Self_Employed_Business_Taxes").checked;
    var GST_PST_WCB_Returns = document.getElementById("Client_GST_PST_WCB_Returns").checked;
    var Payroll_Services = document.getElementById("Client_Payroll_Services").checked;
    var Previous_Year_Filings = document.getElementById("Client_Previous_Year_Filings").checked;
    var Government_Requisite_Form_Applications = document.getElementById("Client_Government_Requisite_Form_Applications").checked;
    var Other = document.getElementById("Client_Other");
    var Name = document.getElementById("Client_Name");
    var ContactNumber = document.getElementById("Client_ContactNumber");


    var CheckboxError = document.getElementById("CheckboxError");
    var NameError = document.getElementById("NameError");
    var ContactNumberError = document.getElementById("ContactNumberError");

    var PhoneRegEx = "[0-9]{3}-[0-9]{3}-[0-9]{4}$";

    var NameBool = true;
    var ContactNumberBool = true;
    var CheckboxBool = true;

    if (Name.value == "") {
        NameError.innerHTML = "The 'Name' field is required";
        NameBool = false;
    } else {
        NameError.innerHTML = "";
    }

    if (ContactNumber.value == "") {
        ContactNumberError.innerHTML = "The 'Contact Number' field is required";
        ContactNumberBool = false;
    } else if (!ContactNumber.value.match(PhoneRegEx)) {
        ContactNumberError.innerHTML = "Invalid contact number";
        ContactNumberBool = false;
    } else {
        ContactNumberError.innerHTML = "";
    }

    if (Bookkeeping == false &&
        Personal_Income_Taxation == false &&
        Self_Employed_Business_Taxes == false &&
        GST_PST_WCB_Returns == false &&
        Tax_Returns == false &&
        Payroll_Services == false &&
        Previous_Year_Filings == false &&
        Government_Requisite_Form_Applications == false &&
        Other.value == "") {
        CheckboxError.innerHTML = "At least one checkbox or the 'Other' field must be filled";
        CheckboxBool = false;;
    }
    else {
        CheckboxError.innerHTML = "";
    }

    if (ContactNumberBool == false || NameBool == false || CheckboxBool == false)
        return false;

    return true;
};

function DeleteConfirmation() {
    swal({
        title: "Are you sure you want to delete this client?",
        text: "Once deleted, you cannot revert back!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it",
        cancelButtonText: "No, don't delete it"
        }).then((result) => {
            if (result.value) {
                return true;
            } else {
                return false;
            }
        })
};