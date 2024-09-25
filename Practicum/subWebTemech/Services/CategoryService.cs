//using AutoMapper;
//using subWebTemech.DTOs;
//using subWebTemech.Models;
//using subWebTemech.Repository;
//using AutoMapper;
//namespace subWebTemech.Services
//{
//    public class CategoryService : ICategoryService
//    {

//        ICategoryRepository CategoryRepository;
//        IMapper mapper;
//        public CategoryService (ICategoryRepository categoryRepository)
//        {
//            this.CategoryRepository = categoryRepository;
//            var MapperConfiguration?config = new MapperConfiguration(cnf => cnf.AddProfile<Mapper>());
//            mapper = config.CreateMapper();
//        }

//        public List<CategoryDto> GetAllCategory()
//        {
//            return mapper.Map<List<Category>, List<CategoryDto>>(CategoryRepository.GetAllCategory());
//        }
//    }
//}
