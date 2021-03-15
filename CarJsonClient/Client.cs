using ModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;


namespace CarJsonClient
{
    class Client
    {
        public void Start()
        {
            Car car = new Car("Jeep","Purple", 92210);
            TcpClient client = null;
            try
            {
                Int32 port = 10001;
                client = new TcpClient("localhost", port);

                Stream ns = client.GetStream();

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string jsonToSend = JsonConvert.SerializeObject(car);
                sw.WriteLine(jsonToSend);

                ns.Close();
                client.Close();

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}

