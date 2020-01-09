<%@ Page Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MonitoreoUniversal.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="server">

    <section id="collapsible">
        <div class="row">
            <div class="col-lg-12 col-xl-12">
                <div class="card collapse-icon accordion-icon-rotate" id="tableros">
                   
                </div>
            </div>
        </div>
    </section>
<!-- Collapse end -->
    <script async defer src="https://maps.googleapis.com/maps/api/js?v=3&amp;callback=agmLazyMapsAPILoader&amp;key=AIzaSyCERobClkCv1U4mDijGm1FShKva_nxsGJY" type="text/javascript"></script>   
    <script src="../resources/app-assets/vendors/js/gmaps.min.js"></script>
    <script src="../JavaScript/index.js"></script>
</asp:Content>

