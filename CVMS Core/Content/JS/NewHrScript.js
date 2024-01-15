$(document).ready(function () {

    alert("Welcome to new page");
    var params = new window.URLSearchParams(window.location.search);
    ApplicantDetails(params.get('jobId'));
});


function ApplicantDetails(jobId) {
    debugger
    if (jobId > 0) {
        $.ajax({
            type: "GET",
            url: "../ModelView/ApplicantDtlJob?jobId=" + jobId,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger

                $("#jobName").val(data.obj.jobName);
                $("#requiredSkills").val(data.obj.requiredSkills);
                $("#preferredQualifications").val(data.obj.preferredQualifications);
                $("#minExperience").val(data.obj.minimumExperience);
                $("#Salary").val(data.obj.salaryPackage);


            },
            error: function (xhr) {


                alert('Some error occured.');
            }
        });
    }
}

$("#SaveBtn").click(function (event) {
    event.preventDefault();
    var isValid = true;
    debugger
    var fullname = $("#fullName").val();
    var qualifications = $("#qualifications").val();
    var experience = $("#experience").val();
    var aadharnumber = $("#aadharNumber").val();
    var jobname = $("#jobName").val();
    var skills = $("#requiredSkills").val();
    var prefqualifications = $("#preferredQualifications").val();
    var minexperience = $("#minExperience").val();
    var salarypackage = $("#Salary").val();
    var fileInput1 = $("#filepath")[0].files[0];

    function isValidName(input)
    {
        return /^[A-Z][a-z]* [A-Z][a-z]*$/.test(input);
    }

    debugger

    if (!isValidName(fullname)) {
        $('#name').text('Please enter a valid name').addClass('text-danger');
        isValid = false;
        $('#fullName').addClass('border-danger');
    }
    else {
        $('#fullName').removeClass('border-danger');
        $('#name').text('').removeClass('text-danger');
    }

    if (qualifications == '') {
        isValid = false;
        $('#qua').text('Please enter valid qualifications').addClass('text-danger');
        $('#qualifications').addClass('border-danger');
    }
    else {
        $('#qualifications').removeClass('border-danger');
        $('#qua').text('').removeClass('text-danger');
    }

    if (experience == '') {
        isValid = false;
        $('#exp').text('Please enter your year of experience').addClass('text-danger');
        $('#experience').addClass('border-danger');
    }
    else {
        $('#experience').removeClass('border-danger');
        $('#exp').text('').removeClass('text-danger');
    }

    if (aadharnumber == '') {
        isValid = false;
        $('#ano').text('Please enter aadhar number').addClass('text-danger');
        $('#aadharNumber').addClass('border-danger');
    }
    else {
        $('#aadharNumber').removeClass('border-danger');
        $('#ano').text('').removeClass('text-danger');
    }

    if (fileInput1 == undefined) {
        isValid = false;
        $('#cv').text('Please upload a document').addClass('text-danger');
        $('#filepath').addClass('border-danger');
    }
    else {
        $('#filepath').removeClass('border-danger');
        $('#cv').text('').removeClass('text-danger');
    }

    if (!isValid) {
        alert('form is not valid.');
        return isValid;

    }
    
    var formData = new FormData();

    formData.append('FullName', fullname);
    formData.append('Qualifications', qualifications);
    formData.append('Experience', experience);
    formData.append('AadharNumber', aadharnumber);
    formData.append('JobName', jobname);
    formData.append('RequiredSkills', skills);
    formData.append('PreferredQualifications', prefqualifications);
    formData.append('MinimumExperience', minexperience);
    formData.append('SalaryPackage', salarypackage);

    if (fileInput1) {
        formData.append('Fileattach', fileInput1);


    $.ajax({
        type: "POST",
        url: "../ModelView/PostApplicantDtl",
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json",
        success: function (data) {
            alert("Success");
            window.location.reload();
        },
        error: function (data, error) {
            alert("Failed to Save Data");
        }
    });
    

    }

    else {
    $("#message").html("<div class='alert alert-danger'>Please select a file to upload.</div>");
}
});