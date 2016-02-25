var idUser = 0;
$(document).ready(function () {
    idUser = $("#header_txtIdUsuario").val();

    $("#btnBuscarB").click(function () {
        selectBecaUser(idUser);

    });

    seleccionarDatos(idUser);
    consulBeca(idUser);
});                    //--------------------------------------- fin del document ready---------------------------------------------\\



function selectBecaUser(idUser) {
    bloqueoPantalla();
    $.ajax({
        url: "Home.aspx/selectBecaUser",
        data: "{idUser:" + idUser + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                $("#divBecas").html("");
                $("#divBecas").append(data.d);
              
                $.unblockUI();
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}

function seleccionarDatos(idUser) {
    $.ajax({
        url: "Home.aspx/obtenerDatosUser",
        data: "{iduser:" + idUser + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                $("#txtNombre").text(data.d[0]);
                $("#txtPromedio").text(data.d[1]);
                $("#txtCarrera").text(data.d[2]);
                $("#txtGrupo").text(data.d[3]);
                
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}
function solicitar(idBeca) {
    $.ajax({
        url: "Home.aspx/solicitarB",
        data: "{iduser:" + idUser + ",idBeca:" + idBeca + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "0") {
                alert("Beca solicitada!");
                window.location.reload();
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });
}

function consulBeca(idUser) {
    $.ajax({
        url: "Home.aspx/consulBeca",
        data: "{iduser:" + idUser + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                $("#divBecasS").val("");
                $("#divBecasS").append(data.d);
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });
}


function eliminarS(idb) {
    $.ajax({
        url: "Home.aspx/eliminarS",
        data: "{idB:" + idb + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d = "0") {
                alert("Beca Cancelada!");
                window.location.reload();
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });
}


function bloqueoPantalla() {
    block();
}

