function validarFormulario() {        
    var usuario = document.getElementById('txtUsuario').value;
    if (usuario.length == 0) {
        document.getElementById('lblMensajes').innerHTML = 'No has escrito nada en el usuario';
        return false;
    }
    var clave = document.getElementById('txtClave').value;
    if (clave.length < 6) {
        document.getElementById('lblMensajes').innerHTML = 'La clave no es válida';
        return false;
    }
    return true;
}