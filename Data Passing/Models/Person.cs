using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data_Passing.Models
{
    public class Person
    {
        public string name { get; set; }
        public string emails { get; internal set; }
    }
}