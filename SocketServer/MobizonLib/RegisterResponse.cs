namespace MobizonLib;

public class RegisterResponse
{
    public Errors Errors { get; set; } = new Errors();
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public string TraceId { get; set; } = string.Empty;
}
