
﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalGoods.DAL.Models
{
    public class User :IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }


#nullable disable

namespace LocalGoods.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(5)]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public string TelePhone { get; set; }
        public string FaceBook { get; set; }
        public string Instagram { get; set; }
        public ICollection<Farm> Farms { get; set; }
        public Role Role { get; set; }

    }
}
