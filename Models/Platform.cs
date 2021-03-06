using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPI.Models
{
    public class Platform
    {
        [Required]
        public string? Name {get;set;}
        public string? Id {get;set;}=$"platform:{Guid.NewGuid().ToString()}";
    }
}