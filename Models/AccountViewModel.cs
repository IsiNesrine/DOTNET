using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une spécialité.")]
        public Major Major { get; set; }
        public required AllowedLevel UserType { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer votre mot de passe.")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [DataType(DataType.Password)]
        public required string ConfirmedPassword { get; set; }
    }
}