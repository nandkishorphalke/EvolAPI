using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class ContactMetaData
    {
        public int ContactId { get; set; } 

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Nullable<bool> Status { get; set; }
    }
}