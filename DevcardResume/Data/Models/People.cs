using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DevcardResume.Data.Models
{
    public class People
    {

        [Key]
        public int PID { get; set; }
        [NotMapped]
        [AllowNull]
        public String EncyptPID { get; set; }
        [StringLength(100)]
        [AllowNull]
        public string FirstName { get; set; }
        [StringLength(100)]
        [AllowNull]
        public string LastName { get; set; }
        [StringLength(50)]
        [AllowNull]
        public string City { get; set; }
    }
}
