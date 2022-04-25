using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Communications
{
    public class ClientCom
    {
        private string clientName;
        private Socket Client;
        private StreamReader reader;
        private StreamWriter writer;
        public string ClientName { get => clientName; set => clientName = value; }

        public ClientCom(Socket socket)
        {
            this.Client = socket;
            Stream stream = new NetworkStream(this.Client);
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
        }

        //<CR><LF>
        public bool Write(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public String Read()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Disconnect()
        {
            try
            {
                this.Client.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
