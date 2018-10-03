using System.Collections.Generic;
using Catering.Dto.AdminDto;

namespace Catering.Repository.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<BiletListDto> GetBiletList();

        BiletDetailDto GetBiletDetail(int id);

        void BiletOku(int id);

        bool SaveImage(string path);
        List<string> GetGallery();
        List<AdminGaleriDto> GetGalleryForAdmin();

        void ResimSil(int id);

    }
}