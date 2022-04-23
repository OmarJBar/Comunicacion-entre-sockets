using evaQ.DAL;
using evaQ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evaQ.Operations
{
    public partial class Program
    {
         static IMedidor medidorDAL = new MedidorFiles();
        static void ShowMedidores()
        {
            List<Medidor> medidor = medidorDAL.ObtenerMedidores();
            for (int i=0; i < medidor.Count(); i++)
            {
                Medidor current = medidor[i]; // objeto actual
                Console.WriteLine("Medidor {0} : numero : {1}, fecha : {2}, y consumo: {3}", i, current.MedidorNro, current.Fecha, current.Consumo);
            }

        }
        static void SearchMedidor()
        {
            Console.WriteLine("Ingrese nombre");
            List<Medidor> filter = medidorDAL.FiltrarMedidores(Convert.ToInt32(Console.ReadLine().Trim()));
            filter.ForEach(me => Console.WriteLine("numero : {0}, fecha : {1}, y consumo: {2}", me.MedidorNro, me.Fecha, me.Consumo));
        }
        static void AddMedidor()
        {
            int medidorNro;
            string fecha;
            double consumo;
        Console.WriteLine("Bienvenido al programa");

            bool esValido;

            do
            {
                Console.WriteLine("Ingrese numero");

                esValido = Int32.TryParse(Console.ReadLine().Trim(), out medidorNro);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese peso");
                esValido = double.TryParse(Console.ReadLine().Trim(), out consumo);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese nombre");
                fecha = Console.ReadLine().Trim();
            } while (fecha.Equals(string.Empty));

            Medidor p = new Medidor()
            { MedidorNro = medidorNro, Consumo = consumo, parseFecha(fecha) };

            //------ en proceso, aqui falta hacer que reemplace lo del tipo fecha con la funcion parseFecha()
            /*

            personasDAL.AgregarPersona(p);

            Console.WriteLine("Nombre : {0}", p.Nombre);
            Console.WriteLine("Telefono : {0}", p.Telefono);
            Console.WriteLine("Peso : {0}", p.Peso);
            Console.WriteLine("Estatura : {0}", p.Estatura);
            Console.WriteLine("IMC : {0}", p.IMC.Texto);
            Console.ReadKey();
            */

        }
    }
}
