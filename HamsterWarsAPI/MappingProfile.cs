using AutoMapper;
using Core.Domain.Entities.Models;
using Core.Shared.DataTransferObject.Battle;
using Core.Shared.DataTransferObject.Hamster;


namespace Presentation.HamsterWarsAPI;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hamster, HamsterGetDto>();
        CreateMap<HamsterPostDto, Hamster>();
        CreateMap<HamsterPostDto, Hamster>().ReverseMap();

        CreateMap<HamsterPutDto, Hamster>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Battle, BattleGetDto>();
        CreateMap<BattlePostDto, Battle>();
        CreateMap<BattlePostDto, Battle>().ReverseMap();
    }
}
