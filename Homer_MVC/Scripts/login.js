//Login Ajax Call
// test username = username1 password = password
// the database stores it as a hash
$("#loginForm").submit(function (e) {
    var user = document.getElementById("username").value;
    var pass = document.getElementById("password").value;
    var hash = "";
    var salt = "";

    $.ajax({
        type: 'POST',
        url: '/Login/CheckLogin',
        datatype: 'json',
        cache: false,
        async: false,
        data: {username: user, password: pass},
        contenttype: 'application/json',
        success: function (data) {
            hash = data.Hash;
            salt = data.Salt;
            alert(data.Hash);
        },
        error: function (data) {
            alert("ERROR, YO");
        }

    });

    var passWithSalt = pass + salt;
    var newHash = Sha256.hash(passWithSalt);
    if (newHash == hash) {
        // do redirect
        alert("Login Success");
    } else {
        alert("Login failure");
    }
});