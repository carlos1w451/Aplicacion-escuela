using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);
 builder.Services.Configure<JsonOptions>(Options=> 
 Options.SerializerOptions.PropertyNamingPolicy=null); 
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapGet("/", () => "Hello World!");

app.MapPost("/usuarios/registrar",AlmacenarRequestHandler.Registrar);
app.MapPost("/usuarios/ingresar",IngresarRequestHandler.Ingresar);
app.MapPost("/usuarios/recuperar",VerificarRequestHandler.Verificar);

app.MapPost("/categorias/crear",CategoriasRequestHandler.Crear);
app.MapGet("/categorias/listar",CategoriasRequestHandler.Listar);

app.MapGet("/lenguaje/{idCategoria}",LenguajeRequestHandler.ListaRegistros);
app.MapPost("/lenguaje",LenguajeRequestHandler.CrearRegistro);
app.MapDelete("/lenguaje/{id}",LenguajeRequestHandler.Eliminar);

app.Run();
