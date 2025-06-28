using AutoMapper;
using MetroPass.Application.DTOs;
using MetroPass.Application.Extension;
using MetroPass.Presentation.WebApi.Models.Request;
using MetroPass.Presentation.WebApi.Models.Response;

namespace MetroPass.Presentation.WebApi.Profiles
{
    public class SwipeProfile : Profile
    {
        public SwipeProfile()
        {
            CreateMap<SwipeEntryRequest, SwipeRequestDTO>();

            CreateMap<SwipeResponseDTO, SwipeEntryResponse>()
                .ForMember(d => d.CardType, o => o.MapFrom(s => s.CardType.GetDisplayName()));
        }
    }
}

