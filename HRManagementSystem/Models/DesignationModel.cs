using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementSystem.Models {
    public class DesignationModel {



        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID{ get; set; }

        public string DesignationName { get; set; } = "";

    }
}
