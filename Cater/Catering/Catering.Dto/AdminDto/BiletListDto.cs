using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Dto.AdminDto
{
    public class BiletListDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string EPosta { get; set; }
        public string Telefon { get; set; }
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
        public bool OkunduMu { get; set; }
        public DateTime OlusturulmaZamani { get; set; }
    }
}
