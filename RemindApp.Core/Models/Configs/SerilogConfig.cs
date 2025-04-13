namespace RemindApp.Core.Models.ConfigsModels;
public class SerilogConfig
{
    public required string LogName { get; set; }
    public required string Uri { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string CaCertFileName { get; set; }
    public required string FileLogTemplate { get; set; }
    public long FileSizeLimitBytes { get; set; }
}
