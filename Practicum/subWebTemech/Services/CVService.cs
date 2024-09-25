using AutoMapper;
using Microsoft.Extensions.Logging;
using subWebTemech.DTOs;
using subWebTemech.Mapper;
using subWebTemech.Models;
using subWebTemech.Repository;


namespace subWebTemech.Services
{
    public class CVService : ICVService
    {
        private readonly ICVRepository cvRepository;
        private readonly IMapper mappers;

        public CVService(ICVRepository cvRepository)
        {
            this.cvRepository = cvRepository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper.Mapper>();
            });
            mappers = config.CreateMapper();
        }
        public async Task<List<cvDto>> GetAllCV()
        {
            try
            {
                var answer = await cvRepository.GetAllCV();
                return mappers.Map<List<cvDto>>(answer);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("faild to get all cv in the service", ex);
            }
        }
        public async Task<cvDto> GetCVById(int id)
        {
            try
            {
                var cv =await  cvRepository.GetCVById(id);
                return mappers.Map<cvDto>(cv);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting the CV by id", ex);
            }
        }

        public async Task<cvDto> GetRecentCV()
        {
            var RecentCV=  await cvRepository.GetRecentCV();
            return mappers.Map<cvDto> (RecentCV);
        }
        public async Task<bool> DeleteCV(int id)
        {
            try
            {
                await cvRepository.DeleteCV(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while delete CV", ex);
            }
        }
        public async Task<bool> AddCV(cvDto cvDto)
        {
            try
            {
                var mapCV = mappers.Map<CV>(cvDto);
                await cvRepository.AddCV(mapCV);
                return true;
            }

            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding CV", ex);
            }
        }

        public async Task<List<cvDto>> GetRecentCVs()
        {
            var recentCvs = await cvRepository.GetRecentCVs();
            return mappers.Map<List<cvDto>>(recentCvs);
        }

        public async Task<bool> UpdateCV(cvDto cvDto)
        {
            try
            {
                var mapCV = mappers.Map<CV>(cvDto);
                await cvRepository.UpdateCV(mapCV);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while update CV", ex);
            }
        }
    }
}
