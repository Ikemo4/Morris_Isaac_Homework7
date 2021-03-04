using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework7.Models
{
    //Book model for each individual book
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression("^(97(8 | 9)) ?[d]{9}([d]|X)$)")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [RegularExpression("[0-9]+([.][0-9] [0-9]?)?")]
        public double Price { get; set; }
        [Required]
        public int NumPages { get; set; }
    }
}