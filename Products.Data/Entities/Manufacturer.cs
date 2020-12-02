using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Products.Data.Entities
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string Email { get; set; }
        public string WebSiteUrl { get; set; }
        public string Mobile { get; set; }
        
    }
}
