﻿var otable;
$(function () {
    initDataTable();
    initEvent();
    bootsVal();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetEstados',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            otable = $('#dtEstado').DataTable({
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
                    { data: "idEstado" },
                    { data: "descripcion" },
                    { data: "paises.descripcion" }


                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtEstado tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtEstado').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            $('#dtEstado tbody').on('dblclick', 'tr', function () {
                $(this).addClass('selected');
                editarEstado();
                $('#formEstados').bootstrapValidator('destroy');
                bootsVal();
            });

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtEstado thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });
}
function initEvent() {


    $("#btnPlus").click(function () {
        $('#divEstados').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePais').html('<b>Registro de pais </b>');

                $("#btnGuardar").click(function () {
                    guardarEstado();
                });
            });
        });
    });

    $("#btnCancelar").click(function () {
        $('#divCrear').hide('fast', function () {
            $('#divEstados').show('fast', function () {
                $('#formEstados')[0].reset();
            });
        });
    });

    $("#btnEdit").click(function () {
        editarEstado();
        $('#formEstados').bootstrapValidator('destroy');
        bootsVal();
    });

    $("#btnDelete").click(function () {
        var row = $('#dtEstado').DataTable().row('.selected').data();

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
                estados: {
                    idEstado: row.idEstado
                }
            };

            $.ajax({
                type: 'POST',
                url: '../Service.svc/EliminarEstados',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(json),
                success: function (data) {
                    if (data.result) {
                        swal('¡Éxito!', 'Se ha eliminado el Pais seleccionado.', 'success');

                        $('#divCrear').hide('fast', function () {
                            $('#divEstados').show('fast', function () {
                                $('#formEstados')[0].reset();
                                $('#btnGuardar').prop("disabled", false);
                                $('#formEstados').bootstrapValidator('destroy');

                                otable.clear().draw();
                                otable.destroy();
                                initDataTable();

                                $('#dtEstado tbody').on(
                                    'click',
                                    'tr',
                                    function () {
                                        if ($(this).hasClass('selected')) {
                                            $(this).removeClass('selected');
                                        } else {
                                            $('#dtEstado').DataTable().$('tr.selected').removeClass(
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

        })
    });

    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetPaises',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            llenarCombo("pais", data, "idPais", "descripcion");
        }
    });
}
function bootsVal() {
    $('#formEstados').bootstrapValidator({
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
            },
            pais: {
                selector: '#pais',
                group: '.col-md-4',
                validators: {
                    callback: {
                        message: 'El pais es obligatorio',
                        callback: function (value, validator) {
                            if (value === "0") {
                                return false;
                            } else {
                                return true;
                            }

                        }
                    }
                }
            }
        }
    });
}
function editarEstado() {

    var row = $('#dtEstado').DataTable().row('.selected').data();
    console.log(row);
    if (row) {

        $("#nombre").val(row.descripcion);
        $("#pais").val(row.paises.idPais);


        $('#divEstados').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePais').html('<b>Edicion de Pais:' + row.descripcion + ' </b>');

                $("#btnGuardar").click(function () {
                    bootsVal();
                    $('#formEstados').data('bootstrapValidator').validate();
                    var n = $('#formEstados').data('bootstrapValidator').isValid();

                    if (n) {
                        var json = {
                            estados: {
                                descripcion: $('#nombre').val(),
                                paises: {
                                    idPais: $('#pais').val()
                                },
                                idEstado: row.idEstado
                            }
                        };

                        $.ajax({
                            type: 'POST',
                            url: '../Service.svc/EditarEstados',
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
                                                $('#divEstados').show('fast', function () {
                                                    $('#formEstados')[0].reset();
                                                    $('#btnGuardar').prop("disabled", false);
                                                    $('#formEstados').bootstrapValidator('destroy');

                                                    otable.clear().draw();
                                                    otable.destroy();
                                                    initDataTable();

                                                    $('#dtEstado tbody').on(
                                                        'click',
                                                        'tr',
                                                        function () {
                                                            if ($(this).hasClass('selected')) {
                                                                $(this).removeClass('selected');
                                                            } else {
                                                                $('#dtEstado').DataTable().$('tr.selected').removeClass(
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
                });
            });
        });
    }
}
function guardarEstado() {
    bootsVal();
    $('#formEstados').data('bootstrapValidator').validate();
    var n = $('#formEstados').data('bootstrapValidator').isValid();

    if (n) {
        var json = {
            estados: {
                descripcion: $('#nombre').val(),
                paises: {
                    idPais: $('#pais').val()
                }
            }
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/InsertEstados',
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
                                $('#divEstados').show('fast', function () {
                                    $('#formEstados')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formEstados').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtEstado tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtEstado').DataTable().$('tr.selected').removeClass(
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