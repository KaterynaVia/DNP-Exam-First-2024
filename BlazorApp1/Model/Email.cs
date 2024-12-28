namespace BlazorApp1.Model;

public class Email
{
    public string Sender { get; set; }        
    public string  Receiver { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime TimeSent { get; set; }

    public Email(string sender, string receiver, string title, string body)
    {
        Sender = sender;
        Receiver = receiver;
        Title = title;
        Body = body;
        TimeSent = DateTime.Now;
    }
    
}