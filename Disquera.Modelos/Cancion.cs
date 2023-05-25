using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disquera.Modelos
{
    public class Cancion
    {
        [Key]
        public int id_cancion { get; set; }
        public String? nombre { get; set; }
        public String? reproducciones { get; set; }
        public String? genero { get; set; }

        //Claves foraneas        
        public Autor? Autor { get; set; }
        public int Autorid_autor { get; set; } //Clave Foranea

    }
}
