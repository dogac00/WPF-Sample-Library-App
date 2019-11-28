using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace CetLibrary.Data
{
    public class CetUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]        
        public string UserName { get; set; }

        [Required]
        [StringLength(256)]
        public string Password { get; set; }      
        public DateTime CreatedDate { get; set; }

        public Role Role { get; set; }

        public override bool Equals(object obj)
        {
            CetUser other = obj as CetUser;

            if (other is null)
                return false;

            return this.Id == other.Id;
        }

        public string GetFullName()
        {
            return $"{this.Name} {this.Surname}";
        }
    }
}
