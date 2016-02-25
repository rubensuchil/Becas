$(document).ready(function () {
    $("#divCarrera").hide();
    $("#divGrupo").hide();
    $("#divtioBeca").hide();
    $(".m").hide();
    $(".r").hide()
    cargarCombo();
    $("#imgB").click(function () {
        $("#divBeca").show();
        $("#divGrupo").hide();
        $("#divCarrera").hide();
        $("#divtioBeca").hide();
        obtenerTabla(1);
        cargarCombo();
        $(".g").show();
    });

    $("#imgG").click(function () {
        $("#divGrupo").show();
        $("#divBeca").hide();
        $("#divCarrera").hide();
        $("#divtioBeca").hide();
        obtenerTabla(2);
        $(".g").show();
    });

    $("#imgC").click(function () {
        $("#divCarrera").show();
        $("#divBeca").hide();
        $("#divGrupo").hide();
        $("#divtioBeca").hide();
        obtenerTabla(3);
        $(".g").show();
    });

    $("#imtipob").click(function () {
        $("#divCarrera").hide();
        $("#divBeca").hide();
        $("#divGrupo").hide();
        $("#divtioBeca").show();
        obtenerTabla(4);
        $(".g").show();
    });


    $(".r").click(function () {
        $(".g").show();
        $(".m").hide();
        $(".r").hide();
    });
});                      //--------------------------------------- fin del document ready---------------------------------------------\\



function obtenerTabla(origen) {
    
    $.ajax({
        url: "configuracion.aspx/obtenerTabla",
        data: "{origen:" + origen + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                $("#tabla").html("");
                $("#tabla").append(data.d);
                
               
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}

function eliminar(origen,id) {
    $.ajax({
        url: "configuracion.aspx/eliminar",
        data: "{origen:" + origen + ",id:" + id + "}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "0") {
                alert("eliminado");
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}

function guardar(origen) {

    if (origen == 1) {
        var tipob = $("#ss").val();
        var beca = $("#TxtBeca").val();
        var prom = $("#txtprom").val();
        var desc = "Na";
    } else if (origen == 2) {
        var tipob = 0;
        var beca = $("#txtGrupo").val();
        var prom = 0;
        var desc = $("#txtDescripciong").val();

    } else if (origen == 3) {
        var tipob = 0;
        var beca = $("#txtCarrera").val();
        var prom = 0;
        var desc = $("#txtDescripcionc").val();

    }
    else if (origen == 4) {
        var tipob = 0;
        var beca = $("#txttBeca").val();
        var prom = 0;
        var desc = $("#txtdesctb").val();

    }
    $.ajax({
        url: "configuracion.aspx/guardar",
        data: "{beca:'" + beca + "',tipob:" + tipob + ",prom:"+prom+",ido:"+origen+",desc:'"+desc+"'}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "0") {
                alert("guardado");
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}


function modificarb(id) {

    var beti = $("#txttiB" + id).val();
    var prom = $("#txtprom" + id).val();
    var bec = $("#txtb" + id).val();
    var idB = $("#txttiB" + id).val();

    $("#TxtBeca").val(bec);
    $("#txtIdBeca").val(beti);
    $("#txtprom").val(prom);

    $('#ss > option[value="'+idB+'"]').attr('selected', 'selected');

    $(".g").hide();
    $(".m").show();
    $(".r").show();
}

function modificarg(id) {
   var id = $("#txtidg" + id).val();
   var dec= $("#txtdesc"+id).val();
   var grup = $("#txtg" + id).val();

   $("#txtGrupo").val(grup);
   $("#txtIdGrupo").val(id);
   $("#txtDescripciong").val(dec);
   $(".g").hide();
   $(".m").show();
   $(".r").show();

}

function modificarc(id) {
    var dec = $("#txtdc" + id).val();
    var carr = $("#txtc" + id).val();

    $("#txtCarrera").val(carr);
    $("#txtIdCarrera").val(id);
    $("#txtDescripcionc").val(dec);
    $(".g").hide();
    $(".m").show();
    $(".r").show();
}


function modificartbb(id) {
    var dec = $("#txtdesc" + id).val();
    var beca = $("#txtb" + id).val();

    $("#txttBeca").val(beca);
    $("#txtidtBeca").val(id);
    $("#txtdesctb").val(dec);
    $(".g").hide();
    $(".m").show();
    $(".r").show();
}


function modificarbase(origen) {

    if (origen == 1) {

        var id = $("#txtIdBeca").val();
        var tipob = $("#ss").val();
        var beca = $("#TxtBeca").val();
        var prom = $("#txtprom").val();
        var desc = "Na";
    } else if (origen == 2) {
        var id = $("#txtIdGrupo").val();        
        var tipob = 0;
        var beca = $("#txtGrupo").val();
        var prom = 0;
        var desc = $("#txtDescripciong").val();

    } else if (origen == 3) {
        var id = $("#txtIdCarrera").val();
        var tipob = 0;
        var beca = $("#txtCarrera").val();
        var prom = 0;
        var desc = $("#txtDescripcionc").val();

    }
    else if (origen == 4) {
        var id = $("#txtidtBeca").val();
        var tipob = 0;
        var beca = $("#txttBeca").val();
        var prom = 0;
        var desc = $("#txtdesctb").val();

    }
    $.ajax({
        url: "configuracion.aspx/modificar",
        data: "{id:"+id+",beca:'" + beca + "',tipob:" + tipob + ",prom:" + prom + ",ido:" + origen + ",desc:'" + desc + "'}",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "0") {
                alert("Modificado");
            } else {
                alert("error de conexion");
            }
        }, error: function (xhr, error, status) {
            alert("Error de conexión, intenta nuevamente");
        }
    });

}


function cargarCombo() {
    $.ajax({
        url: "configuracion.aspx/cargarCombo",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                $("#divcombo").html("");
                $("#divcombo").append(data.d);
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

