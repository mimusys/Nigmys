$.validator.addMethod('regex', function (value, element, param) {
    return this.optional(element) || value.match(typeof param == 'string' ? new RegExp(param) : param);
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
        password: "required",
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
        password: "A password is requried",
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
        $('[href=#step3]').tab('show');
    }
});

$("#submitButton").click(function () {
    doFullValidation();
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

            // do image upload if file selected
            var fileInput = document.getElementById("fileUpload");
            if (fileInput.files.length == 1 && success) {
                var formData = new FormData();
                formData.append("file", fileInput.files[0]);
                $.ajax({
                    type: 'POST',
                    url: 'SignUp/UploadPicture',
                    data: formData,
                    dataType: 'json',
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        if (data == false) {
                            alert("Failed to upload profile picture.");
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.status);
                        alert(thrownError);
                    }
                })
            }

            if (success) {
                window.location.href = "/Dashboard/Index";
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

$(function () {

    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $('a[data-toggle="tab"]').removeClass('btn-primary');
        $('a[data-toggle="tab"]').addClass('btn-default');
        $(this).removeClass('btn-default');
        $(this).addClass('btn-primary');
    })

    $('.next').click(function () {
        var nextId = $(this).parents('.tab-pane').next().attr("id");
        $('[href=#' + nextId + ']').tab('show');
    })

    $('.prev').click(function () {
        var prevId = $(this).parents('.tab-pane').prev().attr("id");
        $('[href=#' + prevId + ']').tab('show');
    })

    $('.submitWizard').click(function () {

        var approve = $(".approveCheck").is(':checked');
        if (approve) {
            // Got to step 1
            $('[href=#step1]').tab('show');

            // Serialize data to post method
            var datastring = $("#simpleForm").serialize();

            // Show notification
            swal({
                title: "Thank you!",
                text: "You approved our example form!",
                type: "success"
            });
            //            Example code for post form
            //            $.ajax({
            //                type: "POST",
            //                url: "your_link.php",
            //                data: datastring,
            //                success: function(data) {
            //                    // Notification
            //                }
            //            });
        } else {
            // Show notification
            swal({
                title: "Error!",
                text: "You have to approve form checkbox.",
                type: "error"
            });
        }
    })
})