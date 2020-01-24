$(function () {
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
            html += '                <div class="col-md-4">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Tipo Grafica</label>'
            html += '                        <select class="form-control" id="tipo' + i + '" name="tipo' + i +'"><option value="1">Lineal</option><option value="2">Barra</option></select>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-4">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Dispositivo</label>'
            html += '                        <select class="form-control" id="nombreTabla' + i + '" name="nombreTabla' + i + '">'
            html += '                        </select >'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '                <div class="col-md-4">'
            html += '                    <fieldset class="form-group">'
            html += '                        <label for="basicInput">Variable</label>'
            html += '                        <select class="form-control" id="campoTabla' + i + '" name="campoTabla' + i + '"></select>'
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
            html += '                            <br/><button type="button" class="btn btn-raised btn-primary" id="btnGuardar' + i + '">Graficar <i class="fa fa-bar-chart" aria-hidden="true"></i></button>'
            html += '                    </fieldset>'
            html += '                </div>'
            html += '            </div>'
            html += '        </div>'

            html += '    </div>'
            html += '    <div class="card-content"><br/><br/>'
            html += '        <div class="card-body chartjs">'
            html += '            <canvas id="chart' + i +'" height="401" width="1549" style="display: block; width: 690px; height: 246;"></canvas>'
            html += '        </div>'
            html += '    </div>'
            html += '</div>'
        }

        $("#graficasDinamicas").html(html);

        for (var j = 0; j < $("#graficasN").val(); j++) {
            eventoBoton(j);
            //llenarCombo(j);    
            iniciarDatePicker(j);
        }
        

    });
}
function graficaLineal(id,datas,labels) {
    $("#" + id).empty();
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
function graficaBarra(id, datas, labels) {
    $("#" + id).empty();

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
function eventoBoton(numero) {
    
    $("#btnGuardar" + numero).click(function () {
        var labels = ["Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"];
        var datas = [numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200), numeroAleatorio(50,200)];
        var json = {};
        if ($("#tipo" + numero).val() == "1" || $("#tipo" + numero).val() == 1) {
             graficaLineal("chart" + numero, datas, labels);
        } else if ($("#tipo" + numero).val() == "2" || $("#tipo" + numero).val() == 2){
             graficaBarra("chart" + numero, datas, labels);
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
        formatSubmit: 'yyyy/mm/dd'
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
        formatSubmit: 'yyyy/mm/dd'
    });

}
function numeroAleatorio(min,max) {
    return Math.round(Math.random() * (max - min) + min);
}