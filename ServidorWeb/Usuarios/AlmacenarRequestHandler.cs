
using MongoDB.Driver;

public static class AlmacenarRequestHandler{

    public static IResult Registrar(Registro datos){
      if(string.IsNullOrWhiteSpace(datos.Nombre)){
        return Results.BadRequest("El nombre es requerido");
      }
      if(string.IsNullOrWhiteSpace(datos.Correo)){
        return Results.BadRequest("El correo es requerido");
      }
      if(string.IsNullOrWhiteSpace(datos.Password)){
        return Results.BadRequest("El password es requerido");
      } 

BaseDatos bd= new BaseDatos();
var coleccion= bd.ObtenerColeccion<Registro>("Usuarios");
if(coleccion==null){
throw new Exception("No existe la coleccion Usuarios");
}
FilterDefinitionBuilder<Registro> filterBuilder = new FilterDefinitionBuilder<Registro>();
var filter = filterBuilder.Eq(x=> x.Correo, datos.Correo);

Registro? usuarioExistente =coleccion.Find(filter).FirstOrDefault();
if(usuarioExistente!=null){
    return Results.BadRequest($"Ya existe un usuario con el correo{datos.Correo}");
}
coleccion.InsertOne(datos);

return Results.Ok();
    }
    
}