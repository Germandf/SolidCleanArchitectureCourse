﻿using System.ComponentModel.DataAnnotations;

namespace SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

public class LeaveTypeVm
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    [Display(Name = "Default Number Of Days")]
    public int DefaultDays { get; set; }
}
