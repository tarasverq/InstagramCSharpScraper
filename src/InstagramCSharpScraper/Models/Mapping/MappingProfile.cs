using System.Linq;
using AutoMapper;
using InstagramCSharpScraper.Models.Raw;

namespace InstagramCSharpScraper.Models.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel.EdgeFollowClass, long>().ConvertUsing(x=> x.Count);

            CreateMap<UserModel.Dimensions, Dimensions>();
            CreateMap<UserModel.Owner, Owner>();
            CreateMap<UserModel.ThumbnailResource, Thumbnail>();
            
            CreateMap<Models.Raw.UserModel.User, User>()
                ;
            
            CreateMap<Models.Raw.UserModel.Media, Media>()
                .ForMember(x=> x.Caption, src=> src.MapFrom(x=> x.Caption.Edges.FirstOrDefault().Node.Text))
                .ForMember(x=> x.CommentsCount, src=> src.MapFrom(x=> x.Comment.Count))
                .ForMember(x=> x.Dimensions, src=> src.MapFrom(x=> x.Dimensions))
                .ForMember(x=> x.LikesCount, src=> src.MapFrom(x=> x.EdgeMediaPreviewLike.Count))
                .ForMember(x=> x.Location, src=> src.MapFrom(x=> x.Location))
                .ForMember(x=> x.Owner, src=> src.MapFrom(x=> x.Owner))
                .ForMember(x=> x.Thumbnails, src=> src.MapFrom(x=> x.ThumbnailResources))

                ;
        }
    }
}