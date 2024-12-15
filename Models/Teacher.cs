using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public class Teacher : Account
{
    [Required]
    public Major Major { get; set; }
}
