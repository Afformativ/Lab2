using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viruses.Models
{
    public class Virus
    {
        public Virus()
        {
            VirusDrug = new List<VirusDrug>();
            VirusScientist = new List<VirusScientist>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The field cannot be empty!"), RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "The name is not correct!")]
        public string Name { get; set; }
        public int GenomeId { get; set; }
        public int OrganismId { get; set; }

        public virtual Genome Genome { get; set; }
        public virtual Organism Organism { get; set; }
        public virtual ICollection<VirusDrug> VirusDrug { get; set; }
        public virtual ICollection<VirusScientist> VirusScientist { get; set; }
    }
}
