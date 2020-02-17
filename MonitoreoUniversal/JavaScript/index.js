
$(function () {
    $("#sidebarToggle").click();

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
            }
        });
    }).change();

    $("#sectorHead").change(function () {
        initEventos();
    });

    //initEventos();
    //cicloActualizacion();
});

function cicloActualizacion() {
    initEventos();
    setTimeout(function () {
        cicloActualizacion();
    }, 60000);
}
function initEventos() {
    
    var html = '';
    var nSensor = 0;
    var coordenadas = [];

    var Senso = [];

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
            console.log(data);
            $.each(data.result, function (i, item) {
                nSensor = i;
                coordenadas.push(item.coordenadas);
                Senso.push(item.idDispositivo);
                
            });


            var lat = [];
            var lng = [];
            var cordenada1 = [];
            var cordenada2 = [];
            var numero = 0;
            for (var i = 0; i <= nSensor; i++) {
                cordenada1 = coordenadas[i].split(',')[0];
                cordenada2 = coordenadas[i].split(',')[1];
                
                lat.push(cordenada1);
                lng.push(cordenada2);
                numero = i;
            }
            initMaps(Senso, numero, lat, lng);
        }

    });
}
function initMaps(sensor, numero, lat, lng) {
    var infowindow;
    var marker;

    var uluru = { lat: parseFloat(lat[0]), lng: -parseFloat(lng[0]) };
    var map = new google.maps.Map(document.getElementById('basic-map'), {
        zoom: 18,
        center: uluru
    });

    for (var i = 0; i < numero + 1; i++) {
        uluru = { lat: parseFloat(lat[i]), lng: -parseFloat(lng[i]) };
            

         marker = new google.maps.Marker({
            position: uluru,
            map: map,
            title: 'Dispositivo: ' + sensor[i]
        });

        infowindow = new google.maps.InfoWindow();

        var content = '<p>Dispositivo: ' + sensor[i] + ' <br> <br> Ubicacion: ITE Soluciones S.A de C.V</p>';

        var idDispo = 'Dispositivo:'+sensor[i];

        google.maps.event.addListener(marker, 'click', (function (marker, content, infowindow) {
            
            return function () {
                var cadena = content;
                var re = /<p>Dispositivo: /g;
                var resultado = cadena.replace(re, '');
                re = / <br> <br> Ubicacion: ITE Soluciones S.A de C.V/g;
                resultado = resultado.replace(re, '');
                resultado = resultado.substring(0, resultado.length - 4);
                console.log(resultado);

                var json = {
                    idDispositivo: parseInt(resultado)
                };

                $.ajax({
                    type: 'POST',
                    url: '../Service.svc/GetVariablesxDispositivos',
                    dataType: 'json',
                    data: JSON.stringify(json),
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        var html = "";
                        $("#contenedorVariables").empty();
                        $.each(data.result, function (i, item) {
                           
                            html += '<div class="col-md-6" >';
                            html += '        <div class="card gradient-green-tea">';
                            html += '            <div class="card-content">';
                            html += '                <div class="card-body pt-2 pb-0">';
                            html += '                    <div class="media">';
                            html += '                        <div class="media-body white text-left">';
                            html += '                            <center><h3 class="font-large-1 mb-0">' + item.valor + ' ' + item.unidadLectura.descripcion+'</h3></center>';
                            html += '                            <span><center>' + item.nombre+'</center></span><br>';
                            html += '                        </div>';
                            html += '                     </div>';
                            html += '                 </div>';
                            html += '            </div>';
                            html += '        </div>';
                            html += '   </div>';

                        });

                        $("#contenedorVariables").html(html);
                    }
                });

                infowindow.setContent(content);
                infowindow.open(map, marker);
            };

            
        })(marker, content, infowindow));

    }
}
function eventBotonGrafica() {
    if ($("#sectorHead").val() == 0) {
        toastWarning("Debe seleccionar un sector", "Advertencia");
    } else {
        window.open('graficas.aspx?idSectorr=' + $("#sectorHead").val(), '_self');
    }
}
function eventBotonReportes() {
}
function eventBotonBitacora() {
}