using AutoMapper;
using Domain.Entities.Models;
using Shared.DataTransferObject.Battle;
using Shared.DataTransferObject.Hamster;

namespace HamsterWarsAPI;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hamster, HamsterGetDto>();
        CreateMap<HamsterPostDto, Hamster>();
        CreateMap<HamsterPostDto, Hamster>().ReverseMap();
        CreateMap<HamsterPutDto, Hamster>();
        CreateMap<HamsterPutDto, Hamster>().ReverseMap();

        CreateMap<Battle, BattleGetDto>();
        CreateMap<BattlePostDto, Battle>();
        CreateMap<BattlePostDto, Battle>().ReverseMap();
    }
}
