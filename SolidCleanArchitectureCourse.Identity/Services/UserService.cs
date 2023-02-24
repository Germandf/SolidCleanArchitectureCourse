using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SolidCleanArchitectureCourse.Application.Contracts.Identity;
using SolidCleanArchitectureCourse.Application.Models.Identity;
using SolidCleanArchitectureCourse.Identity.Models;
using System.Security.Claims;

namespace SolidCleanArchitectureCourse.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(
        UserManager<ApplicationUser> userManager, 
        IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        
        return new Employee
        {
            Email = employee.Email,
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
        };
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        
        return employees.Select(x => new Employee
        {
            Id = x.Id,
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToList();
    }
}
