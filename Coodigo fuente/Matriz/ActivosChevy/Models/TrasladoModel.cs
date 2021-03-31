using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosChevy.Models
{
    public class TrasladoModel
    {
        public IList<Listado> Estado;
        public IList<Listado> Area;
        public IList<Listado> Ubicación;
    }
}