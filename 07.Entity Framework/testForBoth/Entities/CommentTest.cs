using Xunit;

namespace BlogApp.Entities.Tests
{
    public class CommentTests
    {
        [Fact]
        public void Comment_Properties_ReturnExpectedValues()
        {
            // Arrange
            int id = 1;
            int postId = 2;
            string text = "Test Comment";
            DateTime createdAt = DateTime.Now;
            Post post = new Post(){Title = "", Content = ""};

            // Act
            Comment comment = new Comment
            {
                Id = id,
                PostId = postId,
                Text = text,
                CreatedAt = createdAt,
                Post = post
            };

            // Assert
            Assert.Equal(id, comment.Id);
            Assert.Equal(postId, comment.PostId);
            Assert.Equal(text, comment.Text);
            Assert.Equal(createdAt, comment.CreatedAt);
            Assert.Equal(post, comment.Post);
        }


        [Fact]
        public void Comment_SetProperties_OverrideValues()
        {
            // Arrange
            Comment comment = new Comment
            {
                Id = 1,
                PostId = 2,
                Text = "Initial Comment",
                CreatedAt = DateTime.Now,
            };

            // Act            
            comment.Text = "Updated Comment";
            comment.Post = null;

            // Assert
            Assert.Equal("Updated Comment", comment.Text);
            Assert.NotEqual(default(DateTime), comment.CreatedAt);
            Assert.Null(comment.Post);
        }
    }
}