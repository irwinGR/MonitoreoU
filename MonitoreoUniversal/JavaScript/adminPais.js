var otable;
$(function () {
    initDataTable();
    initEvent();
    bootsVal();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetPaises',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            otable = $('#dtPais').DataTable({
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
                    { data: "idPais" },
                    { data: "descripcion" },


                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtPais tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtPais').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            $('#dtPais tbody').on('dblclick', 'tr', function () {
                $(this).addClass('selected');
                editarPais();
                $('#formPaises').bootstrapValidator('destroy');
                bootsVal();
            });

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtPais thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });
}
function initEvent() {


    $("#btnPlus").click(function () {
        $('#divPaises').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePais').html('<b>Registro de pais </b>');

                $("#btnGuardar").click(function () {
                    guardarPais();
                    $('#btnGuardar').unbind("click");
                });
            });
        });
    });

    $("#btnCancelar").click(function () {
        $('#divCrear').hide('fast', function () {
            $('#divPaises').show('fast', function () {
                $('#formPaises')[0].reset();
            });
        });
    });

    $("#btnEdit").click(function () {
        editarPais();
        $('#formPaises').bootstrapValidator('destroy');
        bootsVal();
    });

    $("#btnDelete").click(function () {
        var row = $('#dtPais').DataTable().row('.selected').data();

        if (row) {
            swal({
                title: 'Estas seguro que deseas eliminar el Pais ' + row.descripcion + '?',
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
                    paises: {
                        idPais: row.idPais
                    }
                };

                $.ajax({
                    type: 'POST',
                    url: '../Service.svc/EliminarPaises',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(json),
                    success: function (data) {
                        if (data.result) {
                            swal('¡Éxito!', 'Se ha eliminado el Pais seleccionado.', 'success');

                            $('#divCrear').hide('fast', function () {
                                $('#divPaises').show('fast', function () {
                                    $('#formPaises')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formPaises').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtPais tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtPais').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });

                        } else {
                            swal("Error!", "Surgio un error al eliminar el Pais", "error");
                        }
                    }
                });
            }, function (dismiss) {
            });
        } else {
            swal("Advertencia!", "debes seleccionar un registro", "warning");
        }
    });

}
function bootsVal() {
    $('#formPaises').bootstrapValidator({
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

function editarPais() {

    var row = $('#dtPais').DataTable().row('.selected').data();

    if (row) {

        $("#nombre").val(row.descripcion);

        $('#divPaises').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePais').html('<b>Edicion de Pais:' + row.descripcion + ' </b>');

                $("#btnGuardar").click(function () {
                    bootsVal();
                    $('#formPaises').data('bootstrapValidator').validate();
                    var n = $('#formPaises').data('bootstrapValidator').isValid();

                    if (n) {
                        var json = {
                            paises: {
                                descripcion: $('#nombre').val(),
                                idPais: row.idPais
                            }
                        };

                        $.ajax({
                            type: 'POST',
                            url: '../Service.svc/EditarPaises',
                            dataType: 'json',
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(json),
                            success: function (data) {
                                if (data.result) {
                                    swal({
                                        title: 'Exito',
                                        text: "Se actualizo correctamente el Pais",
                                        type: 'success',
                                        confirmButtonColor: '#0CC27E',
                                        cancelButtonColor: '#FF586B',
                                        confirmButtonText: 'Aceptar',
                                    }).then(function (isConfirm) {
                                        if (isConfirm) {
                                            $('#divCrear').hide('fast', function () {
                                                $('#divPaises').show('fast', function () {
                                                    $('#formPaises')[0].reset();
                                                    $('#btnGuardar').prop("disabled", false);
                                                    $('#formPaises').bootstrapValidator('destroy');

                                                    otable.clear().draw();
                                                    otable.destroy();
                                                    initDataTable();

                                                    $('#dtPais tbody').on(
                                                        'click',
                                                        'tr',
                                                        function () {
                                                            if ($(this).hasClass('selected')) {
                                                                $(this).removeClass('selected');
                                                            } else {
                                                                $('#dtPais').DataTable().$('tr.selected').removeClass(
                                                                    'selected');
                                                                $(this).addClass('selected');
                                                            }
                                                        });

                                                });
                                            });
                                        }
                                    }).catch(swal.noop);
                                } else {
                                    swal("Error!", "Surgio un error al actualizar el Pais", "error");
                                }
                            }
                        });
                    }

                    $('#btnGuardar').unbind("click");

                });
            });
        });
    } else {
        swal("Advertencia!", "debes seleccionar un registro", "warning");
    }
}
function guardarPais() {
    bootsVal();
    $('#formPaises').data('bootstrapValidator').validate();
    var n = $('#formPaises').data('bootstrapValidator').isValid();

    if (n) {
        var json = {
            paises: {
                descripcion: $('#nombre').val()
            }
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/InsertPaises',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(json),
            success: function (data) {
                if (data.result) {
                    swal({
                        title: 'Exito',
                        text: "Se registro correctamente el Pais",
                        type: 'success',
                        confirmButtonColor: '#0CC27E',
                        cancelButtonColor: '#FF586B',
                        confirmButtonText: 'Aceptar',
                    }).then(function (isConfirm) {
                        if (isConfirm) {
                            $('#divCrear').hide('fast', function () {
                                $('#divPaises').show('fast', function () {
                                    $('#formPaises')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formPaises').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtPais tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtPais').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });
                        }
                    }).catch(swal.noop);
                } else {
                    swal("Error!", "Surgio un error al guardar el Pais", "error");
                }
            }
        });
    }
}