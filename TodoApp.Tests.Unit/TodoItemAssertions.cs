using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using TodoApp.API.Models;

namespace TodoApp.Tests.Unit
{
    public class TodoItemAssertions : ReferenceTypeAssertions<TodoItem, TodoItemAssertions>
    {
        public TodoItemAssertions(TodoItem subject)
            : base(subject, AssertionChain.GetOrCreate())
        {
        }
        protected override string Identifier => "todo";
    }

    public static class TodoItemAssertionExtensions
    {
        public static TodoItemAssertions Should(this TodoItem todoItem)
        {
            return new TodoItemAssertions(todoItem);
        }

        public static AndConstraint<TodoItemAssertions> HaveSameNameAndCompletionStatus(
            this TodoItemAssertions assertions,
            TodoItem expected,
            string because = "",
            params object[] becauseArgs)
        {
            assertions.CurrentAssertionChain
                .BecauseOf(because, becauseArgs)

                .ForCondition(assertions.Subject is not null)
                .FailWith("Expected {context:todoitem} to be non-null{reason}, but found <null>.")

                .Then
                .ForCondition(expected is not null)
                .FailWith("Expected comparison todoitem to be non-null{reason}, but found <null>.")

                .Then
                .ForCondition(assertions.Subject!.Name == expected!.Name)
                .FailWith(
                    "Expected todoitem name to be {0}{reason}, but found {1}.",
                    expected.Name, assertions.Subject.Name)

                .Then
                .ForCondition(assertions.Subject.IsCompleted == expected.IsCompleted)
                .FailWith(
                    "Expected todoitem IsCompleted to be {0}{reason}, but found {1}.",
                    expected.IsCompleted, assertions.Subject.IsCompleted);

            return new AndConstraint<TodoItemAssertions>(assertions);
        }

    }
}