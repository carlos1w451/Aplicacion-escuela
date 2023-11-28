using MongoDB.Driver;
public static class VerificarRequestHandler{

    public static IResult Verificar(DatosOlvidoContraseña datos){
      if(string.IsNullOrWhiteSpace(datos.Correo)){
        return Results.BadRequest("El correo es requerido");
      }
     
BaseDatos bd= new BaseDatos();
var coleccion= bd.ObtenerColeccion<Registro>("Usuarios");
if(coleccion==null){
throw new Exception("No existe la coleccion Usuarios");
}
FilterDefinitionBuilder<Registro> filterBuilder = new FilterDefinitionBuilder<Registro>();
var filter = filterBuilder.Eq(x=> x.Correo, datos.Correo);

Registro? usuarioExistente =coleccion.Find(filter).FirstOrDefault();
if(usuarioExistente==null){
    return Results.BadRequest("Ese correo no ha sido registrado");
} else if(usuarioExistente.Correo==datos.Correo){
    Correos c =new Correos();
    c.Para=usuarioExistente.Correo; 
     c.Asunto="Devolver Correo";
     c.Contenido="Tu contraseña es "+usuarioExistente.Password;
      c.Enviar();     
}
return Results.Ok();
    }   
}