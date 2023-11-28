using MongoDB.Bson;
public class DatosOlvidoContraseña
{
    
    public ObjectId Id {get;set;}
    public string Correo {get; set;}= string.Empty;
    public string Para {get; set; }=string.Empty;
public string Asunto {get; set; }=string.Empty;
public string Contenido  {get; set; }=string.Empty;

}