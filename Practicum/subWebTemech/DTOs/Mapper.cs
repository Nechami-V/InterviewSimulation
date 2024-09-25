using AutoMapper;
using subWebTemech.Models;
using subWebTemech.DTOs;

namespace subWebTemech.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<QuestionSimulation, QuestionSimulationDTO>().ReverseMap()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText))
                .ForMember(dest => dest.Hint, opt => opt.MapFrom(src => src.Hint))
                .ForMember(dest => dest.QuestionSimulationID, opt => opt.Ignore());

            CreateMap<AnswerSimulation, AnswerSimulationDTO>().ReverseMap()
                .ForMember(dest => dest.AnswerText, opt => opt.MapFrom(src => src.AnswerText))
                .ForMember(dest => dest.Links, opt => opt.MapFrom(src => src.Links))
                .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect))
                .ForMember(dest => dest.AnswerSimulationID, opt => opt.Ignore());

            CreateMap<InterviewSimulation, InterviewSimulationDTO>().ReverseMap()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.InterviewSimulationDate, opt => opt.MapFrom(src => src.InterviewSimulationDate))
                .ForMember(dest => dest.InterviewSimulationID, opt => opt.Ignore());

            CreateMap<QuestionAnswer, QuestionAnswerDTO>().ReverseMap()
                .ForMember(dest => dest.QuestionSimulationID, opt => opt.MapFrom(src => src.QuestionSimulationID))
                .ForMember(dest => dest.AnswerSimulationID, opt => opt.MapFrom(src => src.AnswerSimulationID))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<User, UserDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IsGoogleAccount, opt => opt.MapFrom(src => src.IsGoogleAccount));



        }
    }
}
