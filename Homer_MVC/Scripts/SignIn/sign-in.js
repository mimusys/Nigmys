 //Login Ajax Call
// test username = username1 password = password
// the database stores it as a hash

$("#Login_Button").click( function() {
    var user = document.getElementById("username").value;
    var pass = document.getElementById("password").value;
    var nonce = "";
    var salt = "";

    // get login metadata; i.e. salt and nonce
    $.ajax({
        type: 'POST',
        url: '/SignIn/GetLoginMetadata',
        datatype: 'json',
        cache: false,
        async: false,
        data: {username: user},
        contenttype: 'application/json',
        success: function (data) {
            nonce = data.Nonce;
            salt = data.Salt;
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
            alert(thrownError);
        }

    });

    // password info not found in database
    if (salt == "") {
        $("#loginError").removeClass("hidden-error");
        $("#usernameGroup").addClass("has-error");
        $("#passwordGroup").addClass("has-error");
        e.preventDefault();
    } else {
        // hash given password with salt then
        // do hash again with nonce and send
        // back to server for authorization
        var passWithSalt = pass + salt;
        var hashedPass = Sha256.hash(passWithSalt) + nonce;
        var newHash = Sha256.hash(hashedPass);
        var success;

        $.ajax({
            type: 'POST',
            url: '/SignIn/VerifyLogin',
            datatype: 'json',
            cache: false,
            async: false,
            data: { username: user, hashWithNonce: newHash },
            contenttype: 'application/json',
            success: function (data) {
                success = data.Success;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(xhr.responseText);
                alert(thrownError);
            }
        })

        // if login was a success do a redirect to dashboard
        // else show error
        if (success == true) {
            window.location.href = "/Dashboard/Index";
        } else {
            $("#loginError").removeClass("hidden-error");
            $("#usernameGroup").addClass("has-error");
            $("#passwordGroup").addClass("has-error");
            e.preventDefault();
        }
    }
});