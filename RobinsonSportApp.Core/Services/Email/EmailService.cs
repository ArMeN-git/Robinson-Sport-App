using Microsoft.Extensions.Options;
using RobinsonSportApp.Core.CustomExceptions;
using RobinsonSportApp.Core.Services.Email.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace RobinsonSportApp.Core.Services.Email;

internal class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly ISendGridClient _sendGridClient;

    public EmailService(IOptionsMonitor<EmailSettings> emailOptionsMonitor, ISendGridClient sendGridClient)
    {
        _emailSettings = emailOptionsMonitor.CurrentValue;
        _sendGridClient = sendGridClient;
    }

    public async Task SendEmailAsync(string receiverEmail, string subject, string body, bool isHtmlContent = false, CancellationToken cancellationToken = default)
    {
        var email = new SendGridMessage
        {
            From = new EmailAddress(_emailSettings.SenderEmail, string.Empty),
            Subject = subject,
            PlainTextContent = isHtmlContent ? string.Empty : body,
            HtmlContent = isHtmlContent ? body : string.Empty
        };
        email.AddTo(new EmailAddress(receiverEmail));
        var response = await _sendGridClient.SendEmailAsync(email, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new RBException(await response.Body.ReadAsStringAsync(cancellationToken), response.StatusCode);
        }
    }
}
