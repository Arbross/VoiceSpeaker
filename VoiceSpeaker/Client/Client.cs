using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace VoiceSpeaker
{
    public class Client
    {
        private TcpClient client = new TcpClient();
        private IPEndPoint serverEndPoint = null;

        public Client(IPAddress address, int port)
        {
            Address = address;
            Port = port;
        }

        private int port;
        public int Port
        {
            get => port;
            set
            {
                if (value >= 1 && value <= 65535)
                {
                    port = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR][{DateTime.UtcNow}] Can't load port value.");
                    Tools.ErrorLogSave($"[ERROR][{DateTime.UtcNow}] Can't load port value.");
                }
            }
        }

        private string address;
        public IPAddress Address
        {
            get => IPAddress.Parse(address);
            set
            {
                address = value.ToString();
            }
        }

        public void SendRegister()
        {
            serverEndPoint = new IPEndPoint(Address, Port);

            // підключаємося до сервера
            client.Connect(serverEndPoint);
            // відправляємо запит на початок гри
            SendCommand(new ClientCommand() { Type = CommandType.REGISTER });
        }

        // метод відправки команди на сервер
        private Task SendCommand(ClientCommand command)
        {
            // викликаємо Task для можливості запускати метод асинхронно (за доп. await)
            return Task.Run(() =>
            {
                // серіалізуємо об'єкт команди в мережевий потік,
                // після чого відразу відбувається відправка
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(client.GetStream(), command);
            });
        }
    }
}
