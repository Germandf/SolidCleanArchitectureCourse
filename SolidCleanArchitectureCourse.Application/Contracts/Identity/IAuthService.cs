using SolidCleanArchitectureCourse.Application.Models.Identity;

namespace SolidCleanArchitectureCourse.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
