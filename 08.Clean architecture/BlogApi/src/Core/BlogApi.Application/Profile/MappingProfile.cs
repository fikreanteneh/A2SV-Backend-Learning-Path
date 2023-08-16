using AutoMapper;
using BlogApi.Application.DTO.Comment;
using BlogApi.Application.DTO.Post;
using BlogApi.Domain;

namespace BlogApi.Application.Profile;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostListDto>().ReverseMap();  
        CreateMap<Comment, CommentDto>().ReverseMap();
    }
    
}