using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evaQ.DTO;

namespace evaQ.DAL
{
    /// <summary>
    /// Medidor archivo --> Clase lista
    /// </summary>
    public class MedidorFiles : IMedidor
    {
        private static string fileName="medidores.txt";
        private static string ruta = Directory.GetCurrentDirectory()+"/"+fileName;
        public void AgregarMedidor(Medidor medidor)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    string text = medidor.MedidorNro + "|" + medidor.Fecha + "|"
                                   + medidor.Consumo + "|";
                    writer.WriteLine(text);
                    writer.Flush();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Hubo un error agregando el medidor"+ error.Message);
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        public List<Medidor> FiltrarMedidores(int medidorNum)
        {
            return ObtenerMedidores().FindAll(me => me.MedidorNro == medidorNum);
        }

        public List<Medidor> ObtenerMedidores()
        {
            List<Medidor> medidores = new List<Medidor>();
            using (StreamReader reader=new StreamReader(ruta))
            {
                string text;
                do
                {
                    text = reader.ReadLine();
                    if (text != null)
                    {
                        string[] textArray = text.Trim().Split('|');
                        int medidorNro = Convert.ToInt32(textArray[0]);
                        DateTime fecha = Convert.ToDateTime(textArray[1]);
                        double consumo = Convert.ToDouble(textArray[2]);
                        Medidor me = new Medidor()
                        {
                            MedidorNro = medidorNro,
                            Fecha = fecha,
                            Consumo = consumo,
                        };

                        medidores.Add(me);

                    }
                } while (text != null);
            }
                return medidores;
        }
    }
}
