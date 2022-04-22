using evaQ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evaQ.DAL
{
    public interface IMedidor
    {
        void AgregarMedidor(Medidor persona);

        List<Medidor> ObtenerMedidores();

        List<Medidor> FiltrarMedidores(string medidor);
    }
}
