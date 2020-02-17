$(function () {
    $.ajax({
        async: false,
        type: 'GET',
        url: '../Service.svc/GetEmpresas',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            llenarCombo2("empresas", data, "idCliente", "nombre");
        }
    });

    $("#empresas").change(function () {
        var json = {
            idEmpresa: $("#empresas").val()
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/SectoresxEmpresa',
            dataType: 'json',
            data: JSON.stringify(json),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                llenarComboxParametro("sectorHead", data, "idSector", "descripcion");

                $("#sectorHead").val(obtenerParametroPorNombre('idSectorr')).trigger('change');
            }
        });
    }).change();


   

    initEventos();
});
function initEventos() {
    $("#graficasN").change(function () {
        var html = '';
        
        $("#graficasDinamicas").empty();

        for (var i = 0; i < $("#graficasN").val(); i++) {
            html += '<div class="col-md-12" >'
            html += '    <div class="card-header">'
            html += '        <div class="form-body">'
            html += '            <div class="row">'
            html += '                <div class="col-md-3">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Tipo Grafica</label>'
            html += '                        <select class="form-control" id="tipo' + i + '" name="tipo' + i +'"><option value="1">Lineal</option><option value="2">Barra</option><option value="3">Versus</option></select>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-3">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Rangos</label>'
            html += '                        <select class="form-control" id="rangos' + i + '" name="rangos' + i + '"><option value="1">Dias</option><option value="2">Meses</option>'
            html += '                        </select >'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-3">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Dispositivo</label>'
            html += '                        <select class="form-control" id="dispositivos' + i + '" name="nombreTabla' + i + '">'
            html += '                        </select >'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-3">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Variable</label>'
            html += '                        <select class="form-control" id="variables' + i + '" name="campoTabla' + i + '" size="1"  multiple="multiple" class="select2"></select>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '            </div>'
            html += '            <div class="row">'
            html += '                <div class="col-md-4">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Fecha Inicio</label>'
            html += '                        <input  placeholder="fecha inicio" id="fechaIni' + i + '" data-date-format="yyyy/mm/dd" class="form-control pickadate" type="text"/>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-4">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Fecha Fin</label>'
            html += '                        <input  placeholder="fecha fin" id="fechaFin' + i + '" data-date-format="yyyy/mm/dd" class="form-control pickadate" type="text"/>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-4">'
            html += '                    <fieldset class="form-group">'
            html += '                            <br/><button type="button" class="btn btn-raised btn-primary" id="btnGuardar' + i + '" dataJson="no" dataYaxis= "no" lado="1">Graficar <i class="fa fa-bar-chart" aria-hidden="true" ></i></button>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '            </div>'
            html += '        </div>'

            html += '    </div>'
            html += '    <div class="card-content"><br/><br/>'
            html += '        <div class="card-body chartjs" id="graph-container' + i +'">'
            html += '            <canvas id="chart' + i +'" height="401" width="1549" style="display: block; width: 690px; height: 246;"></canvas>'
            html += '        </div>'
            html += '    </div>'
            html += '</div>'
        }

        $("#graficasDinamicas").html(html);

        var json = {
            idCliente: $("#empresas").val(),
            idSector: $("#sectorHead").val()
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/GetDispositivos',
            dataType: 'json',
            data: JSON.stringify(json),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {

                for (var j = 0; j < $("#graficasN").val(); j++) {
                    eventoBoton(j);
                    //llenarCombo(j);    
                    iniciarDatePicker(j);
                    llenarComboxParametro("dispositivos" + j, data, "idDispositivo", "descripcion");
                    initComboVariables(j);

                    $("#variables" + j).select2({
                        placeholder: "Seleccione una opcion...",
                        width: "200px"
                    });
                }
            }

        });

    });
}
function initComboVariables(id) {
        $("#dispositivos" + id).change(function () {
            var json = {
                idDispositivo: parseInt($("#dispositivos" + id).val())
            };

            $.ajax({
                type: 'POST',
                url: '../Service.svc/GetVariablesxDispositivos',
                dataType: 'json',
                data: JSON.stringify(json),
                contentType: 'application/json; charset=utf-8',
                success: function (dat) {
                    llenarComboxParametro("variables" + id, dat, "idVariable", "nombre");
                }
            });

        });

}
function graficaLineal(id, datas, labels, numero, columna) {
    console.log(obtenerTextoSelect2ById(columna));

    var chartColors = {
        red: 'rgb(255, 99, 132)',
        orange: 'rgb(255, 159, 64)',
        yellow: 'rgb(255, 205, 86)',
        green: 'rgb(75, 192, 192)',
        blue: 'rgb(54, 162, 235)',
        purple: 'rgb(153, 102, 255)',
    };

    var colores = ['rgb(255, 159, 64)', 'rgb(255, 205, 86)', 'rgb(75, 192, 192)', 'rgb(54, 162, 235)', 'rgb(153, 102, 255)', 'rgb(231,233,237)'];

    var dataSet = {};
    var axis = {};
    var arr = [];
    var arrYaxis = [];

    if ($("#btnGuardar" + numero).attr("dataJson") == "no") {
        dataSet = {
            label: $('select[id="dispositivos' + numero +'"] option:selected').text()+" - "+obtenerTextoSelect2ById(columna),
            backgroundColor: chartColors.red,
            borderColor: chartColors.red,
            data: datas,
            fill: false,
            yAxisID: obtenerTextoSelect2ById(columna)
        };
        arr.push(dataSet);

        axis = {
            display: true,
            scaleLabel: {
                display: true,
            },
            id: obtenerTextoSelect2ById(columna),
            type: 'linear',
            position: 'left',
            gridLines: {
                zeroLineColor: chartColors.red
            }
        };

        arrYaxis.push(axis);

        $("#btnGuardar" + numero).attr("dataYaxis", JSON.stringify(arrYaxis));
        $("#btnGuardar" + numero).attr("dataJson", JSON.stringify(arr));
        $("#btnGuardar" + numero).attr("lado", "1");

    } else {
        $("#" + id).remove(); // this is my <canvas> element
        $('#graph-container' + numero).append('<canvas id="chart' + numero + '" height="401" width="1549" style="display: block; width: 690px; height: 246;"></canvas>');

        var color = colores[numeroAleatorio(0, 4)];

        dataSet = {
            label: $('select[id="dispositivos' + numero + '"] option:selected').text() + " - " + obtenerTextoSelect2ById(columna),
            backgroundColor: color,
            borderColor: color,
            data: datas,
            fill: false,
            yAxisID: obtenerTextoSelect2ById(columna)
        };

        var lado = numeroAleatorio(0, 1);

        if (lado == "1" || lado == 1) {
            axis = {
                display: true,
                scaleLabel: {
                    display: true,
                },
                id: obtenerTextoSelect2ById(columna),
                type: 'linear',
                position: 'right',
                gridLines: {
                    color: color,
                    display: false
                }

            };
            $("#btnGuardar" + numero).attr("lado", "0");
        } else {
            axis = {
                display: true,
                scaleLabel: {
                    display: true,
                },
                id: obtenerTextoSelect2ById(columna),
                type: 'linear',
                position: 'left',
                gridLines: {
                    color: color,
                    display: false
                }

            };
            $("#btnGuardar" + numero).attr("lado", "1");
        }

        var arr1 = JSON.parse($("#btnGuardar" + numero).attr("dataJson"));
        var arr2 = [dataSet];
        arr = arr1.concat(arr2);
        $("#btnGuardar" + numero).attr("dataJson", JSON.stringify(arr));

        var arrYaxis1 = JSON.parse($("#btnGuardar" + numero).attr("dataYaxis"));
        var arrYaxis2 = [axis];
        arrYaxis = arrYaxis1.concat(arrYaxis2);
        $("#btnGuardar" + numero).attr("dataYaxis", JSON.stringify(arrYaxis));
    }

    labelsD = [];

    if ($("#rangos" + numero).val() == 1 || $("#rangos" + numero).val() == "1") {
        for (var i = 1; i <= 31; i++) {
            labelsD.push(i);
        }
    } else {
        labelsD = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
    }

    var config = {
        type: 'scatter',
        data: {
            labels: labelsD,
            datasets: arr
        },
        options: {
            responsive: true,
            tooltips: {
                mode: 'label'
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Mes'
                    }
                }],
                yAxes: arrYaxis
            },

            maintainAspectRatio: false,
            responsiveAnimationDuration: 500,
        }
    };


    var ctx = document.getElementById(id).getContext("2d");
    ourChart = new Chart(ctx, config);
}
function graficaBarra(id, datas, labels, numero) {
    $("#" + id).remove();
    $('#graph-container' + numero).append('<canvas id="chart' + numero + '" height="401" width="1549" style="display: block; width: 690px; height: 246;"></canvas>');

    var canvas = document.getElementById(id);
    var data = {
        labels: labels,
        datasets: [
            {
                label: "Barra",
                backgroundColor: "rgba(255,99,132,0.2)",
                borderColor: "rgba(255,99,132,1)",
                borderWidth: 2,
                hoverBackgroundColor: "rgba(255,99,132,0.4)",
                hoverBorderColor: "rgba(255,99,132,1)",
                data: datas,
            }
        ]
    };
    var option = {
        animation: {
            duration: 5000
        },
        responsive: true,
        maintainAspectRatio: false,
        responsiveAnimationDuration: 500,

    };


    var myBarChart = Chart.Bar(canvas, {
        data: data,
        options: option
    });


}
function graficaVersus(id, datas, datas2, labels, numero) {
    $("#" + id).remove();
    $('#graph-container' + numero).append('<canvas id="chart' + numero + '" height="401" width="1549" style="display: block; width: 690px; height: 246;"></canvas>');

    var chartColors = {
        red: 'rgb(255, 99, 132)',
        orange: 'rgb(255, 159, 64)',
        yellow: 'rgb(255, 205, 86)',
        green: 'rgb(75, 192, 192)',
        blue: 'rgb(54, 162, 235)',
        purple: 'rgb(153, 102, 255)',
        grey: 'rgb(231,233,237)'
    };

    var config = {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: "Lineal",
                backgroundColor: chartColors.red,
                borderColor: chartColors.red,
                data: datas,
                fill: false
            }, {
                    label: "Lineal",
                    backgroundColor: chartColors.blue,
                    borderColor: chartColors.blue,
                    data: datas2,
                    fill: false
                }]
        },
        options: {
            responsive: true,

            tooltips: {
                mode: 'label'
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Mes'
                    }
                }],
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: ''
                    }
                }]
            },
            maintainAspectRatio: false,
            responsiveAnimationDuration: 500,
        }
    };


    var ctx = document.getElementById(id).getContext("2d");
    window.myLine = new Chart(ctx, config);
}
function eventoBoton(numero) {
    $("#btnGuardar" + numero).unbind();
    $("#btnGuardar" + numero).click(function () {
        var arrSelect2 = [];
        arrSelect2 = $("#variables" + numero).val();
        for (var i = 0; i < arrSelect2.length; i++) {

            var datas = [];
            var labels = [];
            var json = {};
            if ($("#tipo" + numero).val() == "1" || $("#tipo" + numero).val() == 1) {
                json = {
                    idDispositivos: $("#dispositivos" + numero).val(),
                    idVariable: arrSelect2[i],
                    fechaIni: $("#fechaIni" + numero).val(),
                    fechaFin: $("#fechaFin" + numero).val(),
                    opcion: $("#rangos" + numero).val()
                };
                $.ajax({
                    async:false,
                    type: 'POST',
                    url: '../Service.svc/getDatosGrafica',
                    data: JSON.stringify(json),
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        $.each(data.result, function (i, item) {
                            datas.push({ x: parseInt(item.label), y: parseInt(item.valor)});
                            labels.push(item.label);
                        });

                        console.log(datas);
                        graficaLineal("chart" + numero, datas, labels, numero, arrSelect2[i]);
                    }
                });

            }
        }
    });
}
function iniciarDatePicker(numero) {
    $('#fechaIni' + numero).pickadate({
        monthsFull: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthsShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        weekdaysFull: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
        weekdaysShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
        selectMonths: true,
        selectYears: 100, // Puedes cambiarlo para mostrar más o menos años
        today: 'Hoy',
        clear: 'Limpiar',
        close: 'Ok',
        labelMonthNext: 'Siguiente mes',
        labelMonthPrev: 'Mes anterior',
        labelMonthSelect: 'Selecciona un mes',
        labelYearSelect: 'Selecciona un año',
        format: 'yyyy-m-d',
        formatSubmit: 'yyyy-m-d'
    });

    $('#fechaFin' + numero).pickadate({
        monthsFull: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthsShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        weekdaysFull: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
        weekdaysShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
        selectMonths: true,
        selectYears: 100, // Puedes cambiarlo para mostrar más o menos años
        today: 'Hoy',
        clear: 'Limpiar',
        close: 'Ok',
        labelMonthNext: 'Siguiente mes',
        labelMonthPrev: 'Mes anterior',
        labelMonthSelect: 'Selecciona un mes',
        labelYearSelect: 'Selecciona un año',
        format: 'yyyy-m-d',
        formatSubmit: 'yyyy-m-d'
    });

}
function numeroAleatorio(min,max) {
    return Math.round(Math.random() * (max - min) + min);
}
function obtenerTextoSelect2ById(id) {
    var opcionText;
    $("#variables0 option").each(function () {
        if (id == $(this).attr('value')) {
            opcionText = $(this).text();
        }
    });

    return opcionText;
}