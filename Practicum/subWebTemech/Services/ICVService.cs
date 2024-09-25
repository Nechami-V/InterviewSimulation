using subWebTemech.DTOs;
namespace subWebTemech.Services
{
    public interface ICVService
    {
        Task<cvDto> GetRecentCV();
        Task<List<cvDto>> GetRecentCVs();
        Task<cvDto> GetCVById(int id);
        Task<List<cvDto>> GetAllCV();
        Task<bool> DeleteCV(int id);
        Task<bool> AddCV(cvDto cv);
        Task<bool> UpdateCV(cvDto cv);
    }
}
