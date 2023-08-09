using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BlogApp.Entities.Tests
{
    public class PostTests
    {
        [Fact]
        public void Post_Properties_ReturnExpectedValues()
        {
            // Arrange
            int id = 1;
            string title = "Test Title";
            string content = "Test Content";
            DateTime createdAt = DateTime.Now;
            ICollection<Comment> comments = new HashSet<Comment>();

            // Act
            Post post = new Post
            {
                Id = id,
                Title = title,
                Content = content,
                CreatedAt = createdAt,
                Comments = comments
            };

            // Assert
            Assert.Equal(id, post.Id);
            Assert.Equal(title, post.Title);
            Assert.Equal(content, post.Content);
            Assert.Equal(createdAt, post.CreatedAt);
            Assert.Equal(comments, post.Comments);
        }
    }
}