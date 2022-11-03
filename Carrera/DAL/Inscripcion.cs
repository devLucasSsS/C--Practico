using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Inscripcion
    {
        public Recorrido Recorrido { get; set; }
        public Categoria Categoria { get; set; }
        public string Identificador { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public double Valor { get; set; }

        public override string ToString()
        {
            return this.Recorrido +"\n" + this.Categoria + "\n"+ this.Identificador + "\n" + this.FechaInscripcion + "\n" + this.Nombre + "\n" + this.Edad + "\n"+ this.Email + "\n" + this.Valor;
        }
    }
}
