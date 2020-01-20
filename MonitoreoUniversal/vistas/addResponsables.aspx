<section class="basic-elements">
	<div class="row">
		<div class="col-md-12">
			<div class="card">
				
				<div class="card-content">
					<div class="px-3">
						<form class="form" id="formResponsables" 
                                                            data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                                                            data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
                                                            data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
							<div class="form-body">
                                <h4 class="form-section" id="nombreResponsables"></h4>
								<div class="row">
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Nombre(s)</label>
											<input type="text" class="form-control" id="nombre" name="nombre" onkeypress =" return soloLetras(event);">
										</fieldset>
									</div>
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Apellido Paterno</label>
											<input type="text" class="form-control" id="apellidoP" name="apellidoP" onkeypress =" return soloLetras(event);">
										</fieldset>
									</div>
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Apellido Materno</label>
											<input type="text" class="form-control" id="apellidoM" name="apellidoM" onkeypress = "return soloLetras(event);" >
										</fieldset>
									</div>
								</div>
							</div>
                            <div class="form-body">
								<div class="row">
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Correo</label>
											<input type="text" class="form-control" id="correo" name="correo" required >                 
										</fieldset>
									</div>
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Teléfono</label>
											<input type="text" class="form-control" id="telefono" name=telefono onkeypress ="return soloNumeros(event);">
										</fieldset>
									</div>
								</div>
							</div>
                            <div class="form-actions">
								<div class="text-right">
									<button type="button" class="btn btn-raised btn-primary" id="btnGuardar">Guardar <i class="fa fa-floppy-o" aria-hidden="true"></i></button>
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