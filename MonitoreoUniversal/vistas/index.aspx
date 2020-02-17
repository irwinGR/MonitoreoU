<%@ Page Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MonitoreoUniversal.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">

    <section id="collapsible">
        <div class="row">
            <div class="col-lg-12 col-xl-12">
                <div class="card collapse-icon accordion-icon-rotate" id="tableros">
                   <div id="headingCollapse" class="card-header pb-3">
                        <%--<a data-toggle="collapse" href="#collapse" aria-expanded="true" aria-controls="collapse" class="card-title lead collapsed">
                            
                        </a>--%>
                       <div class="form-actions">
                            <button id="btnGraficas" type="button" class="btn btn-primary btn-lg" onclick="eventBotonGrafica()">
                                    <i class="fa fa-line-chart"></i>  Graficas
                            </button>
                            <button id="btnReportes" type="button" class="btn btn-warning btn-lg" onclick="eventBotonReportes()">
                                    <i class="fa fa-file-text"></i>  Reportes
                            </button>
                            <button id="btnBitacora" type="button" class="btn btn-danger btn-lg" onclick="eventBotonBitacora()">
                                    <i class="fa fa-align-right"></i>  BItacoras
                            </button>
                        </div>
                    </div>

                    <div id="collapse" role="tabpanel" aria-labelledby="headingCollapse" class="collapse show" style="">
                        <div class="card-content">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="basic-map" class="height-400"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row" id="contenedorVariables">

                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
<!-- Collapse end -->
    <script async defer src="https://maps.googleapis.com/maps/api/js?v=3&amp;callback=agmLazyMapsAPILoader&amp;key=AIzaSyCERobClkCv1U4mDijGm1FShKva_nxsGJY" type="text/javascript"></script>   
    <script src="../resources/app-assets/vendors/js/gmaps.min.js"></script>
    <script src="../JavaScript/utilidadesScript.js"></script>
    <script src="../JavaScript/index.js"></script>
</asp:Content>

