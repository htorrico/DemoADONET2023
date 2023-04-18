using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public class BRegion
    {

        public List<Region> Listar(string description)
        {

            DRegion datos= new DRegion();
            var regiones = datos.Listar();
            var result = regiones.Where(x => x.Description == description
            || string.IsNullOrEmpty(description)
            ).ToList();
            return result;

        }
    }
}
