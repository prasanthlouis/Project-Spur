using ProjectSpur.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSpur.Models
{
    public class Friend
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Availability Availability { get; set; }
    }
}
