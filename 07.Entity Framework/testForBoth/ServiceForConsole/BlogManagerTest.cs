using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using BlogApplication.Entities;
using BlogApplication.Services;
using BlogApplication.Context;

namespace BlogApplication.Tests
{
    [TestFixture]
    public class BlogManagerTests
    {
        private DbContextOptions<BlogContext> _dbContextOptions;
        private BlogContext _context;
        private BlogManager _blogManager;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            
            _context = new BlogContext(_dbContextOptions);
            _blogManager = new BlogManager(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void DisplayPosts_ShouldReturnTrue()
        {
            // Arrange
            // Add test data to the in-memory database
            _context.Posts.AddRange(new[]
            {
                new Post { Id = 1, Title = "First Post", Content = "Content of the first post" },
                new Post { Id = 2, Title = "Second Post", Content = "Content of the second post" }
            });
            _context.SaveChanges();

            // Act
            var result = _blogManager.DisplayPosts();

            // Assert
            NUnit.Framework.Assert.IsTrue(result);
            // Add assertions to verify the expected behavior
        }

        [Test]
        public void DisplayPostDetail_WithValidPostId_ShouldReturnTrue()
        {
            // Arrange
            var postId = 1;
            // Add test data to the in-memory database
            _context.Posts.Add(new Post { Id = postId, Title = "Test Post", Content = "Content of the test post" });
            _context.Comments.AddRange(new[]
            {
                new Comment { Id = 1, PostId = postId, Text = "First comment" },
                new Comment { Id = 2, PostId = postId, Text = "Second comment" }
            });
            _context.SaveChanges();

            // Act
            var result = _blogManager.DisplayPostDetail(postId);

            // Assert
            NUnit.Framework.Assert.IsTrue(result);
            // Add assertions to verify the expected behavior
        }

        // Add more unit tests for other methods in BlogManager class

        // ...
    }
}