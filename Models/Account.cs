using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public enum AllowedLevel
{
    TEACHER, STUDENT
}
public class Account : IdentityUser
{
    [StringLength(20, MinimumLength = 2)]
    public required string Firstname { get; set; }

    [StringLength(20, MinimumLength = 2)]
    public required string Lastname { get; set; }

    public int Age { get; set; }

    public AllowedLevel UserType { get; set; }

}