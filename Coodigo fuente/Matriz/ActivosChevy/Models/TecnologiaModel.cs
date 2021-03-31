using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ActivosChevy.Models
{
    public class TecnologiaModel
    {
        public IList<Listado> Categoria;
        public IList<Listado> Estado;
        public IList<Listado> Area;
        public bool estado { get; set; }
        public String user { get; set; }

        public TecnologiaModel()
        {
          //  estado = false;
        }
    }
}