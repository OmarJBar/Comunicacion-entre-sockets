using System;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using UtilsMedidor;
using UtilsServer;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {

            int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            Console.WriteLine("Iniciando servidor en puerto {0}", port);

            ServerSocket server = new ServerSocket(port);
            if (server.StartConnection())
            {

                Console.WriteLine("Servidor Iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Cliente");
                    Socket socketClient = server.GetClient();
                    ClientCom client = new ClientCom(socketClient);
                    client.Write("Hola Mundo cliente, dime tu nombre???");
                    string respuesta = client.Read();
                    Console.WriteLine("Bienvenido {0}", respuesta);
                    Comunicacion(client);

                    //MenuProgram.MainMenu();

                    client.Disconnect();
                }
            }
            else
            {
                Console.WriteLine("Puerto {0} en uso, intente mas tarde...", port);
            }

        }
        private static void Comunicacion(ClientCom cliente)
        {

            bool salir = false;
            while (!salir)
            {
                cliente.Write("Ingresar un medidor?\n Ingrese Y para salir o N para continuar");
                string mensaje = cliente.Read();

                if (mensaje != null)
                {
                    if (mensaje.ToLower() == "n")
                    {
                        cliente.Write("Saliendo...");
                        Thread.Sleep(2000);
                        Console.WriteLine("Cliente salio");
                        salir = true;
                    }
                    else if(mensaje.ToLower()=="y")
                    {
                        Console.WriteLine("-----Mostrando Menu-----");
                        Menu(cliente);
                    }
                    else
                    {
                        cliente.Write("No se ingreso lo esperado");
                    }
                    
                }
                else
                {
                    cliente.Write("No se ingreso nada");
                }
            }
            cliente.Disconnect();
        }
        private static void Menu(ClientCom cliente)
        {
            string result;
            string resp = "1. Ingresar\n2. Mostrar\n3. Buscar \n0. Salir";
            cliente.Write(resp);
            
            switch (cliente.Read().Trim())
            {
                case "1":
                    string[] array = DatosCliente(cliente);
                    result = MenuProgram.AddMedidor(Convert.ToInt32(array[0]), Convert.ToDouble(array[1]));
                    cliente.Write(result);
                    break;
                case "2":
                    string[] values = MenuProgram.ShowMedidores();
                    cliente.Write(String.Join("\n", values));
                    break;
                case "3":
                    cliente.Write("Ingrese el nombre del medidor");
                    result= MenuProgram.SearchMedidor(cliente.Read().Trim());
                    Console.WriteLine("Se ingreso el medidor: {0}",result);
                    cliente.Write(result);
                    break;
                case "0":
                    cliente.Write("Saliendo");
                    Thread.Sleep(5000);
                    break;
                default:
                    cliente.Write("No se encontro la opcion elegida...");
                    Thread.Sleep(2000);
                    break;
            }
        }
        private static string[] DatosCliente(ClientCom client)
        {
            bool esValido;
            string[] array = new string[2];
            int medidorNro;
            double consumo;

            do
            {
                client.Write("Ingrese numero");
                esValido = Int32.TryParse(client.Read().Trim(), out medidorNro);
            } while (!esValido);

            do
            {
                client.Write("Ingrese consumo");
                esValido = double.TryParse(client.Read().Trim(), out consumo);
            } while (!esValido);

            array[0] = medidorNro.ToString();
            array[1] = consumo.ToString();
            return array;
        }
    }
}
