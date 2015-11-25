//Login Ajax Call
$("#loginForm").submit(function (e) {
    var user = document.getElementById("username").value;
    var pass = document.getElementById("password").value;

    $.ajax({
        type: 'POST',
        url: '/Login/CheckLogin',
        datatype: 'json',
        cache: false,
        async: false,
        data: {username: user, password: pass},
        contenttype: 'application/json',
        success: function (data) {
            alert(data.Message);
        },
        error: function (data) {
            alert("ERROR, YO");
        }

    });
});