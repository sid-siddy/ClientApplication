using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagement.Model
{
    public class ClientUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Name Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide Password")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Length must be within 2 to 100 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "City is must")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Must be with 2 to 100 characters")]
        public string City { get; set; }
    }
}
