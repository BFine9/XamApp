using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App.Models
{    
    public class User 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstLastName { get { return FirstName + " " + LastName; } }
        public string Age { get; set; }
        public string City { get; set; }
    }
}
