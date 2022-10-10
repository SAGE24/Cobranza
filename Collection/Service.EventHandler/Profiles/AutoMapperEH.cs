using AutoMapper;
using Service.EventHandler.Commands;

namespace Service.EventHandler.Profiles
{
    public class AutoMapperEH : Profile
    {
        public AutoMapperEH() {
            var config = new MapperConfiguration(config => {
                config.AllowNullDestinationValues = true;
                CreateMap<Debtor, Domain.Debtor>();
            });
            var mapper = config.CreateMapper();
        }
    }
}
