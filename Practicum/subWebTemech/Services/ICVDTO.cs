using subWebTemech.DTOs;
using subWebTemech.Models;

namespace subWebTemech.Services
{
    public interface ICVDTO
    {
        //GetAllResumes: שליפת כל קורות החיים של המשתמש.
        public Task<List<cvDto>> GetAllResumesById(int id);
        //GetFavoriteResume: שליפת קובץ קורות החיים המסומן כמועדף.
        public Task<cvDto> GetFavoriteResume(int id);
        //SetFavoriteResume: סימון קובץ קורות חיים כמועדף.
        Task SetFavoriteResume(CVDTO v, bool favorite);

    }
}
