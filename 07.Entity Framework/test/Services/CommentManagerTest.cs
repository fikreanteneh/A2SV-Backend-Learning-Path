using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Validator;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services.Tests
{
    public class CommentManagerTests 
    {
        [Fact]
        public void CreateComment_WithExistingPostId_ShouldCreateNewComment()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var post = new Post
            {
                Title = "Test Post",
                Content = "Test Content"
            };
            _context.Posts.Add(post);
            _context.SaveChanges();

            var comment = new Comment
            {
                PostId = post.Id,
                Text = "Test Comment"
            };

            // Act
            var createdComment = _commentManager.CreateComment(comment);

            // Assert
            Assert.NotNull(createdComment);
            Assert.Equal(comment.PostId, createdComment.PostId);
            Assert.Equal(comment.Text, createdComment.Text);
            Assert.True(createdComment.Id > 0);
        }

        [Fact]
        public void CreateComment_WithNonExistingPostId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var nonExistingPostId = 999; // Non-existing Post ID

            var comment = new Comment
            {
                PostId = nonExistingPostId,
                Text = "Test Comment"
            };

            // Act & Assert
            Assert.Throws<CustomException>(() => _commentManager.CreateComment(comment));
        }

        [Fact]
        public void UpdateComment_ShouldUpdateExistingComment()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var existingComment = new Comment
            {
                PostId = 1, // Assuming a valid Post ID
                Text = "Existing Comment"
            };
            _context.Comments.Add(existingComment);
            _context.SaveChanges();

            var updatedComment = new Comment
            {
                Id = existingComment.Id,
                PostId = existingComment.PostId,
                Text = "Updated Comment"
            };

            // Act
            var result = _commentManager.UpdateComment(updatedComment);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedComment.Id, result.Id);
            Assert.Equal(updatedComment.PostId, result.PostId);
            Assert.Equal(updatedComment.Text, result.Text);

            var retrievedComment = _context.Comments.Find(updatedComment.Id);
            Assert.NotNull(retrievedComment);
            Assert.Equal(updatedComment.Text, retrievedComment.Text);
        }

        [Fact]
        public void UpdateComment_WithNonExistingId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var updatedComment = new Comment
            {
                Id = 999, // Non-existing ID
                PostId = 1, // Assuming a valid Post ID
                Text = "Updated Comment"
            };

            // Act & Assert
            Assert.Throws<CustomException>(() => _commentManager.UpdateComment(updatedComment));
        }

        [Fact]
        public void DeleteComment_ShouldDeleteExistingComment()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var existingComment = new Comment
            {
                PostId = 1, // Assuming a valid Post ID
                Text = "Existing Comment"
            };
            _context.Comments.Add(existingComment);
            _context.SaveChanges();

            // Act
            _commentManager.DeleteComment(existingComment.Id);

            // Assert
            var deletedComment = _context.Comments.Find(existingComment.Id);
            Assert.Null(deletedComment);
        }

        [Fact]
        public void DeleteComment_WithNonExistingId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var nonExistingCommentId = 999; // Non-existing ID

            // Act & Assert
            Assert.Throws<CustomException>(() => _commentManager.DeleteComment(nonExistingCommentId));
        }

        [Fact]
        public void GetAllComments_WithExistingPostId_ShouldReturnAllCommentsForPost()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var post = new Post
            {
                Title = "Test Post",
                Content = "Test Content"
            };
            _context.Posts.Add(post);
            _context.SaveChanges();

            var comment1 = new Comment
            {
                PostId = post.Id,
                Text = "Comment 1"
            };
            var comment2 = new Comment
            {
                PostId = post.Id,
                Text = "Comment 2"
            };
            _context.Comments.AddRange(comment1, comment2);
            _context.SaveChanges();

            // Act
            var comments = _commentManager.GetAllComments(post.Id);

            // Assert
            Assert.NotNull(comments);
            Assert.Equal(2, comments.Count);
            Assert.Contains(comment1, comments);
            Assert.Contains(comment2, comments);
        }

        [Fact]
        public void GetAllComments_WithNonExistingPostId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var nonExistingPostId = 999; // Non-existing Post ID

            // Act & Assert
            Assert.Throws<CustomException>(() => _commentManager.GetAllComments(nonExistingPostId));
        }

        [Fact]
        public void GetCommentById_WithExistingId_ShouldReturnComment()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var comment = new Comment
            {
                PostId = 1, // Assuming a valid Post ID
                Text = "Test Comment"
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();

            // Act
            var retrievedComment = _commentManager.GetCommentById(comment.Id);

            // Assert
            Assert.NotNull(retrievedComment);
            Assert.Equal(comment.Id, retrievedComment.Id);
            Assert.Equal(comment.PostId, retrievedComment.PostId);
            Assert.Equal(comment.Text, retrievedComment.Text);
        }

        [Fact]
        public void GetCommentById_WithNonExistingId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _commentManager = new CommentManager(_context);
            // Arrange
            var nonExistingCommentId = 999; // Non-existing ID

            // Act & Assert
            Assert.Throws<CustomException>(() => _commentManager.GetCommentById(nonExistingCommentId));
        }
    }
}