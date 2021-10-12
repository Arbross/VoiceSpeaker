using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static ServerInfo serverInfo = new ServerInfo();

        public static void FillServerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($"[QUESTION][{DateTime.UtcNow}] Enter ip addres : "); serverInfo.Address = IPAddress.Parse(Console.ReadLine());
            Console.Write($"[QUESTION][{DateTime.UtcNow}] Enter port : "); serverInfo.Port = int.Parse(Console.ReadLine());

            Console.Clear();
        }

        public static void ServerMain()
        {
            FillServerInfo();

            TcpClient client = null;
            TcpListener server = new TcpListener(serverInfo.Address, serverInfo.Port);
            server.Start(5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO][{DateTime.UtcNow}] Server successfuly started!");

            while (true)
            {
                client = server.AcceptTcpClient();

                // отримуємо об'єкт команди від клієнта
                BinaryFormatter formatter = new BinaryFormatter();
                ClientCommand command = formatter.Deserialize(client.GetStream()) as ClientCommand;

                if (command != null)
                {
                    switch (command.Type)
                    {
                        case CommandType.WAIT:
                            {

                            }
                            break;
                        case CommandType.REGISTER:
                            {

                            }
                            break;
                        case CommandType.LOGIN:
                            {

                            }
                            break;
                        case CommandType.EXIT:
                            {

                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {

                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                ServerMain();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR][{DateTime.UtcNow}] {ex.ToString()}");
                Tools.ErrorLogSave($"[ERROR][{DateTime.UtcNow}] {ex.ToString()}");
            }
        }
    }
}
