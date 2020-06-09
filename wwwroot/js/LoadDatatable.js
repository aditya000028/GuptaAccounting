var dataTable;
var EmptyDataTableMessage;

$(document).ready(function () {

    //Set the empty datatable message depending on where we are on the site
    EmptyDataTableMessage = String(window.location.href);
    if (EmptyDataTableMessage.includes("Existing")) {
        EmptyDataTableMessage = "No existing clients to show";
    } else {
        EmptyDataTableMessage = "No consultation clients to show";
    }

    loadDataTable();
});

function loadDataTable() {
    //will populate the data table from the cdn that I have used on id DT_load
    dataTable = $('#DT_load').DataTable({
        //need to make an ajax call using the api that i included
        "ajax": {
            "url": "/api/client",
            //this is a get request
            "type": "GET",
            "datatype": "json"
        },
        //this is an array
        "columns": [
            //these are all column names filled with data
            { "data": "name", "width": "20%" },
            { "data": "contactNumber", "width": "15%" },
            {
                "data": "emailAddress",
                "render": function (data) {
                    return `<a href="mailto:${data}">${data}</a>`
                },
                "width": "20%"
            },
            {
                //This is the work type column
                "data": null,
                "width": "20%",
                "render": function (data, type, row) {
                    var html = [];
                    if (row.bookkeeping) {
                        html.push("Bookkeeping");
                    }
                    if (row.personal_Income_Taxation) {
                        html.push("Personal Income Taxation");
                    }
                    if (row.self_Employed_Business_Taxes) {
                        html.push("Self Employed Business Taxes");
                    }
                    if (row.gST_PST_WCB_Returns) {
                        html.push("GST/PST/WCB Returns");
                    }
                    if (row.tax_Returns) {
                        html.push("Tax Returns");
                    }
                    if (row.payroll_Services) {
                        html.push("Payroll Services");
                    }
                    if (row.previous_Year_Filings) {
                        html.push("Previous Year Filings");
                    }
                    if (row.government_Requisite_Form_Applications) {
                        html.push("Government Requisite Form Applications");
                    }
                    if (row.other != "") {
                        html.push(row.other);
                    }

                    return html.join('<br>');
                }
            },
            { "data": "nextStep", "width": "20%" },
            //the last column is the delete and edit button
            {
                //need to pass the id when editing
                "data": "id",
                //need to render 2 buttons
                "render": function (data) { //this data will have the id of the client
                    //we want to return a div with 2 buttons
                    return ` <div class="text-center">
                                <a href="/Admin/Edit?id=${data}" class="btn btn-success text-white p-1" style="cursor:pointer;width:90px">Edit</a>
                                <a class="btn btn-danger text-white p-1" style="cursor:pointer;width:90px" onclick=Delete('/api/client?id=+${data}')>Delete</a>
                             </div>`;
                    //make the render have a width of 30%             
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": EmptyDataTableMessage
        },
        "width": "100%"
    });
};

function Delete(url) {
    swal({
        title: "Are you sure you want to delete this client?",
        text: "Once deleted, you cannot revert back!",
        icon: "warning",
        dangerMode: true,
        buttons: true
    }).then((result) => {
        if (result) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
};