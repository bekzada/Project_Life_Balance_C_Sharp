using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LifeBalance.Models;

namespace LifeBalance.Models
{
    public class Values{
     [Key]
    public int ID { get; set; }
    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title1  { get; set; }

    [Range(1,10)]
    public int Rating1 { get; set; }

    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title2  { get; set; }
     [Range(1,10)]
    public int Rating2 { get; set; }

    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title3  { get; set; }
    [Range(1,10)]
    public int Rating3 { get; set; }

    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title4  { get; set; }
    [Range(1,10)]
    public int Rating4 { get; set; }

    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title5  { get; set; }
     [Range(1,10)]
    public int Rating5 { get; set; }
    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title6  { get; set; }
     [Range(1,10)]
    public int Rating6 { get; set; }
    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]
    public string Title7  { get; set; }
     [Range(1,10)]
    public int Rating7 { get; set; }
    [Required (ErrorMessage = "Please name your value")]
    [MinLength (2, ErrorMessage = "give your real value")]
    [Display (Name = "Title of your value: ")]

    public string Title8  { get; set; }
    [Range(1,10)]
    public int Rating8 { get; set; }

    [Required (ErrorMessage = "please inter the date ?")]
    [Display (Name = "Date: ")]

    [DataType(DataType.Date)]
    public DateTime DateOfValue { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required (ErrorMessage = "NO COORDINATOR ID")]
    public int CoordinatorID { get; set; }  //userID desemda bolot birok bashka jerlerdi da ozgortush kerek
    public User Coordinator { get; set; }
    }   
}