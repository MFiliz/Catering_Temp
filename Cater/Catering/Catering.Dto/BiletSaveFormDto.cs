using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Dto
{
    public class BiletSaveFormDto
    {
        public string Isim { get; set; }
        public string EPosta { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        public string Telefon { get; set; }
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
    }
}
