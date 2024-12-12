using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public class Teacher : IdentityUser
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    [Required]
    public Major Major { get; set; }
}
