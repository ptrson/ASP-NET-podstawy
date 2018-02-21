using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SklepInternet_Komp.Models
{
    public class Producent
    {
        internal readonly object Title;

        [Key]
        public int IdProducenta { get; set; }

        [StringLength(20, ErrorMessage = "Nazwa Producenta jest zbyt długa")]
        [Required(ErrorMessage = "Nazwa Producenta jest wymagana")]
        [Display(Name = "Producent")]
        public String NazwaProducenta { get; set; }

        [Range(1500, 2100, ErrorMessage = "Rok jest nieprawidłowy")]
        [Required(ErrorMessage = "Rok jest wymagany")]
        [Display(Name = "Rok Zalozenia")]
        public int RokZalozenia { get; set; }

        [StringLength(20, ErrorMessage = "Nazwa Panstwa jest zbyt długa")]
        [Required(ErrorMessage = "Nazwa Panstwa jest wymagana")]
        [Display(Name = "Panstwo")]
        public String Panstwo { get; set; }

        public virtual ICollection<Sprzet> Sprzets { get; set; }

    }
}