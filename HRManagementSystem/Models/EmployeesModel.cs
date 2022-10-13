using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models;

public class EmployeesModel {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }


    [MaxLength(100)] [Required] public string FirstName { get; set; } = "";
    [MaxLength(100)] [Required] public string LastName { get; set; } = "";

    [MaxLength(100)]
    [Required(ErrorMessage = "Please enter email")]
    public string Email { get; set; } = "";

    [MaxLength(30)] public string Phone { get; set; } = "";
    
    [Required]
    [MaxLength(30)]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
    public string Password { get; set; } = "";
}