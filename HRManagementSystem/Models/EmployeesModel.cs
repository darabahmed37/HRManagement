using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models {
    public class EmployeesModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [MaxLength(100)] [Required] public string FirstName { get; set; } = "";
        [MaxLength(100)] [Required] public string LastName { get; set; } = "";
        [MaxLength(100)] [Required] public string Email { get; set; } = "";

        [MaxLength(30)] public string Phone { get; set; } = "";
        [Required] public string Password { get; set; } = "";
    }
}