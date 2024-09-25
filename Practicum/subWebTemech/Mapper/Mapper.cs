using AutoMapper;
using subWebTemech.DTOs;
using subWebTemech.Models;
using System.Runtime;

namespace subWebTemech.Mapper
{
    public class Mapper : AutoMapper .Profile
    {
        public Mapper()
        {
            //מיפוי לטבלת משתמשים
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            //מיפוי לטבלת משתמשים
            CreateMap<UserDto, User>().ReverseMap();

            //מיפוי לטבלת תתקטגוריות
            CreateMap<SubCategory, SubCategoryDTO>();
            CreateMap<SubCategoryDTO, SubCategory>();

            //מיפוי לטבלת סוג עבודה
            CreateMap<JobType, JobTypeDTO>();
            CreateMap<JobTypeDTO, JobType>();

            //מיפוי לטבלת ערים
            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>();

        

            CreateMap<Job, JobDTO>();
            CreateMap<JobDTO, Job>();
            CreateMap<cvDto, CV>();
            CreateMap<CV, cvDto>();
             }
    }
}
