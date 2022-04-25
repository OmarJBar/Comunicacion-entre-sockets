using Server.Communications;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            Console.WriteLine("Iniciando servidor en puerto {0}",port);

            ServerSocket server = new ServerSocket(port);
            if (server.StartConnection())
            {
                
                Console.WriteLine("Servidor Iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Cliente");
                    Socket socketClient = server.GetClient();
                    //Construir el mecanismo para escribir y leer
                    ClientCom client = new ClientCom(socketClient);
                    //aqui esta el protocolo de comuncacion, ambos deben conocerlo
                    client.Write("Hola Mundo cliente, dime tu nombre???");
                    string respuesta = client.Read();
                    client.ClientName = respuesta;
                    Console.WriteLine("Bienvenido {0}", respuesta);
                    
                    //llamar el otro proyecto 
                    client.Disconnect();
                }

            }
            else
            {
                Console.WriteLine("Ocurrio un error en el puerto{0}, puerto en uso", port);
            }
        }
    }
}
