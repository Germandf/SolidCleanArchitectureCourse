using SolidCleanArchitectureCourse.Application.Models.Identity;

namespace SolidCleanArchitectureCourse.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string userId);
}
