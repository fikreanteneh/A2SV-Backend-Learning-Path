using AutoMapper;
using BlogApi.Application.DTO.Comment;
using BlogApi.Application.DTO.Post;
using BlogApi.Domain;

namespace BlogApi.Application.Profile;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile()
    {
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostListDto>().ReverseMap();

    }
    
}