using MongoDB.Bson;

public  class Ingresar{
    public ObjectId Id {get;set;}
public string Correo {get; set;}= string.Empty;
public string Password {get; set;}= string.Empty;
}