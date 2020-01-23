var otable;
$(function () {
    initDataTable();
    initEvent();
    bootsVal();
});

function initDataTable() {
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetPerfil',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
             otable = $('#dtPerfil').DataTable({
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
                    { data: "idPerfil" },
                    { data: "descripcion" },
                   

                ]
            });

            // función que da formato a la fecha

            // Método creado para agregar el evento de selección de una fila
            $('#dtPerfil tbody').on(
                'click',
                'tr',
                function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('#dtPerfil').DataTable().$('tr.selected').removeClass(
                            'selected');
                        $(this).addClass('selected');
                    }
                });

            // Evento creado para abrir la ventana de editar al dar doble click sobre un
            // registro
            $('#dtPerfil tbody').on('dblclick', 'tr', function () {
                $(this).addClass('selected');
                editarPerfil();
                $('#formPerfiles').bootstrapValidator('destroy');
                bootsVal();
            });

            // Evento creado para realizar la búsqueda cuando se presione la tecla ENTER
            $("#dtPerfil thead th input[type=text]").on('keyup', function (e) {
                otable.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    });   
}
function initEvent() {
    $("#acciones").select2({
        placeholder: "Seleccione...",
        width: "300px"
    });

    $("#btnPlus").click(function () {
        $('#divPerfiles').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePerfil').html('<b>Registro de perfil </b>');

                $("#btnGuardar").click(function () {
                    guardarPerfil();
                    $('#btnGuardar').unbind("click");
                    
                });
            });
        });  
    });

    $("#btnCancelar").click(function () {
        $('#divCrear').hide('fast', function () {
            $('#divPerfiles').show('fast', function () {
                $('#formPerfiles').bootstrapValidator('destroy');
                
                $('#formPerfiles')[0].reset();
                

            });
        });
    });

    $("#btnEdit").click(function () {
        editarPerfil();
        $('#formPerfiles').bootstrapValidator('destroy');
        bootsVal();
      

    });

    $("#btnDelete").click(function () {
        var row = $('#dtPerfil').DataTable().row('.selected').data();
        if (row) {
            swal({
                title: '¿Estás seguro que deseas eliminar el perfil ' + row.descripcion + '?',
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
                    perfiles: {
                        idPerfil: row.idPerfil
                    }
                };

                $.ajax({
                    type: 'POST',
                    url: '../Service.svc/EliminarPerfil',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(json),
                    success: function (data) {
                        if (data.result) {
                            swal('¡Éxito!', 'Se ha eliminado el perfil seleccionado.', 'success');

                            $('#divCrear').hide('fast', function () {
                                $('#divPerfiles').show('fast', function () {
                                    $('#formPerfiles')[0].reset();
                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formPerfiles').bootstrapValidator('destroy');

                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtPerfil tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtPerfil').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });

                        } else {
                            swal("¡Error!", "Surgio un error al eliminar el perfil", "error");
                        }
                    }
                });
            }, function (dismiss) {

            });
        } else {
            swal("¡Advertencia!", "Debes seleccionar un registro", "warning");
        }
       
           
    });
    $("#acciones").select2({
        placeholder: "Seleccione...",
        width: "300px"
    });
    $.ajax({
        type: 'GET',
        url: '../Service.svc/GetAcciones',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
          
            llenarCombo("acciones", data, "idAccion", "descripcion");
           

        }
        
           
    });
}
function bootsVal() {
    $('#formPerfiles').bootstrapValidator({
        live: 'enabled',
        submitButtons: 'button[id="btnGuardar"]',
        message: 'Valor inválido',
        fields: {
            nombre: {
                group: '.col-md-4',
                selector: '#nombre',
                validators: {
                    notEmpty: {
                        message: 'El nombre del perfil es obligatorio.'
                    }
                }
            },
            acciones: {
                selector: '#acciones',
                group: '.col-md-4',
                validators: {
                    notEmpty: {
                        message: 'Las Acciones son obligatorias.'
                    }
                }
            }
        }
    });
}
function editarPerfil() {

    var row = $('#dtPerfil').DataTable().row('.selected').data();

    if (row) {

        $("#nombre").val(row.descripcion);

        $('#divPerfiles').hide('fast', function () {
            $('#divCrear').show('fast', function () {
                $('#nombrePerfil').html('<b>Edicion de perfil:' + row.descripcion +' </b>');

                $("#btnGuardar").click(function () {
                    bootsVal();
                    $('#formPerfiles').data('bootstrapValidator').validate();
                    var n = $('#formPerfiles').data('bootstrapValidator').isValid();

                    if (n) {
                        var json = {
                            perfiles: {
                                descripcion: $('#nombre').val(),
                                idPerfil: row.idPerfil
                            }
                        };

                        $.ajax({
                            type: 'POST',
                            url: '../Service.svc/EditarPerfil',
                            dataType: 'json',
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(json),
                            success: function (data) {
                                if (data.result) {
                                    swal({
                                        title: '¡Éxito!',
                                        text: "Se actualizó correctamente el perfil",
                                        type: 'success',
                                        confirmButtonColor: '#0CC27E',
                                        cancelButtonColor: '#FF586B',
                                        confirmButtonText: 'Aceptar',
                                    }).then(function (isConfirm) {
                                        if (isConfirm) {
                                            $('#divCrear').hide('fast', function () {
                                                $('#divPerfiles').show('fast', function () {
                                                    $('#formPerfiles')[0].reset();
                                                    $('#btnGuardar').prop("disabled", false);
                                                    $('#formPerfiles').bootstrapValidator('destroy');

                                                    otable.clear().draw();
                                                    otable.destroy();
                                                    initDataTable();

                                                    $('#dtPerfil tbody').on(
                                                        'click',
                                                        'tr',
                                                        function () {
                                                            if ($(this).hasClass('selected')) {
                                                                $(this).removeClass('selected');
                                                            } else {
                                                                $('#dtPerfil').DataTable().$('tr.selected').removeClass(
                                                                    'selected');
                                                                $(this).addClass('selected');
                                                            }
                                                        });

                                                });
                                            });
                                        }
                                    }).catch(swal.noop);
                                } else {
                                    swal("¡Error!", "Surgio un error al actualizar el perfil", "error");
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
function guardarPerfil() {
    bootsVal();
    $('#formPerfiles').data('bootstrapValidator').validate();
    var n = $('#formPerfiles').data('bootstrapValidator').isValid();

    if (n) {
        var json = {
            perfiles: {
                descripcion: $('#nombre').val(),
                empresa: {
                    idCliente: 1
                },
               acciones :{
                    descripcion: $('#acciones').val()
                }
            }
        };

        $.ajax({
            type: 'POST',
            url: '../Service.svc/InsertPerfil',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(json),
            success: function (data) {
                if (data.result) {
                    swal({
                        title: '¡Éxito!',
                        text: "Se registró correctamente el perfil",
                        type: 'success',
                        confirmButtonColor: '#0CC27E',
                        cancelButtonColor: '#FF586B',
                        confirmButtonText: 'Aceptar',
                    }).then(function (isConfirm) {
                        if (isConfirm) {
                            $('#divCrear').hide('fast', function () {
                                $('#divPerfiles').show('fast', function () {
                                    $('#formPerfiles')[0].reset();
                                    
                                 

                                    $('#btnGuardar').prop("disabled", false);
                                    $('#formPerfiles').bootstrapValidator('destroy');


                                    otable.clear().draw();
                                    otable.destroy();
                                    initDataTable();

                                    $('#dtPerfil tbody').on(
                                        'click',
                                        'tr',
                                        function () {
                                            if ($(this).hasClass('selected')) {
                                                $(this).removeClass('selected');
                                            } else {
                                                $('#dtPerfil').DataTable().$('tr.selected').removeClass(
                                                    'selected');
                                                $(this).addClass('selected');
                                            }
                                        });

                                });
                            });
                        }
                    }).catch(swal.noop);
                } else {
                    swal("¡Error!", "Surgio un error al guardar el perfil", "error");
                }
            }
        });
    }
}