using System.Net.Mail;

namespace Domain.ValueObjects;

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        try
        {
            var addr = new MailAddress(value);
            Value = addr.Address;
        }
        catch
        {
            throw new ArgumentException("Invalid email format");
        }
    }

    public override string ToString()
    {
        return Value;
    }
}