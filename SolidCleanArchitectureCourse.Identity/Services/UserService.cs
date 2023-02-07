﻿using Microsoft.AspNetCore.Identity;
using SolidCleanArchitectureCourse.Application.Identity;
using SolidCleanArchitectureCourse.Application.Models.Identity;
using SolidCleanArchitectureCourse.Identity.Models;

namespace SolidCleanArchitectureCourse.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

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
