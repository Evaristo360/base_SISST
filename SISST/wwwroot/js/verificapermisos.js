/**
 *  Verifica codigo de retorno de una llamada ajax en requisitos legales
 */
function verificaPermisos(xhr, modulo, mensaje, permiso) {
	if (Number(xhr.status) === 200) {
		var texto = xhr.responseText;
		var noautorizado = texto.search("No autorizado");
		if (noautorizado>0) {
			var mensajeAlerta = "No cuenta con el privilegio \n" + permiso + "\n para " + mensaje + "\n en el módulo " + modulo;

			//swal("", mensajeAlerta, "warning");
            toastr["warning"](mensajeAlerta);


			return true;
		}
	} else if (Number(xhr.status) === 400) {
		var mensajeAlerta = "No se puede autenticar la solicitud a \n" + permiso + "\n para " + mensaje + "\n en el módulo " + modulo;
		swal("", mensajeAlerta, "warning");
		return true;
	}
	return false;
}