$(function () {
    $("#sidebarToggle").click();

    initEventos();
    cicloActualizacion();
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
    $.ajax({
        async: false,
        type: 'GET',
        url: '../Service.svc/GetPrueba',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $("#tableros").empty();

            $.each(data, function (i, item) {

                html += '<div id="headingCollapse' + i + '" class="card-header pb-3">';
                html += '    <a data-toggle="collapse" href="#collapse' + i + '" aria-expanded="true" aria-controls="collapse' + i + '" class="card-title lead collapsed">';
                html += '        Sensor ' + item.idDispositivo;
                html += '    </a>';
                html += '</div>';

                html += '<div id="collapse' + i + '" role="tabpanel" aria-labelledby="headingCollapse' + i + '" class="collapse show" style="">';
                html += '    <div class="card-content">';
                html += '        <div class="card-body">';
                html += '            <div class="row">';
                html += '                <div class="col-md-6">';
                html += '                    <div id="basic-map' + i + '" class="height-400"></div>';
                html += '                </div>';
                html += '                <div class="col-md-3">';
                html += '                    <div class="card gradient-green-tea">';
                html += '                        <div class="card-content">';
                html += '                            <div class="card-body pt-2 pb-0">';
                html += '                                <div class="media">';
                html += '                                    <div class="media-body white text-left">';
                html += '                                       <h3 class="font-large-1 mb-0"><center>' + item.humedad + '%</center></h3>';
                html += '                                        <span><center>Humedad</center></span><br>';
                html += '                                    </div>';
                html += '                                </div>';
                html += '                            </div>';
                html += '                        </div>';
                html += '                    </div>';
                html += '                </div>';
                html += '                <div class="col-md-3">';
                html += '                    <div class="card gradient-green-tea">';
                html += '                        <div class="card-content">';
                html += '                            <div class="card-body pt-2 pb-0">';
                html += '                                <div class="media">';
                html += '                                    <div class="media-body white text-left">';
                html += '                                        <h3 class="font-large-1 mb-0"><center>' + item.conductividadElectrica + ' US/CM</center></h3>';
                html += '                                        <span><center>Conductividad</center></span><br>';
                html += '                                    </div>';
                html += '                                </div>';
                html += '                            </div>';
                html += '                        </div>';
                html += '                    </div>';
                html += '                </div>';
                html += '            </div>';
                html += '        </div>';
                html += '    </div>';
                html += '</div>';

                nSensor = i;
                coordenadas.push(item.coordenadas);
                Senso.push(item.idDispositivo);
            });

            $("#tableros").html(html);

            var lat = 0;
            var lng = 0;
            var cordenada1 = [];
            var cordenada2 = [];

            for (var i = 0; i <= nSensor; i++) {
                cordenada1 = coordenadas[i].split(',')[0];
                cordenada2 = coordenadas[i].split(',')[1];
                
                lat = cordenada1;
                lng = cordenada2;

                initMaps(Senso[i],i, lat, lng);

            }
        }

    });
}
function initMaps(sensor,numero,lat,lng) {
        // Basic Map
        // ------------------------------
            map = new GMaps({
                div: '#basic-map'+numero,
                lat: lat,
                lng: -lng,
                height: 400,
                zoom: 18
                
            });

            map.addMarker({
                lat: lat,
                lng: -lng,
                title: 'Sensor - ' + sensor,
                infoWindow: {
                    content: '<p>Sensor - ' + sensor + ' <br> <br> Ubicacion: ITE Soluciones S.A de C.V</p>'
                }
            });
}
