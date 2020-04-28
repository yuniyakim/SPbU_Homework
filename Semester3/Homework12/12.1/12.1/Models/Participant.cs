using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRegistration.Models
{
    public class Participant
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        [Key]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll be a speaker or just attending")]
        public bool? Speaker { get; set; }
    }
}
