function savesystemcustomerdata() {

    if ($('#firstnameId').val() == '') {
        Swal.fire("Customer Detail Not Created", 'Firstname is Required', "warning");
        return;
    }
    if ($('#lastnameId').val() == '') {
        Swal.fire("Customer Detail Not Created", 'Lastname is Required', "warning");
        return;
    }

    if ($('#emailaddressId').val() == '') {
        Swal.fire("Customer Detail Not Created", 'Emailaddress is Required', "warning");
        return;
    }
    if ($('#inputGroup-sizing-sm').val() == '' || $('#inputGroup-sizing-sm').val() == 0) {
        Swal.fire("Customer Detail Not Created", 'Phonenumber Prefix is Required', "warning");
        return;
    }
    if ($('#PhonenumberId').val() == '') {
        Swal.fire("Customer Detail Not Created", 'Phonenumber is Required', "warning");
        return;
    }
    if ($('#CustomerstationId').val() == '' || $('#CustomerstationId').val() == 0) {
        Swal.fire("Customer Detail Not Created", 'Station is Required', "warning");
        return;
    }

    var uil =
    {
        CustomerId: $('#customerId').val(), Firstname: $('#firstnameId').val(), Lastname: $('#lastnameId').val(), Companyname: $('#companynameId').val(),
        Designation: $('#customerDesgnationId').val(), Emailaddress: $('#emailaddressId').val(), Phoneid: $('#inputGroup-sizing-sm').val(), Phonenumber: $('#PhonenumberId').val(), StationId: $('#CustomerstationId').val(),
        IDNumber: $('#customeridnumberId').val(), CompanyPIN: $('#CompanypinId').val(), CompanyIncorporationDate: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), CompanyVAT: $('#CompanyVATNoId').val(), CountryId: $('#CustomercountryId').val(),
        NoOfTransactionPerDay: $('#NoOfTransactionPerDayId').val(), AmountPerDay: $('#AmountPerDayId').val(), ConsecutiveTransTimeMin: $('#ConsecutiveTransTimeMinId').val(), CompanyAddress: $('#CompanyaddressId').val(),
        CompanycontactpersonnameId: $('#CompanycontactpersonnameId').val(), CompanycontactpersonemailId: $('#CompanycontactpersonemailId').val(), CompanycontactpersonphoneId: $('#CompanycontactpersonphoneId').val(),
        CompanyRegistrationNo: $('#CompanyRegistrationNoId').val(), IsPortaluser: true,
        Dob: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Gender: $('#customergenderId').val(), ReferenceNumber: $('#customerreferencenumberId').val(),
        Contractstartdate: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Contractenddate: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        CreatedbyId: $('#systemLoggedinedUserid').val(), Createdby: $('#systemLoggedinedUserNameId').val(), ModifiedId: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserNameId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Customer/Registersystemcustomers", uil, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', 'Customer details has been added.', 'success')
            $('#FuelcardsystemModal').hide();
            window.location.href = '/Customer/Signinuser';
         /*   setTimeout(function () { location.reload(); }, 1000);*/
        } else if (response.RespStatus == 1) {
            Swal.fire("Customer details Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}


function savesystemshopdetails() {
    if ($('#inputGroup-sizing-sm').val() == '' || $('#inputGroup-sizing-sm').val() == 0) {
        Swal.fire("Customer Detail Not Created", 'Phonenumber Prefix is Required', "warning");
        return;
    }
    if ($('#PhonenumberId').val() == '') {
        Swal.fire("Customer Detail Not Created", 'Phonenumber is Required', "warning");
        return;
    }
    var uil =
    {
        Shopid: $('#Shopid').val(), Customerid: $('#Customerid').val(), Shopname: $('#ShopnameId').val(), Phoneid: $('#inputGroup-sizing-sm').val(), Shopphone: $('#PhonenumberId').val(),
        Startdate: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Enddate: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Isverified: false,Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Customer/Setupcustomershopdaata", uil, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', 'Shop details has been added.', 'success')
            $('#FuelcardsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Shop details Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}
