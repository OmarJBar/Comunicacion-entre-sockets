using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evaQ.DTO
{
    public class Medidor
    {
        private int medidorNro;
        private DateTime fecha;
        private double consumo;
        public int MedidorNro { get => medidorNro; set => medidorNro = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Consumo { get => consumo; set => consumo = value; }

        public void parseFecha(string date)
        {
            try
            {
                DateTime fechaGet = Convert.ToDateTime(date); 

                this.fecha = fechaGet;
            }
            catch (Exception e)
            {
                DateTime fechaGet = DateTime.Now;
                Console.WriteLine("Error al intentar parsear la fecha, se ingreso al fecha actual ({0})", fechaGet);
                Console.WriteLine("Error tipo {0}", e);
                Console.ReadKey();

                this.fecha = fechaGet;
            }           
        }
    }

}
