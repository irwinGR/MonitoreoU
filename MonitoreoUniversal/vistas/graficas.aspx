<%@ Page Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="graficas.aspx.cs" Inherits="MonitoreoUniversal.vistas.graficas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">
    <style>
        /*.chartjs {
            position: relative !important;
            margin: auto !important;
            width: 450px !important;
            height: 379px;
        }*/
    </style>

    <section class="basic-elements">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-content">
                        <div class="px-3">
                                <form class="form">
                                    <div class="form-body">
                                        <h4 class="form-section" id="">Graficas</h4>
                                        <br />
								        <div class="row">
                                            <div class="col-md-3">
                                                <fieldset class="form-group">
                                                    <label class="label-control" for="basicInput">N° de graficas </label>
                                                    <select class="form-control" id="graficasN" name="graficasN">
                                                        <option value="0">Seleccione una opcion</option>
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                    </select>
                                                </fieldset>
                                            </div>
                                        </div>
                                     </div>
                                </form>
                            </div>
                    </div>

                    <div id="graficasDinamicas">
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="../JavaScript/chartjs.js"></script>
</asp:Content>