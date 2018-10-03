using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Domain;
using Catering.Dto.AdminDto;
using Catering.Repository.Bases;
using Catering.Repository.Interfaces;

namespace Catering.Repository.RepositoryClass
{
    public class AdminRepository : IAdminRepository
    {
        public IEnumerable<BiletListDto> GetBiletList()
        {
            return
                Bases.Repositories.UnitOfWorkCurrent.Biletler.Where(x => x.IsActive && !x.IsDeleted)
                    .Select(x => new BiletListDto
                    {
                        Telefon = x.Telefon,
                        EPosta = x.EPosta,
                        Isim = x.Isim,
                        Baslik = x.Baslik,
                        Mesaj = x.Mesaj,
                        OkunduMu = x.OkunduMu,
                        Id = x.Id,
                        OlusturulmaZamani = x.CreateDate

                    });
        }

        public BiletDetailDto GetBiletDetail(int id)
        {
            return
                Bases.Repositories.UnitOfWorkCurrent.Biletler.Where(x => x.IsActive && !x.IsDeleted && x.Id == id)
                    .Select(x => new BiletDetailDto
                    {
                        Baslik = x.Baslik,
                        Gonderen = x.Isim,
                        Soru = x.Mesaj,
                        Tarih = x.CreateDate
                    })
                    .FirstOrDefault();
        }

        public void BiletOku(int id)
        {
            Bases.Repositories.UnitOfWorkCurrent.Biletler.FirstOrDefault(x => x.Id == id).OkunduMu = true;
            Bases.Repositories.UnitOfWorkCurrent.SaveChanges();
        }

        public bool SaveImage(string path)
        {
            var sonuc = Bases.Repositories.UnitOfWorkCurrent.Galeri.Add(new Gallery
            {
                path = path
            });

            if (Bases.Repositories.UnitOfWorkCurrent.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<string> GetGallery()
        {
           return
                Bases.Repositories.UnitOfWorkCurrent.Galeri.OrderByDescending(t => t.CreateDate).Where(x => x.IsActive && !x.IsDeleted).Select(x => x.path).ToList();
        }

        public List<AdminGaleriDto> GetGalleryForAdmin()
        {
            return
                Bases.Repositories.UnitOfWorkCurrent.Galeri.OrderByDescending(t => t.CreateDate).Where(x => x.IsActive && !x.IsDeleted).Select(x =>new AdminGaleriDto
                {
                    Id = x.Id,
                    path = x.path
                }).ToList();
        }

        public void ResimSil(int id)
        {
            Repositories.UnitOfWorkCurrent.Galeri.FirstOrDefault(x => x.Id == id).IsDeleted = true;
            Repositories.UnitOfWorkCurrent.SaveChanges();
            
        }
    }
}
