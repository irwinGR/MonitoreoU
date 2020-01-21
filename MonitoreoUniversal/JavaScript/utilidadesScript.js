function revalidarBootsVal(idFormulario, nameCampo) {
    $("#" + idFormulario).bootstrapValidator('revalidateField', nameCampo);
}

function llenarCombo(id, data,value,text) {
    $('#' + id).empty();
    $('#' + id).append($('<option>', {
        value: 0,
        text: "Seleccione una opción..."
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
        text: "Seleccione una opción..."
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

function soloLetras(e) {
    key=e.keyCode || e.which;
    teclado = String.fromCharCode(key).toLocaleLowerCase();
    letras = " áéíóúñabcdefghijklmnñopqrstuvwxyz"; 
    especiales = "8-37-38-46-164";

    teclado_especial = false;

    for(var i in especiales)
    {
        if(key==especiales[i]){
            teclado_especial=true;break;
        }
    }

    if(letras.indexOf(teclado)==-1 && !teclado_especial)
    {
        return false;
    }

    
}


    

