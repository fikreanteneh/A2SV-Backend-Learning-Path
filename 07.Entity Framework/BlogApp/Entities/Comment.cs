

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BlogApp.Entities;

public class Comment {
    public int Id { get; init; }
    public required int PostId { get; init; }
    public required string Text { get; set; }
    public DateTime CreatedAt { get; init; }
    public virtual Post? Post { get; set; }
}