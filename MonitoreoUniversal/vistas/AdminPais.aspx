﻿<%@ Page Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="AdminPais.aspx.cs" Inherits="MonitoreoUniversal.vistas.AdminPais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">
    <style>
        .content-wrapper {
            padding: 0px 15px;
        }
    </style>

    <section id="configuration">

        <div id="divPaises" class="row">

            <div class="col-12">
                 <div class="card">
                    <div class="card-header ">
                        <h1><b><i class="fa fa-globe"></i> Países</b></h1>

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
                                <table id="dtPais"
                                    class="table table-striped table-bordered table-hover DTTT_selectable table-condensed"
                                    cellspacing="0" width="100%" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th class="hasinput" style="width: 10%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="idPais" autocomplete="off" /></th>
                                            <th class="hasinput" style="width: 20%">
                                                <input
                                                    type="text" class="form-control"
                                                    placeholder="Nombre" autocomplete="off" /></th>

                                            <tr>
                                                <th style="width: auto">Id País</th>
                                                <th style="width: auto">Nombre</th>
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
                <!-- #INCLUDE FILE="addPais.aspx" -->
            </article>
        </div> 
      
        
    </section>

    <script src="../JavaScript/adminPais.js"></script>
</asp:Content>
