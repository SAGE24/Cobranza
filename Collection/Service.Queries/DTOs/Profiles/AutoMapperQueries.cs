using AutoMapper;

namespace Service.Queries.DTOs.Profiles;
public class AutoMapperQueries : Profile
{
    public AutoMapperQueries() {
        var config = new MapperConfiguration(config => {
            config.AllowNullDestinationValues = true;

            CreateMap<Domain.Debtor, DebtorDTO>();
            CreateMap<List<Domain.Debtor>, DebtorQueryResp>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom((src, dest, prop, ctx) =>
            {
                return (src.Count > 0) ? "0" : "-1";
            }))
            .ForMember(dest => dest.Message, opt => opt.MapFrom((src, dest, prop, ctx) =>
            {
                return (src.Count > 0) ? "OK" : "No existen registros";
            }))
            .ForMember(dest => dest.LstDebtor, opt => opt.MapFrom((src, dest, prop, ctx) =>
            {
                return src;
            }))
            ;
        });
        var mapper = config.CreateMapper();
    }
}
