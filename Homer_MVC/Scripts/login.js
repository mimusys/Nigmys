//Login Ajax Call
$("#Login_Button").on('submit', function(e){
    $.ajax({
        type: 'POST',
        url: '/Login/CheckLogin',
        datatype: 'json',
        data: { username: 'john', password: 'doe' },
        contenttype: 'application/json',
        success: function(data) {
            alert(data.Username + " | " + data.Password + " | " + data.Message);
        },
        error: function(data) {
            alert("ERROR");
        }

    })
});