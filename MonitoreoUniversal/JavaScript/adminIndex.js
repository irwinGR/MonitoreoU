
// *****
// Mensajes console log
// *****
var consoleSuccess = "color: #00a65a; font-weight: bold; font-style: italic;";
var consoleWarning = "color: #e08e0b; font-weight: bold; font-style: italic;";
var consoleDanger  = "color: #d73925; font-weight: bold; font-style: italic;";
var consoleInfo    = "color: #00c0ef; font-weight: bold; font-style: italic;";
var consolePrimary = "color: #3c8dbc; font-weight: bold; font-style: italic;";

$( () => {
	toastrOptions();
});

$("#cerrarSesion").click(function(){
	window.location.href = 'login.aspx';
});

// *****
// Toastr - Notificaciones
// *****
function toastError(titulo, mensaje){
	toastr.error(mensaje, titulo);
}

function toastSuccess(titulo, mensaje){
	toastr.success(mensaje, titulo);
}

function toastWarning(titulo, mensaje){
	toastr.warning(mensaje, titulo);
}

function toastInfo(titulo, mensaje){
	toastr.info(mensaje, titulo);
}

// *****
// Toastr Options
// *****
function toastrOptions(){
	toastr.options.closeButton   = true;
	toastr.options.showEasing    = 'swing';
	toastr.options.closeMethod   = 'fadeOut';
	toastr.options.closeDuration = 1;
	toastr.options.closeEasing   = 'swing';
	toastr.options.newestOnTop   = true;
	toastr.options.progressBar   = true;
	toastr.options.preventDuplicates = true;
}


// Chargin Modal
function openModal() {
    $('body').loadingModal('destroy');
    $('body').loadingModal({
        text: 'Cargando...',
        animation: 'wave'
    });
}

function openModalExcel() {
    $('body').loadingModal('destroy');
    $('body').loadingModal({
        text: 'Generando Reporte...',
        animation: 'circle'
    });
}

function closeModal() {
    $('body').loadingModal('hide');
}