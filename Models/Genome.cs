using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viruses.Models
{
    public class Genome
    {
        public Genome()
        {
            Viruses = new List<Virus>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The field cannot be empty!"), RegularExpression("[A-Z][a-z]+", ErrorMessage = "The name is not correct!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field cannot be empty!"), RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "The strand is not correct!")]
        public string Strand { get; set; }
        [Required(ErrorMessage = "The field cannot be empty!"), RegularExpression("[A-Z][a-z]+", ErrorMessage = "The sense is not correct!")]
        public string Sense { get; set; }
        public virtual ICollection<Virus> Viruses { get; set; }
    }
}
