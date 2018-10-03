using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain
{
   public class Iletisim:BaseDomain
    {
       public string AdresBaslik { get; set; }
       public string Adres1 { get; set; }
       public string Adres2 { get; set; }
       public string Semt { get; set; }
       public string Il { get; set; }
       public string Telefon1 { get; set; }
       public string Telefon2 { get; set; }
       public string Telefon3 { get; set; }
       public string Facebook { get; set; }
       public string Twitter { get; set; }
       public string Instagram { get; set; }
    }
}
