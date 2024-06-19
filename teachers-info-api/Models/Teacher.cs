using System.ComponentModel.DataAnnotations;

namespace teachers_info_api.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(20, 70, ErrorMessage = "Age must be between 20 and 70.")]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }
    }
}
