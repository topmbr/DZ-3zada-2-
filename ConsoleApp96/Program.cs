using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp96
{
    internal class Program
    {
        static async Task Main()
        {
            try
            {
                string serverAddress = "127.0.0.1";
                int port = 8888;

                // Створення TcpClient та асинхронне підключення до сервера
                TcpClient client = new TcpClient();
                await client.ConnectAsync(serverAddress, port);
                Console.WriteLine($"Підключено до сервера {serverAddress}:{port}");

                NetworkStream stream = client.GetStream();

                string greetingMessage = "Привіт, сервере!";
                byte[] data = Encoding.ASCII.GetBytes(greetingMessage);
                await stream.WriteAsync(data, 0, data.Length);

                data = new byte[256];
                int bytesRead = await stream.ReadAsync(data, 0, data.Length);
                string serverResponse = Encoding.ASCII.GetString(data, 0, bytesRead);

                Console.WriteLine($"Отримано від сервера: {serverResponse}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

        }
    }
}