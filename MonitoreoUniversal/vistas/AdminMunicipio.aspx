<%@ Page Language="C#"  MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="AdminMunicipio.aspx.cs" Inherits="MonitoreoUniversal.vistas.AdminMunicipio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">
   <style>
        .content-wrapper {
            padding: 0px 15px;
        }
    </style>

    <section id="configuration">

        <div id="divMunicipiosDelegaciones" class="row">

            <div class="col-12">
                 <div class="card">
                    <div class="card-header">
                        <h1><b><i class="fa fa-user"></i> Municipios/Delegaciones</b></h1>

                        <div class="widget-body-toolbar">
                            <button id="btnPlus" type="button"
                                class="btn btn-primary btn-sm btnPlus">
                                <i class="fa fa-plus-circle"></i>  Agregar
                            </button>

                            <button id="btnEdit" type="button"
                                class="btn btn-warning btn-sm btnRolEdit">
                                <i class="fa fa-file-text"></i>  Editar
                            </button>

                            <button id="btnDelete" type="button"
                                class="btn btn-danger btn-sm btnRolDelete">
                                <i class="fa fa-ban"></i>  Eliminar
                            </button>
                        </div>
                    </div>
                    <div class="card-content">
                        <div class="card-body card-dashboard table-responsive">
                                    
                            <div class="widget-body">
                                <table id="dtMunicipiosDelegaciones"
                                    class="table table-striped table-bordered table-hover DTTT_selectable table-condensed"
                                    cellspacing="0" width="100%" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th class="hasinput" style="width: 10%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="ID" autocomplete="off" /></th>
                                            <th class="hasinput" style="width: 20%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Nombre" autocomplete="off" /></th>
                                            <th class="hasinput" style="width: 20%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Estado" autocomplete="off" /></th>
                                             <th class="hasinput" style="width: 20%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Pais" autocomplete="off" /></th>

                                            <tr>
                                                <th style="width: auto">idMunicipioDelegacion</th>
                                                <th style="width: auto">Nombre</th>
                                                <th style="width: auto">Estado</th>
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
                <!-- #INCLUDE FILE="addMunicioDelegaciones.aspx" -->
            </article>
        </div> 
      

    </section>

    <script src="../JavaScript/adminMunicipioDelegaciones.js"></script>
    </asp:Content>
