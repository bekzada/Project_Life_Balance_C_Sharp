using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace LifeBalance.Models
{
    public class Login
    {
       [Required(ErrorMessage="Email is required.")]
       [EmailAddress]
       [Display(Name="Email:")]
       public string LoginEmail  { get; set;}
       [Required (ErrorMessage="Password is required.")]
       [DataType(DataType.Password)]
       public string LoginPassword { get; set;} 
    }
}