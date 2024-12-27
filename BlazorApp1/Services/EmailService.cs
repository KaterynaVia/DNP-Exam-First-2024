using System.Text.Json;
using BlazorApp1.Model;

namespace BlazorApp1.Services;

public class EmailService: IEmailService
{
    

    public EmailService()
    {
        Emails = new List<Email>();

        var one = new Email("Kateryna", "Seva", "Hi!", "Whats up?");

        var two = new Email("Hugo", "Hugo", "Hello!", "Whats up?");

        var three = new Email("Niels", "Kateryna", "Hello!", "Whats up?");

        var four = new Email("Niels1", "Kateryna1", "Hej!", "Whats up?");

        var five = new Email("Niels2", "Kateryna2", "Pryvit!", "Whats up?");
Emails.Add(one);
Emails.Add(two);
Emails.Add(three);
Emails.Add(four);
Emails.Add(five);
    }
public IList<Email> Emails { get;}
    public void SendEmail(Email email)
    {
        
        email.TimeSent = DateTime.Now;
        if (string.IsNullOrWhiteSpace(email.Sender))
        {
            email.Sender = "Kateryna";
        }

        Emails.Add(email);
        var jsonString = JsonSerializer.Serialize(email);
        Console.WriteLine(jsonString);
        Console.WriteLine($"Email sent: {email.Sender} -> {email.Receiver}, Title: {email.Title}");
    }

    public IEnumerable<Email> GetEmails()
    {
        Console.WriteLine($"Returning {Emails.Count} emails.");
        return Emails.AsEnumerable();
    }
}