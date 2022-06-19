using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using Data.ContactPage;
using SendGrid;
using Api.Options;

namespace Api;

public class ContactMessageFunction
{
    private readonly SendGridOptions _options;

    public ContactMessageFunction(IOptions<SendGridOptions> options)
    {
        _options = options.Value;
    }

    [FunctionName(nameof(ContactMessageFunction))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "contactmessage")] [FromBody] Message message)
    {
        var msg = new SendGridMessage();

        msg.SetFrom(new EmailAddress(message.Email, message.Name));

        msg.AddTo(new EmailAddress("Spur.ken@justbeawesomeat.net", "Ken Spur"));

        msg.SetSubject($"{message.Name} - Contact Form");
        msg.AddContent(MimeType.Text, message.Text);

        await new SendGridClient(_options.ApiKey).SendEmailAsync(msg);

        return new OkResult();
    }
}