using subWebTemech.Models;

namespace subWebTemech.Repository
{
    public interface ICVRepository
    {
        //GetAllResumes: שליפת כל קורות החיים של המשתמש.
        public Task<List<CV>> GetAllResumesById(int id);
        //GetFavoriteResume: שליפת קובץ קורות החיים המסומן כמועדף.
        public Task<CV> GetFavoriteResume(int id);
        //SetFavoriteResume: סימון קובץ קורות חיים כמועדף.
        Task SetFavoriteResume(CV v,bool favorite);

        //UpdateResumeUsage: עדכון כמות השימושים בקובץ.
        Task<List<CV>> GetAllCV();         // לקבל את כל ה-CVs
        Task<CV> GetCVById(int id);        // לקבל CV לפי ID
        Task<CV> GetRecentCV();            // לקבל את ה-CV האחרון
        Task<List<CV>> GetRecentCVs();     // לקבל את כל ה-CVs האחרונים
        Task AddCV(CV cv);                 // להוסיף CV חדש
        Task UpdateCV(CV cv);              // לעדכן CV קיים
        Task DeleteCV(int id);

    }
}


