namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // тип источника, целевой тип
        CreateMap<UpdateTopicRequestDto, Topic>()
            // .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)) // правила маппинга
            // .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary)) // простое правило - отработает рефлексия
            // .ForMember(dest => dest.TopicType, opt => opt.MapFrom(src => src.TopicType))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => Location.Of(src.Location.City, src.Location.Street)))
            // .ForMember(dest => dest.EventStart, opt => opt.MapFrom(src => src.EventStart))
            .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => dest.Id))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember is not string str || !string.IsNullOrWhiteSpace(str)));

        CreateMap<CreateTopicRequestDto, Topic>() // без указание простых правил
            .BeforeMap((src, dest) => // валидация
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(src.Title);
                ArgumentException.ThrowIfNullOrWhiteSpace(src.Summary);
                ArgumentException.ThrowIfNullOrWhiteSpace(src.TopicType);
            })
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => Location.Of(src.Location.City, src.Location.Street)))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => TopicId.Of(Guid.NewGuid())));
    }
}