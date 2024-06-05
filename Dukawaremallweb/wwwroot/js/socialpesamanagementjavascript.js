function savesystemproductcategorydata() {
    var uil =
    {
        ProductcategoryId: $('#CategoryId').val(), Productcategoryname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(),Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductcategorydata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Category details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Category details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemproductunitofmeasuredata() {
    var uil =
    {
        UnitofmeasureId: $('#CategoryId').val(), Unitofmeasurename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductunitofmeasuredata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Unit of Measure details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Unit of Measure details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemproductbranddata() {
    var uil =
    {
        BrandId: $('#CategoryId').val(), Brandname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductbranddata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Brand details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Brand details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemproductattributedata() {
    var uil =
    {
        AttributeId: $('#CategoryId').val(), Attributename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductattributedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Attribute details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Attribute details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
} 

function savesystemproductfeaturedata() {
    var uil =
    {
        FeatureId: $('#CategoryId').val(), Featurename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductfeaturedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Feature details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Feature details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
} 

function savesystemproductspecificationdata() {
    var uil =
    {
        SpecificationId: $('#CategoryId').val(), Specificationname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductspecificationdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Specification details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Specification details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
} 

function savesystemproductwhatsinboxdata() {
    var uil =
    {
        WhatsinboxId: $('#CategoryId').val(), Whatsinboxname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addsystemproductwhatsinboxdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product Wahats in Box details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product Wahats in Box details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemjobindustrydata() {
    var uil =
    {
        CategoryId: $('#CategoryId').val(), Categoryname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemjobservicesmanagement/Addsystemjobserviceindustrydata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Job Industry details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Job Indutry details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemjobtypedata() {
    var uil =
    {
        JobTypeId: $('#CategoryId').val(), JobTypename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemjobservicesmanagement/Addsystemjobservicetypedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Job Type details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Job Type details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}
function savesystemjobeducationdata() {
    var uil =
    {
        EducationId: $('#SocialPesaEducationId').val(), JobVacancyId: $('#SocialPesaJobVacancyId').val(), Educationsdata: $('#SocialPesaEducationsdataId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemjobservicesmanagement/Addjobeducationrequirementdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Job Education details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Job Education details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemjobdescriptiondata() {
    var uil =
    {
        DescriptionId: $('#SocialPesaDescriptionId').val(), JobVacancyId: $('#SocialPesaJobVacancyId').val(), Descriptionsdata: $('#SocialPesaDescriptionsdataId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemjobservicesmanagement/Addjobeducationdescriptiondata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Job Decription details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Job Decription details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemblogcategorydata() {
    var uil =
    {
        CategoryId: $('#CategoryId').val(), Categoryname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/SystemBlogmanagement/Addsystemblogcategorydata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Blog Category details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Blog Category details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystempropertycountytownestatedata() {
    var uil =
    {
        LocationId: $('#CategoryId').val(), Locationname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemlandpropertymanagement/Addsystempropertylocationdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Property Location details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Property Location details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystempropertykitchentypedata() {
    var uil =
    {
        KitchentypeId: $('#CategoryId').val(), Kitchentypename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemlandpropertymanagement/Addsystempropertykitchentypedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Property Kitchen Type details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Property Kitchen Type details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}
function savesystempropertydepositdata() {
    var uil =
    {
        DepositId: $('#CategoryId').val(), Depositname: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemlandpropertymanagement/Addsystempropertydepositdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Property Services With Deposit details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Property Services With Deposit details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}


function savesystempropertyfeaturesdata() {
    var uil =
    {
        FeatureId: $('#CategoryId').val(), Featurename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemlandpropertymanagement/Addsystempropertyfeaturedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Property Features details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Property Features details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}


function savesystempropertysizesdata() {
    var uil =
    {
        SizeId: $('#CategoryId').val(), Sizename: $('#CategorynameId').val(), ParentId: $('#CategorynameparentId').val(),
        Createdby: $('#systemLoggedinedUserId').val(), Modifiedby: $('#systemLoggedinedUserId').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemlandpropertymanagement/Addsystempropertysizedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Property Sizes details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Property Sizes details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function savesystemcorporatecustomerdata() {
    var uil =
    {
        CustomerId: $('#customerId').val(), Firstname: $('#firstnameId').val(), Lastname: $('#lastnameId').val(), Companyname: $('#companynameId').val(),
        Designation: $('#customerDesgnationId').val(), Emailaddress: $('#emailaddressId').val(), Phonenumber: $('#phonenumberId').val(),
    };
    $.post("/Systemcustomersmanagement/Addsystemcompanycustomerdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Customer details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Customer details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}



function removereadonlyonsalaryrange() {
    var checkbox_required = $("#JoborservicehasrangeId");
    if (checkbox_required.is(':checked')) {
        $('#JoborservicesalaryrangeId').attr('readonly', false);
    } else {
        $('#JoborservicesalaryrangeId').attr('readonly', true);
    }
}

function savesystemjoborservicedata() {
    var JobDescriptionsdata = new Array();
    var JobEducationRequirementsdata = new Array();
    $("#JobDescriptionTable TBODY TR").each(function () {
        var row = $(this);
        var JobDescription = {};
        JobDescription.Descriptionsdata = row.find("TD").eq(0).html();
        JobDescriptionsdata.push(JobDescription);
    });
    $("#EducationRequirementTable TBODY TR").each(function () {
        var row = $(this);
        var EducationRequirement = {};
        EducationRequirement.Educationsdata = row.find("TD").eq(0).html();
        JobEducationRequirementsdata.push(EducationRequirement);
    });
    var x = $("#JoborservicehasrangeId").is(":checked");
    var uil =
    {
        JobVacancyId: $('#JoborserviceId').val(), JobownerId: $('#systemLoggedinedUserId').val(), JobVacancyTitle: $('#JoborservicetitleId').val(), JobVacancyDescription: $('#JoborserviceDescriptionsId').val(), JobVacancyDescriptions: JobDescriptionsdata, JobEducationRequirements: JobEducationRequirementsdata, JoborService: 1,
        JobcategoryId: $('#JoborservicecategoryId').val(), JobSubcategoryId: $('#JoborservicesubcategoryId').val(), JobTypeId: $('#JoborservicecontracttypeId').val(), JobSubTypeId: $('#JoborservicecontracttypecategoryId').val(), Hasrange: x, Salaryrange: $('#JoborservicesalaryrangeId').val(), JobVacancyLocation: $('#JoborservicelocationId').val(),
        JobVacancyUrl: $('#JoborserviceapplyurlId').val(), JobVacancyCompany: $('#JoborservicecompanynameId').val(), Jobcompanywebsite: $('#JoborservicecompanywebsiteId').val(), Jobcompanylogo: JSON.parse($('#JoborserviceCompanylogourlsId').val().replaceAll('\\"', '"')),
        Createdby: $('#systemLoggedinedUserId').val(),Modifiedby: $('#systemLoggedinedUserId').val(),Applicationenddate: $('#JoborserviceappenddateId').val(),Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Isactive: 1, Isdeleted: 0, Isapproved: 0
    };
    $.post("/Systemjobservicesmanagement/Addjobopportunityorservicedata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Job/Service details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Job/Service details Not saved", response.respMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}


function savesystemlandandpropertydata() {
    var Propertydepositandfees =[];
    var Propertyfeatures = [];

    $('#SocialpesasystempropertydepositfeeId:checked').each(function (i) {
        Propertydepositandfees[i] = $(this).val();
    });
    $('#SocialpesasystempropertyfeatureId:checked').each(function (i) {
        Propertyfeatures[i] = $(this).val();
    });
    var uil =
    {
        CountyId: $('#propertylandCountyId').val(), SubCountyId: $('#propertylandCountyTownId').val(), SubCountyEstate: $('#propertylandCountyTownEstateId').val(), Propertyname: $('#propertylandCountyTownEstateHouseNameId').val(), Propertydepositandfees: Propertydepositandfees, Propertsize: $("input[type='radio'][name='Socialpesasystempropertysize']:checked").val(), Propertyfeatures: Propertyfeatures,
        PropertyKitchenType: $('#propertylandKitchenTypeId').val(), Propertyrent: $('#propertylandpriceId').val(), Propertytype: $('#propertylandPropertyTypeId').val(), PropertyUnits: $('#propertylandunitsId').val(), Propertytype: $("input[type='radio'][name='PropertyType']:checked").val(),
        CreatedBy: $('#systemLoggedinedUserId').val(), ModifiedBy: $('#systemLoggedinedUserId').val(), DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        DateModified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), DatePublished: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };

    alert(JSON.stringify(uil));
    
    $.post("/Systemlandpropertymanagement/Addsystemlandorpropertydata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Property details has been added.', 'success')
            $('#SocialPesaModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Property details Not saved", response.respMessage, "error");
        }
    });
}


function savesystemblogfeeddata() {
    var BlogDescriptionsdata = new Array();
    var BlogTagRequirementsdata = new Array();
    $("#BlogDescriptionTable TBODY TR").each(function () {
        var row = $(this);
        var BlogDescription = {};
        BlogDescription.Descriptionsdata = row.find("TD").eq(0).html();
        BlogDescriptionsdata.push(BlogDescription);
    });
    $("#BlogTagRequirementTable TBODY TR").each(function () {
        var row = $(this);
        var BlogTagRequirement = {};
        BlogTagRequirement.BlogTagdata = row.find("TD").eq(0).html();
        BlogTagRequirementsdata.push(BlogTagRequirement);
    });
    var BlogPostImages = {
        BlogpostimageurlId: JSON.parse($('#SocialpesablogimagesurlsId').val().replaceAll('\\"', '"')),
    };
    var uil =
    {
        BlogownerId: $('#systemLoggedinedUserId').val(), BlogId: $('#SocialPesaBlogId').val(), BlogTitle: $('#SocialPesaBlogTitleId').val(), BlogSummary: $('#SocialPesaBlogSummaryId').val(), BlogDescription: BlogDescriptionsdata,
        BlogCategoryId: $('#SocialPesaBlogCategoryId').val(), BlogTags: BlogTagRequirementsdata, BlogPostImages: BlogPostImages, CreatedBy: $('#systemLoggedinedUserId').val(), ModifiedBy: $('#systemLoggedinedUserId').val(),
        DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        DateModified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        DatePublished: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/SystemBlogmanagement/Addsystemblogpostdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Post Blog details has been added.', 'success')
            $('#SocialPesaBlogFeed').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Post Blog details Not saved", response.respMessage, "error");
        }
    });
}

function updatesystemblogfeeddata() {
    var uil =
    {
        BlogownerId: $('#systemLoggedinedUserId').val(), BlogId: $('#SocialPesaBlogId').val(), BlogTitle: $('#SocialPesaBlogTitleId').val(), BlogSummary: $('#SocialPesaBlogSummaryId').val(),
        BlogCategoryId: $('#SocialPesaBlogCategoryId').val(), CreatedBy: $('#systemLoggedinedUserId').val(), ModifiedBy: $('#systemLoggedinedUserId').val(),
        DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        DateModified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        DatePublished: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/SystemBlogmanagement/Updatesystemblogpostdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Post Blog details has been updated.', 'success')
            $('#SocialPesaBlogFeed').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Post Blog details Not updated", response.respMessage, "error");
        }
    });
}

function savesystemblogdescriptiondata() {
    var uil =
    {
        DescriptionId: $('#SocialPesaDescriptionId').val(), BlogId: $('#SocialPesaBlogId').val(), Descriptionsdata: $('#SocialPesaDescriptionsdataId').val()
    };
    $.post("/SystemBlogmanagement/Registerblogdescriptiondata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Post Blog details has been added.', 'success')
            $('#SocialPesaBlogFeed').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Post Blog details Not added", response.respMessage, "error");
        }
    });
}


function saveproductvariationdata() {
    var ProductAttribute = {
        ProductAttributeId: $('#SocialpesaproductattributesId').val(),
    };
    var ProductFeature = {
        ProductFeatureId: $('#SocialpesaproductfeaturesId').val(),
    };
    var ProductSpecification = {
        ProductSpecificationId: $('#SocialpesaproductspecificationsId').val(),
    };
    var ProductWhatsInbox = {
        ProductWhatsInboxId: $('#SocialpesaproductwhatsinboxId').val(),
    };

    //var ProductImages = {
    //    ProductimageurlId: JSON.parse($('#SocialpesaproductimagesurlsId').val().replaceAll('\\"', '"')),
    //};
    var uil =
    {
        UserId: $('#systemLoggedinedUserId').val(), ProductVariationId: $('#SocialpesaproductId').val(), ProductVariationName: $('#SocialpesaproductnameId').val(), ProductBrandId: $('#SocialpesaproductbrandId').val(), CategoryId: $('#SocialpesaproductcategoryId').val(),
        SubCategoryId: $('#SocialpesaproductsubcategoryId').val(), ProductUomId: $('#SocialpesaproductuomId').val(), ProductReorderLevel: $('#SocialpesaproductreorderlevelId').val(), ProductShelfLife: $('#SocialpesaproductshelflifeId').val(), ProductSku: $('#SocialpesaproductskuId').val(),
        ProductPrice: $('#SocialpesaproductpriceId').val(), ProductDiscount: $('#SocialpesaproductdiscountId').val(), ProductDescription: $('#SocialpesaproductdescriptionId').val(), ProductAttributes: ProductAttribute, ProductFeatures: ProductFeature,
        ProductSpecifications: ProductSpecification, ProductWhatsInbox: ProductWhatsInbox, CreatedBy: $('#systemLoggedinedUserId').val(), ModifiedBy: $('#systemLoggedinedUserId').val(),DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
        DateModified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),DatePublished: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Systemproductservicesmanagement/Addproductvariationdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Product details has been added.', 'success')
            $('#SocialPesaProductService').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Product details Not saved", response.respMessage, "error");
        }
    });
}
function savesystemproductcategoryimagedata() {
    var ProductcategoryImages = {
        ProductcategoryimageurlId: JSON.parse($('#SocialpesaproductcategoryimagesurlsId').val().replaceAll('\\"', '"')),
    };
    var uil =
    {
        ProductcategoryId: $('#ProductcategoryId').val(), ProductCategoryImages: ProductcategoryImages,
        DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' ')
    };
    $.post("/Systemproductservicesmanagement/Uploadsystemproductcategoryimage", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Category Image has been Uploaded.', 'success')
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Category Image Not Uploaded", response.respMessage, "error");
        }
    });
}


function Savesocialpesacartitems() {
    var uil =
    {
        UserId: $('#systemLoggedinedUserId').val(),
        DateCreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' ')
    };
    $.post("/Systemproductservicesmanagement/Addcartitemdata", uil, function (response) {
        if (response.respStatus == 0) {
            Swal.fire('Saved!', 'Cart details has been added.', 'success')
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal.fire("Cart details Not saved", response.respMessage, "error");
        }
    });
}