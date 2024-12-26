using BlazorApp1.Model;

namespace BlazorApp1.Services;

public class EmailService: IEmailService
{
    private List<Email> _emails;

    public EmailService()
    {
        _emails = new List<Email>
        {
            new Email("Kateryna", "Seva", "Hi!", "Whats up?")
            {
                TimeSent = DateTime.Now.AddHours(-1)
            }, //means one hours ago(-1)
            new Email("Hugo", "Hugo", "Hello!", "Whats up?")
            {
                TimeSent = DateTime.Now.AddHours(-1)
            },
            new Email("Niels", "Kateryna", "Hello!", "Whats up?")
            {
                TimeSent = DateTime.Now.AddHours(-1)
            },
            new Email("Niels1", "Kateryna1", "Hej!", "Whats up?")
            {
                TimeSent = DateTime.Now.AddHours(3)
            },
            new Email("Niels2", "Kateryna2", "Pryvit!", "Whats up?")
            {
                TimeSent = DateTime.Now.AddHours(-2)
            }
        };
    }

    public void SendEmail(Email email)
    {
        _emails.Add(email);
        email.TimeSent = DateTime.Now;
        // Optionally serialize and log to the console
        var json = System.Text.Json.JsonSerializer.Serialize(email);
        Console.WriteLine($"Serialized email: {json}");
    }

    public IEnumerable<Email> GetEmails()
    {
        return _emails.AsEnumerable();
    }
}