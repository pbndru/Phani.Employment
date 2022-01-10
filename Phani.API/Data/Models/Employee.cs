using System;

namespace Phani.Employment.API.Data.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
