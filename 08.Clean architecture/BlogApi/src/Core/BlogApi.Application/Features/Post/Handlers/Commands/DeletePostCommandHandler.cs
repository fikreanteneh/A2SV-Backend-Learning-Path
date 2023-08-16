
using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.Persistence.Contracts;
namespace BlogApi.Application.Features.Post.Handlers.Commands;

public class DeletePostCommandHandler : IRequestHandler<DeletePostRequest, Unit>
{
    IPostRepository _postRepository;
    Mapper _mapper;
    public DeletePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;

    }

    public async Task<Unit> Handle(DeletePostRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        await _postRepository.Delete(post);
        return Unit.Value;
    }
}