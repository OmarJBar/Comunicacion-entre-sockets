using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evaQ
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            while (Menu());
        
        }
        static bool Menu()
        {
            bool exit = true;
            Console.WriteLine("1. Ingresar");
            Console.WriteLine("2. Mostrar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    //Ingresar
                    break;
                case "2":
                    //Mostrar
                    break;
                case "3":
                    //buscar
                    break;
                case "0": exit = false;
                    //salir
                    break;
                default: Console.WriteLine("No se encontro la opcion elegida...");
                    break;
            }
            return exit;
        }
    }
}
