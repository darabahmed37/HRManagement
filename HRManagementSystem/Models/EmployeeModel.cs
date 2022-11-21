using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models {
    public class EmployeeModel {

        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]


        public int Code { get; set; }

        public string Name { get; set; } = "";
        public string AppointedBy { get; set; } = "";
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string LandLine { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Qualification { get; set; } = "";
        public string Religion { get; set; } = "";
        public string MaritalStatus { get; set; } = "";
        public string EmployeePicture { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime DobDate { get; set; } 
        public DateTime JoinDate { get; set; }





    }


}
