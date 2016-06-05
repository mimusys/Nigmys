$.validator.addMethod('regex', function (value, element, param) {
    return this.optional(element) || value.match(typeof param == 'string' ? new RegExp(param) : param);
});

$.validator.addMethod('similarFields', function (value, element, param) {
    return this.optional(element) || (param[0] != value && param[1] != value && param[2] != value);
});

var userInfoValidator = $("#userInfoForm").validate({
    onkeyup: false,
    ignore: ".ignore",
    rules: {
        username: {
            required: true,
            remote: {
                url: '/SignUp/CheckUsername',
                type: 'POST',
                data: {
                    username: function () {
                        return $("#username").val();
                    }
                }
            } 
        },
        email: {
            required: true,
            email: true,
            remote: {
                url: '/SignUp/CheckEmail',
                type: 'POST',
                data: {
                    email: function () {
                        return $("#email").val();
                    }
                }
            }
        },
        repeatEmail: {
            required: true,
            email: true,
            equalTo: "#email"
        },
        password: {
            required: true,
            regex: '^[a-zA-Z]\\w{3,14}$',
            similarFields: function () {
                return [$('#username').val(), $('#firstname').val(), $('#lastname').val()];
            }
        },
        repeatPassword: {
            required: true,
            equalTo: "#password"
        }
    },
    messages: {
        username: {
            required: "A username is required",
            remote: "Username already taken"
        },
        email: {
            required: "An email is required",
            email: "Email is invalid",
            remote: "This email is already registered to another user"
        },
        repeatEmail: {
            required: "Repeat the email entered",
            email: "A valid email is required",
            equalTo: "Emails do not match"
        },
        password: {
            required: "A password is required",
            regex: "Password must start with a letter, be 4-15 characters, and only contain numbers, letters and underscore",
            similarFields: "password cannot equal first name, last name, or username"
        },
        repeatPassword: {
            required: "Repeat the password entered",
            equalTo: "Passwords do not match"
        }
    }
});

var personalInfoValidator = $("#personalInfoForm").validate({
    onkeyup: false,
    ignore: ".ignore",
    rules: {
        firstname: "required",
        lastname: "required",
        address: "required",
        zipcode: {
            required: true,
            minlength: 5,
            maxlength: 5,
            regex: /^[0-9]+$/
        },
        bday: {
            required: true,
            date: true
        }
    },
    messages: {
        firstname: "A first name is required",
        lastname: "A last name is required",
        address: "An address is required",
        zipcode: {
            required: "A zipcode is required",
            minlength: jQuery.validator.format("Zipcode must be at least {0} numbers"),
            maxlength: jQuery.validator.format("Zipcode cannot be longer than {0} numbers"),
            regex: "A zipcode can only contain numbers"
        },
        bday: "A valid date is required"
    }  
});

$("#userInfoNext").click(function () {
    userInfoValidator.form();
    if (userInfoValidator.valid()) {
        $('[href=#step2]').tab('show');
    }
});

$("#personalInfoNext").click(function () {
    personalInfoValidator.form();
    if (personalInfoValidator.valid()) {
        generateSummary();
        $('[href=#step3]').tab('show');
    }
});


function doFullValidation() {
    userInfoValidator.form();
    if (!userInfoValidator.valid()) {
        $('[href=#step1]').tab('show');
    } else {
        personalInfoValidator.form();
        if (personalInfoValidator.valid()) {
            var salt = generateSalt();
            var hash = hashPass($("#password").val(), salt);
            var success = false;
            var successPhoto = false;
            // create user object to pass through ajax
            var user = {
                Username: $("#username").val(),
                Salt: salt,
                PasswordHash: hash,
                Email: $("#email").val(),
                FirstName: $("#firstname").val(),
                LastName: $("#lastname").val(),
                Address: $("#address").val(),
                Zipcode: $('#zipcode').val(),
                Birthday: $('#birthday').val(),
                CompanyName: $('#companyName').val()
            };

            // do image upload if file selected
            //var fileInput = document.getElementById("uploadFile");
            var fileInput = $("#uploadBtn")[0];

            // call create new user
            $.ajax({
                url: '/SignUp/NewUser',
                type: 'POST',
                dataType: 'json',
                cache: false,
                async: false,
                data: user,
                contenttype: 'application/json',
                success: function (data) {
                    if (data == true) {
                        success = true;
                    } else alert("Failed to create new user.");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }
            });
            
            if (fileInput.files.length == 1 && success) {
                var formData = new FormData();
                formData.append("file", fileInput.files[0]);
                $.ajax({
                    type: 'POST',
                    url: '/SignUp/UploadPicture',
                    data: formData,
                    dataType: 'json',
                    contentType: false,
                    processData: false,
                    async: false,
                    success: function (data) {
                        if (data == true) {
                            successPhoto = true;
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.status);
                        alert(thrownError);
                    }
                });

            }
            if (success) {
                if (successPhoto) {
                    swal({
                        title: "Thank you!",
                        text: "Your account has been successfuly created!",
                        type: "success",
                        showCancelButton: true,
                        cancelButtonColor: '#3085D6',
                        cancelButtonText: 'Return Home',
                        confirmButtonColor: '#62cb31',
                        confirmButtonText: 'Go to Titan'
                    },
                    function (isConfirm) {
                        if (isConfirm) {
                            $("body").removeClass('stop-scrolling');
                            window.location.href = "/Dashboard/Index";
                        } else {
                            $("body").removeClass('stop-scrolling');
                            window.location.href = "/";
                        }
                    });
                } else {
                    swal({
                        title: "Thank you!",
                        text: "Your account has been successfuly created (You can upload a profile picture later)",
                        type: "success",
                        showCancelButton: true,
                        cancelButtonColor: '#3085D6',
                        cancelButtonText: 'Return Home',
                        confirmButtonColor: '#62cb31',
                        confirmButtonText: 'Go to Titan'
                    },
                    function (isConfirm) {
                        if (isConfirm) {
                            $("body").removeClass('stop-scrolling');
                            window.location.href = "/Dashboard/Index";
                        } else {
                            $("body").removeClass('stop-scrolling');
                            window.location.href = "/";
                        }
                    });
                }
            } else {
                swal({
                    title: "Error!",
                    text: "Something went wrong when creating your account",
                    type: "error"
                },
                    function (isConfirm) {
                        $("body").removeClass('stop-scrolling');
                    });
            }

        } else {
            $('[href=#step2]').tab('show');
        }
    }
}

function generateSalt() {
    return Math.floor(Math.random() * (9999 - 1001)) + 1000;
}

function hashPass(pass, salt) {
    return Sha256.hash(pass + salt);
}

function generateSummary() {
    var username = $('#username').val();
    var passwordCount = passEncrypt($('#password').val());
    var email = $('#email').val();
    var todayDate = getTodayDate();
    var firstName = $('#firstname').val();
    var lastName = $('#lastname').val();
    var address = $('#address').val();
    var zipCode = $('#zipcode').val();
    var birthDay = $('#birthday').val();
    var companyName = $('#companyName').val() != '' ? $('#companyName').val() : 'N/A';

    $('#summary-username').text(username);
    $('#summary-password').text(passwordCount);
    $('#summary-email').text(email);
    $('#summary-date-created').text(todayDate);
    $('#summary-first-name').text(firstName);
    $('#summary-last-name').text(lastName);
    $('#summary-address').text(address);
    $('#summary-zip-code').text(zipCode);
    $('#summary-birthday').text(birthDay);
    $('#summary-company-name').text(companyName);
}

function passEncrypt(password) {
    var pass = "";
    var n = password.length;
    for (i = 0; i < n; i++) {
        pass = pass.concat('*');
    }
    return pass;
}

function getTodayDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    todayDate = mm + '/' + dd + '/' + yyyy;
    
    return todayDate;
}

$(function () {

    $("#submitButton").click(function () {
        var approve = $("div.approveCheck").children('div:first').hasClass('checked');
        if (approve) {
            doFullValidation();
        } else {
            swal({
                title: "Error!",
                text: "Please approve of our terms and conditions.",
                type: "error"
            },
            function (isConfirm) {
                $("body").removeClass('stop-scrolling');
            });
        }
    });
})