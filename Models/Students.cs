using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public enum Major
{
    CS, IT, MATH, OTHER
}

public class Student
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    [StringLength(20, MinimumLength = 2)]
    [Display(Name = "Prénom")]
    public string Firstname { get; set; }

    [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
    [StringLength(20, MinimumLength = 2)]
    [Display(Name = "Nom")]
    public string Lastname { get; set; }

    [Range(16, 100, ErrorMessage = "L'âge doit être compris entre 16 et 100 ans..")]
    [Required]
    [Display(Name = "Âge")]
    public int Age { get; set; }

    public double GPA { get; set; }

    [Required(ErrorMessage = "Veuillez sélectionner une spécialité.")]
    [Display(Name = "Spécialité")]
    public Major Major { get; set; }

    [Required(ErrorMessage = "Veuillez sélectionner une date d'admission.")]
    [DataType(DataType.Date)]
    [Display(Name = "Date d'Admission")]
    public DateTime AdmissionDate { get; set; }
}