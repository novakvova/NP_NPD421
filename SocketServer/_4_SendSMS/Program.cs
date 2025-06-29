// See https://aka.ms/new-console-template for more information
using System.Web;
using Microsoft.Extensions.Configuration;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;



int input = 0;
do
{
    //string myKey = "ua4edd40df68c99d80a06416fcc535ffdc3cd70d935e3722d80a668c8844a305babaea"; // Замініть на ваш API ключ
    Console.WriteLine("Оберіть операцію");
    Console.WriteLine("1.Дізнатися баланс");
    Console.WriteLine("2.Відправити SMS");
    Console.WriteLine("0.Вихід");

    Console.Write("Введіть номер операції: ");
    input = int.Parse(Console.ReadLine());
    switch (input)
    {
        case 1:
            try
            {
                var mobizonService = new MobizonLib.MobizonService();
                var balance = await mobizonService.getBalance();
                Console.WriteLine($"Ваш баланс: {balance.Data.Balance} {balance.Data.Currency}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при отриманні балансу: {ex.Message}");
            }
            break;
        case 2:
            try
            {
                var mobizonService = new MobizonLib.MobizonService();
                Console.Write("Введіть номер телефону (формат: 380XXXXXXXXX): ");
                string phone = Console.ReadLine();
                Console.Write("Введіть текст повідомлення: ");
                string text = Console.ReadLine();
                var response = await mobizonService.sendSMS(phone, text);
                Console.WriteLine($"SMS відправлено. Відповідь сервера: {response}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при відправці SMS: {ex.Message}");
            }
            break;
        default:
            break;
    }
} while (input!=0);
