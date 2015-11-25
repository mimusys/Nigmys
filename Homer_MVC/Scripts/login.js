//Login Ajax Call
$("#loginForm").submit(function (e) {
    var data = $('#loginForm').serialize();

    $.ajax({
        type: 'POST',
        url: '/Login/CheckLogin',
        datatype: 'json',
        cache: false,
        data,
        contenttype: 'application/json',
        success: function (data) {
            alert("SUCCESS, YO");
        },
        error: function(data) {
            alert("ERROR, YO");
        }

    })
});