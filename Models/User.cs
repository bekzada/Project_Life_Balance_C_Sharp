using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace LifeBalance.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required(ErrorMessage="First name is required.")]
        [MinLength(3, ErrorMessage="First name must be at least 3 characters.")]
        public string FirstName {get; set;}
        [Required (ErrorMessage="Last name is required.")]
        [MinLength(3, ErrorMessage="First name must be at least 3 characters.")]

        public string LastName {get; set;}
        [Required(ErrorMessage="Email is required.")]
        [EmailAddress]
        public string Email  {get; set;}

        [Required(ErrorMessage="Password is required.")]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [Required(ErrorMessage= "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare ("Password", ErrorMessage="Those don't match yo.")]
        [Display(Name="Confirm Password:")]
        [NotMapped]


        public string ConfirmPassword {get; set;}
        public DateTime CreatedAt
        {
            get
            {
                return DateTime.Now;
            }
        }
        public DateTime UpdatedAt{get;set;}
    
    }
}