using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data_Passing.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; internal set; }
        public string Password { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
    }
}