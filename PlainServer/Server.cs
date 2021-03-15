using ModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlainServer
{
    class Server
    {
        public void Start()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 10001;
                IPAddress localAddr = IPAddress.Loopback;
                server = new TcpListener(localAddr, port);
                server.Start();
                Console.WriteLine("Server started");

                TcpClient connectionSocket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = connectionSocket;
                    DoClient(tempSocket);
                });

                server.Stop();

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }

        private void DoClient(TcpClient connectionSocket)
        {

            Console.WriteLine("server activated");
            Stream ns = connectionSocket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string toread;
            toread = sr.ReadLine();
            Car newCar = JsonConvert.DeserializeObject<Car>(toread);
            Console.WriteLine(newCar);

            ns.Close();
            connectionSocket.Close();
        }
    }
}