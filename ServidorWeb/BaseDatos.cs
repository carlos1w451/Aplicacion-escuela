using MongoDB.Driver;

public class BaseDatos{
    private string conexion = "mongodb+srv://Max:mamberroi@cluster0.3vljmiz.mongodb.net/?retryWrites=true&w=majority&appName=AtlasApp";
    private string baseDatos = "Proyecto";
    public IMongoCollection<T>? ObtenerColeccion<T> (string coleccion){
        MongoClient client = new MongoClient(this.conexion);
        IMongoCollection<T>? collection = client.GetDatabase(this.baseDatos).GetCollection<T>(coleccion);

    return collection;
    }
}