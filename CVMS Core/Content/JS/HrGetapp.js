$(document).ready(function () {

    alert("Welcome");
    getapplicant();
});

function getapplicant() {
    debugger
    $.ajax({
        type: 'GET',
        url: "/ModelView/ApplicantGet",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {

            var row = "";
            var rowcount = 1;

            debugger
            $.each(data.applicants, function (item, value) {
                debugger
                row += "<tr>";
                row += "<td>" + rowcount + "</td>";
                row += "<td>" + value.fullName + "</td>";
                row += "<td>" + value.qualifications + "</td>";
                row += "<td>" + value.experience + "</td>";
                row += "<td>" + value.aadharNumber + "</td>";
                row += "<td>" + value.fileattach + "</td>";
                row += "<td>" + value.jobName + "</td>";


                row += "<td>" +
                    "<button type='button' class='btn btn-sm btn-success' data-id=''onclick='Down(" + value.appId + ",event)'><i aria-hidden='true'>DownloadCV</i></button>" +
                    "<button type='button' value=1 class='btn btn-sm btn-success' data-id='' onclick='AppAcc(" + value.AppId + ",event)'><i aria-hidden='true'>Accept</i></button>" +            
                    "<button type='button' value=2 class='btn btn-sm btn-success' data-id='' onclick='AppRej(" + value.AppId + ",event)'><i aria-hidden='true'>Reject</i></button>" +            
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


//$("#downloadButton1").click(function () {
//    var imageSrc1 = $("#imagePreview1").attr("src");

//    var a1 = $("<a>")
//        .attr("href", imageSrc1)
//        .attr("download", "image.jpg"); 

//    a1[0].click();
//});


$('#Search').on('keyup', function () {
    var searchTerm = $(this).val().toLowerCase();
    $('#Usertbl tbody tr').each(function () {
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(searchTerm) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});