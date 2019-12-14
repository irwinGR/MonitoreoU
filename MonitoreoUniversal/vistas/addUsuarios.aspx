<section class="content-header">
        <h1 id="nombreUser"><i class="fa fa-user"></i></h1>
       
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-info">
                    <div class="box-header with-border">
                        <fieldset>
                            <h3 class="box-title" id="userText">Busque un usuario para registrarlo</h3>
                        </fieldset>
                    </div>
                    
                        <div class="box-body">
                            <fieldset id="buscador">
					            <div class="row">
						            <section class="col col-md-4">
							            <label class="control-label">Nombre de Usuario </label> 
                                        <input onkeypress="javascript: return ValidarNumero(event,this)" type="text" class="form-control" id="UsuarioB" name="UsuarioB" placeholder="Ingrese el nombre de usuario a buscar"/>
						            </section>
                                    <section class="col col-md-4">
                                        <label class="control-label" style="color: transparent;">ss</label> 
                                        <br />
                                        <button class="btn btn-success btn-sm" id="btnBuscar" type="button">
							                <i class="fa fa-search"></i> Buscar
						                </button>
							        </section>
                                    <section class="col col-md-4">
							        </section>
					            </div>
				            </fieldset>
                            <br />
                            <fieldset>
                                <form class="form-horizontal" id="fmUser">
					            <div class="row">
						            <section class="col col-md-4">
							            <label class="control-label">*Nombre </label> 
                                        <input type="text" class="form-control" id="nombre" name="nombre" readonly="readonly"/>
						            </section>
                                    <section class="col col-md-4">
							            <label class="control-label">*Apellido paterno </label> 
                                        <input type="text" class="form-control" id="apellidoP" name="apellidoP" readonly="readonly"/>
						            </section>
                                    <section class="col col-md-4">
							            <label class="control-label">*Apellido materno </label> 
                                        <input type="text" class="form-control" id="apellidoM" name="apellidoM" readonly="readonly"/>
						            </section>
					            </div>
				            </fieldset>
                            <br />
                            <fieldset>
					            <div class="row">
						            <section class="col col-md-4">
							            <label class="control-label">*Nombre de usuario </label> 
                                        <input type="text" class="form-control" id="nombreUsuario" name="nombreUsuario" readonly="readonly"/>
						            </section>
                                    <section class="col col-md-4">
							            <label class="control-label">*Correo electronico </label> 
                                        <input type="text" class="form-control" id="correo" name="correo" readonly="readonly"/>
						            </section>
                                    <section class="col col-md-4">
							            
						            </section>
					            </div>
				            </fieldset><br>
                            <div class="box-header with-border">
                                <fieldset>
                                    <h3 class="box-title" id="">Asignacion de rol</h3>
                                </fieldset>
                            </div>
                             <fieldset class="box box-info">
					            <div class="row">
                                    <br />
						            <section class="col col-md-4">
							            <label class="control-label">*Asignar rol </label> 
                                        <select  class="form-control" id="rol" name="rol">
                                            <%--<option value="0">Selecciones la Opcion</option>
                                            <option value="1">Administrador</option>--%>
                                        </select>
                                        
						            </section>
                                    <section class="col col-md-4">
							           
						            </section>
                                    <section class="col col-md-4">
							            
						            </section>
					            </div>
				            </fieldset>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                             <div class="widget-body-toolbar pull-right">
					            <div class="form-actions">
						                <button id="btnCancel" type="button" class="btn btn-danger btn-sm">
							                <i class="fa fa-arrow-left"></i> Cancelar
						                </button>
						                <button class="btn btn-primary btn-sm" id="btnSave" type="button">
							                <i class="fa fa-save"></i> Guardar
						                </button>
                                        <button class="btn btn-primary btn-sm" id="btnEditPlus" type="button" hidden>
							                <i class="fa fa-save"></i> Guardar
						                </button>
					            </div>
				             </div>
                        </div>
                        <!-- /.box-footer -->
                    </form>
                </div>
            </div>
        </div>
</section>
