using System.Linq;
using Catering.Domain;
using Catering.Dto;
using Catering.Repository.Interfaces;

namespace Catering.Repository.RepositoryClass
{
    public class IletisimRepository : IIletisimRepository
    {
        public IletisimGetDto GetIletisimBilgileri()
        {
            return Bases.Repositories.UnitOfWorkCurrent.Iletisim.Select(x => new IletisimGetDto
            {
                AdresBaslik = x.AdresBaslik,
                Adres1 = x.Adres1,
                Adres2 = x.Adres2,
                Telefon1 = x.Telefon1,
                Telefon2 = x.Telefon2,
                Telefon3 = x.Telefon3,
                Semt = x.Semt,
                Il = x.Il,
                Instagram = x.Instagram,
                Twitter = x.Twitter,
                Facebook = x.Facebook
            }).FirstOrDefault();
        }

        public bool AddBilet(BiletSaveFormDto dto)
        {
            Bases.Repositories.UnitOfWorkCurrent.Biletler.Add(new Biletler
            {
                Telefon = dto.Telefon,
                Isim = dto.Isim,
                Baslik = dto.Baslik,
                EPosta = dto.EPosta,
                OkunduMu = false,
                Mesaj = dto.Mesaj
            });
            if (Bases.Repositories.UnitOfWorkCurrent.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
