using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosChevy.Models
{
    public class GestionModels
    {
        public IList<Listado> Estado;
        public IList<Listado> Area;
        public IList<Listado> Area2;
        public bool estado{get;set;}
        public String user{ get; set; }
        
        public GestionModels(){
        //estado = false;
        }
    }
}