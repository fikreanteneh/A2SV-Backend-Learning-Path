using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Validator;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services.Tests
{
    public class PostManagerTests
    {

        [Fact]
        public void CreatePost_ShouldCreateNewPost()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var post = new Post
            {
                Title = "Test Post",
                Content = "Test Content"
            };

            // Act
            var createdPost = _postManager.CreatePost(post);

            // Assert
            Assert.NotNull(createdPost);
            Assert.Equal(post.Title, createdPost.Title);
            Assert.Equal(post.Content, createdPost.Content);
            Assert.True(createdPost.Id > 0);
        }

        [Fact]
        public void UpdatePost_ShouldUpdateExistingPost()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var existingPost = new Post
            {
                Title = "Existing Post",
                Content = "Existing Content"
            };
            _context.Posts.Add(existingPost);
            _context.SaveChanges();

            var updatedPost = new Post
            {
                Id = existingPost.Id,
                Title = "Updated Post",
                Content = "Updated Content"
            };

            // Act
            var result = _postManager.UpdatePost(updatedPost);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedPost.Id, result.Id);
            Assert.Equal(updatedPost.Title, result.Title);
            Assert.Equal(updatedPost.Content, result.Content);

            var retrievedPost = _context.Posts.Find(updatedPost.Id);
            Assert.NotNull(retrievedPost);
            Assert.Equal(updatedPost.Title, retrievedPost.Title);
            Assert.Equal(updatedPost.Content, retrievedPost.Content);
        }

        [Fact]
        public void UpdatePost_WithNonExistingId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var updatedPost = new Post
            {
                Id = 999, // Non-existing ID
                Title = "Updated Post",
                Content = "Updated Content"
            };

            // Act & Assert
            Assert.Throws<CustomException>(() => _postManager.UpdatePost(updatedPost));
        }

        [Fact]
        public void DeletePost_ShouldDeleteExistingPost()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var existingPost = new Post
            {
                Title = "Existing Post",
                Content = "Existing Content"
            };
            _context.Posts.Add(existingPost);
            _context.SaveChanges();

            // Act
            _postManager.DeletePost(existingPost.Id);

            // Assert
            var deletedPost = _context.Posts.Find(existingPost.Id);
            Assert.Null(deletedPost);
        }

        [Fact]
        public void DeletePost_WithNonExistingId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var nonExistingPostId = 999; // Non-existing ID

            // Act & Assert
            Assert.Throws<CustomException>(() => _postManager.DeletePost(nonExistingPostId));
        }

        [Fact]
        public void GetAllPosts_ShouldReturnAllPosts()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var post1 = new Post
            {
                Title = "Post 1",
                Content = "Content 1"
            };
            var post2 = new Post
            {
                Title = "Post 2",
                Content = "Content 2"
            };
            _context.Posts.AddRange(post1, post2);
            _context.SaveChanges();

            // Act
            var result = _postManager.GetAllPosts();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(post1, result);
            Assert.Contains(post2, result);
        }

        [Fact]
        public void GetPostById_WithExistingId_ShouldReturnPost()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var expectedPost = new Post
            {
                Title = "Test Post",
                Content = "Test Content"
            };
            _context.Posts.Add(expectedPost);
            _context.SaveChanges();

            // Act
            var result = _postManager.GetPostById(expectedPost.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPost.Id, result.Id);
            Assert.Equal(expectedPost.Title, result.Title);
            Assert.Equal(expectedPost.Content, result.Content);
        }

        [Fact]
        public void GetPostById_WithNonExistingId_ShouldThrowCustomException()
        {
            var _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var _context = new ApiDbContext(_options);
            var _postManager = new PostManager(_context);
            // Arrange
            var nonExistingPostId = 999; // Non-existing ID

            // Act & Assert
            Assert.Throws<CustomException>(() => _postManager.GetPostById(nonExistingPostId));
        }
    }
}