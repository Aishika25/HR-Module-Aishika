$(document).ready(function () {

    alert("Welcome to the page");
    getemployedtl();

    $('#mobile').on('keyup', function () {
        var value = $(this).val();
        var digitArray = value.match(/[0-9]/g); 

        if (digitArray && digitArray.length <= 10) {
            var validValue = digitArray.join('').substr(0, 10); 
            $(this).val(validValue);
        } else {
            $(this).val('');
        }

        
    });
    var today = new Date().toISOString().split('T')[0];
    $('#dob').attr('max', today);

    $('#dob').change(function () {
        var selectedDate = $(this).val();
        var isValid = true;

        // Check if the selected date is in the future
        if (new Date(selectedDate) > new Date(today)) {
            isValid = false;
            $('#edob').text('Please select a date on or before today').addClass('text-danger');
            $(this).addClass('border-danger');
        } else {
            $(this).removeClass('border-danger');
            $('#edob').text('').removeClass('text-danger');
        }

        // Perform any additional actions based on the validation result
        if (isValid) {
            // Your additional actions if the date is valid
        }
    });
});
$('#SaveEmp').click(function (event) {
    event.preventDefault();
    var isValid = true;
    debugger
    var Empame = $("#name").val();
    var Empdob = $("#dob").val();
    var Empgender = $("#gender").val();
    var Empmob = $("#mobile").val();
    var Empemail = $("#email").val();
    var Empadd = $("#address").val();
    var Bankname = $("#bankName").val();
    var Accholder = $("#accountHolderName").val();
    var Ifsccode = $("#ifscCode").val();
    var Accno = $("#accountNumber").val();

    function isValidName(input)
    {
        return /^[A-Z][a-z]* [A-Z][a-z]*$/.test(input);
    }

    //var email_regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    function isValidEmail(input) {
        return /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(input);
    }

    debugger

    if (!isValidName(Empame)) {
        $('#ename').text('Please enter a valid name').addClass('text-danger');
        isValid = false;
        $('#name').addClass('border-danger');
    }
    else {
        $('#name').removeClass('border-danger');
        $('#ename').text('').removeClass('text-danger');
    }

    if (Empdob == '') {
        isValid = false;
        $('#edob').text('Please select a date on or before today').addClass('text-danger');
        $('#dob').addClass('border-danger');
    }
    else {
        $('#dob').removeClass('border-danger');
        $('#edob').text('').removeClass('text-danger');
    }

    if (Empgender == '') {
        isValid = false;
        $('#egender').text('Please select a gender').addClass('text-danger');
        $('#gender').addClass('border-danger');
    }
    else {
        $('#gender').removeClass('border-danger');
        $('#egender').text('').removeClass('text-danger');
    }

    if (Empmob == '') {
        isValid = false;
        $('#mob').text('Please give a 10 digit mobile number').addClass('text-danger');
        $('#mobile').addClass('border-danger');
    }
    else {
        $('#mobile').removeClass('border-danger');
        $('#mob').text('').removeClass('text-danger');
    }

    if (!isValidEmail(Empemail)) {
        $('#mail').text('Please enter a valid email id').addClass('text-danger');
        isValid = false;
        $('#email').addClass('border-danger');
    }
    else {
        $('#email').removeClass('border-danger');
        $('#mail').text('').removeClass('text-danger');
    }

    if (Empadd == '') {
        isValid = false;
        $('#add').text('Please give an address').addClass('text-danger');
        $('#address').addClass('border-danger');
    }
    else {
        $('#address').removeClass('border-danger');
        $('#add').text('').removeClass('text-danger');
    }

    if (Bankname == '') {
        isValid = false;
        $('#bankdtl').text('Please give a bank name').addClass('text-danger');
        $('#bankName').addClass('border-danger');
    }
    else {
        $('#bankName').removeClass('border-danger');
        $('#bankdtl').text('').removeClass('text-danger');
    }

    if (Bankname == '') {
        isValid = false;
        $('#bankdtl').text('Please give a bank name').addClass('text-danger');
        $('#bankName').addClass('border-danger');
    }
    else {
        $('#bankName').removeClass('border-danger');
        $('#bankdtl').text('').removeClass('text-danger');
    }

    if (!isValidName(Accholder)) {
        $('#acc').text('Please enter a valid name').addClass('text-danger');
        isValid = false;
        $('#accountHolderName').addClass('border-danger');
    }
    else {
        $('#accountHolderName').removeClass('border-danger');
        $('#acc').text('').removeClass('text-danger');
    }

    if (Ifsccode == '') {
        isValid = false;
        $('#ifsc').text('Please give a bank name').addClass('text-danger');
        $('#ifscCode').addClass('border-danger');
    }
    else {
        $('#ifscCode').removeClass('border-danger');
        $('#ifsc').text('').removeClass('text-danger');
    }

    if (Accno === '' || !/^\d+$/.test(Accno)) {
        $('#accountNumber').addClass('border-danger');
        $('#accno').text('Please enter a valid account number.').addClass('text-danger');
        isValid = false;
    } else {
        $('#accountNumber').removeClass('border-danger');
        $('#accno').text('').removeClass('text-danger');
    }


    if (!isValid) {
        alert('form is not valid.');
        return isValid;

    }
    else {


        var formData = new FormData();
        formData.append('EmpName', Empame);
        formData.append('EmpDob', Empdob);
        formData.append('EmpGender', Empgender);
        formData.append('EmpMob', Empmob);
        formData.append('EmpEmail', Empemail);
        formData.append('EmpAddress', Empadd);
        formData.append('BankName', Bankname);
        formData.append('AccountHolderName', Accholder);
        formData.append('IfscCode', Ifsccode);
        formData.append('AccountNo', Accno);

        debugger
        $.ajax({

            type: "POST",
            url: "../ModelView/EmpDetailsPost/",
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
    }

});

function getemployedtl() {
    debugger
    $.ajax({
        type: 'GET',
        url: "/ModelView/EmpDetailGet",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {

            var row = "";
            var rowcount = 1;

            debugger
            $.each(data.empdtl, function (item, value) {
                debugger
                row += "<tr>";
                row += "<td>" + rowcount + "</td>";
                row += "<td>" + value.empName + "</td>";
                row += "<td>" + value.empDob + "</td>";
                row += "<td>" + value.empGender + "</td>";
                row += "<td>" + value.empMob + "</td>";
                row += "<td>" + value.empEmail + "</td>";
                row += "<td>" + value.empAddress + "</td>";
                row += "<td>" + value.bankName + "</td>";
                row += "<td>" + value.accountHolderName + "</td>";
                row += "<td>" + value.ifscCode + "</td>";
                row += "<td>" + value.accountNo + "</td>";



                
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

$('#search').on('keyup', function () {
    var searchTerm = $(this).val().toLowerCase();
    $('#usertbl tbody tr').each(function () {
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(searchTerm) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});