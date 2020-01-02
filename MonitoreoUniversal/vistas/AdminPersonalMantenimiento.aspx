<%@ Page Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="AdminPersonalMantenimiento.aspx.cs" Inherits="MonitoreoUniversal.vistas.AdminPersonalMantenimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">
    <style>
        .content-wrapper {
            padding: 0px 15px;
        }
    </style>

    <section id="configuration">

        <div id="divResponsables" class="row">

            <div class="col-12">
                 <div class="card">
                    <div class="card-header">
                        <h1><b><i class="fa fa-user"></i> Personal Mantenimiento</b></h1>
                    </div>
                    <div class="card-content">
                        <div class="card-body card-dashboard table-responsive">
                                    
                            <div class="widget-body">
                                <table id="dtPersonalMantenimiento"
                                    class="table table-striped table-bordered table-hover DTTT_selectable table-condensed"
                                    cellspacing="0" width="100%" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th class="hasinput" style="width: 10%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Nombre" autocomplete="off" /></th>
                                            <th class="hasinput" style="width: 20%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Apellido Paterno" autocomplete="off" /></th>

                                            <tr>
                                                <th style="width: auto">Id Personal</th>
                                                <th style="width: auto">Nombre</th>
                                                <th style="width: auto">Apellido Paterno</th>
                                                <th style="width: auto">Apellido Materno</th>
                                                <th style="width: auto">Correo</th>
                                                <th style="width: auto">Telefono</th>
                                            </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                 </div>
            </div>


        </div>


        <div id="divCrear" class="row" style="display: none">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <!-- #INCLUDE FILE="addUsuarios.aspx" -->
            </article>
        </div> 
      
        <!--  MODAL Eliminar -->
        <div class="modal fade" tabindex="-1" role="dialog" id="modalEliminar">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"
                            aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">
                            <i class="fa fa-ban"></i> Deshabilitar Proyecto
                        </h4>
                    </div>
                    <div class="modal-body">
                        <p class="hidden" id="idRegistroEliminarD"></p>

                        <h4 id="modalMensajeD" class="text-center"></h4>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCncelarEliminar">
                            <i class="fa fa-reply"></i> Cancelar
                        </button>
                        <button type="button" class="btn btn-success" data-dismiss="modal"
                            id="btnEliminarModal">
                            <i class="fa fa-check"></i> Confirmar
                        </button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

    </section>

    <script src="../JavaScript/adminPersonalMantenimiento.js"></script>

</asp:Content>

