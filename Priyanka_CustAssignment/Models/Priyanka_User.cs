//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Priyanka_CustAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Priyanka_User
    {
        public Priyanka_User()
        {
            Role = "Customer";
        }


        public int Id { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public string Role { get; set; }
    }
}

