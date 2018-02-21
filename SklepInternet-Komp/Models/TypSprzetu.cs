using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SklepInternet_Komp.Models
{
    public class TypSprzetu
    {

        [Key]
        public int IdTypu { get; set; }

        [StringLength(60, ErrorMessage = "Nazwa Typu jest za długa")]
        [Required(ErrorMessage = "Nazwa Typu jest wymagana")]
        public String NazwaTypu { get; set; }

        public virtual ICollection<Sprzet> Sprzets { get; set; }
    }
}