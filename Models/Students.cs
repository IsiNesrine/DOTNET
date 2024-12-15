using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public enum Major
{
    CS, IT, MATH, ANGLAIS, ASTRONOMIE, PHILOSOPHIE, PCSI
}

public class Student : Account
{
    public double GPA { get; set; }

    [Required(ErrorMessage = "Veuillez sélectionner une spécialité.")]
    [Display(Name = "Spécialité")]
    public Major Major { get; set; }

    [Required(ErrorMessage = "Veuillez sélectionner une date d'admission.")]
    [DataType(DataType.Date)]
    [Display(Name = "Date d'Admission")]
    public DateTime AdmissionDate { get; set; } = DateTime.Now;
}