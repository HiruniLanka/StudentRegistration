//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace StudentRegistration.Domain.Entities
//{
//    internal class Student
//    {
//    }
//}

using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "NIC is required")]
        [StringLength(12, MinimumLength = 10)]
        public string NIC { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100)]
        public string FirstName { get; set; }

        
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name with initials is required")]
        [StringLength(100)]
        public string LastNameWithInitials { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(500)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone format")]
        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string BasicQualifications { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}