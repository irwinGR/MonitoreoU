$(function () {
    initDataTable();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetPersonal',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var otable = $('#dtPersonal').DataTable({
                orderCellsTop: false,
                fixedHeader: true,
                lengthMenu: [[5, 10, 15, 30, 50, 100], [5, 10, 15, 30, 50, 100]],
                "scrollCollapse": true,
                "oLanguage": {
                    "sUrl": "../resources/app-assets/vendors/js/datatable/json-spanish.json"
                },
                "autoWidth": true,
                "sDom": "<'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>>" +
                    "<'row'<'col-sm-12'tr>>" +
                    "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",

                data: data,
                columns: [
                    { data: "nombre" },
                    { data: "apPaterno" },
                    { data: "rfc" },
                    { data: "perfiles.descripcion" },
                    { data: "puestos.descripcion" },
                    { data: "email" }

                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtPersonal tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtPersonal').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            //$('#dtPersonal tbody').on('dblclick', 'tr', function () {
            //    $(this).addClass('selected');
            //    $("#btnEditPlus").show();
            //    $("#btnSave").hide();
            //    editUsuario();
            //    $('#fmUser').bootstrapValidator('destroy');
            //    $('#nombreUser').html('<b><i class="fa fa-users"></i> &nbsp; Editar usuario </b>');
            //    bootsVal();
            //});

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtPersonal thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });   
}

function initEvent() {

}