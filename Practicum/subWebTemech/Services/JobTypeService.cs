//using AutoMapper;
//using subWebTemech.DTOs;
//using subWebTemech.Models;
//using subWebTemech.Repository;

//namespace subWebTemech.Services
//{
//    public class JobTypeService : IJobTypeService
//    {
//        IJobTypeRepository JobTypeRepository;
//        IMapper mapper;
//        public JobTypeService(IJobTypeRepository jobTypeRepository)
//        {
//            JobTypeRepository = jobTypeRepository;
//            var config = new MapperConfiguration(cnf => cnf.AddProfile<Mapper>());
//            mapper = config.CreateMapper();
//        }
//        public List<JobTypeDTO> GetAllJobType()
//        {
//            return mapper.Map<List<JobType>, List<JobTypeDTO>>(JobTypeRepository.GetAllJobType());

//        }
//    }
//}
