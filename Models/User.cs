using System;
using System.ComponentModel.DataAnnotations;

namespace MyFirstmvc.Models;

public class Users
{
public int ID{get;set;}
[Required]
public string? Name{get;set;}    
public string? Email{get;set;}

[StringLength(128, MinimumLength = 6)]
[Required]
public string? Password{get;set;}
 [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Not a valid phone number")]
        public string? PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

}
