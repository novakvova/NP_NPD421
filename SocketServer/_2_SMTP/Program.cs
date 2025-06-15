// See https://aka.ms/new-console-template for more information
using _2_SMTP;
using MailKit.Net.Smtp;
using MimeKit;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Привіт козаки!");

EmailConfiguration conf = new EmailConfiguration();
Message msg = new Message
{
    Body = "Привіт, козак(козачка)! Це тестовий лист відправлений через SMTP сервер.",
    Subject = "Їжте сало",
    To = "novakvova@gmail.com"
};

var message = new MimeMessage();
message.From.Add(new MailboxAddress(conf.From));
message.To.Add(new MailboxAddress(msg.To));
message.Subject = msg.Subject;
message.Body = new TextPart("plain")
{
    Text = msg.Body
};

using var client = new SmtpClient();
try
{
    client.Connect(conf.StmpServer, conf.Port, true);
    client.Authenticate(conf.UserName, conf.Password);
    client.Send(message);
    Console.WriteLine("Лист успішно відправлено!");
    client.Disconnect(true);
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
    return;
}
