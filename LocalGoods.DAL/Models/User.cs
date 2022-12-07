
﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Identity;
#nullable disable
namespace LocalGoods.DAL.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FaceBook { get; set; }
        public string Instagram { get; set; }
        public ICollection<Farm> Farms { get; set; }
    }
}
