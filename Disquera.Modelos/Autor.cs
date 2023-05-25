using System.ComponentModel.DataAnnotations;

namespace Disquera.Modelos
{
    public class Autor
    {
        [Key]
        public int id_autor { get; set; } //pk, sugerencia de tipo int
  
        public String? nombre { get; set; }
        public String? nacionalidad { get; set; }
        public int? edad { get; set; }

        //relacion
        public List<Cancion>? Canciones { get; set; }


    }
}