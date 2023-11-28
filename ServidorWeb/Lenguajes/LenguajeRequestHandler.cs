using MongoDB.Driver;
using MongoDB.Bson;
public class LenguajeRequestHandler{
public static IResult ListaRegistros(string IdCategoria){
        var filterBuilder=new FilterDefinitionBuilder<LenguajeDbMap>();
        var filter = filterBuilder.Eq(x=>x.IdCategoria, IdCategoria);
   
   BaseDatos bd=new BaseDatos();
   var coleccion=bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
   var lista=coleccion.Find(filter).ToList();

return Results.Ok(lista.Select(x => new {
    Id=x.Id.ToString(),
    IdCategoria=x.IdCategoria,
    Titulo=x.Titulo,
    Descripcion=x.Descripcion,
    EsVideo=x.EsVideo,
    Url=x.Url
}).ToList());
       }

 public static IResult Eliminar(string id){


    if(!ObjectId.TryParse(id,out ObjectId idLenguaje)){
        return Results.BadRequest($"La id proporcionada no es valida");
    }
    BaseDatos bd = new BaseDatos();
    var filterBuilder= new FilterDefinitionBuilder<LenguajeDbMap>();
    var filter = filterBuilder.Eq(x=> x.Id, idLenguaje);
    var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
    coleccion!.DeleteOne(filter);

    return Results.NoContent();
 }
public static IResult CrearRegistro(LenguajeDTO dto){
    if(string.IsNullOrWhiteSpace(dto.IdCategoria)){
        return Results.BadRequest("La categoria debe tener id");
    }else
    if(dto.IdCategoria.Length!=24){
        return Results.BadRequest("El formato de la categoria  es incorrecto");
        
    }
    if(!ObjectId.TryParse(dto.IdCategoria,out ObjectId IdCategoria)){
        return Results.BadRequest($"La id de la categoria  no es válida");

    }
    BaseDatos bd = new BaseDatos();
    var filterBuilderCategorias=new FilterDefinitionBuilder<CategoriaDbMap>();
    var filterCategoria=filterBuilderCategorias.Eq(x=> x.Id, IdCategoria);
    var coleccionCategoria=bd.ObtenerColeccion<CategoriaDbMap>("Categorias");
    var categoria= coleccionCategoria.Find(filterCategoria).FirstOrDefault();
     
     if(categoria == null ){
        return Results.NotFound($"No existe una categoria con es ID'");
     }
         
if(string.IsNullOrWhiteSpace(dto.Descripcion)){
        return Results.BadRequest("No tiene descripción");
    
    }if(string.IsNullOrWhiteSpace(dto.Titulo)){
        return Results.BadRequest("No tiene titulo");
    
    }if(string.IsNullOrWhiteSpace(dto.Url)){
    
        return Results.BadRequest("La Url de la categoria no existe");
    } 
    LenguajeDbMap registro=new LenguajeDbMap();
    registro.Titulo=dto.Titulo;
    registro.EsVideo=dto.EsVideo;
    registro.Descripcion=dto.Descripcion;
     registro.Url=dto.Url;
     registro.IdCategoria=dto.IdCategoria;
     
     var colecconLenguaje= bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
     colecconLenguaje!.InsertOne(registro);

     return Results.Ok(registro.Id.ToString());
    }
}

