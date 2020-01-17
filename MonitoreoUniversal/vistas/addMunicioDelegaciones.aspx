<section class="basic-elements">
	<div class="row">
		<div class="col-md-12">
			<div class="card">
				
				<div class="card-content">
					<div class="px-3">
						<form class="form" id="formMunicipiosDelegaciones">
							<div class="form-body">
                                <h4 class="form-section" id="nombreMunicipiosDelegaciones"></h4>
                                <br />
								<div class="row">
									<div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Nombre del municipio o delegación</label>
											<input type="text" class="form-control" id="nombre" name="nombre" required>
										</fieldset>
									</div>
                                    <div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Pais</label>
											<select class="form-control" id="pais" name="país"></select>
										</fieldset>
									</div>
                                    <div class="col-md-4">
										<fieldset class="form-group">
											<label for="basicInput">* Estado</label>
											<select class="form-control" id="estado" name="estado"></select>
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