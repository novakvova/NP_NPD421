// See https://aka.ms/new-console-template for more information
using System.Text;
using MobizonLib;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;
// This is a simple console application that prints "Hello, World!" to the console.
// It serves as a basic example of a C# program structure.
var um = new UserService();
//await um.DeleteRangeUsersAsync(
do
{
    User newUser = new User();
    var service = new RegisterService();


    Console.Write("Enter email: ");
    newUser.Email = Console.ReadLine();

    Console.Write("Enter first name: ");
    newUser.FirstName = Console.ReadLine();

    Console.Write("Enter second name: ");
    newUser.SecondName = Console.ReadLine();

    Console.Write("Enter url photo: ");
    newUser.Photo = await Console.ReadLine().UriToBase64();

    Console.Write("Enter phone: ");
    newUser.Phone = Console.ReadLine().ToPhoneFormat();

    Console.Write("Enter password: ");
    newUser.Password = Console.ReadLine();

    Console.Write("Confirm password: ");
    newUser.ConfirmPassword = Console.ReadLine();



    bool res = await service.RegisterUser(newUser);

    if (res)
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Success registered!");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Press Enter");
        Console.ResetColor();

        Console.ReadLine();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Press Enter");
        Console.ResetColor();

        Console.ReadLine();

        Console.Clear();
    }
}
while (true);
