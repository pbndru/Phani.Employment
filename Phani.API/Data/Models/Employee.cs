using System;
using System.ComponentModel.DataAnnotations;

namespace Phani.Employment.API.Data.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
