using BlazorApp1.Model;

namespace BlazorApp1.Services;

public interface IEmailService
{
     void SendEmail(Email email);
     
     IEnumerable<Email> GetEmails();
}