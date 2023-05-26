using Disquera.UAPI;
using Disquera.Modelos;

var uapi = new Crud<Autor>();


var ec = uapi.Select_byId("https://localhost:7290/api/Autores", "1");

ec.edad = 33;

uapi.Update("https://localhost:7290/api/Autores","1", ec);
var autores = uapi.Select("https://localhost:7290/api/Autores");


