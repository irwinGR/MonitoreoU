﻿function revalidarBootsVal(idFormulario, nameCampo) {
    $("#" + idFormulario).bootstrapValidator('revalidateField', nameCampo);
}

function llenarCombo(id, data,value,text) {
    $('#' + id).empty();
    $('#' + id).append($('<option>', {
        value: 0,
        text: "Seleccione una opcion..."
    }));

    $.each(data, function (i, item) {
        $('#' + id).append($('<option>', {
            value: item[value],
            text: item[text]
        }));
    });
}
function llenarComboxParametro(id, data,value, text) {
    $('#' + id).empty();
    $('#' + id).append($('<option>', {
        value: 0,
        text: "Seleccione una opcion..."
    }));

    $.each(data.result, function (i, item) {
        $('#' + id).append($('<option>', {
            value: item[value],
            text: item[text]
        }));
    });
}


function soloNumeros(e) {
    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        e.preventDefault();
    }
}