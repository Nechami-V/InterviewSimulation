using AutoMapper;
using subWebTemech.DTOs;
using subWebTemech.Models;
using subWebTemech.Repository;

namespace subWebTemech.Services
{
    public class CVDTO : ICVDTO
    {
        private readonly ICVRepository _cvRepository;
        private readonly IMapper _mapper;
        public CVDTO(ICVRepository _cVRepository ,IMapper _mapper)
        {
            this._cvRepository = _cVRepository;
            this._mapper = _mapper;
        }
        //GetAllResumes: שליפת כל קורות החיים של המשתמש.
        public async Task<List<cvDto>> GetAllResumesById(int id)
        {
            try
            {
                var CVList = await _cvRepository.GetAllResumesById(id);
                return _mapper.Map<List<cvDto>>(CVList);
            }
            catch (Exception ex)
            {
                return new List<cvDto>();
            }
        }
        //GetFavoriteResume: שליפת קובץ קורות החיים המסומן כמועדף.
        public async Task<cvDto> GetFavoriteResume(int id)
        {
            try
            {
                var cv = await _cvRepository.GetFavoriteResume(id);
                return _mapper.Map<cvDto>(cv);
            }
            catch (Exception ex)
            {
                return new cvDto();
            }
            
        }
        //SetFavoriteResume: סימון קובץ קורות חיים כמועדף.
        public async Task SetFavoriteResume(CVDTO cvDto, bool favorite)
        {
            try
            {
                var cv = _mapper.Map<CV>(cvDto);
                cv.Favorite = favorite;
               await _cvRepository.SetFavoriteResume(cv, favorite);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        }
    }

