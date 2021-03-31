using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato
{
    public interface IDaoGenerico<T>
    {
        //IList<T> ConsultarTodos();
        //int Crear(T reg);
        //void Actualizar(T reg);
        T ConsultarPorId(int id);
    }
}
