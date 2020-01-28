<section class="basic-elements">
    <div id="divAddPerfiles" class="row">
		<div class="col-md-12">
			<div class="card">
				<div class="card-content">
					<div class="px-3">
						<form class="form" id="formPerfiles" 
                                                            data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                                                            data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
                                                            data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
							<div class="form-body">
                                <h4 class="form-section" id="nombrePerfil"></h4>
                                <br />
								<div class="row">
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Nombre del perfil</label>
											<input type="text" class="form-control" id="nombre" name="nombre" onkeypress ="return soloLetras(event);">
										</fieldset>
                                    </div>
                                    <div class="col-md-4">
                                        
                                            <label for="basicInput">* Acciones</label>
                                            <select  name = "acciones" id="acciones" size="1"  multiple="multiple" class="select2" >
                                                
                                            </select>
                                        
                                    </div>
                              </div>
								</div>
							</div>
                            <div class="form-actions">
								<div class="text-right">
									<button type="button" class="btn btn-raised btn-primary"  id="btnGuardar" > Guardar <i class="fa fa-floppy-o" aria-hidden="true"></i></button>
									<button type="button" class="btn btn-raised btn-warning" id="btnCancelar">Cancelar <i class="fa fa-undo" aria-hidden="true"></i></button>
								</div>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</section>