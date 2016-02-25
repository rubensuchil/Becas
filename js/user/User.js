$(document).ready(function () {

    // user("#txtIdUser", "#txtName", "user");
    carrera("#txtIdCarrera", "#txtCarrera", "carrera");
    grupo("#txtIdGrupo", "#txtGrupo", "grupo");
    usuario("#txtIdUser", "#txtName", "user");

    $("#btnSave").click(function () {
        validarCampos();
    });

    $("#btnReset").click(function () {
        reset();
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
    $("#dialogSucces").dialog({
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

    $("#dialogAlet").dialog({
        autoOpen: false,
        width: 200,
        height: 120,
        show: {
            effect: "blind",
            duration: 2000
        },
        hide: {
            effect: "blind",
            duration: 2000
        }
    });

    $("#btnDelete").click(function () {
        $("#dialogAlet").dialog('open');
    });

    $("#hrefCancelar").click(function () {
        $("#dialogAlet").dialog('close');
    });

    $("#btnAcept").click(function () {
        var idUser = $("#txtIdUser").val();
        deleteUser(idUser);
    });



});                 //--------------------------------------- fin del document ready---------------------------------------------\\

function validarCampos() {
    var name = $("#txtName").val();
    var email = $("#txtEmail").val();
    var pass = $("#txtPassword").val();
    var user =$("#txtIdUser").val();

    var carrear = $("#txtCarrera").val();
    var idCarrera = $("#txtIdCarrera").val();
    var grupo = $("#txtGrupo").val();
    var idGrupo = $("#txtIdGrupo").val();
    var prom = $("#txtProm").val();

    var idRol = 0;
    $(".rdb").each(function () {
        var idchk = this.id;

        if (idchk == "rdbM") {
            if ($("#rdbM").is(':checked')) {
                idRol = 1;
            }
        } else
            if (idchk == "rdbC") {
                if ($("#rdbC").is(':checked')) {
                    idRol = 2;
                }
            } else
                if (idchk == "rdbP") {
                    if ($("#rdbP").is(':checked')) {
                        idRol = 3;
                    }
                }
    });


    if (name != "" && email != "" && pass != "" && idRol > 0 && carrera != "" && grupo != "" && prom > 0) {
        saveUser(name, email, pass, idRol,idCarrera,idGrupo,prom);
    } else {
       
        if (name == "") {
            $("#txtName").css({ "border": "1px solid red" });
            $("#txtName").focus();
        } else if (email == "") {
            $("#txtEmail").css({ "border": "1px solid red" });
            $("#txtEmail").focus();
        } else if (pass == "") {
            $("#txtPassword").css({ "border": "1px solid red" });
            $("#txtPassword").focus();
        } else if (idRol == 0) {
            $("#divRol").css({ "border": "1px solid red" });
            $("#divRol").focus();
        }else if (carrera == 0) {
            $("#txtCarrera").css({ "border": "1px solid red" });
            $("#txtCarrera").focus();
        }else if (grupo == 0) {
            $("#txtGrupo").css({ "border": "1px solid red" });
            $("#txtGrupo").focus();
        } else if (prom == 0) {
            $("#txtProm").css({ "border": "1px solid red" });
            $("#txtProm").focus();
        } 
    }
}

function saveUser(name, email, pass, idRol, idCarrera, idGrupo, prom) {
    bloqueoPantalla();
    $.ajax({
        url: "User.aspx/saveUser",
        data: "{name:'" + name + "',email:'" + email + "',pass:'" + pass + "',idRol:" + idRol + ",idCarrera:" + idCarrera + ",idGrupo:" + idGrupo + ",prom:" + prom + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == '0') {
                $("#lblSucces").text("");
                $("#lblSucces").text("Usuario insertado con exito!");
                $("#dialogSucces").dialog('open');
                $("#dialogSucces").dialog('close');
                reset();
            } else if (data.d == '-1') {
                $("#lblError").text("");
                $("#lblError").text("El usuario ya existe!");
                $("#dialogError").dialog('open');
                $("#dialogError").dialog('close');
            } 
            $.unblockUI();
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}



function carrera(idObjeto, nombre, metodo) {
    $(nombre).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "User.aspx/" + metodo + "",
                data: "{ term: '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.nombre,
                            ID: item.ID,
                            cc: item.label
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            var value = ui.item.value;
            var id = $(ui.item).attr("ID");
            $(idObjeto).val(id);
        }

    });
}

function grupo(idObjeto, nombre, metodo) {
    $(nombre).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "User.aspx/" + metodo + "",
                data: "{ term: '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.nombre,
                            ID: item.ID,
                            cc: item.label
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            var value = ui.item.value;
            var id = $(ui.item).attr("ID");
            $(idObjeto).val(id);
        }

    });
}


function usuario(idObjeto, nombre, metodo) {
    $(nombre).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "User.aspx/" + metodo + "",
                data: "{ term: '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.nombre,
                            ID: item.ID,
                            cc: item.label
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            var value = ui.item.value;
            var id = $(ui.item).attr("ID");
            $(idObjeto).val(id);
            selectUser(id);
        }

    });
}




function selectUser(idUser) {
    bloqueoPantalla();
    $.ajax({
        url: "User.aspx/selectUser",
        data: "{idUser:" + idUser + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                $("#txtEmail").val(data.d[0]);
                $("#txtPassword").val(data.d[1]);
                if (data.d[2] == 1) {
                    $("#rdbM").attr('checked', true);
                } else if (data.d[2] == 2) {
                    $("#rdbC").attr('checked', true);
                }
                var idCarrera = $("#txtIdCarrera").val(data.d[3]);
                var carrear = $("#txtCarrera").val(data.d[4]);
                var idGrupo = $("#txtIdGrupo").val(data.d[5]);
                var grupo = $("#txtGrupo").val(data.d[6]);
                var prom = $("#txtProm").val(data.d[7]);


                $("#btnDelete").removeClass("hide");
                $.unblockUI();
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}

function deleteUser(idUser) {
    bloqueoPantalla();
    $.ajax({
        url: "User.aspx/deleteUser",
        data: "{idUser:" + idUser + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == true) {
                $("#dialogAlet").dialog('close');
                $("#lblSucces").text("");
                $("#lblSucces").text("Succes, user deleted!");
                $("#dialogSucces").dialog('open');
                $("#dialogSucces").dialog('close');
                $.unblockUI();
                reset();
            } else {
                alert("error de conexion");
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

function reset(){
        $("#txtName").val("");
        $("#txtEmail").val("");
        $("#txtPassword").val("");
        $("#txtIdUser").val("");
        $(".rdb").attr('checked', false);
        $("#btnDelete").hide();
    }

    function bloqueoPantalla() {
        block();
    }