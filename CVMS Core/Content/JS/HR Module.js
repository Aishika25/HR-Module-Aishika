$(document).ready(function () {

    alert("welcome");
    getemployee();   
    
});

$('#SaveBtn').click(function (event) {
    event.preventDefault();
    var isValid = true;
    debugger
    var JobName = $("#jobName").val();
    var RequiredSkills = $("#requiredSkills").val();
    var PreferredQualifications = $("#preferredQualifications").val();
    var MinExperience = $("#minExperience").val();
    var Salary = $("#Salary").val();
    var ValidUpto = $("#validUpto").val();


    debugger

    if (JobName == '') {
        isValid = false;
        $('#jname').text('Please enter a job name').addClass('text-danger');
        $('#jobName').addClass('border-danger');
    }
    else {
        $('#jobName').removeClass('border-danger');
        $('#jname').text('').removeClass('text-danger');
    }

    if (RequiredSkills == '') {
        isValid = false;
        $('#rskill').text('Please enter required skills').addClass('text-danger');
        $('#requiredSkills').addClass('border-danger');
    }
    else {
        $('#requiredSkills').removeClass('border-danger');
        $('#rskill').text('').removeClass('text-danger');
    }

    if (PreferredQualifications == '') {
        isValid = false;
        $('#pqua').text('Please enter preferred qualifications').addClass('text-danger');
        $('#preferredQualifications').addClass('border-danger');
    }
    else {
        $('#preferredQualifications').removeClass('border-danger');
        $('#pqua').text('').removeClass('text-danger');
    }

    if (MinExperience == '') {
        isValid = false;
        $('#minex').text('Please enter minimum experience').addClass('text-danger');
        $('#minExperience').addClass('border-danger');
    }
    else {
        $('#minExperience').removeClass('border-danger');
        $('#minex').text('').removeClass('text-danger');
    }

    if (Salary == '') {
        isValid = false;
        $('#spac').text('Please enter salary package').addClass('text-danger');
        $('#Salary').addClass('border-danger');
    }
    else {
        $('#Salary').removeClass('border-danger');
        $('#spac').text('').removeClass('text-danger');
    }

    if (ValidUpto == '') {
        isValid = false;
        $('#vupto').text('Please enter salary package').addClass('text-danger');
        $('#validUpto').addClass('border-danger');
    }
    else {
        $('#validUpto').removeClass('border-danger');
        $('#vupto').text('').removeClass('text-danger');
    }


    if (!isValid) {
        alert('form is not valid.');
        return isValid;

    }


    var formData = new FormData();
    formData.append('JobName', JobName);
    formData.append('RequiredSkills', RequiredSkills);
    formData.append('PreferredQualifications', PreferredQualifications);
    formData.append('MinimumExperience', MinExperience);
    formData.append('SalaryPackage', Salary);
    formData.append('ValidUpto', ValidUpto);
    debugger
    $.ajax({

        type: "POST",
        url: "../ModelView/JobOpeningPost/",
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json",
        success: function (data) {


            window.location.reload();
            
        },

        error: function (data, error) {
           
            alert("Failed to Save Data");
        }
    });

});

function getemployee() {
    debugger
    $.ajax({
        type: 'GET',
        url: "/ModelView/GetJob",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {

            var row = "";
            var rowcount = 1;

            debugger
            $.each(data.applicant, function (item, value) {
                debugger
                row += "<tr>";
                row += "<td>" + rowcount + "</td>";
                row += "<td>" + value.jobName + "</td>";
                row += "<td>" + value.requiredSkills + "</td>";
                row += "<td>" + value.preferredQualifications + "</td>";
                row += "<td>" + value.minimumExperience + "</td>";
                row += "<td>" + value.salaryPackage + "</td>";
                row += "<td>" + value.validUpto + "</td>";


               row += "<td>" +
                   "<button type='button' class='btn btn-sm btn-success' data-id=''onclick='AppDtl(" + value.jobId + ",event)'><i aria-hidden='true'>ApplyNow</i></button>" +            
                    "</td>";
               row += "</tr>";
                rowcount += 1;
            });

                $("#mtable").append(row);
        },
        error: function (error) {

            alert("Not Found");
        },
    });
}

function AppDtl(jobId) {
    debugger
    window.location.href = '../ModelView/JobApplicant?jobId=' + jobId;
}

$('#search').on('keyup', function () {
    var searchTerm = $(this).val().toLowerCase();
    $('#userTbl tbody tr').each(function () {
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(searchTerm) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});