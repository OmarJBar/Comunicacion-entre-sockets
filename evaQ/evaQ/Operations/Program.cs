using evaQ.DAL;
using evaQ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evaQ
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
        Console.WriteLine("__Agregar_Medidor__");

            bool esValido;

            do
            {
                Console.WriteLine("Ingrese numero");

                esValido = Int32.TryParse(Console.ReadLine().Trim(), out medidorNro);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese consumo");
                esValido = double.TryParse(Console.ReadLine().Trim(), out consumo);
            } while (!esValido);

            do
            {/*
                Console.WriteLine("Ingrese dia");

                Console.WriteLine("Ingrese mes");

                Console.WriteLine("Ingrese año");

                Console.WriteLine("Ingrese hora de medicion");

                Console.WriteLine("Ingrese minuto de medicion");

                fecha = Console.ReadLine().Trim();*/

                fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            } while (fecha.Equals(string.Empty));

            Medidor me = new Medidor()
            { MedidorNro = medidorNro, Consumo = consumo, };
            me.parseFecha(fecha);
            medidorDAL.AgregarMedidor(me);

            medidorDAL.FiltrarMedidores(me.MedidorNro);
        }
    }
}
