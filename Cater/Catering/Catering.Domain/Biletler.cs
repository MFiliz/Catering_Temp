using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain
{
  public  class Biletler:BaseDomain
    {
      public string Isim { get; set; }
      public string EPosta { get; set; }
      public string Telefon { get; set; }
      public string Baslik { get; set; }
      public string Mesaj { get; set; }
      public bool OkunduMu { get; set; }
    }
}
