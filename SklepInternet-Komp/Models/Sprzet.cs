using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepInternet_Komp.Models
{
    public class Sprzet
    {
        [Key]
        public int IdSprzetu { get; set; }

        [StringLength(60, ErrorMessage = "Nazwa jest za długa")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public String Nazwa { get; set; }

        [Range(1500, 2100, ErrorMessage = "Rok jest nieprawidłowy")]
        [Required(ErrorMessage = "Rok jest wymagany")]
        [Display(Name = "Rok Produkcji")]
        public int RokProdukcji { get; set; }

        [StringLength(10, ErrorMessage = "Nazwa koloru jest za długa")]
        [Required(ErrorMessage = "Kolor sprzetu jest wymagany")]
        public String Kolor { get; set; }

        [Range(1, 5000, ErrorMessage = "Cena jest nieprawidłowa")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        public int Cena { get; set; }


        //relacja jeden do wielu
        public int IdProducenta { get; set; }
        public Producent Producents { get; set; }
        public int IdTypu { get; set; }
        public TypSprzetu TypSprzetus { get; set; }

        //relacja wiele do wielu
        //[ForeignKey("Producents")]
        //public int IdProducenta { get; set; } //niepotrzebne
        //public virtual ICollection<Producent> Producents { get; set; }

        //[ForeignKey("TypSprzetus")]
        //public int IdTypu { get; set; }
        //public virtual ICollection<TypSprzetu> TypSprzetus { get; set; }

        //Sprzet sprzet = db.Sprzets.Include(s => s.Producents).FirstOrDefault(s => s.IdProducenta == id);
    }
}