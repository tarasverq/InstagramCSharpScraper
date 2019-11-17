using AutoMapper;
using InstagramCSharpScraper.Interfaces;

namespace InstagramCSharpScraper.Models.Mapping
{
    public class ModelMapper : IModelMapper
    {
        private readonly IMapper _mapper;
        
        public ModelMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            
            _mapper = config.CreateMapper();
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}