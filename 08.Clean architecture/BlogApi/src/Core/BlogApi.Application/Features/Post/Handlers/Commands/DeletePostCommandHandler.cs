
using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Requests;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;

public class DeletePostCommandHandler : IRequestHandler<DeletePostRequest>
{
    IPostRepository _postRepository;
    Mapper _mapper;
    public DeletePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;

    }



    public async Task<Unit> IRequestHandler<DeletePostRequest, Unit>.Handle(DeletePostRequest request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request.Id);
        await _postRepository.Delete(post);
        return Unit.Value;
    }
}