function ingresar() {
    if ($('#user').val() != "" && $('#pass').val() != "") {
        user={
            user: $('#user').val(),
            pass: $('#pass').val(),
            grupo: ""
        }
        $.ajax({
            type: "POST",
            url: "api/login/ingresar",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(user),
            success: function (data) {
                if (data) {
                    if (data[2] != 'Fail') {
                        user.grupo = data[0];
                        user.pass = data[1];
                        //window.location.href = data[3];
                        alert(data[2]);
                    } else {
                        user = {};
                        alert(data[1]);
                    }
                    
                    
                    
                } else
                    alert("Error");
            }
        });
    }
}