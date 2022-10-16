using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models {
    public class EmployeeModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; } = "";
        public string AppointedBy { get; set; } = "";
        public string EmployeeCode { get; set; } = "";
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string LandLine { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Address { get; set; } = "";
        public DateOnly DobDate { get; set; } 
        public DateOnly JoinDate { get; set; }
    }
}
