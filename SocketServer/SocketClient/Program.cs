// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Socket client = new Socket(AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);

Console.WriteLine("Вкажіть текст повідомлення");
string text = Console.ReadLine();

//Це буде localhost
string ipServer = "127.0.0.1"; //IP-адреса сервера
client.Connect(ipServer, 1097); //Підключаємося до сервера за IP-адресою та портом

client.Send(System.Text.Encoding.UTF8.GetBytes(text)); //Відправляємо повідомлення на сервер

//Отримуємо відповідь від сервера
byte[] buffer = new byte[1024];
int bytesRead = client.Receive(buffer); //Отримуємо дані від сервера
string responseMessage = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
Console.WriteLine($"Відповідь від сервера: {responseMessage}");

client.Shutdown(SocketShutdown.Both); //Закриваємо з'єднання з сервером
client.Close(); //Закриваємо сокет клієнта