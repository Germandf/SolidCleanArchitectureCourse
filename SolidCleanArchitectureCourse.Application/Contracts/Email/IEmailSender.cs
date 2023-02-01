using SolidCleanArchitectureCourse.Application.Models.Email;

namespace SolidCleanArchitectureCourse.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
