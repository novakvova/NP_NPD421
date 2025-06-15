namespace _2_SMTP;

public class EmailConfiguration
{
    /// <summary>
    /// Адреса електронної пошти відправника.
    /// </summary>
    public string From { get; set; } = "super.novakvova@ukr.net";
    /// <summary>
    /// SMTP сервер для відправки електронних листів.
    /// </summary>
    public string StmpServer { get; set; } = "smtp.ukr.net";
    /// <summary>
    /// Порт SMTP сервера.
    /// </summary>
    public int Port { get; set; } = 2525;
    /// <summary>
    /// Ім'я користувача для автентифікації на SMTP сервері.
    /// </summary>
    public string UserName { get; set; } = "super.novakvova@ukr.net";
    /// <summary>
    /// Пароль для автентифікації на SMTP сервері.
    /// </summary>
    public string Password { get; set; } = "0gFY4Q9P9s5H9iLd"; // Пароль для SMTP сервера
}
