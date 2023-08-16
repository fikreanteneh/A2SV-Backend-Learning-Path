// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Requests;
using BlogApi.Application.Persistence.Contracts;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostRequest, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly Mapper _mapper;

    public UpdatePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.updatePost.Id);
        _mapper.Map(request.updatePost, post);        
        await _postRepository.Update(post);
        return Unit.Value;
    }
}