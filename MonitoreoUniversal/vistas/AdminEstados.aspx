<%@ Page Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="AdminEstados.aspx.cs" Inherits="MonitoreoUniversal.vistas.AdminEstados" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">
    <style>
        .content-wrapper {
            padding: 0px 15px;
        }
    </style>

    <section id="configuration">

        <div id="divEstados" class="row">

            <div class="col-12">
                 <div class="card">
                    <div class="card-header ">
                        <h1><b><i class="fa ft-compass"></i> Estados</b></h1>

                        <div class="form-actions">
                            <button id="btnPlus" type="button"
                                class="btn btn-primary btn-sm btnPlus">
                                <i class="fa fa-plus-circle"></i>  Agregar
                            </button>

                            <button id="btnEdit" type="button"
                                class="btn btn-warning btn-sm btnEdit">
                                <i class="fa fa-file-text"></i>  Editar
                            </button>

                            <button id="btnDelete" type="button"
                                class="btn btn-danger btn-sm btnDelete">
                                <i class="fa fa-ban"></i>  Eliminar
                            </button>
                        </div>
                    </div>
                    <div class="card-content">
                        <div class="card-body card-dashboard table-responsive">
                                    
                            <div class="widget-body">
                                <table id="dtEstado"
                                    class="table table-striped table-bordered table-hover DTTT_selectable table-condensed"
                                    cellspacing="0" width="100%" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th class="hasinput" style="width: auto">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="id Estado" autocomplete="off" /></th>

                                            <th class="hasinput" style="width: auto">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Nombre" autocomplete="off" /></th>

                                            <th class="hasinput" style="width: auto">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Pais" autocomplete="off" /></th>

                                            <tr>
                                                <th style="width: auto">Id Estado</th>
                                                <th style="width: auto">Nombre</th>
                                                <th style="width: auto">Pais</th>

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
                <!-- #INCLUDE FILE="addEstados.aspx" -->
            </article>
        </div> 
      
        
    </section>

    <script src="../JavaScript/adminEstado.js"></script>
</asp:Content>
