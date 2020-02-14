var otable;
$(function () {
    initDataTable();
    initEvent();
    bootsVal();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetMunicipioDelegacion',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            otable = $('#dtMunicipiosDelegaciones').DataTable({
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
                    { data: "idMunicipioDelegacion" },
                    { data: "descripcion" }, /*Nombre*/
                    { data: "Estados.descripcion" },/*name propiedad del metodo-descripcion*/
                    { data: "pais.descripcion" }
                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtMunicipiosDelegaciones tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtMunicipiosDelegaciones').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            $('#dtMunicipiosDelegaciones tbody').on('dblclick', 'tr', function () {
                $(this).addClass('selected');
                editarMunicipiosDelegaciones();
                $('#formMunicipiosDelegaciones').bootstrapValidator('destroy');
                bootsVal();
            });

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtMunicipiosDelegaciones thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });
}
function initEvent() {


    $("#btnPlus").click(function () {
        $('#divMunicipiosDelegaciones').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombreMunicipiosDelegaciones').html('<b>Registro de Municipio/Delegación </b>');
                 $("#btnGuardar").click(function () {
                    guardarMunicipiosDelegaciones();
                    $('#btnGuardar').unbind("click");

                });
            });
        });
    });

    $("#btnCancelar").click(function () {
        $('#divCrear').hide('fast', function () {
            $('#divMunicipiosDelegaciones').show('fast', function () {
                $('#formMunicipiosDelegaciones').bootstrapValidator('destroy');
                

                $('#formMunicipiosDelegaciones')[0].reset();
            });
        });
    });

    $("#btnEdit").click(function () {
        editarMunicipiosDelegaciones();
        $('#formMunicipiosDelegaciones').bootstrapValidator('destroy');
        bootsVal();
    });

    $("#btnDelete").click(function () {
        var row = $('#dtMunicipiosDelegaciones').DataTable().row('.selected').data();
        if (row) {
        swal({
            title: '¿Estás seguro que deseas eliminar el Municipio/Delegación ' + row.descripcion + '?',
            text: "No podrás revertir la acción realizada",
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
                municipioDelegacion: {
                    idMunicipioDelegacion: row.idMunicipioDelegacion
                }
            };

            $.ajax({
                type: 'POST',
                url: '../Service.svc/EliminarMunicipioDelegacion',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(json),
                success: function (data) {
                    if (data.result) {
                        swal('¡Éxito!', 'Se ha eliminado el Municipio/Delegación seleccionado.', 'success');

                        $('#divCrear').hide('fast', function () {
                            $('#divMunicipiosDelegaciones').show('fast', function () {
                                $('#formMunicipiosDelegaciones')[0].reset();
                                $('#btnGuardar').prop("disabled", false);
                                $('#formMunicipiosDelegaciones').bootstrapValidator('destroy');

                                otable.clear().draw();
                                otable.destroy();
                                initDataTable();

                                $('#dtMunicipiosDelegaciones tbody').on(
                                    'click',
                                    'tr',
                                    function () {
                                        if ($(this).hasClass('selected')) {
                                            $(this).removeClass('selected');
                                        } else {
                                            $('#dtMunicipiosDelegaciones').DataTable().$('tr.selected').removeClass(
                                                'selected');
                                            $(this).addClass('selected');
                                        }
                                    });

                            });
                        });

                    } else {
                        swal("¡Error!", "Surgió un error al eliminar el Municipio/Delegación", "error");
                    }
                }
            });
        }, function (dismiss) {

            });

        } else {
            swal("¡Advertencia!", "Debes seleccionar un registro", "warning");
        }
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

    $("#pais").change(function () {
        var json = {
            idPais: $("#pais").val()
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/getEstadosxPais',
            dataType: 'json',
            data: JSON.stringify(json),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                llenarComboxParametro("estado", data,"idEstado","descripcion");
                revalidarBootsVal("formMunicipiosDelegaciones","estado");
            }
        });
    });
}
function bootsVal() {
    $('#formMunicipiosDelegaciones').bootstrapValidator({
        live: 'enabled',
        submitButtons: 'button[id="btnGuardar"]',
        message: 'Valor invalido',
        fields: {
            nombre: {
                group: '.col-md-4',
                selector: '#nombre',
                validators: {
                    notEmpty: {
                        message: 'El nombre de Municipio/Delegación es obligatorio.',
                        callback: function (value, validator) {
                            if (value === "0") {
                                return false;
                            } else {
                                return true;
                            }
                        }
                    }
                }
            },
            estado: {
                selector: '#estado',
                group: '.col-md-4',
                validators: {
                    callback: {
                        message: 'El Estado es obligatorio',
                        callback: function (value, validator) {
                            if (value === "0") {
                                return false;
                            } else {
                                return true;
                            }

                        }
                    }
                }
            },
            pais: {
                selector: '#pais',
                group: '.col-md-4',
                validators: {
                    callback: {
                        message: 'El País es obligatorio',
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
function editarMunicipiosDelegaciones() {

    var row = $('#dtMunicipiosDelegaciones').DataTable().row('.selected').data();
    console.log(row);
    if (row) {

        $("#nombre").val(row.descripcion);
        $("#estado").val(row.Estados.idEstado);


        $('#divMunicipiosDelegaciones').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombreMunicipiosDelegaciones').html('<b>Edición de Municipio/Delegación: ' + row.descripcion + ' </b>');

                $("#btnGuardar").click(function () {
                    bootsVal();
                    $('#formMunicipiosDelegaciones').data('bootstrapValidator').validate();
                    var n = $('#formMunicipiosDelegaciones').data('bootstrapValidator').isValid();

                    if (n) {
                        var json = {
                            municipioDelegacion: {
                                descripcion: $('#nombre').val(),
                                Estados: {
                                    idEstado: $('#estado').val()
                                },
                                pais: {
                                    idPais: $('#pais').val()
                                },
                                idMunicipioDelegacion: row.idMunicipioDelegacion
                            }
                        };

                        $.ajax({
                            type: 'POST',
                            url: '../Service.svc/EditarMunicipioDelegacion',
                            dataType: 'json',
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(json),
                            success: function (data) {
                                if (data.result) {
                                    swal({
                                        title: '¡Éxito!',
                                        text: "Se actualizó correctamente el Municipio/Delegación",
                                        type: 'success',
                                        confirmButtonColor: '#0CC27E',
                                        cancelButtonColor: '#FF586B',
                                        confirmButtonText: 'Aceptar',
                                    }).then(function (isConfirm) {
                                        if (isConfirm) {
                                            $('#divCrear').hide('fast', function () {
                                                $('#divMunicipiosDelegaciones').show('fast', function () {
                                                    $('#formMunicipiosDelegaciones')[0].reset();
                                                    $('#btnGuardar').prop("disabled", false);
                                                    $('#formMunicipiosDelegaciones').bootstrapValidator('destroy');

                                                    otable.clear().draw();
                                                    otable.destroy();
                                                    initDataTable();

                                                    $('#dtMunicipiosDelegaciones tbody').on(
                                                        'click',
                                                        'tr',
                                                        function () {
                                                            if ($(this).hasClass('selected')) {
                                                                $(this).removeClass('selected');
                                                            } else {
                                                                $('#dtMunicipiosDelegaciones').DataTable().$('tr.selected').removeClass(
                                                                    'selected');
                                                                $(this).addClass('selected');
                                                            }
                                                        });

                                                });
                                            });
                                        }
                                    }).catch(swal.noop);
                                } else {
                                    swal("¡Error!", "Surgió un error al actualizar el Municipio/Delegación", "error");
                                }
                            }
                        });
                    }
                    $('#btnGuardar').unbind("click");
                });
            });
        });
    } else {
        swal("¡Advertencia!", "Debes seleccionar un registro", "warning");
    }
}
function guardarMunicipiosDelegaciones() {
    bootsVal();
    $('#formMunicipiosDelegaciones').data('bootstrapValidator').validate();
    var n = $('#formMunicipiosDelegaciones').data('bootstrapValidator').isValid();

    if (n) {
        var json = {
            municipioDelegacion: {
                descripcion: $('#nombre').val(),
                Estados: {
                    idEstado: $('#estado').val()
                },
                pais: {
                    idPais: $('#pais').val()
                }
            }
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/InsertMunicipioDelegacion',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(json),
            success: function (data) {
                if (data.result) {
                    swal({
                        title: '¡Éxito!',
                        text: "Se registró correctamente el Municipio/Delegación",
                        type: 'success',
                        confirmButtonColor: '#0CC27E',
                        cancelButtonColor: '#FF586B',
                        confirmButtonText: 'Aceptar',
                    }).then(function (isConfirm) {
                        if (isConfirm) {
                            $('#divCrear').hide('fast', function () {
                                $('#divMunicipiosDelegaciones').show('fast', function () {
                                    $('#formMunicipiosDelegaciones')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formMunicipiosDelegaciones').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtMunicipiosDelegaciones tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtMunicipiosDelegaciones').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });
                        }
                    }).catch(swal.noop);
                } else {
                    swal("¡Error!", "Surgió un error al guardar el Municipio/Delegación", "error");
                }
            }
        });
    }
}