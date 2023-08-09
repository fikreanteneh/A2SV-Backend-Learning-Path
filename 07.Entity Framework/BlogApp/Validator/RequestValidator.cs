

namespace BlogApp.Validator;

public record CreatePostDto(string Title, string Content);
public record CreateCommentDto(string Text);
public record UpdatePostDto(string Title, string Content);
public record UpdateCommentDto(string Text);