$(document).ready(function () {


    $("#btnLogin").click(function () {
        validarCampos();
    });

    quitarError();

    $("#dialogError").dialog({
        autoOpen: false,
        width: 200,
        height: 90,
        show: {
            effect: "blind",
            duration: 2000
        },
        hide: {
            effect: "explode",
            duration: 2000
        }
    });
});          //--------------------------------------- fin del document ready---------------------------------------------\\

function validarCampos() {
   var email =  $("#txtEmail").val();
   var pass = $("#txtPassword").val();

   if (email != "" && pass != "") {
        validarLogin(email,pass);
    }else{
        if (email == "") {
            $("#txtEmail").css({ "border": "1px solid red" });
            $("#txtEmail").focus();
        }else if(pass ==""){
            $("#txtPassword").css({ "border": "1px solid red" });
            $("#txtPassword").focus();
        }
    }
}

function validarLogin(email, password) {
    bloqueoPantalla();
    $.ajax({
        url: "LogIn.aspx/validarUsuario",
        data: "{email:'" + email + "',password:'" + password + "'}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var res = data.d;
            if (res == true) {
                $(location).attr("href", "Home.aspx")
            } else {
                $("#lblError").text("");
                $("#lblError").text("Login or password is incorrect!");
                $("#dialogError").dialog('open');
                $("#dialogError").dialog('close');
                $.unblockUI();
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}

function quitarError() {
    $(".holder").click(function () {
        $(this).css({ "border": "1px solid #ccc" });
    });
}

function bloqueoPantalla() {
    block();
}