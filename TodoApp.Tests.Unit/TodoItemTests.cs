using FluentAssertions;
using TodoApp.API.Models;

namespace TodoApp.Tests.Unit
{
    public class TodoItemTests
    {
        [Fact]
        public void Name_Should_Be_Set_Correctly()
        {
            var todoItem = new TodoItem
            {
                Name = "Wake up and smile",
                IsCompleted = true
            };

            Assert.True(todoItem.Name == "Wake up and smile");
        }

        [Fact]
        public void IsCompleted_Should_Be_Set_To_False_By_Default()
        {
            var todoItem = new TodoItem
            {
                Name = "Wake up and smile"
            };

            Assert.False(todoItem.IsCompleted);
        }

        [Fact]
        public void IsCompleted_Should_Update_Correctly()
        {
            var todoItem = new TodoItem
            {
                Name = "Wake up and smile",
                IsCompleted = true
            };

            Assert.True(todoItem.IsCompleted);
        }

        [Fact]
        public void TodoItems_With_Same_Name_And_Status_Should_Match()
        {
            var expected = new TodoItem
            {
                Name = "Reach for the skies",
                IsCompleted = true
            };

            var actual = new TodoItem
            {
                Name = "Reach for the skies",
                IsCompleted = true
            };

            actual.Should().HaveSameNameAndCompletionStatus(expected);
        }

        [Fact]
        public void Creating_Multiple_TodoItems_Should_Assign_Unique_Ids()
        {
            var todo1 = new TodoItem { Name = "Task 1", IsCompleted = false };
            var todo2 = new TodoItem { Name = "Task 2", IsCompleted = true };
            var todo3 = new TodoItem { Name = "Task 3", IsCompleted = false };

            var todos = new[] { todo1, todo2, todo3 };

            todos
                .Select(t => t.Id)
                .Should()
                .OnlyHaveUniqueItems();
        }
    }
}