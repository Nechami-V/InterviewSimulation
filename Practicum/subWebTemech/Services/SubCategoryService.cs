//using AutoMapper;
//using subWebTemech.DTOs;
//using subWebTemech.Models;
//using subWebTemech.Repository;

//namespace subWebTemech.Services
//{
//    public class SubCategoryService : ISubCategoryService
//    {

//        ISubCategoryRepository SubCategoryRepository;
//        IMapper mapper;
//        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
//        {
//            this.SubCategoryRepository = subCategoryRepository;
//            var config = new MapperConfiguration(cnf => cnf.AddProfile<Mapper>());
//            mapper = config.CreateMapper();
//        }

//        public List<SubCategoryDTO> GetAllSubCategory()
//        {
//            return mapper.Map<List<SubCategory>, List<SubCategoryDTO>>(SubCategoryRepository.GetAllSubCategory());
//        }

//    }
//}
