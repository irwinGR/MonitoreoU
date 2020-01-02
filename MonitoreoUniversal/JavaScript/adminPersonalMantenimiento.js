var otable;
$(function () {
    initDataTable();
    initEvent();
    bootsVal();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetPersonalMantenimiento',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            otable = $('#dtPersonalMantenimiento').DataTable({
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
                    { data: "idPersonalMantenimiento" },
                    { data: "nombre" },
                    { data: "apellidoP" },
                    { data: "apellidoM" },
                    { data: "correo" },
                    { data: "telefono"}
                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtPersonalMantenimiento tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtPersonalMantenimiento').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            $('#dtPersonalMantenimiento tbody').on('dblclick', 'tr', function () {
                $(this).addClass('selected');
                editarPersonalMantenimiento();
                $('#formPersonalMantenimiento').bootstrapValidator('destroy');
                bootsVal();
            });

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtPersonalMantenimiento thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });
}
function initEvent() {


    $("#btnPlus").click(function () {
        $('#divPersonalMantenimiento').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePersonalMantenimiento').html('<b>Registro de personal mantenimiento </b>');

                $("#btnGuardar").click(function () {
                    guardarPersonalMantenimiento();
                });
            });
        });
    });

    $("#btnCancelar").click(function () {
        $('#divCrear').hide('fast', function () {
            $('#divPersonalMantenimiento').show('fast', function () {
                $('#formPersonalMantenimiento')[0].reset();
            });
        });
    });

    $("#btnEdit").click(function () {
        editarPersonalMantenimiento();
        $('#formPersonalMantenimiento').bootstrapValidator('destroy');
        bootsVal();
    });

    $("#btnDelete").click(function () {
        var row = $('#dtPersonalMantenimiento').DataTable().row('.selected').data();

        swal({
            title: 'Estas seguro que deseas eliminar el personal ' + row.descripcion + '?',
            text: "No podras revertir la acción realizada",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#0CC27E',
            cancelButtonColor: '#FF586B',
            confirmButtonText: 'Sí, ¡Deseo eliminar!',
            cancelButtonText: 'No, ¡Cancelar!',
            confirmButtonClass: 'btn btn-success btn-raised mr-5',
            cancelButtonClass: 'btn btn-danger btn-raised',
            buttonsStyling: false
        }).then(function () {

            var json = {
                personalmantenimiento: {
                    idPersonalMantenimiento: row.idPersonalMantenimiento
                }
            };

            $.ajax({
                type: 'POST',
                url: '../Service.svc/EliminarPersonalMantenimiento',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(json),
                success: function (data) {
                    if (data.result) {
                        swal('¡Éxito!', 'Se ha eliminado el personal seleccionado.', 'success');

                        $('#divCrear').hide('fast', function () {
                            $('#divPersonalMantenimiento').show('fast', function () {
                                $('#formPersonalMantenimiento')[0].reset();
                                $('#btnGuardar').prop("disabled", false);
                                $('#formPersonalMantenimiento').bootstrapValidator('destroy');

                                otable.clear().draw();
                                otable.destroy();
                                initDataTable();

                                $('#dtPersonalMantenimiento tbody').on(
                                    'click',
                                    'tr',
                                    function () {
                                        if ($(this).hasClass('selected')) {
                                            $(this).removeClass('selected');
                                        } else {
                                            $('#dtPersonalMantenimiento').DataTable().$('tr.selected').removeClass(
                                                'selected');
                                            $(this).addClass('selected');
                                        }
                                    });

                            });
                        });

                    } else {
                        swal("Error!", "Surgio un error al eliminar el personal", "error");
                    }
                }
            });
        }, function (dismiss) {

        })
    })

}
function bootsVal() {
    $('#formPersonalMantenimiento').bootstrapValidator({
        live: 'enabled',
        submitButtons: 'button[id="btnGuardar"]',
        message: 'Valor invalido',
        fields: {
            nombre: {
                group: '.col-md-4',
                selector: '#nombre',
                validators: {
                    notEmpty: {
                        message: 'El nombre de proyecto  es obligatorio.'
                    }
                }
            }
        }
    });
}

function editarPersonalMantenimiento() {

    var row = $('#dtPersonalMantenimiento').DataTable().row('.selected').data();

    if (row) {

        $("#nombre").val(row.descripcion);
        
        $('#divPersonalMantenimiento').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePersonalMantenimiento').html('<b>Edicion de personal:' + row.descripcion + ' </b>');

                $("#btnGuardar").click(function () {
                    bootsVal();
                    $('#formPersonalMantenimiento').data('bootstrapValidator').validate();
                    var n = $('#formPersonalMantenimiento').data('bootstrapValidator').isValid();

                    if (n) {
                        var json = {
                            perfiles: {
                                nombre: $('#nombre').val(),
                                idPersonalMantenimiento: row.idPersonalMantenimiento
                            }
                        };

                        $.ajax({
                            type: 'POST',
                            url: '../Service.svc/EditarPersonalMantenimiento',
                            dataType: 'json',
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(json),
                            success: function (data) {
                                if (data.result) {
                                    swal({
                                        title: 'Exito',
                                        text: "Se actualizo correctamente el personal",
                                        type: 'success',
                                        confirmButtonColor: '#0CC27E',
                                        cancelButtonColor: '#FF586B',
                                        confirmButtonText: 'Aceptar',
                                    }).then(function (isConfirm) {
                                        if (isConfirm) {
                                            $('#divCrear').hide('fast', function () {
                                                $('#divPersonalMantenimiento').show('fast', function () {
                                                    $('#formPersonalMantenimiento')[0].reset();
                                                    $('#btnGuardar').prop("disabled", false);
                                                    $('#formPersonalMantenimiento').bootstrapValidator('destroy');

                                                    otable.clear().draw();
                                                    otable.destroy();
                                                    initDataTable();

                                                    $('#dtPersonalMantenimiento tbody').on(
                                                        'click',
                                                        'tr',
                                                        function () {
                                                            if ($(this).hasClass('selected')) {
                                                                $(this).removeClass('selected');
                                                            } else {
                                                                $('#dtPersonalMantenimiento').DataTable().$('tr.selected').removeClass(
                                                                    'selected');
                                                                $(this).addClass('selected');
                                                            }
                                                        });

                                                });
                                            });
                                        }
                                    }).catch(swal.noop);
                                } else {
                                    swal("Error!", "Surgio un error al actualizar el personal", "error");
                                }
                            }
                        });
                    }
                });
            });
        });
    }
}
function guardarPersonalMantenimiento() {
    bootsVal();
    $('#formPersonalMantenimiento').data('bootstrapValidator').validate();
    var n = $('#formPersonalMantenimiento').data('bootstrapValidator').isValid();

    if (n) {
        var json = {
            personalMantenimiento: {
                nombre: $('#nombre').val(),
            }
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/InsertPersonalMantenimiento',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(json),
            success: function (data) {
                if (data.result) {
                    swal({
                        title: 'Exito',
                        text: "Se registro correctamente el personal",
                        type: 'success',
                        confirmButtonColor: '#0CC27E',
                        cancelButtonColor: '#FF586B',
                        confirmButtonText: 'Aceptar',
                    }).then(function (isConfirm) {
                        if (isConfirm) {
                            $('#divCrear').hide('fast', function () {
                                $('#divPersonalMantenimiento').show('fast', function () {
                                    $('#formPersonalMantenimiento')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formPersonalMantenimiento').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtPersonalMantenimiento tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtPersonalMantenimiento').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });
                        }
                    }).catch(swal.noop);
                } else {
                    swal("Error!", "Surgio un error al guardar el personal", "error");
                }
            }
        });
    }
}