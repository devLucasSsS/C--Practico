using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class InscripcionBLL
    {
        List<Inscripcion> inscripciones = new List<Inscripcion>();

        public void Agregar(Inscripcion inscripcion)
        {
            inscripciones.Add(inscripcion);
        }
        public List<Inscripcion> GetAll()
        {
            return inscripciones;
        }

    }
}
