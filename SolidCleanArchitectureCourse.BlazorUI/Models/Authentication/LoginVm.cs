using System.ComponentModel.DataAnnotations;

namespace SolidCleanArchitectureCourse.BlazorUI.Models.Authentication;

public class LoginVm
{
    [Required]
    public string Email { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}
