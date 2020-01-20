 var otable;
$(function () {
    initDataTable();
    initEvent();
    bootsVal();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetResponsables',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            otable = $('#dtResponsables').DataTable({
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
                    { data: "idReponsable" },
                    { data: "nombre" },
                    { data: "apellidoP" },
                    { data: "apellidoM" },
                    { data: "correo" },
                    { data: "telefono" }
                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtResponsables tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtResponsables').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            $('#dtResponsables tbody').on('dblclick', 'tr', function () {
                $(this).addClass('selected');
                editarResponsables();
                $('#formResponsables').bootstrapValidator('destroy');
                bootsVal();
            });

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtResponsables thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });
}
function initEvent() {


    $("#btnPlus").click(function () {
        $('#divResponsables').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombreResponsables').html('<b>Registro de responsable </b>');
                $("#btnGuardar").click(function () {
                    guardarResponsable();
                    $('#btnGuardar').unbind("click");
                });
            });
        });
    });

    $("#btnCancelar").click(function () {
        $('#divCrear').hide('fast', function () {
            $('#divResponsables').show('fast', function () {
                $('#formResponsables')[0].reset();
                $('#formResponsables').bootstrapValidator('destroy');
            });
        });
    });

    $("#btnEdit").click(function () {
        editarResponsables();
        $('#formResponsables').bootstrapValidator('destroy');
        bootsVal();
    });

    $("#btnDelete").click(function () {
        var row = $('#dtResponsables').DataTable().row('.selected').data();

        if (row) {

            swal({
            title: '¿Estás seguro que deseas eliminar el responsable ' + row.nombre + '?',
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
                responsables: {
                    idReponsable: row.idReponsable,
                }
            };

            $.ajax({
                type: 'POST',
                url: '../Service.svc/EliminarResponsables',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(json),
                success: function (data) {
                    if (data.result) {
                        swal('¡Éxito!', 'Se ha eliminado el responsable seleccionado.', 'success');

                        $('#divCrear').hide('fast', function () {
                            $('#divResponsables').show('fast', function () {
                                $('#formResponsables')[0].reset();
                                $('#btnGuardar').prop("disabled", false);
                                $('#formResponsables').bootstrapValidator('destroy');

                                otable.clear().draw();
                                otable.destroy();
                                initDataTable();

                                $('#dtResponsables tbody').on(
                                    'click',
                                    'tr',
                                    function () {
                                        if ($(this).hasClass('selected')) {
                                            $(this).removeClass('selected');
                                        } else {
                                            $('#dtResponsables').DataTable().$('tr.selected').removeClass(
                                                'selected');
                                            $(this).addClass('selected');
                                        }
                                    });

                            });
                        });

                    } else {
                        swal("¡Error!", "Surgio un error al eliminar el responsable", "error");
                    }
                }
            });
        }, function (dismiss) {

            });
        } else {
            swal("¡Advertencia!", "Debes seleccionar un registro", "warning");
        }
    });

}
function bootsVal() {
    $('#formResponsables').bootstrapValidator({
        live: 'enabled',
        submitButtons: 'button[id="btnGuardar"]',
        message: 'Valor inválido',
        fields: {
            nombre: {
                group: '.col-md-4',
                selector: '#nombre',
                validators: {
                    notEmpty: {
                        message: 'El nombre  es obligatorio.'
                    }
                }
            },
            apellidoP: {
                group: '.col-md-4',
                selector: '#apellidoP',
                validators: {
                    notEmpty: {
                        message: 'El apellido paterno es obligatorio.'
                    }
                }
            },
            apellidoM: {
                group: '.col-md-4',
                selector: '#apellidoM',
                validators: {
                    notEmpty: {
                        message: 'El apellido materno es obligatorio.'
                    }
                }
            },
            correo: {
                group: '.col-md-4',
                selector: '#correo',
                validators: {
                    notEmpty: {
                        message: 'El correo es obligatorio.'
                    },
                    emailAddress: {
                        message: 'Correo inválido'
                    }
                }
            },
            telefono: {
                group: '.col-md-4',
                selector: '#telefono',
                validators: {
                    notEmpty: {
                        message: 'El teléfono es obligatorio.'
                    }
                }
            }
    }
        
    });
}

function editarResponsables() {

    var row = $('#dtResponsables').DataTable().row('.selected').data();

    if (row) {

        $("#nombre").val(row.nombre),
        $("#apellidoP").val(row.apellidoP),
        $("#apellidoM").val(row.apellidoM),
        $("#correo").val(row.correo),
        $("#telefono").val(row.telefono);

        $('#divResponsables').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombreResponsables').html('<b>Edicion de responsable:' + row.nombre + ' </b>');

                $("#btnGuardar").click(function () {
                    bootsVal();
                    $('#formResponsables').data('bootstrapValidator').validate();
                    var n = $('#formResponsables').data('bootstrapValidator').isValid();

                    if (n) {
                        var json = {
                            responsables: {
                                nombre: $('#nombre').val(),
                                apellidoP: $("#apellidoP").val(),
                                apellidoM: $("#apellidoM").val(),
                                correo: $("#correo").val(),
                                telefono: $("#telefono").val(),
                                idReponsable: row.idReponsable
                            }
                        };

                        $.ajax({
                            type: 'POST',
                            url: '../Service.svc/EditarResponsables',
                            dataType: 'json',
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(json),
                            success: function (data) {
                                if (data.result) {
                                    swal({
                                        title: '¡Éxito!',
                                        text: "Se actualizó correctamente el responsable",
                                        type: 'success',
                                        confirmButtonColor: '#0CC27E',
                                        cancelButtonColor: '#FF586B',
                                        confirmButtonText: 'Aceptar',
                                    }).then(function (isConfirm) {
                                        if (isConfirm) {
                                            $('#divCrear').hide('fast', function () {
                                                $('#divResponsables').show('fast', function () {
                                                    $('#formResponsables')[0].reset();
                                                    $('#btnGuardar').prop("disabled", false);
                                                    $('#formResponsables').bootstrapValidator('destroy');

                                                    otable.clear().draw();
                                                    otable.destroy();
                                                    initDataTable();

                                                    $('#dtResponsables tbody').on(
                                                        'click',
                                                        'tr',
                                                        function () {
                                                            if ($(this).hasClass('selected')) {
                                                                $(this).removeClass('selected');
                                                            } else {
                                                                $('#dtResponsables').DataTable().$('tr.selected').removeClass(
                                                                    'selected');
                                                                $(this).addClass('selected');
                                                            }
                                                        });

                                                });
                                            });
                                        }
                                    }).catch(swal.noop);
                                } else {
                                    swal("¡Error!", "Surgio un error al actualizar el responsable", "error");
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
function guardarResponsable() {
    bootsVal();
    $('#formResponsables').data('bootstrapValidator').validate();
    var n = $('#formResponsables').data('bootstrapValidator').isValid();

    if (n) {
        var json = {
            responsables: {
                nombre: $('#nombre').val(),
                apellidoP: $('#apellidoP').val(),
                apellidoM: $('#apellidoM').val(),
                correo: $('#correo').val(),
                telefono: $('#telefono').val()
            }
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/InsertResponsables',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(json),
            success: function (data) {
                if (data.result) {
                    swal({
                        title: '¡Éxito!',
                        text: "Se registró correctamente el responsable",
                        type: 'success',
                        confirmButtonColor: '#0CC27E',
                        cancelButtonColor: '#FF586B',
                        confirmButtonText: 'Aceptar',
                    }).then(function (isConfirm) {
                        if (isConfirm) {
                            $('#divCrear').hide('fast', function () {
                                $('#divResponsables').show('fast', function () {
                                    $('#formResponsables')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formResponsables').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtResponsables tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtResponsables').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });
                        }
                    }).catch(swal.noop);
                } else {
                    swal("¡Error!", "Surgio un error al guardar el responsable", "error");
                }
            }
        });
    }
}