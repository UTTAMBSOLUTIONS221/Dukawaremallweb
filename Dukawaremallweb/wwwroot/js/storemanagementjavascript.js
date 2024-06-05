function savesystemshopproductdetails() {
    if ($('#SellingpriceId').val() === "" || $('#SellingpriceId').val() === 0) {
        Swal.fire("Shop Product details Not saved", "Selling Price cant be Empty.", "warning");
        return;
    }
    if ($('#SystemProductStatusId').val() === "" || $('#SystemProductStatusId').val() === "0") {
        Swal.fire("Shop Product details Not saved", "Product status cant be Empty.", "warning");
        return;
    }
    if ($('#IslipapolepoleId').prop('checked')) {
        if ($('#InitialdepositId').val() === "" || $('#InitialdepositId').val() === 0) {
            Swal.fire("Shop Product details Not saved", "Deposit cant be Empty.", "warning");
            return;
        }
        if ($('#InterestrateId').val() === "" || $('#InterestrateId').val() === 0) {
            Swal.fire("Shop Product details Not saved", "Interest rate cant be Empty.", "warning");
            return;
        }
    }
    var uil1 = {
        Shopproductid: $('#Shopproductid').val(), Productid: $('#Productid').val(), Productprice: $('#SellingpriceId').val(), Ishirepurchase: $('#IslipapolepoleId').prop('checked'),
        Depositamount: $('#InitialdepositId').val(), Interestrate: $('#InterestrateId').val(), Productstatus: $('#SystemProductStatusId').val(), Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(),
        DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), DateModified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Customer/Addsystemshopproductdata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#Productid').val('');
            $('#SellingpriceId').val('');
            $('#InitialdepositId').val('');
            $('#InterestrateId').val('');
            $('#Uttambsolutionsshopproductmodal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Shop product details Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}