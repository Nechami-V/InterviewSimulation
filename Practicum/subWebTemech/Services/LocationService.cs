//using AutoMapper;
//using subWebTemech.DTOs;
//using subWebTemech.Models;
//using subWebTemech.Repository;

//namespace subWebTemech.Services
//{
//    public class LocationService : ILocationService
//    {

//        ILocationRepository LocationRepository;
//        IMapper mapper;
//        public LocationService(ILocationRepository locationRepository)
//        {
//            this.LocationRepository = locationRepository;
//            var config = new MapperConfiguration(cnf => cnf.AddProfile<Mapper>());
//            mapper = config.CreateMapper();
//        }

//        public List<LocationDTO> GetAllLocation()
//        {
//            return mapper.Map<List<Location>, List<LocationDTO>>(LocationRepository.GetAllLocation());
//        }
//    }
//}
