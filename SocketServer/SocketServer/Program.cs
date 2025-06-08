// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Socket server = new Socket(AddressFamily.InterNetwork, 
    SocketType.Stream, 
    ProtocolType.Tcp);

//0.0.0.0
IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 1097); //2 байти
//Нашаштовує привязку, тобто якщо є Bind, то ми можемо приймати запити
server.Bind(serverEndPoint);  //метод прив'язки сокета до ендпоінту

server.Listen(10); //10 - максимальна кількість клієнтів, які можуть підключитися до сервера

Console.WriteLine("Сервер запущено. Очікування підключення клієнтів...");
while(true)
{     //Очікуємо підключення клієнта
    //Наша консль буде стояти, поки не пілкючиться клієнт
    Socket client = server.Accept(); //метод прийняття підключення клієнта
    //По суті, у Socket client буде інформація про клієнта, який підключився до сервера
    //Виводимо на консоль IP-адресу та порт клієнта, який підключився
    Console.WriteLine($"Клієнт підключено: {client.RemoteEndPoint}");

    var buffer = new byte[1024]; //Буфер для отримання даних від клієнта
    int bytesRead = client.Receive(buffer); //Отримуємо дані від клієнта

    //Перетворюємо отримані дані з байтів в рядок
    string message = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine($"Отримано повідомлення від клієнта: {message}");

    string responseMessage = $"Хай, козак(козачка)! У мене час {DateTime.Now}";
    //Віповідь клієнту коду у байти
    byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(responseMessage);

    client.Send(responseBytes); //Відправляємо відповідь клієнту

    client.Shutdown(SocketShutdown.Both); //Закриваємо з'єднання з клієнтом
    client.Close(); //Закриваємо сокет клієнта
}
