using Catering.Dto;

namespace Catering.Repository.Interfaces
{
    public interface IIletisimRepository
    {
        IletisimGetDto GetIletisimBilgileri();

        bool AddBilet(BiletSaveFormDto dto);
    }
}