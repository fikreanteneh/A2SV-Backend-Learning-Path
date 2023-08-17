

namespace BlogApi.Domain;
public class Comment : BaseEntityDomain
{
    public required string Text { get; set; }
    public required int PostId { get; set; }
    public virtual Post? Post { get; set; }

}