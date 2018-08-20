using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AddUserRolesBindingModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public List<RoleBindingModel> Roles { get; set; }
    }

    public class RoleBindingModel
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
    }

}