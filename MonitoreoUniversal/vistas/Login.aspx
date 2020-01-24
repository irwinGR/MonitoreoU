<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MonitoreoUniversal.vistas.Login" %>

<!DOCTYPE html>
<html lang="en" class="loading">
   <!-- BEGIN : Head-->
   <!-- Mirrored from pixinvent.com/apex-angular-4-bootstrap-admin-template/html-demo-1/login-page.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 22 Oct 2019 16:19:36 GMT -->
   <head>
      <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
      <meta name="description" content="Apex admin is super flexible, powerful, clean &amp; modern responsive bootstrap 4 admin template with unlimited possibilities.">
      <meta name="keywords" content="admin template, Apex admin template, dashboard template, flat admin template, responsive admin template, web app">
      <meta name="author" content="PIXINVENT">
      <title>Iniciar Sesion</title>
      <link rel="apple-touch-icon" sizes="60x60" href="../resources/app-assets/img/ico/apple-icon-60.html">
      <link rel="apple-touch-icon" sizes="76x76" href="../resources/app-assets/img/ico/apple-icon-76.html">
      <link rel="apple-touch-icon" sizes="120x120" href="../resources/app-assets/img/ico/apple-icon-120.html">
      <link rel="apple-touch-icon" sizes="152x152" href="../resources/app-assets/img/ico/apple-icon-152.html">
      <link rel="shortcut icon" type="image/x-icon" href="../resources/app-assets/img/ico/favicon.ico">
      <link rel="shortcut icon" type="image/png" href="../resources/app-assets/img/ico/favicon-32.png">
      <meta name="apple-mobile-web-app-capable" content="yes">
      <meta name="apple-touch-fullscreen" content="yes">
      <meta name="apple-mobile-web-app-status-bar-style" content="default">
      <link href="https://fonts.googleapis.com/css?family=Rubik:300,400,500,700,900|Montserrat:300,400,500,600,700,800,900" rel="stylesheet">
     
       <!-- BEGIN VENDOR CSS-->
 
      <link rel="stylesheet" type="text/css" href="../resources/app-assets/fonts/feather/style.min.css">
      <link rel="stylesheet" type="text/css" href="../resources/app-assets/fonts/simple-line-icons/style.css">
      <link rel="stylesheet" type="text/css" href="../resources/app-assets/fonts/font-awesome/css/font-awesome.min.css">
      <link rel="stylesheet" type="text/css" href="../resources/app-assets/vendors/css/perfect-scrollbar.min.css">
      <link rel="stylesheet" type="text/css" href="../resources/app-assets/vendors/css/prism.min.css">

      <link rel="stylesheet" type="text/css" href="../resources/app-assets/css/app.css">
 
      <link href="../resources/app-assets/vendors/css/toastr.css" rel="stylesheet" />
      <link href="../resources/app-assets/vendors/css/toastr.min.css" rel="stylesheet" />

      <!-- BEGIN VENDOR JS-->
      <script src="../resources/app-assets/vendors/js/core/jquery-3.2.1.min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/core/popper.min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/core/bootstrap.min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/prism.min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/jquery.matchHeight-min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/screenfull.min.js" type="text/javascript"></script>
      <script src="../resources/app-assets/vendors/js/pace/pace.min.js" type="text/javascript"></script>
    
      <script src="../resources/app-assets/js/app-sidebar.js" type="text/javascript"></script>
      <script src="../resources/app-assets/js/notification-sidebar.js" type="text/javascript"></script>
      <script src="../resources/app-assets/js/customizer.js" type="text/javascript"></script>
      <script src="../resources/app-assets/js/toastr/toastr.min.js"  type="text/javascript"></script>
      <script src="../JavaScript/adminIndex.js" type="text/javascript"></script>

      <script type="text/javascript">
         function llamar() {
             toastr.success('Estas ingresando al monitoreo 360°', '¡Bienvenido!');                
             setTimeout(function () {
                     location.href = "index.aspx";
                },1000)
            }
       </script>


   </head>
   <!-- END : Head-->
   <!-- BEGIN : Body-->
   <body data-col="1-column" class=" 1-column  blank-page">
      <!-- ////////////////////////////////////////////////////////////////////////////-->
      <div class="wrapper">
         <div class="main-panel">
            <!-- BEGIN : Main Content-->
            <div class="main-content">
               <div class="content-wrapper">
                  <!--Login Page Starts-->
                  <section id="login">
                     <div class="container-fluid">
                        <div class="row full-height-vh m-0">
                           <div class="col-12 d-flex align-items-center justify-content-center">
                              <div class="card">
                                 <div class="card-content">
                                    <div class="card-body login-img">
                                       <div class="row m-0">
                                          <div class="col-lg-6 d-lg-block d-none py-2 text-center align-middle">
                                             <img src="../resources/app-assets/img/gallery/login.png" alt="" class="img-fluid mt-5" width="400" height="230">
                                          </div>
                                          <div class="col-lg-6 col-md-12 bg-white px-4 pt-3">
                                             <h4 class="mb-2 card-title">Iniciar Sesion</h4>
                                              <br />
                                             <p class="card-text mb-3">
                                                Bienvenido, Por favor inicia sesion con tu cuenta.
                                             </p>
                                              <form runat="server">
                                                    <asp:TextBox type="text" class="form-control mb-3" ID="user" runat="server" placeholder="Nombre de usuario" required="required" autocomplete="off"></asp:TextBox>
                                                    <asp:TextBox runat="server" type="password" class="form-control mb-1" ID="password" placeholder="Contraseña" required="required" ></asp:TextBox>
                                                    <div class="d-flex justify-content-between mt-2">
                                                    <div class="forgot-password-option">
                                                        <a href="forgot-password-page.html" class="text-decoration-none text-info">Olvidaste tu contraseña?</a>
                                                    </div>
                                                    </div>
                                                    <br />
                                                    <div class="fg-actions justify-content-between">
                                                        <div class="recover-pass ">
                                                            <center>
                                                                <asp:Button type="button" class="btn btn-block btn-info round" ID="btnLogin" Text="Entrar" runat="server" OnClick="Button1_Click"></asp:Button>
                                                            </center>
                                                        </div>
                                                    </div>
                                              </form>
                                             
                                             
                                             <hr class="m-0">
                                             
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </section>
                  <!--Login Page Ends-->
               </div>
            </div>
            <!-- END : End Main Content-->
         </div>
      </div>
      
   </body>
   <!-- END : Body-->
   <!-- Mirrored from pixinvent.com/apex-angular-4-bootstrap-admin-template/html-demo-1/login-page.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 22 Oct 2019 16:19:36 GMT -->
</html>
