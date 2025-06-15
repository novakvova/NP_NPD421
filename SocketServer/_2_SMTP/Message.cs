namespace _2_SMTP;

public class Message
{
    /// <summary>
    /// Тема листа, який буде відправлено
    /// </summary>
    public string Subject { get; set; } = String.Empty;
    /// <summary>
    /// Текст листа, який буде відправлено
    /// </summary>
    public string Body { get; set; } = String.Empty;
    /// <summary>
    /// Кому посилаємо листа
    /// </summary>
    public string To { get; set; } = String.Empty;
}
